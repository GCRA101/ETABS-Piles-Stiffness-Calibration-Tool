Public Class CheckError

    'ATTRIBUTES
    Private severity As ErrorSeverity
    Private message As String
    Private metadata As Object


    'CONSTRUCTOR
    ' Overloaded v1
    Public Sub New(severity As ErrorSeverity, message As String)
        Me.severity = severity
        Me.message = message
        Me.metadata = Nothing
    End Sub
    ' Overloaded v2
    Public Sub New(severity As ErrorSeverity, message As String, metadata As Object)
        Me.severity = severity
        Me.message = message
        Me.metadata = metadata
    End Sub

    'METHODS

    'Setters and Getters
    Public Sub setMessage(message As String)
        Me.message = message
    End Sub
    Public Sub setMetadata(metadata As Object)
        Me.metadata = metadata
    End Sub

    Public Function getMessage() As String
        Return Me.message
    End Function
    Public Function getMetadata() As Object
        Return Me.metadata
    End Function
    Public Function getSeverity() As ErrorSeverity
        Return Me.severity
    End Function

End Class
