Imports Newtonsoft.Json.Linq
Imports pdispauto_20_1

''' <summary>
'''     <remarks>
'''         Concrete class implementing the FEAModelCheckerInterface and specialized in
'''         running checks on the PDisp model to make sure that the inputs are correct.
'''         All the methods return as ouput both a success boolean parameter and a CheckError object.
'''         This approach follows the "Fail Fast" principle, which allows to stop the execution of the program as soon as an error is found and is
'''         inspired by the Error Handling strategy used by the Golang programming language.
'''         When an error is found, the ouptut boolean is set to False and the CheckError object is instantiated with error message and severity.
'''         When no error is found, the ouptut boolean is set to True and the CheckError object is set to Nothing.
'''     </remarks>
''' </summary>
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
            Return (False, New CheckError(ErrorSeverity.WARNING, "Impossible to extract the Displacement Grids from the PDisp model."))
        End If

        '2. CHECK THAT CALCULATE OPTION IS NOT ACTIVE AT ANY DISPLACEMENT GRID
        Dim computedDispGridNames As List(Of String) = New List(Of String)()
        For i As Short = 1 To gridsNum
            Dim dispGrid As DisplacementGrid
            ret = Me.pDispModel.getPDispApp().GetDisplacementGrid(i, dispGrid)
            If ret <> 0 Then
                Return (False, New CheckError(ErrorSeverity.WARNING, "Impossible to extract Displacement Grid " & i & " from the PDisp model."))
            End If
            If dispGrid.Calculate Then
                computedDispGridNames.Add(dispGrid.Name)
            End If
        Next

        '3. RETURN ERROR MESSAGE IF ANY DISPLACEMENT GRID IS SET TO BE CALCULATED
        If computedDispGridNames.Count > 0 Then
            Dim errorMessage As String
            errorMessage = "Displacement Grid(s) '" & String.Join(", ", computedDispGridNames) & "' in the PDisp model have the Calculate option ticked."
            Return (False, New CheckError(ErrorSeverity.WARNING, errorMessage))
        End If

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
            If w = 0 OrElse Double.IsNaN(w) OrElse Double.IsInfinity(w) OrElse
               l = 0 OrElse Double.IsNaN(l) OrElse Double.IsInfinity(l) Then
                errorMessage &= pDispRectLoad.getLoad().Name & ", "
                errorsCount += 1
            End If
        Next
        'Check area load dimensions for PDispCirc Loads
        For i As Integer = 0 To pDispCircLoads.Count - 1
            Dim pDispCircLoad As PDispCircLoad = pDispCircLoads(i)
            Dim w As Double
            w = pDispCircLoad.getLoad().Width
            If w = 0 OrElse Double.IsNaN(w) OrElse Double.IsInfinity(w) Then
                errorMessage &= pDispCircLoad.getLoad().Name & ", "
                errorsCount += 1
            End If
        Next

        '3. RETURN RESULTS
        '...if errors have been encountered, return false bool flag and error object with built error message...
        If errorsCount > 0 Then
            errorMessage = errorMessage.TrimEnd(", ")
            Return (False, New CheckError(ErrorSeverity.FATAL, errorMessage))
        End If
        '...if no errors have been encountered, return true bool flag and null error object...
        Return (True, Nothing)
    End Function

    Public Function checkLoadTypes() As (success As Boolean, err As CheckError)
        '1. Get number of results for the 3 different load types (Rect, Circ, Poly)
        Dim ret01, ret02, ret03, numRectLoads, numCircLoads, numPolyLoads As Short
        ret01 = Me.pDispModel.getPDispApp().NumRectLoads(numRectLoads)
        ret02 = Me.pDispModel.getPDispApp().NumCircLoads(numCircLoads)
        ret03 = Me.pDispModel.getPDispApp().NumPolyLoads(numPolyLoads)
        '2. Check that extraction of number of results was successful, otherwise return False + Error Object
        If ret01 <> 0 OrElse ret02 <> 0 OrElse ret03 <> 0 Then
            Return (False, New CheckError(ErrorSeverity.WARNING, "Impossible to extract the number of loads from the PDisp model."))
        End If
        '3. Check for unsupported load types (polyloads)
        If numPolyLoads > 0 Then
            Return (False, New CheckError(ErrorSeverity.FATAL, "The PDisp Model contains Polygonal Loads, which are not supported."))
        End If

        '...if no errors have been encountered, return true bool flag and null error object...
        Return (True, Nothing)
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
