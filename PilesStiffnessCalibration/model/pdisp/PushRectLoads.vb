Imports pdispauto_20_1

Public Class PushRectLoads
    Inherits PushBehaviour
    Implements PushData

    'ATTRIBUTES
    Private rectLoads As List(Of PDispRectLoad)

    'CONSTRUCTORS
    Public Sub New(pDispModel As PDispModel)
        MyBase.New(pDispModel)
    End Sub
    Public Sub New(pDispModel As PDispModel, rectLoads As List(Of PDispRectLoad))
        MyBase.New(pDispModel)
        Me.rectLoads = rectLoads
    End Sub

    'method
    Public Sub setRectLoads(rectLoads As List(Of PDispRectLoad))
        Me.rectLoads = rectLoads
    End Sub

    Public Sub push(overwrite As Boolean) Implements PushData.push

        With Me.pDispModel.getPDispApp()
            '1. DELETE EXISTING RECTLOADS IF overwrite=True
            If (overwrite) Then
                Dim numRectLoads As Short
                Do
                    .DeleteRectLoad(1)
                    .NumRectLoads(numRectLoads)
                Loop Until numRectLoads = 0
            End If
            '2. ADD NEW RECTLOADS
            Me.rectLoads.ForEach(Sub(rectLd) .AddRectLoad(rectLd.getLoad()))

        End With

    End Sub

End Class
