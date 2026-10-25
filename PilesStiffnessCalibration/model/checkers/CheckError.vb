Public Class CheckError

    'ATTRIBUTES
    Private message As String


    'CONSTRUCTOR
    Public Sub New(message As String)
        Me.message = message
    End Sub


    'METHODS

    'Setters and Getters
    Public Sub setMessage(message As String)
        Me.message = message
    End Sub

    Public Function getMessage() As String
        Return Me.message
    End Function

End Class
