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
            Return (False, New CheckError(ErrorSeverity.FATAL, "Impossible to extract object names from the ETABS model for the given ETABS group."))
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
        If namesOnlyInEtabsGroup.Count = 0 AndAlso namesOnlyInPointNames.Count = 0 Then
            Return (True, Nothing)
        End If
        '...If mismatching names have been found...return false flag and error object...
        Dim errorMessage As String = ""
        If namesOnlyInPointNames.Count > 0 Then
            errorMessage &= "Following Point Names are missing in Etabs Group " & selEtabsGroupName & ": " &
                            String.Join(", ", namesOnlyInPointNames) & ". "
        End If
        If namesOnlyInEtabsGroup.Count > 0 Then
            errorMessage &= "Following Point Names are in Etabs Group " & selEtabsGroupName &
                            " but missing from the input points: " & String.Join(", ", namesOnlyInEtabsGroup) & "."
        End If
        Return (False, New CheckError(ErrorSeverity.FATAL, errorMessage.Trim()))

    End Function

    Public Function checkPointSpringProperties(pointNames As List(Of String)) As (success As Boolean, err As CheckError)    'T(n)

        ' 1. COLLECT UNIQUE NAMES OF POINTSPRINGPROPERTY ASSIGNED TO INPUT POINTNAMES
        ' Variables Declaration
        Dim ret As Integer                                                                                                  'Θ(1)
        Dim pointName, pointSpringPropName As String                                                                        'Θ(1)
        Dim pointSpringPropNames As New HashSet(Of String)                                                                  'Θ(1)
        ' Looping through input pointNames
        For Each pointName In pointNames                                                                                    'n*Θ(1)+Θ(1)
            ' Extract name of PointSpringProperty from current pointName
            ret = Me.etabsModel.PointObj.GetSpringAssignment(pointName, pointSpringPropName)                                'Θ(1)
            If ret <> 0 OrElse String.IsNullOrEmpty(pointSpringPropName) OrElse pointSpringPropName = "None" Then
                Return (False, New CheckError(ErrorSeverity.FATAL,
                        "No point spring property could be read for point '" & pointName & "'."))
            End If
            ' Add to HashSet DataStructure
            pointSpringPropNames.Add(pointSpringPropName)                                                                   'Θ(1)
        Next

        '2. EXTRACT STIFFNESS ARRAYS FROM COLLECTED POINTSPRINGPROPERTIES
        ' Variables Declaration
        Dim springOption, color As Integer                                                                                  'Θ(1)
        Dim stiffnessArray As Double()                                                                                      'Θ(1)
        Dim cSys, soilProfile, footing, notes, iGuid As String                                                              'Θ(1)
        Dim period As Double                                                                                                'Θ(1)
        Dim pointSpringProps As New Dictionary(Of String, Double())                                                         'Θ(1)
        ' Extract Arrays and assign them to dictionary
        For Each pointSpringPropName In pointSpringPropNames                                                                'O(n)/Ω(1) +Θ(1)
            ret = Me.etabsModel.PropPointSpring.GetPointSpringProp(pointSpringPropName, springOption, stiffnessArray, cSys,
                                                             soilProfile, footing, period, color, notes, iGuid)             'Θ(1)
            If ret <> 0 OrElse stiffnessArray Is Nothing Then
                Return (False, New CheckError(ErrorSeverity.FATAL,
                        "Impossible to read ETABS Point Spring Property '" & pointSpringPropName & "'."))
            End If
            pointSpringProps.Add(pointSpringPropName, stiffnessArray)                                                       'Θ(1)
        Next

        '3. CHECK STIFFNESS ARRAYS
        ' Variables Declaration
        'Errors Count + Message
        Dim errorsCount As Integer = 0                                                                                      'Θ(1)
        Dim errorMessage As String = "Computed point spring properties contain " +
                                        "NaN Or Infinity Values at following locations: "                                   'Θ(1)
        ' Check errors in each stiffness array
        For Each kvp In pointSpringProps                                                                                    'O(n)/Ω(1) +Θ(1)
            If kvp.Value.ToList().Any(Function(ki) Double.IsNaN(ki) OrElse Double.IsInfinity(ki)) Then                      'Θ(1)
                errorsCount += 1                                                                                            'Θ(1)
                errorMessage &= kvp.Key & ", "                                                                              'Θ(1)
            End If                                                                                                          'Θ(1)
        Next                                                                                                                'Θ(1)

        ' 4. RETURN RESULTS
        If errorsCount > 0 Then                                                                                             'Θ(1)
            '...If errors have been encountered...return false flag and error object...
            Return (False, New CheckError(ErrorSeverity.FATAL, errorMessage.TrimEnd(","c, " "c)))                           'Θ(1)
        Else                                                                                                                'Θ(1)
            '...If no error has been encountered...return true flag and null error object
            Return (True, Nothing)                                                                                          'Θ(1)
        End If                                                                                                              'Θ(1)
    End Function
    ' Time Complexity: T(n) = Θ(n)


    Public Function checkPointReactions(pointNames As List(Of String)) As (success As Boolean, err As CheckError)    'T(n)

        ' 1. EXTRACT REACTIONS FROM INPUT POINTNAMES
        ' Variables Declaration
        Dim ret, numRes As Integer                                                                                          'Θ(1)
        Dim itemTypeElm As ETABSv1.eItemTypeElm                                                                             'Θ(1)
        Dim obj, elm, loadCase, stepType As String()                                                                        'Θ(1)
        Dim stepNum, f1, f2, f3, m1, m2, m3 As Double()                                                                     'Θ(1)
        'Errors Count + Message
        Dim errorsCount As Integer = 0                                                                                      'Θ(1)
        Dim errorMessage As String = "Point reactions contain NaN Or Infinity Values at following locations: "              'Θ(1)
        ' Looping through input pointNames
        For Each pointName In pointNames                                                                                    'Θ(n)+Θ(1)
            ret = Me.etabsModel.Results.JointReact(pointName, itemTypeElm, numRes, obj, elm, loadCase,
                                                   stepType, stepNum, f1, f2, f3, m1, m2, m3)                               'Θ(1)
            If ret <> 0 OrElse numRes = 0 OrElse f1 Is Nothing OrElse f2 Is Nothing OrElse f3 Is Nothing OrElse
               m1 Is Nothing OrElse m2 Is Nothing OrElse m3 Is Nothing Then
                Return (False, New CheckError(ErrorSeverity.FATAL,
                        "Impossible to read ETABS reactions for point '" & pointName & "'."))
            End If

            ' 2. CHECK REACTIONS
            If f1.Concat(f2).Concat(f3).Concat(m1).Concat(m2).Concat(m3).
                Any(Function(r) Double.IsNaN(r) OrElse Double.IsInfinity(r)) Then                                           'Θ(1)
                errorsCount += 1                                                                                            'Θ(1)
                errorMessage &= pointName & ", "                                                                            'Θ(1)
            End If
        Next

        ' 3. RETURN RESULTS
        If errorsCount > 0 Then                                                                                             'Θ(1)
            '...If errors have been encountered...return false flag and error object...
            Return (False, New CheckError(ErrorSeverity.FATAL, errorMessage.TrimEnd(","c, " "c)))                           'Θ(1)
        End If
        '...If no error has been encountered...return true flag and null error object
        Return (True, Nothing)                                                                                              'Θ(1)
    End Function
    ' Time Complexity: T(n) = O(n) / Ω(1)


    Public Function checkPointLinearSpringProperties(pileObjs As List(Of PileObject)) As (success As Boolean, err As CheckError)

        '1. CHECK MATCHING OF STIFFNESS ARRAYS BETWEEN PILEOBJS AND ETABS MODEL POINTSPRINGPROPERTIES                         'T(n)
        ' Variables Declaration
        Dim ret, springOption, color, i As Integer                                                                            'Θ(1)
        Dim stiffnessArray As Double()                                                                                        'Θ(1)
        Dim cSys, soilProfile, footing, notes, iGuid As String                                                                'Θ(1)
        Dim period As Double                                                                                                  'Θ(1)
        Dim match As Boolean                                                                                                  'Θ(1)
        Dim errorsCount As Integer = 0                                                                                        'Θ(1)
        Dim errorMessage As String = "ETABS Point Spring Properties do not match computed values at following locations: "    'Θ(1)
        ' Check pileobjs stiffness arrays against ETABS model spring stiffness arrays
        For Each pileObj In pileObjs                                                                                          'O(n)/Ω(1) +Θ(1)
            ' ETABS point spring property is named after the point (see PSC_Model.updatePointSprings)
            Dim propName As String = pileObj.getLocation().getName()                                                          'Θ(1)
            ret = Me.etabsModel.PropPointSpring.GetPointSpringProp(propName,
                        springOption, stiffnessArray, cSys, soilProfile, footing, period, color, notes, iGuid)                'Θ(1)
            If ret <> 0 OrElse stiffnessArray Is Nothing Then                                                                 'Θ(1)
                Return (False, New CheckError(ErrorSeverity.FATAL,
                        "Impossible to read ETABS Point Spring Property '" & propName & "'."))                                'Θ(1)
            End If                                                                                                            'Θ(1)
            ' Expected array as assigned in ETABS: U1, U2, U3 + zero rotational stiffnesses
            Dim expectedStiffnessArray As Double() = {pileObj.getStiffness().getU1(), pileObj.getStiffness().getU2(),
                                        pileObj.getStiffness().getU3(), 0, 0, 0}                                              'Θ(1)
            ' Reset bool control parameter
            match = True                                                                                                      'Θ(1)
            ' Compare arrays length
            If stiffnessArray.Length <> expectedStiffnessArray.Length Then                                                    'Θ(1)
                match = False                                                                                                 'Θ(1)
            End If                                                                                                            'Θ(1)
            ' Compare arrays values with tolerance of 0.1 N/mm
            For i = 0 To stiffnessArray.Length - 1
                Dim tolerance As Double = 0.1                                                                                 'Θ(1)
                If Math.Abs(expectedStiffnessArray(i) - stiffnessArray(i)) > tolerance Then                                   'Θ(1)
                    match = False                                                                                             'Θ(1)
                End If                                                                                                        'Θ(1)
            Next                                                                                                              'Θ(1)
            If Not match Then                                                                                                 'Θ(1)
                errorsCount += 1                                                                                              'Θ(1)
                errorMessage &= propName & ", "                                                                               'Θ(1)
            End If                                                                                                            'Θ(1)
        Next                                                                                                                  'Θ(1)

        '2. RETURN RESULTS
        If errorsCount > 0 Then                                                                                               'Θ(1)
            Return (False, New CheckError(ErrorSeverity.FATAL, errorMessage.TrimEnd(","c, " "c)))                             'Θ(1)
        End If                                                                                                                'Θ(1)
        '...If no error has been encountered...return true flag and null error object
        Return (True, Nothing)                                                                                                'Θ(1)
    End Function                                                                                                              'Θ(1)
    ' Time Complexity: T(n) = O(n) / Ω(1)

    Public Sub runAllChecks() Implements FEAModelCheckerInterface.runAllChecks
        Throw New NotImplementedException()
    End Sub


End Class
