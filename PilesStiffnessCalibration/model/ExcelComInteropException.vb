''' <summary>
''' 
''' InvalidFilePathException Concrete Class
''' 
''' <remarks>
''' <para> Exception Concrete Class thrown when filepath provided by the user is not valid. </para>
''' <para> The class inherits from the Exception class and it gets thrown by the following classes whenever it is found that the provided filepath
''' is not valid.
''' <see cref="PSC_Model"/>
''' <see cref="PSC_Controller"/>
''' <see cref="EventsListener"/>
'''  </para>
''' 
''' <para> Programming Techniques: 
''' - EXCEPTIONS HANDLING </para>
''' 
''' </remarks>
''' 
''' </summary>

Public Class ExcelComInteropException
    Inherits Exception

    ' ATTRIBUTES
    Private errorMessage As String

    ' CONSTRUCTOR
    Public Sub New(message As String, errorMessage As String)
        MyBase.New(message)
    End Sub

    ' METHODS

    ' Setters and Getters
    Public Function getErrorMessage() As String
        Return Me.errorMessage
    End Function

End Class
