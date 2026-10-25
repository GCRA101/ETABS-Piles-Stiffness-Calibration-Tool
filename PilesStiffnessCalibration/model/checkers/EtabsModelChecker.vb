Imports ETABSv1
Imports Newtonsoft.Json.Linq

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
            Dim err = New CheckError("Point Names do not match")
            Return (False, err)
        End If

    End Function

    Public Function checkPointSpringProperties(pointNames As List(Of String)) As (success As Boolean, err As CheckError)

        ' 1. COLLECT UNIQUE NAMES OF POINTSPRINGPROPERTY ASSIGNED TO INPUT POINTNAMES
        ' Variables Declaration
        Dim ret As Integer                                                                                      'Θ(1)
        Dim pointName, pointSpringPropName As String                                                            'Θ(1)
        Dim pointSpringPropNames As HashSet(Of String)                                                          'Θ(1)
        ' Looping through input pointNames
        For Each pointName In pointNames                                                                        'n*Θ(1)+Θ(1)
            ' Extract name of PointSpringProperty from current pointName
            ret = Me.etabsModel.PointObj.GetSpringAssignment(pointName, pointSpringPropName)                    'Θ(1)
            ' Add to HashSet DataStructure
            pointSpringPropNames.Add(pointSpringPropName)                                                       'Θ(1)
        Next

        '2. EXTRACT STIFFNESS ARRAYS FROM COLLECTED POINTSPRINGPROPERTIES
        ' Variables Declaration
        Dim springOption, color As Integer                                                                      'Θ(1)
        Dim stiffnessArray As Double()                                                                          'Θ(1)
        Dim cSys, soilProfile, footing, notes, iGuid As String                                                  'Θ(1)
        Dim period As Double                                                                                    'Θ(1)
        Dim pointSpringProps As Dictionary(Of String, Double())                                                 'Θ(1)
        ' Extract Arrays and assign them to dictionary
        For Each pointSpringPropName In pointSpringPropNames                                                    'O(n) / +Θ(1)
            ret = Me.etabsModel.PropPointSpring.GetPointSpringProp(pointSpringPropName, springOption, stiffnessArray, cSys,
                                                             soilProfile, footing, period, color, notes, iGuid) 'Θ(1)
            pointSpringProps.Add(pointSpringPropName, stiffnessArray)                                           'Θ(1)
        Next

        '3. CHECK STIFFNESS ARRAYS
        For Each kvp In pointSpringProps                                                                        'O(n) / +Θ(1)
            If kvp.Value.ToList().Any(Function(ki) Double.IsNaN(ki)) Then                                       'Θ(1) (O(6))
                Return (False, New CheckError("Computed point spring properties contain NaN Values. "))         'Θ(1)
            End If                                                                                              'Θ(1)
        Next                                                                                                    'Θ(1)

        '...If no error has been encountered...return true flag and null error object
        Return (True, Nothing)


    End Function

    Public Sub runAllChecks() Implements FEAModelCheckerInterface.runAllChecks
        Throw New NotImplementedException()
    End Sub


End Class
