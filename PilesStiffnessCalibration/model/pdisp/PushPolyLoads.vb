Imports pdispauto_20_1

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
            ' Variables Declaration
            Dim numPolyLoads, pli As Short
            Dim polyLoadLevel As Double
            '1. DELETE EXISTING POLYLOADS IF overwrite=True
            If (overwrite) Then
                Do
                    .DeletePolyLoad(1)
                    .NumPolyLoads(numPolyLoads)
                Loop Until numPolyLoads = 0
            End If
            '2. ADD NEW POLYLOADS
            Try
                pli = 1
                For Each polyLd As PDispPolyLoad In Me.polyLoads
                    Dim pdispLoad As PolyLoad = polyLd.getLoad()
                    Dim storedLoad As PolyLoad
                    polyLoadLevel = pdispLoad.Level
                    .AddPolyLoad(pdispLoad)
                    .NumPolyLoads(numPolyLoads)
                    .GetPolyLoad(pli, storedLoad)
                    .SetPolyLoad(pli, storedLoad)
                    pli = numPolyLoads + 1
                Next
            Catch ex As Exception
                ' TODO: log or handle the error appropriately
                System.Diagnostics.Debug.WriteLine($"AddPolyLoad failed: {ex.Message}")
                Throw ' rethrow to preserve the original stack trace; remove if you want to swallow
            End Try
        End With

        ' Via Streams
        ' Me.polyLoads.ForEach(Sub(polyLd) pdispApp.AddPolyLoad(polyLd.getLoad()))
    End Sub



End Class
