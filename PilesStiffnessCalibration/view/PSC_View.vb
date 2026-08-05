Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports Piles_Stiffness_Iteration.model


''' <summary>
''' 
''' <remarks>
''' <para> Concrete class and main class of the View Package. </para>
''' <para> The class contains all the main data and methods for the running the User Interface of the application.
''' The View is updated based on the changes occurring in the Model (<see cref="PSC_Model"/>) via the OBSERVER Design Pattern, while the 
''' Model is updated based on the actions taken by the user in the View (<see cref="PSC_View"/>) via the Controller <see cref="PSC_Controller"/> (MVC Pattern).
'''  </para>
''' 
''' <para> Desing Patterns: 
''' - OBSERVER
''' - MODEL-VIEW-CONTROLLER </para>
''' 
''' </remarks>
''' 
''' </summary>
Public Class PSC_View

	'ATTRIBUTES

	'References to Model and Controller
	Protected model As PSC_Model
	Protected controller As PSC_Controller
	'Main windows of the View
	Protected splashScreen As SplashScreen
	Protected aboutBox As AboutBox
	Protected viewInputs As ViewInputs

	'CONSTRUCTORS
	Public Sub New(model As PSC_Model, controller As PSC_Controller)
		Me.model = model
		Me.controller = controller
	End Sub

	'METHODS

	'CREATION of the VIEWS
	Public Sub createSplashScreen()
		Me.splashScreen = New SplashScreen(Me.model)
		Me.controller.getSoundManager().play(Sound.SPLASHSCREEN)
		Me.model.registerObserver(Me.splashScreen)
		System.Threading.Thread.Sleep(1000)
		Me.splashScreen.Show()
		splashScreen.Refresh()
		System.Threading.Thread.Sleep(5000)
		Me.model.removeObserver(Me.splashScreen)
		splashScreen.Close()
	End Sub
	Public Sub createAboutBox()
		Me.aboutBox = New AboutBox(Me.model)
		Me.model.registerObserver(Me.aboutBox)
		Me.model.notifyObservers()
		Me.aboutBox.Show()
	End Sub
	Public Sub createViewInputs()
		Try
			Me.viewInputs = New ViewInputs(model, controller)
			Me.viewInputs.initialize()
			Me.model.removeObserver(Me.aboutBox)
			Me.model.registerObserver(Me.viewInputs)
			Me.controller.extractEtabsModelData()
			Me.viewInputs.Show()
			Me.aboutBox.Close()
		Catch ex1 As MissingInputsException
			Me.controller.getMissingInputsHandler().execute(ex1)
		Catch ex As Exception
			' Any other unexpected error
			TopMostMsgBox.Show(ex.Message, "WARNING - ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Throw
		End Try

	End Sub

	'SETTERS and GETTERS
	Public Sub setAboutBox(aboutBox As AboutBox)
		Me.aboutBox = aboutBox
	End Sub
	Public Sub setSplashScreen(splashScreen As SplashScreen)
		Me.splashScreen = splashScreen
	End Sub
	Public Sub setViewInputs(viewInputs As ViewInputs)
		Me.viewInputs = viewInputs
	End Sub
	Public Function getAboutBox() As AboutBox
		Return Me.aboutBox
	End Function
	Public Function getSplashScreen() As SplashScreen
		Return Me.splashScreen
	End Function
	Public Function getViewInputs() As ViewInputs
		Return Me.viewInputs
	End Function


End Class
