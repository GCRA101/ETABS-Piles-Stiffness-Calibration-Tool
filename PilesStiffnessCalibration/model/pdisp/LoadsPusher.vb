Public Class LoadsPusher(Of T As PDispLoad)
    Inherits Pusher

    'ATTRIBUTES
    'All protected attributes inherited from the superclass

    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub


    'METHODS
    Public Sub push(pDispLoads As List(Of T), overwrite As Boolean)

        'Check that pDispLoads is not null or empty
        If pDispLoads Is Nothing OrElse pDispLoads.Count = 0 Then Return

        'Initialize corresponding push behaviour class
        Dim typeOfT As Type = GetType(T)

        Select Case typeOfT
            Case GetType(PDispRectLoad)
                Dim pushBehaviour As PushRectLoads = New PushRectLoads(pDispModel, pDispLoads.Cast(Of T))
                pushBehaviour.push(overwrite)
            Case GetType(PDispCircLoad)
                Dim pushBehaviour As PushCircLoads = New PushCircLoads(pDispModel, pDispLoads.Cast(Of T))
                pushBehaviour.push(overwrite)
            Case GetType(PDispPolyLoad)
                Dim pushBehaviour As PushPolyLoads = New PushPolyLoads(pDispModel, pDispLoads.Cast(Of T))
                pushBehaviour.push(overwrite)
        End Select

    End Sub


End Class
