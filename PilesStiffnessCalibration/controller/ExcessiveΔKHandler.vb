Imports System.Windows.Forms

''' <summary>
'''     <remarks>
'''         Concrete class inheriting from the ExceptionHandler class and specialized in creating
'''         and displaying a Warning message when Δ is found to be excessive between two consecutive
'''         iterations of the piles stiffnesses calibration.
'''     </remarks>
''' </summary>

Public Class ExcessiveΔHandler
    Inherits ExceptionHandler

    'CONSTRUCTOR
    Public Sub New(controller As PSC_Controller)
        'Call the constructor of the superclass
        MyBase.New(controller)
    End Sub

    'METHODS
    Public Overrides Sub execute(Optional ex As Exception = Nothing)
        'If the exception is null, just skip
        If ex Is Nothing Then
            Return
        End If
        'Otherwise, build and display a Warning Message for the user
        If ex.GetType() Is GetType(ExcessiveΔException) Then
            'Downcast the Exception
            Dim exΔ As ExcessiveΔException = DirectCast(ex, ExcessiveΔException)
            'Extract the Error message and add further text at the end to anticipate list of piles affected by the issue
            Me.message = ex.Message + vbNewLine + "Affected Pile Objects are the following ones: " + vbNewLine
            'Add the list of Pile Objects affected by the issue
            exΔ.getPileObjs().Select(Function(po) po.getName()).ToList().ForEach(Function(poName) Me.message + poName + ", ")
            'Remove last comma and space from the string message
            Me.message.Remove(Me.message.Count - 2)
            'Display the Warning MessageBox Window
            TopMostMsgBox.Show(Me.message, "WARNING - EXCESSIVE STIFFNESS VARIATION", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


End Class
