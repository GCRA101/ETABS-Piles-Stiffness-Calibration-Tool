Imports System.Reflection
Imports ETABSv1
Imports Newtonsoft.Json


''' <summary>
''' 
''' <remarks>
''' <para> Main class of the Controller Package. </para>
''' <para> It allows the View to communicate with the Model via the MVC Pattern. </para>
'''
''' <para> Desing Patterns: 
''' - MODEL-VIEW-CONTROLLER </para>
''' 
''' <para> Programming Techniques: 
''' - STREAMS </para>
''' 
''' </remarks>
''' </summary>


Public Class PSC_Controller
	Implements ControllerInterface

	'ATTRIBUTES
	''References to Model and View
	Protected model As PSC_Model
	Protected view As PSC_View
	'References to CSI Plugin Objects
	Protected SapModel As cSapModel
	Protected ISapPlugin As cPluginCallback
	'ExceptionHandlers
	Private invalidInputsHandler As InvalidInputsHandler
	Private missingInputsHandler As MissingInputsHandler
	Private excessiveΔKHandler As ExcessiveΔKHandler
	'EventListeners
	Private eventsListener As EventsListener
	'AudioManagers
	Private soundManager As SoundManager
	'FilePaths
	Private jsonFilePath As String
	Private pDispFilePath As String

	'CONSTRUCTORS
	Public Sub New(SapModel As cSapModel, ISapPlugin As cPluginCallback)

		'Save CSI Plugin Objects
		Me.SapModel = SapModel
		Me.ISapPlugin = ISapPlugin
		Dim resourceNames As String()
		resourceNames = Assembly.GetExecutingAssembly().GetManifestResourceNames()

		'Instantiate the Model
		Me.model = PSC_Model.getInstance()
		Me.model.setSapModel(Me.SapModel)
		'Instantiate the View
		Me.view = New PSC_View(Me.model, Me)
		'Istantiate AudioManagers
		Me.soundManager = SoundManager.getInstance()
		'Instantiate EventsListener
		Me.eventsListener = New EventsListener(Me, Me.view)
		'Instantiate ExceptionHandlers
		Me.createExceptionHandlers()
	End Sub

	'METHODS
	Public Sub initialize() Implements ControllerInterface.initialize
		'Show the SplashScreen
		Me.view.createSplashScreen()
		'Show the AboutBox
		Me.view.createAboutBox()
		'Activate the EventsListener of the AboutBox
		Me.eventsListener.initializeAboutBox()
	End Sub

	Public Sub createExceptionHandlers() Implements ControllerInterface.createExceptionHandlers
		Me.missingInputsHandler = New MissingInputsHandler(Me)
		Me.excessiveΔKHandler = New ExcessiveΔKHandler(Me)
	End Sub


	Public Sub processInputData()

		'1. Get the Input Data from the UI

		'Get the name of the Load Combination selected by the user in the UI
		Dim selLoadCombo As String
		If Me.view.getViewInputs().cklbLoadCombos.CheckedItems().Count <> 0 Then
			selLoadCombo = Me.view.getViewInputs().cklbLoadCombos.SelectedItem.ToString()
		Else
			selLoadCombo = ""
		End If

		'Get the name of the Group selected by the user in the UI
		Dim selGroup As String
		If Me.view.getViewInputs().cklbGroups.CheckedItems().Count <> 0 Then
			selGroup = Me.view.getViewInputs().cklbGroups.SelectedItem.ToString()
		Else
			selGroup = ""
		End If

		'Get the type of Non Linear Option selected by the user in the UI
		Dim selNonLinearOption As String
        selNonLinearOption = Me.view.getViewInputs().cbNonLinearOptions.SelectedItem

		'Get the Maximum Number of Iterations selected by the user in the UI
		Dim iterNumMax As Integer
		Try
			iterNumMax = CInt(Me.view.getViewInputs().cbIterations.Items(Me.view.getViewInputs().cbIterations.SelectedIndex))
			If (iterNumMax < 2) Then Throw New InvalidInputsException("Max number of Analysis Iterations must be bigger than 1.")
		Catch ex1 As Exception
			MsgBox("The Input Max Number of Analysis Iterations must be an integer.", vbOKOnly + vbCritical, "WARNING - INVALID INPUTS")
			Throw
		Catch ex2 As InvalidInputsException
			Me.getInvalidInputsHandler().execute(ex2)
		End Try

		'Get the Maximum Displacement Variation selected by the user in the UI
		Dim convergenceFactor As Double
		convergenceFactor = CDbl(Strings.Split(CStr(Me.view.getViewInputs().cbDispVariation.
							Items(Me.view.getViewInputs().cbDispVariation.SelectedIndex)), "%")(0)) / 100.0

		'2. Initialize the Model
		Me.model.initialize(Me.SapModel, pDispFilePath, selLoadCombo, selGroup, selNonLinearOption, iterNumMax, convergenceFactor)

		'Retain only points belonging to selected Group
		Me.model.filterPointsByGroup()


		'3. Set Up the pile objects restraints/stiffnesses based on input criteria

		If Me.view.getViewInputs().rbRigid.Checked = True Then
			' Rigid Piles
			Dim restraintBools As Boolean() = {True, True, True, False, False, False}
			Me.model.setPointRestraints(restraintBools)
		ElseIf Me.view.getViewInputs().rbSpring.Checked = True Then
			' Constant Stiffness Piles
			If Me.view.getViewInputs().tbStiffness.Text() = "" Then Throw New MissingInputsException("Piles Stiffness Missing")
			Dim stiffness_Nmm As Double = CDbl(Me.view.getViewInputs().tbStiffness.Text()) * 1000
			Dim stiffnessValues As Double() = {0.0, 0.0, stiffness_Nmm, 0.0, 0.0, 0.0}
			Me.model.setPointStiffnessesFromValues(stiffnessValues)
		ElseIf Me.view.getViewInputs().rbImportFromFile.Checked = True Then
			' Input Json Stiffness Piles
			Me.model.setPointStiffnessesFromJson(Me.getJsonFilePath())
			Me.model.setPileObjsInit(Me.model.deserialize(Me.getJsonFilePath))
		End If

	End Sub
	Public Sub runIteration() Implements ControllerInterface.runIteration
		'Call the Model's Iteration method
		Me.model.runIteration()
		'Play Sound Effect at the end of the process
		Me.soundManager.play(Sound.ENDITERATION)
	End Sub

	Public Sub terminate() Implements ControllerInterface.terminate
		'Close and dispose the form
		Me.view.getViewInputs.Close()
		Me.view.getViewInputs.Dispose()
		'Memory Release
		Me.ISapPlugin.Finish(0)
	End Sub

	Public Sub serialize() Implements ControllerInterface.serialize
		'Call the Model's method allowing to serialize outputs into json file
		Me.model.serialize(Me.model.getPileObjsList())
	End Sub

	Public Sub deserialize() Implements ControllerInterface.deserialize
		Throw New NotImplementedException()
	End Sub

	Public Sub extractEtabsModelData()
		Me.model.ExtractEtabsModelData()
	End Sub

	'Setters
	Public Sub setSapModel(SapModel As cSapModel)
		Me.SapModel = SapModel
	End Sub
	Public Sub setISapPlugIn(ISapPlugin As cPluginCallback)
		Me.ISapPlugin = ISapPlugin
	End Sub
	Public Sub setSoundManager(soundManager As SoundManager)
		Me.soundManager = soundManager
	End Sub
	Public Sub setEventsListener(eventsListener As EventsListener)
		Me.eventsListener = eventsListener
	End Sub
	Public Sub setInvalidInputsHandler(invalidInputsHandler As InvalidInputsHandler)
		Me.invalidInputsHandler = invalidInputsHandler
	End Sub
	Public Sub setMissingInputsHandler(missingInputsHandler As MissingInputsHandler)
		Me.missingInputsHandler = missingInputsHandler
	End Sub
	Public Sub setExcessiveΔKHandler(excessiveΔKHandler As ExcessiveΔKHandler)
		Me.excessiveΔKHandler = excessiveΔKHandler
	End Sub
	Public Sub setJsonFilePath(jsonFilePath As String)
		Me.jsonFilePath = jsonFilePath
	End Sub
	Public Sub setPDispFilePath(pDispFilePath As String)
		Me.pDispFilePath = pDispFilePath
	End Sub

	'Getters
	Public Function getSapModel() As cSapModel
		Return Me.SapModel
	End Function
	Public Function getISapPlugIn() As cPluginCallback
		Return Me.ISapPlugin
	End Function
	Public Function getSoundManager() As SoundManager
		Return Me.soundManager
	End Function
	Public Function getEventsListener() As EventsListener
		Return Me.eventsListener
	End Function
	Public Function getInvalidInputsHandler() As InvalidInputsHandler
		Return Me.invalidInputsHandler
	End Function
	Public Function getMissingInputsHandler() As MissingInputsHandler
		Return Me.missingInputsHandler
	End Function
	Public Function getExcessiveΔKHandler() As ExcessiveΔKHandler
		Return Me.excessiveΔKHandler
	End Function
	Public Function getJsonFilePath() As String
		Return Me.jsonFilePath
	End Function
	Public Function getPDispFilePath() As String
		Return Me.pDispFilePath
	End Function

End Class
