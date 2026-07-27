Imports System.Web.UI.WebControls.Expressions
Imports System.Windows.Forms
Imports ETABSv1

''' <summary>
'''     <remarks>
'''         Concrete class inheriting from the ExceptionHandler class and specialized in creating
'''         and displaying a Warning message when an issue with the Excel's COM object comes up.
'''     </remarks>
''' </summary>

Public Class ExcelComInteropHandler
    Inherits ExceptionHandler

    'CONSTRUCTOR
    Public Sub New(controller As PSC_Controller)
        MyBase.New(controller)
    End Sub

    'METHODS
    Public Overrides Sub execute(Optional ex As Exception = Nothing)
        'Build and display warning message if exception is not null
        If ex IsNot Nothing And ex.GetType() Is GetType(ExcelComInteropException) Then
            'Downcast the Exception to ExcelComInteropException
            Dim excelComEx As ExcelComInteropException = DirectCast(ex, ExcelComInteropException)
            'Build the message to be displayed in the MessageBox
            Me.message = excelComEx.Message + vbNewLine + "Detailed Error Message: " + excelComEx.getErrorMessage()
            'Show the custom TopMost MessageBox with the warning message
            TopMostMsgBox.Show(Me.message, "WARNING - EXCEL COM ISSUES", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub


End Class
