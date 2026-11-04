Imports System.Reflection
Imports System.Windows.Forms
Imports ETABSv1
Imports pdispauto_20_1

''' <summary>
''' 
''' <remarks>
''' <para> Concrete class implementing the ETABSv1.cPluginContract interface.
''' The method <see cref="cPlugin.Main(ByRef cSapModel, ByRef cPluginCallback)"/> gets run as soon as the 
''' user clicks on the icon of the plugin in the ETABS UI. This method is used to instantiate and initialize
''' the Controller (<see cref="PSC_Controller"/>) of the application that, in turn, initialize the
''' Model (<see cref="PSC_Model"/>) and the View (<see cref="PSC_View"/>) as per MVC Pattern.
''' </para>
''' </remarks>
''' 
''' </summary>


Public Class cPlugin
    Implements ETABSv1.cPluginContract

    Public Sub Main(ByRef SapModel As cSapModel, ByRef ISapPlugin As cPluginCallback) Implements cPluginContract.Main

        Dim controller As PSC_Controller = New PSC_Controller(SapModel, ISapPlugin)
        controller.initialize()

    End Sub

    Public Function Info(ByRef Text As String) As Integer Implements cPluginContract.Info
        Text = "Plugin carrying out the iterative analysis of pile/soil spring stiffnesses"
        Return 0
    End Function



End Class
