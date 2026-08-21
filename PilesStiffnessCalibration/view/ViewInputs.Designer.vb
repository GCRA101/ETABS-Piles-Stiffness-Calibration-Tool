<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ViewInputs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewInputs))
        Me.btnRunIteration = New System.Windows.Forms.Button()
        Me.lblProgrBar = New System.Windows.Forms.Label()
        Me.progrBar = New System.Windows.Forms.ProgressBar()
        Me.lblLoadCombos = New System.Windows.Forms.Label()
        Me.cklbLoadCombos = New System.Windows.Forms.CheckedListBox()
        Me.lblGroups = New System.Windows.Forms.Label()
        Me.cklbGroups = New System.Windows.Forms.CheckedListBox()
        Me.ofdPDispFile = New System.Windows.Forms.OpenFileDialog()
        Me.btnOpenPDispFile = New System.Windows.Forms.Button()
        Me.lblPDispFile = New System.Windows.Forms.Label()
        Me.pbETABSInputs = New System.Windows.Forms.PictureBox()
        Me.pbPDispInputs = New System.Windows.Forms.PictureBox()
        Me.gbPDispInputs = New System.Windows.Forms.GroupBox()
        Me.gbETABSInputs = New System.Windows.Forms.GroupBox()
        Me.cbNonLinearOptions = New System.Windows.Forms.ComboBox()
        Me.lblNonLinearOption = New System.Windows.Forms.Label()
        Me.tbStiffness = New System.Windows.Forms.TextBox()
        Me.btnOpenJSONFile = New System.Windows.Forms.Button()
        Me.lblInitialStiffness = New System.Windows.Forms.Label()
        Me.rbImportFromFile = New System.Windows.Forms.RadioButton()
        Me.rbSpring = New System.Windows.Forms.RadioButton()
        Me.rbRigid = New System.Windows.Forms.RadioButton()
        Me.ofdJsonFile = New System.Windows.Forms.OpenFileDialog()
        Me.gbOutputs = New System.Windows.Forms.GroupBox()
        Me.cbExcelReport = New System.Windows.Forms.CheckBox()
        Me.lblPercentile = New System.Windows.Forms.Label()
        Me.cbPercentile = New System.Windows.Forms.ComboBox()
        Me.lblConvCriterion = New System.Windows.Forms.Label()
        Me.cbConvCriterion = New System.Windows.Forms.ComboBox()
        Me.cbVariation = New System.Windows.Forms.ComboBox()
        Me.lblVariation = New System.Windows.Forms.Label()
        Me.cbIterations = New System.Windows.Forms.ComboBox()
        Me.lblIterations = New System.Windows.Forms.Label()
        Me.gbSettings = New System.Windows.Forms.GroupBox()
        CType(Me.pbETABSInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPDispInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPDispInputs.SuspendLayout()
        Me.gbETABSInputs.SuspendLayout()
        Me.gbOutputs.SuspendLayout()
        Me.gbSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRunIteration
        '
        Me.btnRunIteration.Location = New System.Drawing.Point(109, 761)
        Me.btnRunIteration.Margin = New System.Windows.Forms.Padding(4)
        Me.btnRunIteration.Name = "btnRunIteration"
        Me.btnRunIteration.Size = New System.Drawing.Size(165, 47)
        Me.btnRunIteration.TabIndex = 29
        Me.btnRunIteration.Text = "RUN ITERATION"
        Me.btnRunIteration.UseVisualStyleBackColor = True
        '
        'lblProgrBar
        '
        Me.lblProgrBar.AutoSize = True
        Me.lblProgrBar.Location = New System.Drawing.Point(29, 827)
        Me.lblProgrBar.Name = "lblProgrBar"
        Me.lblProgrBar.Size = New System.Drawing.Size(134, 16)
        Me.lblProgrBar.TabIndex = 28
        Me.lblProgrBar.Text = "Iteration in Progress..."
        '
        'progrBar
        '
        Me.progrBar.Location = New System.Drawing.Point(31, 848)
        Me.progrBar.Margin = New System.Windows.Forms.Padding(4)
        Me.progrBar.Maximum = 100000
        Me.progrBar.Name = "progrBar"
        Me.progrBar.Size = New System.Drawing.Size(317, 27)
        Me.progrBar.TabIndex = 27
        '
        'lblLoadCombos
        '
        Me.lblLoadCombos.AutoSize = True
        Me.lblLoadCombos.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadCombos.Location = New System.Drawing.Point(9, 126)
        Me.lblLoadCombos.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblLoadCombos.Name = "lblLoadCombos"
        Me.lblLoadCombos.Size = New System.Drawing.Size(87, 13)
        Me.lblLoadCombos.TabIndex = 35
        Me.lblLoadCombos.Text = "LOAD COMBOS"
        '
        'cklbLoadCombos
        '
        Me.cklbLoadCombos.CheckOnClick = True
        Me.cklbLoadCombos.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbLoadCombos.FormattingEnabled = True
        Me.cklbLoadCombos.Location = New System.Drawing.Point(8, 145)
        Me.cklbLoadCombos.Margin = New System.Windows.Forms.Padding(4)
        Me.cklbLoadCombos.Name = "cklbLoadCombos"
        Me.cklbLoadCombos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cklbLoadCombos.Size = New System.Drawing.Size(319, 49)
        Me.cklbLoadCombos.TabIndex = 34
        '
        'lblGroups
        '
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroups.Location = New System.Drawing.Point(9, 47)
        Me.lblGroups.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblGroups.Name = "lblGroups"
        Me.lblGroups.Size = New System.Drawing.Size(51, 13)
        Me.lblGroups.TabIndex = 33
        Me.lblGroups.Text = "GROUPS"
        '
        'cklbGroups
        '
        Me.cklbGroups.BackColor = System.Drawing.SystemColors.Window
        Me.cklbGroups.CheckOnClick = True
        Me.cklbGroups.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cklbGroups.FormattingEnabled = True
        Me.cklbGroups.Location = New System.Drawing.Point(9, 64)
        Me.cklbGroups.Margin = New System.Windows.Forms.Padding(4)
        Me.cklbGroups.Name = "cklbGroups"
        Me.cklbGroups.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cklbGroups.Size = New System.Drawing.Size(320, 49)
        Me.cklbGroups.TabIndex = 32
        '
        'ofdPDispFile
        '
        Me.ofdPDispFile.FileName = "ofdPDispFile"
        '
        'btnOpenPDispFile
        '
        Me.btnOpenPDispFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenPDispFile.Location = New System.Drawing.Point(205, 46)
        Me.btnOpenPDispFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenPDispFile.Name = "btnOpenPDispFile"
        Me.btnOpenPDispFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpenPDispFile.Size = New System.Drawing.Size(124, 28)
        Me.btnOpenPDispFile.TabIndex = 36
        Me.btnOpenPDispFile.Text = "Browse..."
        Me.btnOpenPDispFile.UseVisualStyleBackColor = True
        '
        'lblPDispFile
        '
        Me.lblPDispFile.AutoSize = True
        Me.lblPDispFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPDispFile.Location = New System.Drawing.Point(8, 52)
        Me.lblPDispFile.Name = "lblPDispFile"
        Me.lblPDispFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPDispFile.Size = New System.Drawing.Size(77, 12)
        Me.lblPDispFile.TabIndex = 37
        Me.lblPDispFile.Text = "Select PDisp File:"
        '
        'pbETABSInputs
        '
        Me.pbETABSInputs.Image = CType(resources.GetObject("pbETABSInputs.Image"), System.Drawing.Image)
        Me.pbETABSInputs.InitialImage = Nothing
        Me.pbETABSInputs.Location = New System.Drawing.Point(0, 0)
        Me.pbETABSInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbETABSInputs.Name = "pbETABSInputs"
        Me.pbETABSInputs.Size = New System.Drawing.Size(40, 34)
        Me.pbETABSInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbETABSInputs.TabIndex = 38
        Me.pbETABSInputs.TabStop = False
        '
        'pbPDispInputs
        '
        Me.pbPDispInputs.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.pbPDispInputs.Image = CType(resources.GetObject("pbPDispInputs.Image"), System.Drawing.Image)
        Me.pbPDispInputs.InitialImage = Nothing
        Me.pbPDispInputs.Location = New System.Drawing.Point(0, 0)
        Me.pbPDispInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.pbPDispInputs.Name = "pbPDispInputs"
        Me.pbPDispInputs.Size = New System.Drawing.Size(40, 34)
        Me.pbPDispInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPDispInputs.TabIndex = 39
        Me.pbPDispInputs.TabStop = False
        '
        'gbPDispInputs
        '
        Me.gbPDispInputs.Controls.Add(Me.pbPDispInputs)
        Me.gbPDispInputs.Controls.Add(Me.lblPDispFile)
        Me.gbPDispInputs.Controls.Add(Me.btnOpenPDispFile)
        Me.gbPDispInputs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPDispInputs.Location = New System.Drawing.Point(24, 412)
        Me.gbPDispInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbPDispInputs.Name = "gbPDispInputs"
        Me.gbPDispInputs.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbPDispInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.gbPDispInputs.Size = New System.Drawing.Size(336, 90)
        Me.gbPDispInputs.TabIndex = 42
        Me.gbPDispInputs.TabStop = False
        Me.gbPDispInputs.Text = "PDISP Inputs"
        '
        'gbETABSInputs
        '
        Me.gbETABSInputs.Controls.Add(Me.cbNonLinearOptions)
        Me.gbETABSInputs.Controls.Add(Me.lblNonLinearOption)
        Me.gbETABSInputs.Controls.Add(Me.tbStiffness)
        Me.gbETABSInputs.Controls.Add(Me.btnOpenJSONFile)
        Me.gbETABSInputs.Controls.Add(Me.lblInitialStiffness)
        Me.gbETABSInputs.Controls.Add(Me.rbImportFromFile)
        Me.gbETABSInputs.Controls.Add(Me.rbSpring)
        Me.gbETABSInputs.Controls.Add(Me.rbRigid)
        Me.gbETABSInputs.Controls.Add(Me.cklbLoadCombos)
        Me.gbETABSInputs.Controls.Add(Me.lblLoadCombos)
        Me.gbETABSInputs.Controls.Add(Me.pbETABSInputs)
        Me.gbETABSInputs.Controls.Add(Me.cklbGroups)
        Me.gbETABSInputs.Controls.Add(Me.lblGroups)
        Me.gbETABSInputs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbETABSInputs.Location = New System.Drawing.Point(24, 14)
        Me.gbETABSInputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbETABSInputs.Name = "gbETABSInputs"
        Me.gbETABSInputs.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbETABSInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.gbETABSInputs.Size = New System.Drawing.Size(336, 378)
        Me.gbETABSInputs.TabIndex = 43
        Me.gbETABSInputs.TabStop = False
        Me.gbETABSInputs.Text = "ETABS Inputs"
        '
        'cbNonLinearOptions
        '
        Me.cbNonLinearOptions.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNonLinearOptions.FormattingEnabled = True
        Me.cbNonLinearOptions.Items.AddRange(New Object() {"None (Linear)", "Tension Only", "Compression Only"})
        Me.cbNonLinearOptions.Location = New System.Drawing.Point(203, 209)
        Me.cbNonLinearOptions.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbNonLinearOptions.Name = "cbNonLinearOptions"
        Me.cbNonLinearOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbNonLinearOptions.Size = New System.Drawing.Size(124, 20)
        Me.cbNonLinearOptions.TabIndex = 40
        '
        'lblNonLinearOption
        '
        Me.lblNonLinearOption.AutoSize = True
        Me.lblNonLinearOption.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNonLinearOption.Location = New System.Drawing.Point(8, 213)
        Me.lblNonLinearOption.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblNonLinearOption.Name = "lblNonLinearOption"
        Me.lblNonLinearOption.Size = New System.Drawing.Size(135, 13)
        Me.lblNonLinearOption.TabIndex = 44
        Me.lblNonLinearOption.Text = "Spring Nonlinear Option"
        '
        'tbStiffness
        '
        Me.tbStiffness.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStiffness.Location = New System.Drawing.Point(251, 305)
        Me.tbStiffness.Margin = New System.Windows.Forms.Padding(4)
        Me.tbStiffness.Name = "tbStiffness"
        Me.tbStiffness.Size = New System.Drawing.Size(75, 18)
        Me.tbStiffness.TabIndex = 43
        '
        'btnOpenJSONFile
        '
        Me.btnOpenJSONFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenJSONFile.Location = New System.Drawing.Point(251, 336)
        Me.btnOpenJSONFile.Margin = New System.Windows.Forms.Padding(4)
        Me.btnOpenJSONFile.Name = "btnOpenJSONFile"
        Me.btnOpenJSONFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpenJSONFile.Size = New System.Drawing.Size(76, 25)
        Me.btnOpenJSONFile.TabIndex = 40
        Me.btnOpenJSONFile.Text = "Browse..."
        Me.btnOpenJSONFile.UseVisualStyleBackColor = True
        '
        'lblInitialStiffness
        '
        Me.lblInitialStiffness.AutoSize = True
        Me.lblInitialStiffness.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitialStiffness.Location = New System.Drawing.Point(8, 245)
        Me.lblInitialStiffness.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblInitialStiffness.Name = "lblInitialStiffness"
        Me.lblInitialStiffness.Size = New System.Drawing.Size(213, 13)
        Me.lblInitialStiffness.TabIndex = 42
        Me.lblInitialStiffness.Text = "PILES STIFFNESS BOUNDARY CONDITION"
        '
        'rbImportFromFile
        '
        Me.rbImportFromFile.AutoSize = True
        Me.rbImportFromFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbImportFromFile.Location = New System.Drawing.Point(11, 335)
        Me.rbImportFromFile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbImportFromFile.Name = "rbImportFromFile"
        Me.rbImportFromFile.Size = New System.Drawing.Size(174, 19)
        Me.rbImportFromFile.TabIndex = 41
        Me.rbImportFromFile.TabStop = True
        Me.rbImportFromFile.Text = "Import from Serialized File"
        Me.rbImportFromFile.UseVisualStyleBackColor = True
        '
        'rbSpring
        '
        Me.rbSpring.AutoSize = True
        Me.rbSpring.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbSpring.Location = New System.Drawing.Point(11, 305)
        Me.rbSpring.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbSpring.Name = "rbSpring"
        Me.rbSpring.Size = New System.Drawing.Size(180, 19)
        Me.rbSpring.TabIndex = 40
        Me.rbSpring.TabStop = True
        Me.rbSpring.Text = "All Same Stiffness [KN/mm]"
        Me.rbSpring.UseVisualStyleBackColor = True
        '
        'rbRigid
        '
        Me.rbRigid.AutoSize = True
        Me.rbRigid.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbRigid.Location = New System.Drawing.Point(11, 276)
        Me.rbRigid.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.rbRigid.Name = "rbRigid"
        Me.rbRigid.Size = New System.Drawing.Size(123, 19)
        Me.rbRigid.TabIndex = 39
        Me.rbRigid.TabStop = True
        Me.rbRigid.Text = "All Rigid Supports"
        Me.rbRigid.UseVisualStyleBackColor = True
        '
        'ofdJsonFile
        '
        Me.ofdJsonFile.FileName = "ofdJsonFile"
        '
        'gbOutputs
        '
        Me.gbOutputs.Controls.Add(Me.cbExcelReport)
        Me.gbOutputs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbOutputs.Location = New System.Drawing.Point(24, 677)
        Me.gbOutputs.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbOutputs.Name = "gbOutputs"
        Me.gbOutputs.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbOutputs.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbOutputs.Size = New System.Drawing.Size(336, 65)
        Me.gbOutputs.TabIndex = 43
        Me.gbOutputs.TabStop = False
        Me.gbOutputs.Text = "Outputs"
        '
        'cbExcelReport
        '
        Me.cbExcelReport.AutoSize = True
        Me.cbExcelReport.Checked = True
        Me.cbExcelReport.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbExcelReport.Location = New System.Drawing.Point(11, 26)
        Me.cbExcelReport.Margin = New System.Windows.Forms.Padding(4)
        Me.cbExcelReport.Name = "cbExcelReport"
        Me.cbExcelReport.Size = New System.Drawing.Size(97, 19)
        Me.cbExcelReport.TabIndex = 38
        Me.cbExcelReport.Text = "Excel Report"
        Me.cbExcelReport.UseVisualStyleBackColor = True
        '
        'lblPercentile
        '
        Me.lblPercentile.AutoSize = True
        Me.lblPercentile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPercentile.Location = New System.Drawing.Point(8, 119)
        Me.lblPercentile.Name = "lblPercentile"
        Me.lblPercentile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblPercentile.Size = New System.Drawing.Size(49, 12)
        Me.lblPercentile.TabIndex = 51
        Me.lblPercentile.Text = "Percentile:"
        '
        'cbPercentile
        '
        Me.cbPercentile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbPercentile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbPercentile.FormattingEnabled = True
        Me.cbPercentile.Items.AddRange(New Object() {"80%", "85%", "90%", "95%", "96%", "97%", "98%", "99%", "100%"})
        Me.cbPercentile.Location = New System.Drawing.Point(204, 117)
        Me.cbPercentile.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbPercentile.Name = "cbPercentile"
        Me.cbPercentile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbPercentile.Size = New System.Drawing.Size(124, 20)
        Me.cbPercentile.TabIndex = 50
        '
        'lblConvCriterion
        '
        Me.lblConvCriterion.AutoSize = True
        Me.lblConvCriterion.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConvCriterion.Location = New System.Drawing.Point(7, 32)
        Me.lblConvCriterion.Name = "lblConvCriterion"
        Me.lblConvCriterion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblConvCriterion.Size = New System.Drawing.Size(104, 12)
        Me.lblConvCriterion.TabIndex = 49
        Me.lblConvCriterion.Text = "Convergence Criterion:"
        '
        'cbConvCriterion
        '
        Me.cbConvCriterion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbConvCriterion.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbConvCriterion.FormattingEnabled = True
        Me.cbConvCriterion.Items.AddRange(New Object() {"Reaction", "Displacement", "Stiffness"})
        Me.cbConvCriterion.Location = New System.Drawing.Point(204, 30)
        Me.cbConvCriterion.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbConvCriterion.Name = "cbConvCriterion"
        Me.cbConvCriterion.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbConvCriterion.Size = New System.Drawing.Size(124, 20)
        Me.cbConvCriterion.TabIndex = 48
        '
        'cbVariation
        '
        Me.cbVariation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbVariation.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbVariation.FormattingEnabled = True
        Me.cbVariation.Items.AddRange(New Object() {"5%", "10%", "15%", "20%"})
        Me.cbVariation.Location = New System.Drawing.Point(204, 59)
        Me.cbVariation.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbVariation.Name = "cbVariation"
        Me.cbVariation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbVariation.Size = New System.Drawing.Size(124, 20)
        Me.cbVariation.TabIndex = 47
        '
        'lblVariation
        '
        Me.lblVariation.AutoSize = True
        Me.lblVariation.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVariation.Location = New System.Drawing.Point(8, 61)
        Me.lblVariation.Name = "lblVariation"
        Me.lblVariation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblVariation.Size = New System.Drawing.Size(66, 12)
        Me.lblVariation.TabIndex = 46
        Me.lblVariation.Text = "Max Variation:"
        '
        'cbIterations
        '
        Me.cbIterations.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIterations.FormattingEnabled = True
        Me.cbIterations.Items.AddRange(New Object() {"2", "3", "4", "5", "10", "20", "50", "100"})
        Me.cbIterations.Location = New System.Drawing.Point(204, 88)
        Me.cbIterations.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.cbIterations.Name = "cbIterations"
        Me.cbIterations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbIterations.Size = New System.Drawing.Size(124, 20)
        Me.cbIterations.TabIndex = 45
        '
        'lblIterations
        '
        Me.lblIterations.AutoSize = True
        Me.lblIterations.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIterations.Location = New System.Drawing.Point(8, 90)
        Me.lblIterations.Name = "lblIterations"
        Me.lblIterations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIterations.Size = New System.Drawing.Size(143, 12)
        Me.lblIterations.TabIndex = 44
        Me.lblIterations.Text = "Max Num of Analysis Iterations:"
        '
        'gbSettings
        '
        Me.gbSettings.Controls.Add(Me.lblPercentile)
        Me.gbSettings.Controls.Add(Me.cbPercentile)
        Me.gbSettings.Controls.Add(Me.lblConvCriterion)
        Me.gbSettings.Controls.Add(Me.lblIterations)
        Me.gbSettings.Controls.Add(Me.cbConvCriterion)
        Me.gbSettings.Controls.Add(Me.cbIterations)
        Me.gbSettings.Controls.Add(Me.cbVariation)
        Me.gbSettings.Controls.Add(Me.lblVariation)
        Me.gbSettings.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbSettings.Location = New System.Drawing.Point(24, 523)
        Me.gbSettings.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSettings.Name = "gbSettings"
        Me.gbSettings.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.gbSettings.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.gbSettings.Size = New System.Drawing.Size(336, 150)
        Me.gbSettings.TabIndex = 43
        Me.gbSettings.TabStop = False
        Me.gbSettings.Text = "Settings"
        '
        'ViewInputs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(391, 906)
        Me.Controls.Add(Me.gbOutputs)
        Me.Controls.Add(Me.gbETABSInputs)
        Me.Controls.Add(Me.gbPDispInputs)
        Me.Controls.Add(Me.btnRunIteration)
        Me.Controls.Add(Me.lblProgrBar)
        Me.Controls.Add(Me.progrBar)
        Me.Controls.Add(Me.gbSettings)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Name = "ViewInputs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Piles Stiffness Calibration"
        CType(Me.pbETABSInputs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPDispInputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPDispInputs.ResumeLayout(False)
        Me.gbPDispInputs.PerformLayout()
        Me.gbETABSInputs.ResumeLayout(False)
        Me.gbETABSInputs.PerformLayout()
        Me.gbOutputs.ResumeLayout(False)
        Me.gbOutputs.PerformLayout()
        Me.gbSettings.ResumeLayout(False)
        Me.gbSettings.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRunIteration As Windows.Forms.Button
    Friend WithEvents lblProgrBar As Windows.Forms.Label
    Friend WithEvents progrBar As Windows.Forms.ProgressBar
    Friend WithEvents lblLoadCombos As Windows.Forms.Label
    Friend WithEvents cklbLoadCombos As Windows.Forms.CheckedListBox
    Friend WithEvents lblGroups As Windows.Forms.Label
    Friend WithEvents cklbGroups As Windows.Forms.CheckedListBox
    Friend WithEvents ofdPDispFile As Windows.Forms.OpenFileDialog
    Friend WithEvents btnOpenPDispFile As Windows.Forms.Button
    Friend WithEvents lblPDispFile As Windows.Forms.Label
    Friend WithEvents pbETABSInputs As Windows.Forms.PictureBox
    Friend WithEvents pbPDispInputs As Windows.Forms.PictureBox
    Friend WithEvents gbPDispInputs As Windows.Forms.GroupBox
    Friend WithEvents gbETABSInputs As Windows.Forms.GroupBox
    Friend WithEvents lblInitialStiffness As Windows.Forms.Label
    Friend WithEvents rbImportFromFile As Windows.Forms.RadioButton
    Friend WithEvents rbSpring As Windows.Forms.RadioButton
    Friend WithEvents rbRigid As Windows.Forms.RadioButton
    Friend WithEvents btnOpenJSONFile As Windows.Forms.Button
    Friend WithEvents tbStiffness As Windows.Forms.TextBox
    Friend WithEvents ofdJsonFile As Windows.Forms.OpenFileDialog
    Friend WithEvents lblNonLinearOption As Windows.Forms.Label
    Friend WithEvents cbNonLinearOptions As Windows.Forms.ComboBox
    Friend WithEvents gbOutputs As Windows.Forms.GroupBox
    Friend WithEvents cbExcelReport As Windows.Forms.CheckBox
    Friend WithEvents lblPercentile As Windows.Forms.Label
    Friend WithEvents cbPercentile As Windows.Forms.ComboBox
    Friend WithEvents lblConvCriterion As Windows.Forms.Label
    Friend WithEvents cbConvCriterion As Windows.Forms.ComboBox
    Friend WithEvents cbVariation As Windows.Forms.ComboBox
    Friend WithEvents lblVariation As Windows.Forms.Label
    Friend WithEvents cbIterations As Windows.Forms.ComboBox
    Friend WithEvents lblIterations As Windows.Forms.Label
    Friend WithEvents gbSettings As Windows.Forms.GroupBox
End Class
