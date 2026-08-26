
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Net.WebRequestMethods
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports ETABSv1
Imports Microsoft.Office.Core
Imports Newtonsoft.Json
Imports pdispauto_20_1

''' <summary>
''' 
''' PSC_Model Concrete Class
''' 
''' <remarks>
''' <para> Concrete class and main class of the Model Package. </para>
''' <para> The class contains all the main data and methods for the running of the application.
''' The model is updated based on the actions of the user in the View via the MVC Design Pattern while the View
''' is updated based on the changes of the Model via the OBSERVER Design Pattern. </para>
''' 
''' <para> Desing Patterns: 
''' - OBSERVER
''' - MODEL-VIEW-CONTROLLER
''' - SINGLETON </para>
''' 
''' <para> Programming Techniques: 
''' - STREAMS </para>
''' 
''' </remarks>
''' 
''' </summary>

Public Class PSC_Model
    Implements Observable

    'ATTRIBUTES
    Private Shared instance As PSC_Model
    Private observers As List(Of Observer)
    Private jsonSerializer As JSONSerializer(Of List(Of PileObject))
    Private sapModel As ETABSv1.cSapModel
    Private pDispModel As PDispModel
    Private sapModelInitialPath As String
    Private pDispInitialPath As String
    Private resultsFolderPath As String
    Private sapModelsFolderPath As String
    Private pDispModelsFolderPath As String
    Private jsonFilesFolderPath As String
    Private etabsGroupNames As List(Of String)      'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private etabsLoadCaseNames As List(Of String)   'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private etabsLoadComboNames As List(Of String)  'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private etabsPointNames As List(Of String)      'TO BE REPLACED WITH ETABS WRAPPING CLASSES !!!
    Private selEtabsGroupName As String
    Private selEtabsLoadComboName As String
    Private selNonLinearOption As String
    Private overridePDispLoads As Boolean
    Private iterNumMax As Integer
    Private convergenceCriterion As String
    Private convergenceFactor As Double
    Private percentile As Double
    Private pileObjs As List(Of PileObject)
    Private pileObjsInit As List(Of PileObject)
    Private pileObjsQueue As Queue(Of List(Of PileObject))
    Private convergingPiles As List(Of PileObject)
    Private nonConvergingPiles As List(Of PileObject)
    Private rectLoadsPuller As LoadsPuller(Of PDispRectLoad)
    Private circLoadsPuller As LoadsPuller(Of PDispCircLoad)
    Private polyLoadsPuller As LoadsPuller(Of PDispPolyLoad)
    Private rectloadsPusher As LoadsPusher(Of PDispRectLoad)
    Private circloadsPusher As LoadsPusher(Of PDispCircLoad)
    Private polyloadsPusher As LoadsPusher(Of PDispPolyLoad)
    Private pDispRectLoadsV0 As List(Of PDispRectLoad)
    Private pDispCircLoadsV0 As List(Of PDispCircLoad)
    Private ret As Integer
    Private iterNum As Integer = 0
    Private stepRun As Boolean = False
    Private iterationStarted As Boolean = False
    Private iterationComplete As Boolean = False
    Private Const ΔMax As Double = 10
    Private Const kmin As Double = 1
    Private Const fixity As Double = 100000000
    Private Const nonConvergingGroupName = "PSCT - NON CONVERGING"

    Private Const MODEL_NAME = "Piles Stiffness Calibration Tool"
    Private Const MODEL_VERSION = "Version: " + "2.0.0"
    Private Const MODEL_COPYRIGHT = "Copyright @ Buro Happold Ltd Inc.2024"
    Private Const MODEL_AUTHOR = "Giorgio Carlo Roberto Albieri"
    Private Const MODEL_OWNER = "Buro Happold Ltd"


    ' CONSTRUCTOR - Private'
    Private Sub New()
        Me.observers = New List(Of Observer)
        Me.jsonSerializer = New JSONSerializer(Of List(Of PileObject))
        Me.pileObjsQueue = New Queue(Of List(Of PileObject))
    End Sub

    ' STATIC METHOD .getInstance() '
    Public Shared Function getInstance() As PSC_Model
        If (instance Is Nothing) Then
            instance = New PSC_Model()
        End If
        Return instance
    End Function

    ' METHDOS
    Public Sub registerObserver(o As Observer) Implements Observable.registerObserver
        'Add a new observer
        Me.observers.Add(o)
    End Sub
    Public Sub removeObserver(o As Observer) Implements Observable.removeObserver
        'Remove and observer
        Me.observers.Remove(o)
    End Sub
    Public Sub notifyObservers() Implements Observable.notifyObservers
        'Update all observers via Streams
        Me.observers.ForEach(Sub(o) o.update())
    End Sub


    Public Sub initialize(sapModel As ETABSv1.cSapModel, pDispFilePath As String, selEtabsLoadComboName As String,
                          selEtabsGroupName As String, selNonLinearOption As String, overridePDispLoads As Boolean,
                          iterNumMax As Integer, convergenceCriterion As String, convergenceFactor As Double, percentile As Double)
        'Check validity of inputs
        Me.checkInputsData(sapModel, pDispFilePath, selEtabsLoadComboName, selEtabsGroupName, iterNumMax, convergenceFactor)
        'Assign Model attributes
        Me.sapModel = sapModel
        Me.pDispModel = New PDispModel(pDispFilePath)
        Me.selEtabsLoadComboName = selEtabsLoadComboName
        Me.selEtabsGroupName = selEtabsGroupName
        Me.selNonLinearOption = selNonLinearOption
        Me.overridePDispLoads = overridePDispLoads
        Me.iterNumMax = iterNumMax
        Me.convergenceCriterion = convergenceCriterion
        Me.convergenceFactor = convergenceFactor
        Me.percentile = percentile
        Me.sapModelInitialPath = Me.sapModel.GetModelFilename(True)
        Me.pDispInitialPath = pDispFilePath
        'Create PDisp Push/Pull Utility Classes
        Me.rectLoadsPuller = New LoadsPuller(Of PDispRectLoad)(pDispModel)
        Me.circLoadsPuller = New LoadsPuller(Of PDispCircLoad)(pDispModel)
        Me.polyLoadsPuller = New LoadsPuller(Of PDispPolyLoad)(pDispModel)
        Me.rectloadsPusher = New LoadsPusher(Of PDispRectLoad)(pDispModel)
        Me.circloadsPusher = New LoadsPusher(Of PDispCircLoad)(pDispModel)
        Me.polyloadsPusher = New LoadsPusher(Of PDispPolyLoad)(pDispModel)
        'Create Output Directories
        Me.resultsFolderPath = FileManager.setDatedFolderPath(Path.GetDirectoryName(Me.sapModelInitialPath), "PSCT_Results")
        Me.sapModelsFolderPath = Me.resultsFolderPath + "\ETABS_Models"
        Me.pDispModelsFolderPath = Me.resultsFolderPath + "\PDISP_Models"
        Me.jsonFilesFolderPath = Me.resultsFolderPath + "\JSON_Files"
        Directory.CreateDirectory(Me.sapModelsFolderPath)
        Directory.CreateDirectory(Me.pDispModelsFolderPath)
        Directory.CreateDirectory(Me.jsonFilesFolderPath)

    End Sub

    Private Sub checkInputsData(sapModel As ETABSv1.cSapModel, pDispFilePath As String, selEtabsLoadComboName As String,
                                selEtabsGroupName As String, iterNumMax As Integer, convergenceFactor As Double)

        ' BUILD EXCEPTION MESSAGE
        Dim exceptionMessage As String = ""
        ' ETABS Model
        If (sapModel Is Nothing) Then exceptionMessage += "ETABS Model is missing/not valid." + vbNewLine
        ' PDisp Model
        If pDispFilePath Is Nothing Then
            exceptionMessage += "PDisp Model is missing." + vbNewLine
        ElseIf Not pDispFilePath.Contains(".pdd") Then
            exceptionMessage += "PDisp Model is not valid." + vbNewLine
        End If
        ' ETABS Group Name
        If (selEtabsGroupName = "") Then exceptionMessage += "ETABS Group Name missing." + vbNewLine
        ' ETABS Load Combo Name
        If (selEtabsLoadComboName = "") Then exceptionMessage += "ETABS Load Combo Name missing." + vbNewLine
        ' Max Number of Iterations
        If (iterNumMax < 2) Then exceptionMessage += "Maximum Number of Iterations is too low." + vbNewLine
        ' Convergence Factor
        If (convergenceFactor < 0) Then exceptionMessage += "Convergence Factor is not valid."

        ' THROW EXCEPTION MESSAGE
        If exceptionMessage <> "" Then Throw New MissingInputsException(exceptionMessage)
    End Sub

    Public Sub setSapModel(sapModel As ETABSv1.cSapModel)
        'Throw exception if SapModel is not valid/existing
        If (sapModel Is Nothing) Then Throw New MissingInputsException("ETABS Model is missing/not valid")
        Me.sapModel = sapModel
    End Sub
    Public Sub setPDispModel(pdispModel As PDispModel)
        'Throw exception if PDispModel is not valid/existing
        If (pdispModel Is Nothing) Then Throw New MissingInputsException("PDisp Model is missing/not valid")
        Me.pDispModel = pdispModel
    End Sub

    Public Sub extractEtabsModelData()

        Dim errorMessage As String = ""

        '1. Extract Etabs Model's GROUP NAMES
        Dim groupNumNames As Integer, groupNames As String()
        Me.sapModel.GroupDef.GetNameList(groupNumNames, groupNames)
        If (groupNumNames = 0) Then errorMessage += "No Groups are defined in the ETABS Model." & vbNewLine
        '2. Extract Etabs Model's LOAD CASES
        Dim loadCasesNum As Integer, loadCasesNames As String()
        Me.sapModel.LoadCases.GetNameList(loadCasesNum, loadCasesNames)
        If (loadCasesNum = 0) Then errorMessage += "No Load Cases are defined in the ETABS Model." & vbNewLine
        '3. Extract Etabs Model's LOAD COMBO NAMES
        Dim lCombosNum As Integer, lComboNames As String()
        Me.sapModel.RespCombo.GetNameList(lCombosNum, lComboNames)
        If (lCombosNum = 0) Then errorMessage += "No Load Combos are defined in the ETABS Model." & vbNewLine
        '4. Extract Etabs Model's POINT NAMES
        Dim pointNumNames As Integer, pointNames As String()
        Me.sapModel.PointObj.GetNameList(pointNumNames, pointNames)
        If (pointNumNames = 0) Then errorMessage += "No Point Objects are defined in the ETABS Model."

        '5. Check Encountered Errors and if any, throw MissingInputsException
        If (errorMessage <> "") Then Throw New MissingInputsException(errorMessage)

        '6. Assign the extracted data to the Model's attributes
        Me.etabsGroupNames = groupNames.ToList()
        Me.etabsLoadCaseNames = loadCasesNames.ToList()
        Me.etabsLoadComboNames = lComboNames.ToList()
        Me.etabsPointNames = pointNames.ToList()

        '7. Notify Observers
        Me.notifyObservers()
    End Sub


    Public Sub filterPointsByGroup()
        Me.etabsPointNames = Me.etabsPointNames.Where(Function(ppName)
                                                          Dim groupNamesNum As Integer, groupNames As String()
                                                          sapModel.PointObj.GetGroupAssign(ppName, groupNamesNum, groupNames)
                                                          Return groupNames.Contains(Me.selEtabsGroupName)
                                                      End Function).ToList()
    End Sub

    Public Sub setPointRestraints(restraintBools As Boolean())
        'Throw exception if piles restraints are missing
        If restraintBools Is Nothing Then Throw New MissingInputsException("Piles Restraint Boolean Arrays missing")
        'Unlock Etabs Model
        Me.sapModel.SetModelIsLocked(False)
        'Set Point Restraints via Streams...
        Me.etabsPointNames.ForEach(Function(ppName)
                                       Me.sapModel.PointObj.SetRestraint(ppName, restraintBools)
                                   End Function)
    End Sub

    Public Sub setPointStiffnessesFromValues(stiffnessValues As Double())
        'Throw exception if piles stiffnesses are missing
        If stiffnessValues Is Nothing Then Throw New MissingInputsException("Piles Stiffness Value missing")
        'Unlock Etabs Model
        Me.sapModel.SetModelIsLocked(False)
        'Set Point Springs via Streams...
        Me.etabsPointNames.ForEach(Function(ppName)
                                       Me.sapModel.PointObj.SetSpring(ppName, stiffnessValues)
                                   End Function)
    End Sub

    Public Sub setPointStiffnessesFromJson(jsonFilePath As String)

        If jsonFilePath = "" Then Throw New MissingInputsException("FilePath to Piles Stiffness JsonFile missing")

        'Unlock Etabs Model
        Me.sapModel.SetModelIsLocked(False)
        'Deserialize Json File
        Dim startPileObjsList As New List(Of PileObject)
        startPileObjsList = Me.deserialize(jsonFilePath)
        'Set Point Springs via Streams...
        Me.etabsPointNames.ToList().ForEach(Function(ppName)
                                                Dim Kvalues As Double() = startPileObjsList.Where(Function(plObj) (plObj.getName() = ppName)).
                                                                             Single().getStiffness().getValues()
                                                Me.sapModel.PointObj.SetSpring(ppName, Kvalues)
                                            End Function)
    End Sub


    Public Sub runIteration()

        'Turn on iteration control parameter
        Me.iterationStarted = True
        'Notify all Observers - OBSERVER PATTERN
        Me.notifyObservers()

        'MAIN ROUTINE
        Do
            'Save ETABS Model
            sapModel.File.Save(FileManager.setNewFilePath(Me.sapModelInitialPath, Me.sapModelsFolderPath, Me.iterNum))
            'Run Iteration Step
            stepRun = False
            runIterationStep(Me.iterNum)
            stepRun = True
            'Save PDisp Model
            pDispModel.save(FileManager.setNewFilePath(Me.pDispInitialPath, Me.pDispModelsFolderPath, Me.iterNum))
            'Serialize DataSet
            Me.serialize(Me.pileObjs)
            'Notify Observers
            Me.notifyObservers()
            'Increment iter count
            Me.iterNum += 1
            'Loop until iteration number gets equal to max or results reach convergence
        Loop While Me.iterNum < iterNumMax And isConvergent(pileObjsQueue) = False

    End Sub

    Public Sub generateExcelReport()

        'SUMMARY EXCEL SPREADSHEET CREATION

        'ExcelDataManager object initialization
        Dim excelDataManager As ExcelDataManager = Nothing
        'Excel Spreadsheet Creation and Charts Generation
        Try
            'EXCEL OUTPUTS
            'Initialize ExcelDataManager
            excelDataManager = New ExcelDataManager() '(Me.resultsFolderPath + "\Outputs.xlsx")
            excelDataManager.initialize()
            'Retrieve data from output json files
            Dim jsonFilePaths As String() = IO.Directory.GetFiles(Me.jsonFilesFolderPath)
            jsonFilePaths.ToList().Sort()
            jsonFilePaths.ToList().ToDictionary(Function(filePath) filePath.Substring(filePath.IndexOf("Iteration")).Replace(".json", ""),
                                                Function(filePath) jsonSerializer.deserialize(filePath)).ToList().
                                   ForEach(Sub(kvpair) excelDataManager.write("Piles Stiffness Calibration", kvpair.Value, kvpair.Key))
            'Create Charts in Excel SpreadSheet
            excelDataManager.createChart()
            'Destroy the Excel Data Manager object
            excelDataManager.dispose()

        Catch ex As Exception
            'Any unexpected error during the creation of the outputs report in excel...

            'Destroy the Excel Data Manager object
            If excelDataManager IsNot Nothing Then
                excelDataManager.dispose()
            End If
            'Build Warning Message for the user
            Dim warningMessage As String
            warningMessage = "Impossible to generate the Summary Excel Spreadsheet." + vbNewLine + "Try Running a Quick Repair of Microsoft Office."
            'Throw Custom Exception
            Throw New ExcelComInteropException(warningMessage, ex.Message)

        Finally

            'Turn On control parameter iterationComplete
            Me.iterationComplete = True
            'Notify all the Observers - OBSERVER PATTERN
            Me.notifyObservers()
            'Close the PDisp Model
            Me.pDispModel.close()

        End Try

    End Sub


    Public Sub runIterationStep(iter As Integer) 'T(n)

        Try
            'UNLOCK THE ETABS MODEL
            sapModel.SetModelIsLocked(False)

            'INITIALIZE PILES SPRINGS
            If iter = 0 Then
                initializeEtabsPointSprings()
                initializePDispLoads()
            End If

            'ACTIVATE ALL LOAD CASES FOR RUNNING THE ANALYSIS
            ret = sapModel.Analyze.SetRunCaseFlag(Me.etabsLoadCaseNames(0), True, All:=True)

            'RUN THE ANALYSIS
            ret = sapModel.Analyze.RunAnalysis()   'θ(n)

            'ACTIVATE ONLY LOAD COMBO SELECTED BY THE USER
            sapModel.Results.Setup.DeselectAllCasesAndCombosForOutput()
            sapModel.Results.Setup.SetComboSelectedForOutput(Me.selEtabsLoadComboName)

            '1. Initialize/Reset List of PileObject Records for current iteration step
            Me.pileObjs = New List(Of PileObject)
            '2. Read Point Reactions from ETABS and assign them to PileObjects
            readPileObjsForces(Me.pileObjs)
            '3. Update PDisp Loads based on ETABS reactions
            updatePDispLoads(Me.pileObjs, Me.overridePDispLoads)
            '4. Perform Analysis
            pDispModel.analyse()
            '5. Save pDispModel
            'pDispModel.save(FileManager.setNewFilePath(Me.pDispInitialPath, Me.pDispModelsFolderPath, Me.iterNum))
            '5. Read Point Displacements from PDisp and assign them to PileObjects
            readPileObjsDisplacements(Me.pileObjs)
            '6 Update the Piles Status based on the 
            updatePileObjsStatus(Me.pileObjs, Me.pileObjsInit)
            '7. Compute Point Stiffnesses and assign them to PileObjects
            computePileObjsStiffness(Me.pileObjs)
            '8. Add current list of PileObjects to Queue data structure
            pileObjsQueue.Enqueue(Me.pileObjs)
            '9. Update Etabs Point Springs
            updatePointSprings(Me.pileObjs)

        Catch ex As System.Runtime.InteropServices.COMException
            ' COM interop failure (e.g. ETABS/PDisp API error)
            System.Diagnostics.Debug.WriteLine(
                $"runIterationStep failed (COM, HRESULT=0x{ex.HResult:X8}) at iteration {iter}: {ex.Message}")
            Throw
        Catch ex As Exception
            ' Any other unexpected error during the iteration step
            System.Diagnostics.Debug.WriteLine(
                $"runIterationStep failed at iteration {iter}: {ex.Message}")
            Throw
        End Try

    End Sub


    Public Function isConvergent(pileObjsQueue As Queue(Of List(Of PileObject))) As Boolean

        If pileObjsQueue.Count > 1 Then

            '1. INITIALIZE AUXILIARY LIST
            Dim plΔIList As List(Of Double) = New List(Of Double)

            '2. SORT THE FIRST/LAST LISTS OF THE QUEUE BASED ON THE ADDIGNED COMPARATOR
            pileObjsQueue.First().Sort()
            pileObjsQueue.Last().Sort()

            '3. CALCULATE THE RATE INCREASE/DECREASE OF LOAD/STIFFNESS/DISPLACEMENT FOR EACH PILE
            Dim firstIteration As List(Of PileObject) = pileObjsQueue.First()
            Dim lastIteration As List(Of PileObject) = pileObjsQueue.Last()

            For Each plObj As PileObject In lastIteration

                ' Search index in first iteration
                Dim i As Integer = firstIteration.BinarySearch(plObj)

                Dim iprev As Double
                Dim inext As Double

                Select Case Me.convergenceCriterion
                    Case "Reaction"
                        iprev = firstIteration(i).getLoads.getF3()
                        inext = plObj.getLoads.getF3()

                    Case "Displacement"
                        iprev = firstIteration(i).getDisplacements.getU3()
                        inext = plObj.getDisplacements.getU3()

                    Case "Stiffness"
                        iprev = firstIteration(i).getStiffness().getU3()
                        inext = plObj.getStiffness().getU3()
                End Select

                Dim ΔI As Double = Math.Abs(Math.Abs(inext - iprev) / iprev)
                plΔIList.Add(ΔI)

            Next

            '4. DEQUEUE FIRST/PREVIOUS LIST OF THE QUEUE
            pileObjsQueue.Dequeue()

            '5. CHECK THAT MAX DELTA IS LOWER THAN MAX ALLOWED
            ' If it's bigger...stop the iteration and raise an exception with error message for the user.
            'If (plΔIList.Max() > ΔMax) Then
            '    Dim message As String = "Pile Stiffness Variation from previous iteration looks excessive."
            '    Dim errorPilesList As List(Of PileObject)
            '    errorPilesList = plΔIList.Select(Function(dk)
            '                                         If dk >= ΔMax Then
            '                                             Return plΔIList.IndexOf(dk)
            '                                         Else
            '                                             Return -1
            '                                         End If
            '                                     End Function).
            '                               Where(Function(index) index <> -1).
            '                               Select(Function(index) pileObjsQueue.First().Item(index)).
            '                               ToList()

            '    Throw New ExcessiveΔException(message, errorPilesList)
            'End If

            '6. COLLECT/IDENTIFY CONVERGING PILES
            ' Collect only piles which corresponding delta is smaller than the input convergenceFactor.
            ' These piles are the ones for which convergence is achieved.
            Me.convergingPiles = New List(Of PileObject)
            Me.nonConvergingPiles = New List(Of PileObject)
            For i As Integer = 0 To plΔIList.Count - 1
                If plΔIList(i) < convergenceFactor Then
                    Me.convergingPiles.Add(lastIteration(i))
                Else
                    Me.nonConvergingPiles.Add(lastIteration(i))
                End If
            Next

            '7. MARK NON CONVERGING PILES IN THE ETABS MODEL
            ' Group all piles that are not converging at this iteration within a corresponding ETABS Group
            markNonConvergingPiles(Me.nonConvergingPiles.Select(Function(pile) pile.getName()).ToList())
            ' Save the ETABS Model in order not to loose the created groups
            Me.sapModel.File.Save()

            '8. RETURN BOOL
            ' Notify the Observers + Return True if the number of deltas smaller than the convergenceFactor
            ' is either equal or bigger than the percentile input by the user (default = 90%)
            If (Me.convergingPiles.Count / plΔIList.Count >= percentile) Then
                Me.notifyObservers()
                Return True
            End If

        End If

        ' False if not...
        Return False

    End Function


    Private Sub readPileObjsForces(pileObjs As List(Of PileObject))

        'EXTRACT BASE POINT REACTIONS

        Dim itemTypeElm As ETABSv1.eItemTypeElm
        Dim numRes As Integer
        Dim obj, elm, loadCase, stepType As String()
        Dim stepNum As Double()
        Dim f1, f2, f3, m1, m2, m3 As Double()
        Dim f_1, f_2, f_3, m_1, m_2, m_3 As Double
        Dim ppX, ppY, ppZ As Double

        For i = 0 To etabsPointNames.Count - 1 Step 1
            'Get reactions and coordinates from etabs points
            ret = sapModel.Results.JointReact(etabsPointNames(i), itemTypeElm, numRes, obj, elm, loadCase,
                                             stepType, stepNum, f1, f2, f3, m1, m2, m3)
            ret = sapModel.PointObj.GetCoordCartesian(etabsPointNames(i), ppX, ppY, ppZ)
            'Format reactions
            f_1 = f1.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()
            f_2 = f2.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()
            f_3 = f3.Select(Of Double)(Function(force) (Math.Round(force, 0))).First()
            'Assign reactions and coordinates to PileObjects
            pileObjs.Add(New PileObject(etabsPointNames(i), New PointObject(etabsPointNames(i), ppX, ppY, ppZ),,
                         New PointLoads(New Double() {f_1, f_2, f_3})))
        Next

    End Sub


    Private Sub readPileObjsDisplacements(pileObjs As List(Of PileObject))

        'GET PDISP DISPLACEMENTS and COMPUTE SPRING STIFFNESSES

        'Get Disp Point Boussinesq/Mindlin Result
        Dim pMethod As PDispAnalysisMethod
        pDispModel.getPDispApp().AnalysisMethod(pMethod)

        Select Case pMethod
            Case PDispAnalysisMethod.MINDLIN
                Dim MLDispPoints As List(Of PDispMLDispResult) = New ResultsPuller(Of PDispMLDispResult)(pDispModel).pull()
                Dim mldpNames As List(Of String) = MLDispPoints.Select(Function(mldp) (mldp.getResult().Name)).ToList()
                pileObjs.ForEach(Function(plObj)
                                     If (mldpNames.Contains(plObj.getLocation().getName())) Then
                                         Dim nameIndex As Integer = mldpNames.IndexOf(plObj.getLocation().getName())
                                         plObj.setDisplacements(New PointDisplacements(New Double() {
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispX) * 1000, 1),
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispY) * 1000, 1),
                                            Math.Round(CDbl(MLDispPoints(nameIndex).getResult().DispZ) * 1000, 1)}))
                                     End If
                                 End Function)
            Case PDispAnalysisMethod.BOUSSINESQ
                Dim BSQDispPoints As List(Of PDispBSQDispResult) = New ResultsPuller(Of PDispBSQDispResult)(pDispModel).pull()
                Dim bsqdpNames As List(Of String) = BSQDispPoints.Select(Function(bsqdp) (bsqdp.getResult().Name)).ToList()
                pileObjs.ForEach(Function(plObj)
                                     If (bsqdpNames.Contains(plObj.getLocation().getName())) Then
                                         Dim nameIndex As Integer = bsqdpNames.IndexOf(plObj.getLocation().getName())
                                         plObj.setDisplacements(New PointDisplacements(New Double() {0, 0,
                                            Math.Round(CDbl(BSQDispPoints(nameIndex).getResult().DispZ) * 1000, 1)}))
                                     End If
                                 End Function)
        End Select

        'Count the number of PileObjs that have been assigned with Null PDispDisplacements
        Dim numMissingPiles As Double = Me.pileObjs.Sum(Function(po)
                                                            If po.getDisplacements Is Nothing Then
                                                                Return 1.0
                                                            End If
                                                        End Function)

        'Remove all pileObjs with Null Displacements as they are not present in the PDispModel
        Me.pileObjs = Me.pileObjs.Where(Function(po) po.getDisplacements() IsNot Nothing).ToList()

    End Sub


    Private Sub updatePileObjsStatus(pileObjs As List(Of PileObject), Optional initPileObjs As List(Of PileObject) = Nothing)

        If initPileObjs IsNot Nothing Then

            pileObjs.Sort()
            initPileObjs.Sort()

            pileObjs.ForEach(Sub(po)
                                 If initPileObjs.BinarySearch(po) <> -1 And
                                    po.getDisplacements.getU3() < initPileObjs(initPileObjs.BinarySearch(po)).getDisplacements.getU3() Then
                                     po.setStatus(PileStatus.UNLOADED)
                                 Else
                                     po.setStatus(PileStatus.LOADED)
                                 End If
                             End Sub)
        Else
            pileObjs.ForEach(Sub(po) po.setStatus(PileStatus.LOADED))
        End If
    End Sub

    Private Sub computePileObjsStiffness(pileObjs As List(Of PileObject))

        'COMPUTE SPRING STIFFNESSES

        pileObjs.ForEach(Function(plObj)
                             Dim springName = "Spring_" + plObj.getLocation().getName()
                             Dim zStiffness As Double
                             If plObj.getStatus = PileStatus.LOADED Then
                                 zStiffness = Math.Round(CDbl(plObj.getLoads().getF3()) /
                                                         CDbl(plObj.getDisplacements().getU3()), 1)
                             Else
                                 zStiffness = fixity
                             End If
                             Dim stiffnessValues() As Double = {0, 0, zStiffness}
                             plObj.setStiffness(New SpringObject(springName, stiffnessValues))
                         End Function)
    End Sub


    Private Sub updatePDispLoads(pileObjs As List(Of PileObject), Optional override As Boolean = True)

        'UPDATE PDISP LOADS

        'Extract all pdispLoads depending on type
        Dim pDispRectLoads As List(Of PDispRectLoad) = Me.rectLoadsPuller.pull()
        Dim pDispCircLoads As List(Of PDispCircLoad) = Me.circLoadsPuller.pull()
        'Dim pDispPolyLoads As List(Of PDispPolyLoad) = polyLoadsPuller.pull()

        'Update RectLoads based on new loads from ETABS
        pDispRectLoads.ForEach(Function(pDispRectLoad)
                                   Dim ppLoad As Double
                                   ppLoad = pileObjs.Where(Function(plObj) plObj.getLocation().getName() = pDispRectLoad.getLoad().Name).
                                                                 Select(Function(plObj) plObj.getLoads().getF3()).
                                                                 FirstOrDefault()
                                   ppLoad = ppLoad / (pDispRectLoad.getLoad().Width * pDispRectLoad.getLoad().Length)
                                   Dim rectLoad As RectLoad
                                   rectLoad = pDispRectLoad.getLoad()
                                   If (Not override) Then
                                       Dim index As Integer
                                       index = Me.pDispRectLoadsV0.Select(Function(pdrl) pdrl.getLoad().Name).ToList().
                                                                   BinarySearch(pDispRectLoad.getLoad().Name)
                                       rectLoad.Normal = ppLoad + Me.pDispRectLoadsV0(index).getLoad().Normal
                                   Else
                                       rectLoad.Normal = ppLoad
                                   End If
                                   pDispRectLoad.setLoad(rectLoad)
                               End Function)
        'Update CircLoads based on new loads from ETABS
        pDispCircLoads.ForEach(Function(pDispCircLoad)
                                   Dim ppLoad As Double
                                   ppLoad = pileObjs.Where(Function(plObj) plObj.getLocation().getName() = pDispCircLoad.getLoad().Name).
                                                                 Select(Function(plObj) plObj.getLoads().getF3()).
                                                                 FirstOrDefault()
                                   ppLoad = ppLoad / (Math.PI * (Math.Pow(pDispCircLoad.getLoad().Width, 2) / 4))
                                   Dim circLoad As CircLoad
                                   circLoad = pDispCircLoad.getLoad()
                                   If (Not override) Then
                                       Dim index As Integer
                                       index = Me.pDispCircLoadsV0.Select(Function(pdrl) pdrl.getLoad().Name).ToList().
                                                                   BinarySearch(pDispCircLoad.getLoad().Name)
                                       circLoad.Normal = ppLoad + Me.pDispCircLoadsV0(index).getLoad().Normal
                                   Else
                                       circLoad.Normal = ppLoad
                                   End If
                                   pDispCircLoad.setLoad(circLoad)
                               End Function)

        ''Update PolyLoads based on new loads from ETABS
        'pDispPolyLoads.ForEach(Function(pDispPolyLoad)
        '                           Dim ppLoad As Double
        '                           ppLoad = pileObjs.Where(Function(plObj) plObj.getLocation().getName() = pDispPolyLoad.getLoad().Name).
        '                                                         Select(Function(plObj) plObj.getLoads().getF3()).
        '                                                         FirstOrDefault()
        '                           If ppLoad <> 0 Then
        '                               ' Calculate polygon area using Shoelace formula.
        '                               ' IMPORTANT: use the actual number of vertices in Coor,
        '                               ' NOT polyLoad.nRectangles (that field is the integration
        '                               ' sub-rectangles count and is typically 0 by default,
        '                               ' which would make area = 0 and Normal = Infinity, which
        '                               ' in turn crashes PDisp's Analyse() routine with an
        '                               ' "abnormal situation" dialog.
        '                               Dim polyLoad As PolyLoad
        '                               polyLoad = pDispPolyLoad.getLoad()

        '                               If polyLoad.Coor Is Nothing Then Return Nothing
        '                               Dim nPts As Integer = polyLoad.Coor.Length
        '                               If nPts < 3 Then Return Nothing

        '                               Dim area As Double = 0.0
        '                               For j As Integer = 0 To nPts - 1
        '                                   Dim curr As pdispauto_20_1.Point2D =
        '                                       CType(polyLoad.Coor.GetValue(j), pdispauto_20_1.Point2D)
        '                                   Dim nxt As pdispauto_20_1.Point2D =
        '                                       CType(polyLoad.Coor.GetValue((j + 1) Mod nPts), pdispauto_20_1.Point2D)
        '                                   area += curr.X * nxt.Y - nxt.X * curr.Y
        '                               Next
        '                               area = Math.Abs(area) / 2.0

        '                               ' Guard against degenerate polygons / numerical garbage,
        '                               ' so we never hand PDisp a Normal of 0, NaN or Infinity.
        '                               If area <= 0.000001 Then Return Nothing

        '                               Dim normal As Double = ppLoad / area
        '                               If Double.IsNaN(normal) OrElse Double.IsInfinity(normal) Then Return Nothing

        '                               polyLoad.Normal = normal
        '                               pDispPolyLoad.setLoad(polyLoad)
        '                           End If
        '                       End Function)

        'Push updated PdispLoads back in PDisp
        Me.rectloadsPusher.push(pDispRectLoads, True)
        Me.circloadsPusher.push(pDispCircLoads, True)
        'polyloadsPusher.push(pDispPolyLoads, True)

    End Sub


    Private Sub initializeEtabsPointSprings()

        Me.sapModel.SetModelIsLocked(False)

        ' Restraint/Stiffness Arrays Initialization
        Dim rigidLinkKzArray As Double() = {1000000000, 0, 0, 0, 0, 0}
        ' Link Properties Initialization
        Dim linkName, springPropertyName As String
        Dim dof(5), fixed(5), nonLinear(5) As Boolean
        Dim ke(5), ce(5), dis(5) As Double
        Dim numLinks As Integer = 1
        Dim linkNames(0) As String
        Dim linkAxialDirs(0) As Integer
        Dim linkAngles(0) As Double
        dof(0) = True
        nonLinear(0) = True
        dis(0) = 0
        linkAxialDirs(0) = 3
        linkAngles(0) = 0

        Select Case Me.selNonLinearOption
            Case "None (Linear)"
                'Assign Rigid Pinned Suppport to all Points and leave the Subroutine
                For Each etabsPointName In Me.etabsPointNames
                    ret = Me.sapModel.PointObj.SetRestraint(etabsPointName, {True, True, True, False, False, False})
                Next
                Me.sapModel.File.Save()
                Exit Sub
            Case "Tension Only"
                springPropertyName = "tensionOnly"
                linkName = "link_" + springPropertyName
                linkNames(0) = linkName
                ' Create/Update Hook Link (Tension-Only)
                ret = Me.sapModel.PropLink.SetHook(linkName, dof, fixed, nonLinear, ke, ce, rigidLinkKzArray, dis, 0, 0)
            Case "Compression Only"
                springPropertyName = "compressionOnly"
                linkName = "link_" + springPropertyName
                linkNames(0) = linkName
                ' Create/Update Gap Link (Compression-Only)
                ret = Me.sapModel.PropLink.SetGap(linkName, dof, fixed, nonLinear, ke, ce, rigidLinkKzArray, dis, 0, 0)
        End Select

        ' Set Point Spring Property with Blank Stiffness Array
        ret = Me.sapModel.PropPointSpring.SetPointSpringProp(springPropertyName, 1, {0, 0, 0, 0, 0, 0})
        ' Assing Rigid Hook/Gap Link to Point Spring Property
        ret = Me.sapModel.PropPointSpring.SetLinks(springPropertyName, numLinks, linkNames, linkAxialDirs, linkAngles)

        ' Assign Spring Property to all Points
        Dim restraintsArray(5) As Boolean
        For Each etabsPointName In Me.etabsPointNames
            ' Delete the vertical restraint from point object while keeping all the other ones defined by the user
            ret = Me.sapModel.PointObj.GetRestraint(etabsPointName, restraintsArray)
            restraintsArray(2) = False
            ret = Me.sapModel.PointObj.SetRestraint(etabsPointName, restraintsArray)
            ' Delete all previous spring assignments from the point object
            ret = Me.sapModel.PointObj.DeleteSpring(etabsPointName)
            ' Assing created non-linear spring
            Me.sapModel.PointObj.SetSpringAssignment(etabsPointName, springPropertyName)
        Next

        Me.sapModel.File.Save()

    End Sub

    Private Sub initializePDispLoads()
        ' Extract PDisp Rectangular Loads and Sort them based on their Name using a Comparer Lambda Expression
        Me.pDispRectLoadsV0 = Me.rectLoadsPuller.pull()
        Me.pDispRectLoadsV0.Sort(Function(pdrl1, pdrl2) pdrl1.getLoad().Name > pdrl2.getLoad().Name)
        ' Extract PDisp Circular Loads and Sort them based on their Name using a Comparer Lambda Expression
        Me.pDispCircLoadsV0 = Me.circLoadsPuller.pull()
        Me.pDispCircLoadsV0.Sort(Function(pdrl1, pdrl2) pdrl1.getLoad().Name > pdrl2.getLoad().Name)
    End Sub


    Private Sub updatePointSprings(pileObjs As List(Of PileObject))

        ' ASSIGN COMPUTED STIFFNESSES TO ETABS BASE POINTS

        ' Make sure the ETABS Model is unlocked to allow the assignment of point springs
        Me.sapModel.SetModelIsLocked(False)
        ' Restraint/Stiffness Arrays Initialization
        Dim restraintsArray(5) As Boolean
        Dim stiffnessArray(5) As Double
        ' Link Properties Initialization
        Dim linkName As String
        Dim dof(5), fixed(5), nonLinear(5) As Boolean
        Dim ke(5), ce(5), dis(5) As Double
        Dim numLinks As Integer = 1
        Dim linkNames(0) As String
        Dim linkAxialDirs(0) As Integer
        Dim linkAngles(0) As Double
        dof(0) = True
        nonLinear(0) = True
        dis(0) = 0
        linkAxialDirs(0) = 3
        linkAngles(0) = 0

        For Each pileObj In pileObjs
            ' Delete the vertical restraint from point object while keeping all the other ones defined by the user
            ret = Me.sapModel.PointObj.GetRestraint(pileObj.getLocation.getName(), restraintsArray)
            restraintsArray(2) = False
            ret = Me.sapModel.PointObj.SetRestraint(pileObj.getLocation.getName(), restraintsArray)
            ' Delete all spring assignments from the point object
            ret = Me.sapModel.PointObj.DeleteSpring(pileObj.getLocation.getName())

            Select Case Me.selNonLinearOption
                Case "None (Linear)"
                    ' Compute new stiffness array in Global Coordinates
                    stiffnessArray = {pileObj.getStiffness().getU1(), pileObj.getStiffness().getU2(), pileObj.getStiffness().getU3(), 0, 0, 0}
                    ' Generate/Update point spring property directly with computed stiffness array
                    ret = Me.sapModel.PropPointSpring.SetPointSpringProp(pileObj.getLocation.getName(), 1, stiffnessArray)
                Case "Tension Only"
                    ' If the Spring Property is Tension Only, create a Hook Link Object and assign it to the Point Spring Property...
                    ' Set point spring property with blank stiffness array
                    ret = Me.sapModel.PropPointSpring.SetPointSpringProp(pileObj.getLocation.getName(), 1, {0, 0, 0, 0, 0, 0})
                    ' Build up then link name
                    linkName = "tol_Link_" + pileObj.getLocation.getName()
                    linkNames(0) = linkName
                    ' Compute new stiffness array in Local Link Coordinates
                    If pileObj.getLoads.getF3() = 0 And pileObj.getDisplacements.getU3() < 0 Then
                        stiffnessArray = {Me.kmin, 0, 0, 0, 0, 0}
                    Else
                        stiffnessArray = {pileObj.getStiffness().getU3(), 0, 0, 0, 0, 0}
                    End If
                    ' Create/Update Hook Link (Tension-Only)
                    ret = Me.sapModel.PropLink.SetHook(linkName, dof, fixed, nonLinear, ke, ce, stiffnessArray, dis, 0, 0)
                    ' Assing Hook Link to point
                    ret = Me.sapModel.PropPointSpring.SetLinks(pileObj.getLocation.getName(), numLinks, linkNames, linkAxialDirs, linkAngles)
                Case "Compression Only"
                    ' If the Spring Property is Compression Only, create a Gap Link Object and assign it to the Point Spring Property...
                    ' Set point spring property with blank stiffness array
                    ret = Me.sapModel.PropPointSpring.SetPointSpringProp(pileObj.getLocation.getName(), 1, {0, 0, 0, 0, 0, 0})
                    ' Build up then link name
                    linkName = "col_Link_" + pileObj.getLocation.getName()
                    linkNames(0) = linkName
                    ' Compute new stiffness array in Local Link Coordinates
                    If pileObj.getLoads.getF3() = 0 And pileObj.getDisplacements.getU3() > 0 Then
                        stiffnessArray = {Me.kmin, 0, 0, 0, 0, 0}
                    Else
                        stiffnessArray = {pileObj.getStiffness().getU3(), 0, 0, 0, 0, 0}
                    End If
                    ' Create/Update Gap Link (Compression-Only)
                    ret = Me.sapModel.PropLink.SetGap(linkName, dof, fixed, nonLinear, ke, ce, stiffnessArray, dis, 0, 0)
                    ' Assing Gap Link to point
                    ret = Me.sapModel.PropPointSpring.SetLinks(pileObj.getLocation.getName(), numLinks, linkNames, linkAxialDirs, linkAngles)

            End Select

            ' Assign created/updated point spring property to point object
            ret = Me.sapModel.PointObj.SetSpringAssignment(pileObj.getLocation.getName(), pileObj.getLocation.getName())
        Next

        Me.sapModel.View.RefreshView()

    End Sub


    Private Sub markNonConvergingPiles(pileNames As List(Of String))
        ' Unlock the ETABS Model to allow the Creation and Assignment of Groups
        ret = Me.sapModel.SetModelIsLocked(False)
        ' Create Color Object to be assigned to the ETABS Group
        Dim groupColor = New Color(255, 0, 0)
        ' Create ETABS Group using color converted to ETABS integer
        ret = Me.sapModel.GroupDef.SetGroup_1(Me.nonConvergingGroupName, groupColor.getEtabsIntValue())
        ' Assign the ETABS Group to all Points assigned with an input pileName
        For Each pileName In pileNames
            Me.sapModel.PointObj.SetGroupAssign(pileName, Me.nonConvergingGroupName)
        Next
    End Sub


    Public Sub serialize(pileObjs As List(Of PileObject))
        ' SERIALIZE OUTPUTS IN A JSON FILE
        '1. Sort the PileObjects based on a user-defined Comparator
        pileObjs.Sort(Function(pileObj1, pileObj2) (pileObj1.getName().CompareTo(pileObj2.getName())))
        '2. Build the Json File Name depending on number of Iteration
        Dim jsonFilePath As String = Me.jsonFilesFolderPath + "\" + "PilesObjsDataSet_Iteration0" + CStr(Me.iterNum) + ".json"
        '3. Serialize the list of Pile Objects
        Me.jsonSerializer.serialize(pileObjs, jsonFilePath)

    End Sub

    Public Function deserialize(jsonFilePath As String) As List(Of PileObject)
        ' DESERIALIZE JSON FILE IN A LIST OF PILEOBJECTS
        Return Me.jsonSerializer.deserialize(jsonFilePath)
    End Function

    'Setters
    Public Sub setPileObjs(pileObjs As List(Of PileObject))
        Me.pileObjs = pileObjs
    End Sub
    Public Sub setPileObjsInit(pileObjsInit As List(Of PileObject))
        Me.pileObjsInit = pileObjsInit
    End Sub
    Public Sub setEtabsGroupNames(etabsGroupNames As List(Of String))
        Me.etabsGroupNames = etabsGroupNames
    End Sub
    Public Sub setEtabsLoadComboNames(etabsLoadComboNames As List(Of String))
        Me.etabsLoadComboNames = etabsLoadComboNames
    End Sub
    Public Sub setSelEtabsGroupName(selEtabsGroupName As String)
        Me.selEtabsGroupName = selEtabsGroupName
    End Sub
    Public Sub setSelEtabsLoadComboName(selEtabsLoadComboName As String)
        Me.selEtabsLoadComboName = selEtabsLoadComboName
    End Sub
    Public Sub setEtabsPointNames(etabsPointNames As List(Of String))
        Me.etabsPointNames = etabsPointNames
    End Sub
    Public Sub setOverridePDispLoads(overridePDispLoads As Boolean)
        Me.overridePDispLoads = overridePDispLoads
    End Sub
    Public Sub setIterNumMax(iterNumMax As Integer)
        Me.iterNumMax = iterNumMax
    End Sub
    Public Sub setConvergenceCriterion(convergenceCriterion As String)
        Me.convergenceCriterion = convergenceCriterion
    End Sub
    Public Sub setConvergenceFactor(convergenceFactor As Double)
        Me.convergenceFactor = convergenceFactor
    End Sub
    Public Function setPercentile(percentile As Double) As Double
        Me.percentile = percentile
    End Function
    Public Sub setStepRun(stepRun As Boolean)
        Me.stepRun = stepRun
    End Sub

    'Getters
    Public Function getSapModel() As cSapModel
        Return Me.sapModel
    End Function
    Public Function getPDispModel() As PDispModel
        Return Me.pDispModel
    End Function
    Public Function getPileObjs() As List(Of PileObject)
        Return Me.pileObjs
    End Function
    Public Function getPileObjsInit() As List(Of PileObject)
        Return Me.pileObjsInit
    End Function
    Public Function getConvergingPiles() As List(Of PileObject)
        Return Me.convergingPiles
    End Function
    Public Function getNonConvergingPiles() As List(Of PileObject)
        Return Me.nonConvergingPiles
    End Function
    Public Function getEtabsGroupNames() As List(Of String)
        Return Me.etabsGroupNames
    End Function
    Public Function getEtabsLoadComboNames() As List(Of String)
        Return Me.etabsLoadComboNames
    End Function
    Public Function getEtabsGroupName() As String
        Return Me.selEtabsGroupName
    End Function
    Public Function getEtabsLoadComboName() As String
        Return Me.selEtabsLoadComboName
    End Function
    Public Function getEtabsPointNames() As List(Of String)
        Return Me.etabsPointNames
    End Function
    Public Function getOverridePDispLoads() As Boolean
        Return Me.overridePDispLoads
    End Function
    Public Function getIterNumMax() As Integer
        Return Me.iterNumMax
    End Function
    Public Function getConvergenceCriterion() As String
        Return Me.convergenceCriterion
    End Function
    Public Function getConvergenceFactor() As Double
        Return Me.convergenceFactor
    End Function
    Public Function getPercentile() As Double
        Return Me.percentile
    End Function
    Public Function getStepRun() As Boolean
        Return Me.stepRun
    End Function
    Public Function getIterationStarted() As Boolean
        Return Me.iterationStarted
    End Function
    Public Function getIterationComplete() As Boolean
        Return Me.iterationComplete
    End Function
    Public Function getPileObjsList() As List(Of PileObject)
        Return Me.pileObjs
    End Function

    Public Function getModelName() As String
        Return Me.MODEL_NAME
    End Function
    Public Function getModelVersion() As String
        Return Me.MODEL_VERSION
    End Function
    Public Function getModelCopyRight() As String
        Return Me.MODEL_COPYRIGHT
    End Function
    Public Function getModelAuthor() As String
        Return Me.MODEL_AUTHOR
    End Function
    Public Function getModelOwner() As String
        Return Me.MODEL_OWNER
    End Function

End Class
