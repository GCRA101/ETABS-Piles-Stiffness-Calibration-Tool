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

    Public Function checkAnalysisRuns() As Boolean Implements FEAModelCheckerInterface.checkAnalysisRuns
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadPatterns() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadCases() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadCombos() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Function checkModelOpens() As Boolean Implements FEAModelCheckerInterface.checkModelOpens
        Throw New NotImplementedException()
    End Function

    Public Function checkModelSaves() As Boolean Implements FEAModelCheckerInterface.checkModelSaves
        Throw New NotImplementedException()
    End Function

    Public Function checkPointsCount(pointsCount As Integer) As Boolean Implements FEAModelCheckerInterface.checkPointsCount
        Throw New NotImplementedException()
    End Function

    Public Function checkPointsNames(pointNames As List(Of String)) As Boolean Implements FEAModelCheckerInterface.checkPointsNames
        Throw New NotImplementedException()
    End Function

    Public Function checkPointSpringProperties() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Sub runAllChecks() Implements FEAModelCheckerInterface.runAllChecks
        Throw New NotImplementedException()
    End Sub


End Class
