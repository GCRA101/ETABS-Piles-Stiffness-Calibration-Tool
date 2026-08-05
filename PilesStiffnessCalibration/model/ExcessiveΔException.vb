''' <summary>
''' 
''' <remarks>
''' <para> Exception Concrete Class thrown when the difference between the pile stiffness calculated at the current
''' iteration step and the previous one is bigger than the maximum value specified by the user. </para>
''' <para> The class inherits from the Exception class and it gets thrown by the following classes.
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


Public Class ExcessiveΔException
    Inherits Exception

    'ATTRIBUTES
    Private pileObjs As List(Of PileObject)

    'CONSTRUCTOR
    Public Sub New(message As String, pileObjs As List(Of PileObject))
        MyBase.New(message)
        Me.pileObjs = pileObjs
    End Sub

    'METHODS

    'Setters and Getters
    Public Function getPileObjs() As List(Of PileObject)
        Return Me.pileObjs
    End Function


End Class