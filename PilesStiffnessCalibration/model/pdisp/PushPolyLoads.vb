Public Class PushPolyLoads
    Inherits PushBehaviour
    Implements PushData

    'ATTRIBUTES
    Private polyLoads As List(Of PDispPolyLoad)

    'CONSTRUCTORS
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub
    Public Sub New(pDispModel As PDispModel, polyLoads As List(Of PDispPolyLoad))
        MyBase.New(pDispModel)
        Me.polyLoads = polyLoads
    End Sub

    'method
    Public Sub setPolyLoads(polyLoads As List(Of PDispPolyLoad))
        Me.polyLoads = polyLoads
    End Sub

    Public Sub push(overwrite As Boolean) Implements PushData.push

        With Me.pDispModel.getPDispApp()
            '1. DELETE EXISTING POLYLOADS IF overwrite=True
            If (overwrite) Then
                Dim numPolyLoads As Short
                Do
                    .DeletePolyLoad(1)
                    .NumPolyLoads(numPolyLoads)
                Loop Until numPolyLoads = 0
            End If
            '2. ADD NEW POLYLOADS
            Me.polyLoads.ForEach(Sub(polyLd) .AddPolyLoad(polyLd.getLoad()))
        End With

    End Sub



End Class
