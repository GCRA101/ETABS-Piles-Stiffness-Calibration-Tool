''' <summary>
'''     <remarks>
'''         Interface that defines the methods that all the concrete classes of
'''         type FEAModelChecker have to implement.
'''     </remarks>
''' </summary>

Public Interface FEAModelCheckerInterface

    Function checkAnalysisRuns() As Boolean
    Function checkModelOpens() As Boolean
    Function checkModelSaves() As Boolean
    Function checkPointsCount(pointsCount As Integer) As Boolean
    Function checkPointsNames(pointNames As List(Of String)) As Boolean
    Sub runAllChecks()

End Interface
