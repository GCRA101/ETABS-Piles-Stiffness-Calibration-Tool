''' <summary>
'''     <remarks>
'''         Exception thrown when the reactions read from the ETABS model are blank, NaN or Infinity.
'''     </remarks>
''' </summary>

Public Class InvalidFEAOutputsException
    Inherits Exception

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
