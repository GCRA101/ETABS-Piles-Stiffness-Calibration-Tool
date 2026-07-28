Imports ETABSv1
Imports Newtonsoft.Json
Imports pdispauto_20_1
Imports Piles_Stiffness_Iteration.model
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Runtime.Remoting.Contexts
Imports System.Runtime.Serialization
Imports System.Windows.Forms


''' <summary>
''' 
''' <remarks>
''' <para> Concrete class representing the main UI window of the application. </para>
''' <para> The class implements the Observer functional interface that allows it to be updated with 
''' changes occurring in the Model (<see cref="PSC_Model"/>) via the Observer Pattern.
'''  </para>
''' 
''' <para> Desing Patterns: 
''' - FACADE </para>
''' 
''' </remarks>
''' 
''' </summary>

Public Class ViewInputs
    Implements Observer

    ' ATTRIBUTES ***************************************************************************************
    Private model As PSC_Model
    Private controller As PSC_Controller
    Private pDispFilePath, jsonFilePath As String
    Private iterNumMax As Integer
    Private convergenceFactor As Single
    Private ret As Integer
    Private loadComboName, groupName As String
    Private pDispModel As PDispModel
    Private iter As Integer
    Private pileObjsQueue As Queue(Of List(Of PileObject))
    Private startPileObjsList As List(Of PileObject)
    Private jsonSerializer As JSONSerializer(Of List(Of PileObject))
    Private progrBarStep As Integer



    ' CONSTRUCTORS **************************************************************************************
    Public Sub New(model As PSC_Model, controller As PSC_Controller)
        Me.model = model
        Me.controller = controller
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub lblLoadCombos_Click(sender As Object, e As EventArgs) Handles lblLoadCombos.Click

    End Sub

    Private Sub gbETABSInputs_Enter(sender As Object, e As EventArgs) Handles gbETABSInputs.Enter

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblNonLinearOption.Click

    End Sub

    Private Sub rbImportFromFile_CheckedChanged(sender As Object, e As EventArgs) Handles rbImportFromFile.CheckedChanged

    End Sub

    Private Sub btnOpenJSONFile_Click(sender As Object, e As EventArgs) Handles btnOpenJSONFile.Click

    End Sub

    Private Sub tbStiffness_TextChanged(sender As Object, e As EventArgs) Handles tbStiffness.TextChanged

    End Sub

    Private Sub rbSpring_CheckedChanged(sender As Object, e As EventArgs) Handles rbSpring.CheckedChanged

    End Sub

    Private Sub rbRigid_CheckedChanged(sender As Object, e As EventArgs) Handles rbRigid.CheckedChanged

    End Sub

    Private Sub lblInitialStiffness_Click(sender As Object, e As EventArgs) Handles lblInitialStiffness.Click

    End Sub

    Private Sub cbNonLinearOptions_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbNonLinearOptions.SelectedIndexChanged

    End Sub



    ' METHODS *******************************************************************************************

    Public Sub initialize()
        'Clear the CheckedListBoxes
        Me.cklbGroups.Items.Clear()
        Me.cklbLoadCombos.Items.Clear()
        'Set Linear Option as the default one
        Me.cbNonLinearOptions.SelectedIndex = 0
        'Set Rigid Piles Option as the default one
        Me.rbRigid.Checked = True
        'Set first item of each combobox as the default one
        For Each comp As Component In gbPDispInputs.Controls
            If CStr(comp.GetType().Name) = "ComboBox" Then
                Dim cbBox = CType(comp, ComboBox)
                cbBox.SelectedIndex = 0
            End If
        Next
        'Disable/Enable Buttons and Textboxes
        tbStiffness.Enabled = False
        btnOpenJSONFile.Enabled = False
        Me.btnOpenPDispFile.Enabled = True
        'Force window to be the top most one
        Me.TopMost = True

    End Sub


    Private Sub update() Implements Observer.update

        'POPULATE CHECKBOXES

        'Update CheckBoxes with Group Names
        With Me.cklbGroups
            .CheckOnClick = True
            .Items.AddRange(Me.model.getEtabsGroupNames.ToArray())
            .ClearSelected()
        End With
        'Update CheckBoxes with LoadCombo Names
        With Me.cklbLoadCombos
            .CheckOnClick = True
            .Items.AddRange(Me.model.getEtabsLoadComboNames.ToArray())
            .ClearSelected()
        End With

        ' DOCK WINDOWS

        'Dock ETABS and PDISP Windows to left and right halves of the screen
        If model.getIterationStarted() = True Then
            'Dock ETABS Window
            WindowResizer.dockWindow(ProcessName.CSI_ETABS, DockType.LEFT)
            model.getSapModel().View.RefreshView()
            'Dock PDISP Window
            model.getPDispModel().setVisibility(True)
            WindowResizer.dockWindow(ProcessName.OASYS_PDISP, DockType.RIGHT)
        End If

        'UPDATE PROGRESS BAR

        'Get input maximum number of iterations
        Dim iterNumMax As Integer = Me.model.getIterNumMax()
        'Define value of progress bar step based on max number of iterations
        If iterNumMax <> 0 Then
            Me.progrBarStep = (Me.progrBar.Maximum - Me.progrBar.Minimum) \ iterNumMax
        End If
        'Increment the progress bar if step has been run
        If Me.model.getStepRun() = True Then
            Me.progrBar.Increment(progrBarStep)
        End If

        'ITERATION COMPLETE MESSAGE

        If Me.model.getIterationComplete = True Then
            Me.lblProgrBar.Text = "ITERATION COMPLETE!"
            Me.progrBar.Increment(Me.progrBar.Maximum - Me.progrBar.Value)
            Me.Refresh()
            System.Threading.Thread.Sleep(3000)
            WindowResizer.dockWindow(ProcessName.CSI_ETABS, DockType.CENTER)
            model.getSapModel().View.RefreshWindow()
            model.getSapModel().View.RefreshView()
        End If

        Me.Refresh()

    End Sub

End Class