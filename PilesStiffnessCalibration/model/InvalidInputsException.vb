Imports System.Runtime.Serialization

''' <summary>
''' 
''' MissingInputsException Concrete Class
''' 
''' <remarks>
''' <para> Exception Concrete Class thrown when user inputs are missing. </para>
''' <para> The class inherits from the Exception class and it gets thrown by the following classes whenever it is found that the required inputs
''' from the user are missing.
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

Public Class InvalidInputsException
    Inherits Exception

    Public Sub New(message As String)
        MyBase.New(message)
    End Sub
End Class
