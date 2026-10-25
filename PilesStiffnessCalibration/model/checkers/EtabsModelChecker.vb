Imports ETABSv1

''' <summary>
'''     <remarks>
'''         Concrete class implementing the FEAModelCheckerInterface and specialized in
'''         running checks on the ETABS model to make sure that the inputs are correct.
'''     </remarks>
''' </summary>

Public Class EtabsModelChecker
    Implements FEAModelCheckerInterface

    'ATTRIBUTES
    Private etabsModel As ETABSv1.cSapModel


    'CONSTRUCTOR
    Public Sub New(etabsModel As ETABSv1.cSapModel)
        Me.etabsModel = etabsModel
    End Sub


    'METHODS

    Public Function checkAnalysisRuns() As (success As Boolean, err As CheckError) Implements FEAModelCheckerInterface.checkAnalysisRuns
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadPatterns() As (success As Boolean, err As CheckError)
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadCases() As (success As Boolean, err As CheckError)
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadCombos() As (success As Boolean, err As CheckError)
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

        '1. Extract the names of the Point Objects assigned to the Etabs Group
        Dim itemsNum As Integer, objTypes As Integer(), objNames As String()
        Dim ret As Integer = Me.etabsModel.GroupDef.GetAssignments(selEtabsGroupName, itemsNum, objTypes, objNames)
        ' If something goes wrong return False + Error Object
        If ret <> 0 OrElse objNames Is Nothing OrElse pointNames Is Nothing Then
            Return (False, New CheckError("Impossible to extract object names from the ETABS model for the given ETABS group."))
        End If
        'Object Type 1 = Point Object
        Dim etabsGroupPointNames As New List(Of String)
        For i As Integer = 0 To itemsNum - 1
            If objTypes(i) = 1 Then etabsGroupPointNames.Add(objNames(i))
        Next

        '2. Collect the mismatching names in both directions
        Dim namesOnlyInEtabsGroup As List(Of String) = etabsGroupPointNames.Except(pointNames).ToList()
        Dim namesOnlyInPointNames As List(Of String) = pointNames.Except(etabsGroupPointNames).ToList()

        '3. Return True if no mismatching names were found
        If namesOnlyInEtabsGroup.Count = 0 And namesOnlyInPointNames.Count = 0 Then
            Return (True, Nothing)
        Else
            Dim error = New CheckError("Point Names do not match")
            Return (False, error)
        End If

    End Function

    Public Function checkPointSpringProperties() As (success As Boolean, err As CheckError)
        Throw New NotImplementedException()
    End Function

    Public Sub runAllChecks() Implements FEAModelCheckerInterface.runAllChecks
        Throw New NotImplementedException()
    End Sub


End Class
