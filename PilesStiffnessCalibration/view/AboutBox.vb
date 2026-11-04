Imports System.IO
Imports System.Reflection

''' <summary>
''' 
''' <remarks>
''' <para> Concrete class representing the AboutBox of the application, highlighting important information for the user. </para>
''' <para> The AboutBox window appears after the splashscreen has disappeared and its purpose is to show to the user functionalities and limitations of the tool. </para>
''' <para> The class implements the Observer functional interface that allows it to be updated with changes occurring in the Model
''' via the Observer Pattern.</para>
''' <para> The <see cref="update"/> method gets called as soon as the window gets loaded, allowing it to collect the application's assembly 
''' information that is stored in the Model <see cref="PSC_Model"/>
''' </para>
''' 
''' <para> Desing Patterns: 
''' - OBSERVER </para>
''' 
''' </remarks>
''' 
''' </summary>


Public NotInheritable Class AboutBox
    Implements Observer

    'ATTRIBUTES *******************************************************************************************
    Private model As PSC_Model

    'CONSTRUCTOR ******************************************************************************************
    'Overloaded
    Public Sub New(model As PSC_Model)
        ' This call is required by the designer.
        InitializeComponent()
        ' Add any initialization after the InitializeComponent() call.
        Me.model = model
    End Sub

    'METHODS **********************************************************************************************
    Private Sub aboutBox_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Set the title of the form.
        Dim ApplicationTitle As String
        ApplicationTitle = "Pile/Soil Spring Stiffness Calibration Tool"
        Me.Text = String.Format("About {0}", ApplicationTitle)
        ' Initialize all of the text displayed on the About Box.
        Me.update()
        ' Place the AboutBox at the centre of the Screen
        Me.CenterToScreen()
    End Sub

    Private Sub update() Implements Observer.update
        Me.lblProductName.Text = Me.model.getModelName()
        Me.lblVersion.Text = Me.model.getModelVersion()
        Me.lblCopyRight.Text = Me.model.getModelCopyRight()
        Me.lblCompanyName.Text = Me.model.getModelOwner()
        Me.txtDescription.Text = ControllerFileManager.getDocText(Document.APP_DESCRIPTION)
    End Sub
End Class
