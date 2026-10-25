''' <summary>
'''     <remarks>
'''         Interface that defines the methods that all the concrete classes of
'''         type FEAModelChecker have to implement.
'''     </remarks>
''' </summary>
Public Interface FEAModelCheckerInterface

    Function checkAnalysisRuns() As (success As Boolean, Error As CheckError)
    Function checkModelOpens() As (success As Boolean, Error As CheckError)
    Function checkModelSaves() As (success As Boolean, Error As CheckError)
    Function checkPointsCount(selEtabsGroupName As String, pointsCount As Integer) As (success As Boolean, Error As CheckError)
    Function checkPointsNames(selEtabsGroupName As String, pointNames As List(Of String)) As (success As Boolean, Error As CheckError)
    Sub runAllChecks()

End Interface
