<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewInputs
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ViewInputs))
        Me.btnRunIteration = New System.Windows.Forms.Button()
        Me.lblProgrBar = New System.Windows.Forms.Label()
        Me.progrBar = New System.Windows.Forms.ProgressBar()
        Me.cbIterations = New System.Windows.Forms.ComboBox()
        Me.lblIterations = New System.Windows.Forms.Label()
        Me.cbDispVariation = New System.Windows.Forms.ComboBox()
        Me.lblDispVariation = New System.Windows.Forms.Label()
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
        Me.tbStiffness = New System.Windows.Forms.TextBox()
        Me.btnOpenJSONFile = New System.Windows.Forms.Button()
        Me.lblInitialStiffness = New System.Windows.Forms.Label()
        Me.rbImportFromFile = New System.Windows.Forms.RadioButton()
        Me.rbSpring = New System.Windows.Forms.RadioButton()
        Me.rbRigid = New System.Windows.Forms.RadioButton()
        Me.ofdJsonFile = New System.Windows.Forms.OpenFileDialog()
        Me.lblNonLinearOption = New System.Windows.Forms.Label()
        Me.cbNonLinearOptions = New System.Windows.Forms.ComboBox()
        CType(Me.pbETABSInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.pbPDispInputs, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.gbPDispInputs.SuspendLayout()
        Me.gbETABSInputs.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnRunIteration
        '
        Me.btnRunIteration.Location = New System.Drawing.Point(82, 525)
        Me.btnRunIteration.Name = "btnRunIteration"
        Me.btnRunIteration.Size = New System.Drawing.Size(124, 38)
        Me.btnRunIteration.TabIndex = 29
        Me.btnRunIteration.Text = "RUN ITERATION"
        Me.btnRunIteration.UseVisualStyleBackColor = True
        '
        'lblProgrBar
        '
        Me.lblProgrBar.AutoSize = True
        Me.lblProgrBar.Location = New System.Drawing.Point(23, 577)
        Me.lblProgrBar.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblProgrBar.Name = "lblProgrBar"
        Me.lblProgrBar.Size = New System.Drawing.Size(109, 13)
        Me.lblProgrBar.TabIndex = 28
        Me.lblProgrBar.Text = "Iteration in Progress..."
        '
        'progrBar
        '
        Me.progrBar.Location = New System.Drawing.Point(24, 594)
        Me.progrBar.Maximum = 100000
        Me.progrBar.Name = "progrBar"
        Me.progrBar.Size = New System.Drawing.Size(238, 22)
        Me.progrBar.TabIndex = 27
        '
        'cbIterations
        '
        Me.cbIterations.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbIterations.FormattingEnabled = True
        Me.cbIterations.Items.AddRange(New Object() {"2", "3", "4", "5", "10", "20", "50", "100"})
        Me.cbIterations.Location = New System.Drawing.Point(154, 93)
        Me.cbIterations.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbIterations.Name = "cbIterations"
        Me.cbIterations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbIterations.Size = New System.Drawing.Size(94, 20)
        Me.cbIterations.TabIndex = 26
        '
        'lblIterations
        '
        Me.lblIterations.AutoSize = True
        Me.lblIterations.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIterations.Location = New System.Drawing.Point(6, 95)
        Me.lblIterations.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblIterations.Name = "lblIterations"
        Me.lblIterations.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblIterations.Size = New System.Drawing.Size(143, 12)
        Me.lblIterations.TabIndex = 25
        Me.lblIterations.Text = "Max Num of Analysis Iterations:"
        '
        'cbDispVariation
        '
        Me.cbDispVariation.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbDispVariation.FormattingEnabled = True
        Me.cbDispVariation.Items.AddRange(New Object() {"5%", "10%", "15%", "20%"})
        Me.cbDispVariation.Location = New System.Drawing.Point(154, 65)
        Me.cbDispVariation.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.cbDispVariation.Name = "cbDispVariation"
        Me.cbDispVariation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbDispVariation.Size = New System.Drawing.Size(94, 20)
        Me.cbDispVariation.TabIndex = 31
        '
        'lblDispVariation
        '
        Me.lblDispVariation.AutoSize = True
        Me.lblDispVariation.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDispVariation.Location = New System.Drawing.Point(6, 67)
        Me.lblDispVariation.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblDispVariation.Name = "lblDispVariation"
        Me.lblDispVariation.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.lblDispVariation.Size = New System.Drawing.Size(88, 12)
        Me.lblDispVariation.TabIndex = 30
        Me.lblDispVariation.Text = "Max Disp Variation:"
        '
        'lblLoadCombos
        '
        Me.lblLoadCombos.AutoSize = True
        Me.lblLoadCombos.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLoadCombos.Location = New System.Drawing.Point(6, 115)
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
        Me.cklbLoadCombos.Location = New System.Drawing.Point(5, 131)
        Me.cklbLoadCombos.Name = "cklbLoadCombos"
        Me.cklbLoadCombos.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cklbLoadCombos.Size = New System.Drawing.Size(240, 49)
        Me.cklbLoadCombos.TabIndex = 34
        '
        'lblGroups
        '
        Me.lblGroups.AutoSize = True
        Me.lblGroups.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGroups.Location = New System.Drawing.Point(7, 38)
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
        Me.cklbGroups.Location = New System.Drawing.Point(7, 58)
        Me.cklbGroups.Name = "cklbGroups"
        Me.cklbGroups.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cklbGroups.Size = New System.Drawing.Size(241, 49)
        Me.cklbGroups.TabIndex = 32
        '
        'ofdPDispFile
        '
        Me.ofdPDispFile.FileName = "ofdPDispFile"
        '
        'btnOpenPDispFile
        '
        Me.btnOpenPDispFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenPDispFile.Location = New System.Drawing.Point(154, 37)
        Me.btnOpenPDispFile.Name = "btnOpenPDispFile"
        Me.btnOpenPDispFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpenPDispFile.Size = New System.Drawing.Size(93, 23)
        Me.btnOpenPDispFile.TabIndex = 36
        Me.btnOpenPDispFile.Text = "Browse..."
        Me.btnOpenPDispFile.UseVisualStyleBackColor = True
        '
        'lblPDispFile
        '
        Me.lblPDispFile.AutoSize = True
        Me.lblPDispFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPDispFile.Location = New System.Drawing.Point(6, 42)
        Me.lblPDispFile.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
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
        Me.pbETABSInputs.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pbETABSInputs.Name = "pbETABSInputs"
        Me.pbETABSInputs.Size = New System.Drawing.Size(30, 28)
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
        Me.pbPDispInputs.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.pbPDispInputs.Name = "pbPDispInputs"
        Me.pbPDispInputs.Size = New System.Drawing.Size(30, 28)
        Me.pbPDispInputs.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pbPDispInputs.TabIndex = 39
        Me.pbPDispInputs.TabStop = False
        '
        'gbPDispInputs
        '
        Me.gbPDispInputs.Controls.Add(Me.pbPDispInputs)
        Me.gbPDispInputs.Controls.Add(Me.lblPDispFile)
        Me.gbPDispInputs.Controls.Add(Me.btnOpenPDispFile)
        Me.gbPDispInputs.Controls.Add(Me.cbDispVariation)
        Me.gbPDispInputs.Controls.Add(Me.lblDispVariation)
        Me.gbPDispInputs.Controls.Add(Me.cbIterations)
        Me.gbPDispInputs.Controls.Add(Me.lblIterations)
        Me.gbPDispInputs.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.gbPDispInputs.Location = New System.Drawing.Point(18, 381)
        Me.gbPDispInputs.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbPDispInputs.Name = "gbPDispInputs"
        Me.gbPDispInputs.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbPDispInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.gbPDispInputs.Size = New System.Drawing.Size(252, 124)
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
        Me.gbETABSInputs.Location = New System.Drawing.Point(18, 26)
        Me.gbETABSInputs.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbETABSInputs.Name = "gbETABSInputs"
        Me.gbETABSInputs.Padding = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.gbETABSInputs.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.gbETABSInputs.Size = New System.Drawing.Size(252, 340)
        Me.gbETABSInputs.TabIndex = 43
        Me.gbETABSInputs.TabStop = False
        Me.gbETABSInputs.Text = "ETABS Inputs"
        '
        'tbStiffness
        '
        Me.tbStiffness.Font = New System.Drawing.Font("Segoe UI", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbStiffness.Location = New System.Drawing.Point(188, 284)
        Me.tbStiffness.Name = "tbStiffness"
        Me.tbStiffness.Size = New System.Drawing.Size(57, 18)
        Me.tbStiffness.TabIndex = 43
        '
        'btnOpenJSONFile
        '
        Me.btnOpenJSONFile.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnOpenJSONFile.Location = New System.Drawing.Point(188, 309)
        Me.btnOpenJSONFile.Name = "btnOpenJSONFile"
        Me.btnOpenJSONFile.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.btnOpenJSONFile.Size = New System.Drawing.Size(57, 20)
        Me.btnOpenJSONFile.TabIndex = 40
        Me.btnOpenJSONFile.Text = "Browse..."
        Me.btnOpenJSONFile.UseVisualStyleBackColor = True
        '
        'lblInitialStiffness
        '
        Me.lblInitialStiffness.AutoSize = True
        Me.lblInitialStiffness.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInitialStiffness.Location = New System.Drawing.Point(6, 235)
        Me.lblInitialStiffness.Name = "lblInitialStiffness"
        Me.lblInitialStiffness.Size = New System.Drawing.Size(213, 13)
        Me.lblInitialStiffness.TabIndex = 42
        Me.lblInitialStiffness.Text = "PILES STIFFNESS BOUNDARY CONDITION"
        '
        'rbImportFromFile
        '
        Me.rbImportFromFile.AutoSize = True
        Me.rbImportFromFile.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbImportFromFile.Location = New System.Drawing.Point(8, 308)
        Me.rbImportFromFile.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
        Me.rbSpring.Location = New System.Drawing.Point(8, 284)
        Me.rbSpring.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
        Me.rbRigid.Location = New System.Drawing.Point(8, 260)
        Me.rbRigid.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
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
        'lblNonLinearOption
        '
        Me.lblNonLinearOption.AutoSize = True
        Me.lblNonLinearOption.Font = New System.Drawing.Font("Segoe UI", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNonLinearOption.Location = New System.Drawing.Point(4, 200)
        Me.lblNonLinearOption.Name = "lblNonLinearOption"
        Me.lblNonLinearOption.Size = New System.Drawing.Size(135, 13)
        Me.lblNonLinearOption.TabIndex = 44
        Me.lblNonLinearOption.Text = "Spring Nonlinear Option"
        '
        'cbNonLinearOptions
        '
        Me.cbNonLinearOptions.Font = New System.Drawing.Font("Segoe UI", 7.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cbNonLinearOptions.FormattingEnabled = True
        Me.cbNonLinearOptions.Items.AddRange(New Object() {"None (Linear)", "Tension Only", "Compression Only"})
        Me.cbNonLinearOptions.Location = New System.Drawing.Point(150, 197)
        Me.cbNonLinearOptions.Margin = New System.Windows.Forms.Padding(2)
        Me.cbNonLinearOptions.Name = "cbNonLinearOptions"
        Me.cbNonLinearOptions.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.cbNonLinearOptions.Size = New System.Drawing.Size(94, 20)
        Me.cbNonLinearOptions.TabIndex = 40
        '
        'ViewInputs
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(293, 634)
        Me.Controls.Add(Me.gbETABSInputs)
        Me.Controls.Add(Me.gbPDispInputs)
        Me.Controls.Add(Me.btnRunIteration)
        Me.Controls.Add(Me.lblProgrBar)
        Me.Controls.Add(Me.progrBar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(2, 2, 2, 2)
        Me.Name = "ViewInputs"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Piles Stiffness Calibration"
        CType(Me.pbETABSInputs, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.pbPDispInputs, System.ComponentModel.ISupportInitialize).EndInit()
        Me.gbPDispInputs.ResumeLayout(False)
        Me.gbPDispInputs.PerformLayout()
        Me.gbETABSInputs.ResumeLayout(False)
        Me.gbETABSInputs.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnRunIteration As Windows.Forms.Button
    Friend WithEvents lblProgrBar As Windows.Forms.Label
    Friend WithEvents progrBar As Windows.Forms.ProgressBar
    Friend WithEvents cbIterations As Windows.Forms.ComboBox
    Friend WithEvents lblIterations As Windows.Forms.Label
    Friend WithEvents cbDispVariation As Windows.Forms.ComboBox
    Friend WithEvents lblDispVariation As Windows.Forms.Label
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
End Class
