Imports pdispauto_20_1

''' <summary>
'''     <remarks>
'''         Concrete class implementing the FEAModelCheckerInterface and specialized in
'''         running checks on the PDisp model to make sure that the inputs are correct.
'''     </remarks>
''' </summary>

Public Class PDispModelChecker
    Implements FEAModelCheckerInterface

    'ATTRIBUTES
    Private pDispModel As PDispModel


    'CONSTRUCTOR
    Public Sub New(pDispModel As PDispModel)
        Me.pDispModel = pDispModel
    End Sub


    'METHODS

    Public Function checkAnalysisRuns() As (success As Boolean, err As CheckError) Implements FEAModelCheckerInterface.checkAnalysisRuns
        Throw New NotImplementedException()
    End Function

    Public Function checkDisplacementValues() As (success As Boolean, err As CheckError)
        Throw New NotImplementedException()
    End Function

    Public Function checkGridsCalculation() As (success As Boolean, err As CheckError)

        '1. EXTRACT NUMBER OF GRIDS DEFINED IN THE MODEL
        ' Get the number of Displacement Grids defined in the PDisp model
        Dim gridsNum As Short
        Dim ret As Short = Me.pDispModel.getPDispApp().NumDisplacementGrids(gridsNum)
        ' If something goes wrong return False + Error Object
        If ret <> 0 Then
            Return (False, New CheckError("Impossible to extract the Displacement Grids from the PDisp model."))
        End If

        '2. CHECK THAT CALCULATE OPTION IS NOT ACTIVE AT ANY DISPLACEMENT GRID
        ' Return False + Error Object if any Displacement Grid has the Calculate option ticked
        For i As Short = 1 To gridsNum
            Dim dispGrid As DisplacementGrid
            ret = Me.pDispModel.getPDispApp().GetDisplacementGrid(i, dispGrid)
            If ret <> 0 Then
                Return (False, New CheckError("Impossible to extract Displacement Grid " & i & " from the PDisp model."))
            End If
            If dispGrid.Calculate Then
                Return (False, New CheckError("Displacement Grid '" & dispGrid.Name & "' in the PDisp model has the Calculate option ticked."))
            End If
        Next

        '...If no Displacement Grid is set to be calculated, return true bool flag and null checkError object
        Return (True, Nothing)

    End Function

    Public Function checkAreaValues() As (success As Boolean, err As CheckError)
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadTypes() As (success As Boolean, err As CheckError)
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadValues() As (success As Boolean, err As CheckError)
        Throw New NotImplementedException()
    End Function

    Public Function checkModelOpens() As (success As Boolean, err As CheckError) Implements FEAModelCheckerInterface.checkModelOpens
        Throw New NotImplementedException()
    End Function

    Public Function checkModelSaves() As (success As Boolean, err As CheckError) Implements FEAModelCheckerInterface.checkModelSaves
        Throw New NotImplementedException()
    End Function

    Public Function checkPointsCount(selEtabsGroupName As String, pointsCount As Integer) As (success As Boolean, err As CheckError) Implements FEAModelCheckerInterface.checkPointsCount
        Throw New NotImplementedException()
    End Function

    Public Function checkPointsNames(selEtabsGroupName As String, pointNames As List(Of String)) As (success As Boolean, err As CheckError) Implements FEAModelCheckerInterface.checkPointsNames
        Throw New NotImplementedException()
    End Function

    Public Sub runAllChecks() Implements FEAModelCheckerInterface.runAllChecks
        Throw New NotImplementedException()
    End Sub


End Class
