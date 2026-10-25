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

    Public Function checkAnalysisRuns() As Boolean Implements FEAModelCheckerInterface.checkAnalysisRuns
        Throw New NotImplementedException()
    End Function

    Public Function checkDisplacementValues() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Function checkGridsCalculation() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Function checkAreaValues() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadTypes() As Boolean
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadValues() As Boolean
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

    Public Sub runAllChecks() Implements FEAModelCheckerInterface.runAllChecks
        Throw New NotImplementedException()
    End Sub


End Class
