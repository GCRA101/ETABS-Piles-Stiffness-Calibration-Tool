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

    Public Function checkAnalysisRuns() As (success As Boolean, err As CheckError))) Implements FEAModelCheckerInterface.checkAnalysisRuns
        Throw New NotImplementedException()
    End Function

    Public Function checkDisplacementValues() As (success As Boolean, err As CheckError)))
        Throw New NotImplementedException()
    End Function

    Public Function checkGridsCalculation() As (success As Boolean, err As CheckError)))
        Throw New NotImplementedException()
    End Function

    Public Function checkAreaValues() As (success As Boolean, err As CheckError)))
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadTypes() As (success As Boolean, err As CheckError)))
        Throw New NotImplementedException()
    End Function

    Public Function checkLoadValues() As (success As Boolean, err As CheckError)))
        Throw New NotImplementedException()
    End Function

    Public Function checkModelOpens() As (success As Boolean, err As CheckError))) Implements FEAModelCheckerInterface.checkModelOpens
        Throw New NotImplementedException()
    End Function

    Public Function checkModelSaves() As (success As Boolean, err As CheckError))) Implements FEAModelCheckerInterface.checkModelSaves
        Throw New NotImplementedException()
    End Function

    Public Function checkPointsCount(pointsCount As Integer) As (success As Boolean, err As CheckError))) Implements FEAModelCheckerInterface.checkPointsCount
        Throw New NotImplementedException()
    End Function

    Public Function checkPointsNames(pointNames As List(Of String)) As (success As Boolean, err As CheckError))) Implements FEAModelCheckerInterface.checkPointsNames
        Throw New NotImplementedException()
    End Function

    Public Sub runAllChecks() Implements FEAModelCheckerInterface.runAllChecks
        Throw New NotImplementedException()
    End Sub


End Class
