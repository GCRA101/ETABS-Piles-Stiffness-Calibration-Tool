Public Class LoadsPuller(Of T As PDispLoad)
    Inherits Puller(Of T)

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub


    'METHODS
    Public Function pull() As List(Of T)

        Dim typeOfT As Type = GetType(T)

        Select Case typeOfT
            Case GetType(PDispRectLoad)
                Dim pullBehaviour As PullRectLoads = New PullRectLoads(pDispModel)
                Dim results = pullBehaviour.pull()
                If results Is Nothing OrElse results.Count = 0 Then Return New List(Of T)
                Return results.Cast(Of T).ToList()
            Case GetType(PDispCircLoad)
                Dim pullBehaviour As PullCircLoads = New PullCircLoads(pDispModel)
                Dim results = pullBehaviour.pull()
                If results Is Nothing OrElse results.Count = 0 Then Return New List(Of T)
                Return results.Cast(Of T).ToList()
            Case GetType(PDispPolyLoad)
                Dim pullBehaviour As PullPolyLoads = New PullPolyLoads(pDispModel)
                Dim results = pullBehaviour.pull()
                If results Is Nothing OrElse results.Count = 0 Then Return New List(Of T)
                Return results.Cast(Of T).ToList()
        End Select

        Return Nothing

    End Function


End Class
