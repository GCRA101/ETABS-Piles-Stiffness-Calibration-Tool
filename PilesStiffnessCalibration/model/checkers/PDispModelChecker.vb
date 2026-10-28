Imports Newtonsoft.Json.Linq
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

        '1. EXTRACT ALL PDISP LOADS FROM PDISP MODEL (polygonal type is not supported due to bugs in Oasys source code)
        'Set up Pullers for each type of load
        Dim rectLoadsPuller As LoadsPuller(Of PDispRectLoad) = New LoadsPuller(Of PDispRectLoad)(Me.pDispModel)
        Dim circLoadsPuller As LoadsPuller(Of PDispCircLoad) = New LoadsPuller(Of PDispCircLoad)(Me.pDispModel)
        'Extract all pdispLoads depending on type
        Dim pDispRectLoads As List(Of PDispRectLoad) = rectLoadsPuller.pull()
        Dim pDispCircLoads As List(Of PDispCircLoad) = circLoadsPuller.pull()
        'Error lists storing the pdisp loads affected by invalid area load dimensions (width and length)
        Dim errorPDispRectLoads As List(Of PDispRectLoad) = New List(Of PDispRectLoad)()
        Dim errorPDispCircLoads As List(Of PDispCircLoad) = New List(Of PDispCircLoad)()
        'Errors Count + Message
        Dim errorsCount As Integer = 0
        Dim errorMessage As String = "Invalid area load dimensions have been found in the PDisp Model. See Loads "

        '2. CHECK AREA LOAD DIMENSIONS
        'Check area load dimensions for PDispRect Loads
        For i As Integer = 0 To pDispRectLoads.Count - 1
            Dim pDispRectLoad As PDispRectLoad = pDispRectLoads(i)
            Dim w, l As Double
            w = pDispRectLoad.getLoad().Width
            l = pDispRectLoad.getLoad().Length
            If w = 0 Or Double.IsNaN(w) Or Double.IsInfinity(w) Or l = 0 Or Double.IsNaN(l) Or Double.IsInfinity(l) Then
                errorMessage &= pDispRectLoad.getLoad().Name & ", "
                errorsCount += 1
            End If
        Next
        'Check area load dimensions for PDispCirc Loads
        For i As Integer = 0 To pDispCircLoads.Count - 1
            Dim pDispCircLoad As PDispCircLoad = pDispCircLoads(i)
            Dim w, l As Double
            w = pDispCircLoad.getLoad().Width
            If w = 0 Or Double.IsNaN(w) Or Double.IsInfinity(w) Then
                errorMessage &= pDispCircLoad.getLoad().Name & ", "
                errorsCount += 1
            End If
        Next

        '3. RETURN RESULTS
        '...if errors have been encountered, return false bool flag and error object with built error message...
        If errorsCount > 0 Then
            errorMessage = errorMessage.TrimEnd(", ")
            Return (False, New CheckError(errorMessage))
        End If
        '...if no errors have been encountered, return true bool flag and null error object...
        Return (True, Nothing)
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
