Imports pdispauto_20_1

Public Class PullPolyLoads
    Inherits PullBehaviour(Of PDispPolyLoad)

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub

    'METHODS
    Public Overrides Function pull() As List(Of PDispPolyLoad)

        '1. Get Number of Results
        Dim numLoads As Short
        ret = Me.pDispModel.getPDispApp().NumPolyLoads(numLoads)

        '2. Get Polyloads
        Dim polyLoads As List(Of PDispPolyLoad) = New List(Of PDispPolyLoad)
        For i As Integer = 0 To numLoads - 1 Step 1
            Dim polyLoad As PolyLoad
            Me.pDispModel.getPDispApp().GetPolyLoad(i + 1, polyLoad)
            polyLoads.Add(New PDispPolyLoad(polyLoad))
        Next

        Return polyLoads

    End Function
End Class
