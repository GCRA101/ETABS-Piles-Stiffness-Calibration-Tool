Imports pdispauto_20_1

Public Class PullCircLoads
    Inherits PullBehaviour(Of PDispCircLoad)

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub

    'METHODS
    Public Overrides Function pull() As List(Of PDispCircLoad)

        '1. Get Number of Results
        Dim numLoads As Short
        ret = Me.pDispModel.getPDispApp().NumCircLoads(numLoads)

        '2. Get CircLoads
        Dim circLoads As List(Of PDispCircLoad) = New List(Of PDispCircLoad)
        For i As Integer = 0 To numLoads - 1 Step 1
            Dim circLoad As CircLoad
            Me.pDispModel.getPDispApp().GetCircLoad(i + 1, circLoad)
            circLoads.Add(New PDispCircLoad(circLoad))
        Next

        Return circLoads

    End Function

End Class
