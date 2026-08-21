Imports ETABSv1
Imports System.Windows.Forms

''' <summary>
'''     <remarks>
'''         Concrete class inheriting from the ExceptionHandler class and specialized in creating
'''         and displaying a Warning message when inputs are found to be missing.
'''     </remarks>
''' </summary>

Public Class MissingInputsHandler
    Inherits ExceptionHandler

    'CONSTRUCTOR
    Public Sub New(controller As PSC_Controller)
        MyBase.New(controller)
    End Sub

    'METHODS
    Public Overrides Sub execute(Optional ex As Exception = Nothing)
        'Build and display warning message if exception is not null
        If ex IsNot Nothing Then
            Me.message = ex.Message
            TopMostMsgBox.Show(Me.message, "WARNING - MISSING INPUTS", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub


End Class
