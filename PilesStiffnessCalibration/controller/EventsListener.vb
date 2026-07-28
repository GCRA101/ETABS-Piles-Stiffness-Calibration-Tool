Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Windows.Forms
Imports ETABSv1
Imports Piles_Stiffness_Calibration.model
Imports Piles_Stiffness_Calibration.view


''' <summary>
'''     <remarks>
'''         Class responsible for running sound effects and calling Model's methods whenever 
'''         an event gets triggered by any registered command within the UI components of the View.
'''     </remarks>
''' </summary>

Public Class EventsListener

    ' ATTRIBUTES
    Private controller As PSC_Controller
    Private view As PSC_View
    Private WithEvents aboutBoxBtnOk As Windows.Forms.Button
    Private WithEvents viewInputsForm As Windows.Forms.Form
    Private WithEvents viewInputsCklbGroups As Windows.Forms.CheckedListBox
    Private WithEvents viewInputsCklbLoadCombos As Windows.Forms.CheckedListBox
    Private WithEvents viewInputsRbSpring As Windows.Forms.RadioButton
    Private WithEvents viewInputsRbImportFromFile As Windows.Forms.RadioButton
    Private WithEvents viewInputsTbStiffness As Windows.Forms.TextBox
    Private WithEvents viewInputsBtnOpenJSONFile As Windows.Forms.Button
    Private WithEvents viewInputsBtnOpenPDispFile As Windows.Forms.Button
    Private WithEvents viewInputsBtnRunIteration As Windows.Forms.Button

    ' CONSTRUCTORS
    ' Overloaded
    Public Sub New(controller As PSC_Controller, view As PSC_View)
        Me.controller = controller
        Me.view = view
    End Sub


    ' METHODS
    Public Sub initializeAboutBox()
        Me.aboutBoxBtnOk = Me.view.getAboutBox().btnOK
    End Sub

    Public Sub initializeViewInputs()
        Me.viewInputsForm = Me.view.getViewInputs()
        Me.viewInputsCklbGroups = Me.view.getViewInputs().cklbGroups
        Me.viewInputsCklbLoadCombos = Me.view.getViewInputs().cklbLoadCombos
        Me.viewInputsRbSpring = Me.view.getViewInputs().rbSpring
        Me.viewInputsRbImportFromFile = Me.view.getViewInputs().rbImportFromFile
        Me.viewInputsTbStiffness = Me.view.getViewInputs().tbStiffness
        Me.viewInputsBtnOpenJSONFile = Me.view.getViewInputs().btnOpenJSONFile
        Me.viewInputsBtnOpenPDispFile = Me.view.getViewInputs().btnOpenPDispFile
        Me.viewInputsBtnRunIteration = Me.view.getViewInputs().btnRunIteration
    End Sub

    Private Sub btnOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles aboutBoxBtnOk.Click
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CLICKBUTTON)
        'Create the View
        view.createViewInputs()
        'Initialize Components for Events listening
        Me.initializeViewInputs()
    End Sub

    Private Sub cklbGroups_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles viewInputsCklbGroups.ItemCheck
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CHECKBOX)
        'Suspend the Event Handler to prevent its call when unchecking items in code below
        RemoveHandler viewInputsCklbGroups.ItemCheck, AddressOf cklbGroups_ItemCheck
        'Uncheck all items apart from the one chosen by the user (this allows to have one item only checked at the time)
        For i As Integer = 0 To viewInputsCklbGroups.Items.Count - 1 Step 1
            If (i <> e.Index) Then
                viewInputsCklbGroups.SetItemChecked(i, False)
            End If
        Next
        'Reactivate the Event Handler
        AddHandler viewInputsCklbGroups.ItemCheck, AddressOf cklbGroups_ItemCheck
    End Sub

    Private Sub cklbLoadCombos_ItemCheck(sender As Object, e As ItemCheckEventArgs) Handles viewInputsCklbLoadCombos.ItemCheck
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CHECKBOX)
        'Suspend the Event Handler to prevent its call when unchecking items in code below
        RemoveHandler viewInputsCklbLoadCombos.ItemCheck, AddressOf cklbLoadCombos_ItemCheck
        'Uncheck all items apart from the one chosen by the user (this allows to have one item only checked at the time)
        For i As Integer = 0 To viewInputsCklbLoadCombos.Items.Count - 1 Step 1
            If (i <> e.Index) Then
                viewInputsCklbLoadCombos.SetItemChecked(i, False)
            End If
        Next
        'Reactivate the Event Handler
        AddHandler viewInputsCklbLoadCombos.ItemCheck, AddressOf cklbLoadCombos_ItemCheck
    End Sub

    Private Sub rbSpring_CheckedChanged(sender As Object, e As EventArgs) Handles viewInputsRbSpring.CheckedChanged
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CHECKBOX)
        'Enable/Disable Textbox for input stiffness value
        If viewInputsRbSpring.Checked Then
            viewInputsTbStiffness.Enabled = True
        Else
            viewInputsTbStiffness.Enabled = False
        End If
    End Sub

    Private Sub rbImportFromFile_CheckedChanged(sender As Object, e As EventArgs) Handles viewInputsRbImportFromFile.CheckedChanged
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CHECKBOX)
        'Enable/Disable Button to open json file
        If viewInputsRbImportFromFile.Checked Then
            viewInputsBtnOpenJSONFile.Enabled = True
        Else
            viewInputsBtnOpenJSONFile.Enabled = False
        End If
    End Sub

    Private Sub tbStiffness_TextChanged(sender As Object, e As EventArgs) Handles viewInputsTbStiffness.TextChanged
        'Prevent non-numeric values from being input in the textbox
        If Not IsNumeric(viewInputsTbStiffness.Text) And viewInputsTbStiffness.Text <> "" Then
            viewInputsTbStiffness.Text = ""
        End If
    End Sub

    Private Sub btnOpenJSONFile_Click(sender As Object, e As EventArgs) Handles viewInputsBtnOpenJSONFile.Click
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CLICKBUTTON)
        'Call ControllerFileManager method to get path of json file from the client
        Dim jsonFilePath As String = ControllerFileManager.getFilePath(Me.view.getViewInputs().ofdJsonFile,
                                                             "Select Json File", "Json Files|*.json")
        'If the json file has been selected, disable the button to prevent multiple files selection from the user
        If ((jsonFilePath <> "")) Then
            viewInputsBtnOpenJSONFile.Enabled = False
        End If
        Me.controller.setJsonFilePath(jsonFilePath)
    End Sub

    Private Sub btnOpenPDispFile_Click(sender As Object, e As EventArgs) Handles viewInputsBtnOpenPDispFile.Click
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CLICKBUTTON)
        'Call ControllerFileManager method to get path of pdisp file from the client
        Dim pDispFilePath As String = ControllerFileManager.getFilePath(Me.view.getViewInputs().ofdPDispFile,
                                                              "Select PDisp File", "PDisp Files|*.pdd")
        'If the pdisp file has been selected, disable the button to prevent multiple files selection from the user
        If ((pDispFilePath <> "")) Then
            viewInputsBtnOpenPDispFile.Enabled = False
        End If
        Me.controller.setpDispFilePath(pDispFilePath)
    End Sub

    Private Sub btnRunIteration_Click(sender As Object, e As EventArgs) Handles viewInputsBtnRunIteration.Click
        'Play Sound Effect
        Me.controller.getSoundManager().play(Sound.CLICKBUTTON)
        'Launch the iterative process while catching exceptions
        Try
            Me.controller.processInputData()
            Me.controller.runIteration()
            Me.controller.terminate()
        Catch ex1 As OutOfLicensesException
            MsgBox("No PDisp Licenses are currently available.", vbOKOnly + vbCritical, "WARNING")
        Catch ex2 As MissingInputsException
            Me.controller.getMissingInputsHandler().execute(ex2)
        Catch ex3 As ExcessiveΔKException
            Me.controller.getExcessiveΔKHandler().execute(ex3)
        Catch ex4 As ExcelComInteropException
            Me.controller.getExcelComInteropHandler().execute(ex4)
        End Try
    End Sub

    Private Sub viewInputsForm_Closed(sender As Object, e As EventArgs) Handles viewInputsForm.Closed
        'Dispose the Input Form
        viewInputsForm.Dispose()
        'Release the Memory
        Me.controller.getISapPlugIn().Finish(0)
    End Sub



End Class
