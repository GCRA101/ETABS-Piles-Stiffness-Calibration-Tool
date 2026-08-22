<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SplashScreen
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SplashScreen))
        Me.pbAppLogo = New System.Windows.Forms.PictureBox()
        Me.tlpLogo = New System.Windows.Forms.TableLayoutPanel()
        Me.tlpTitle = New System.Windows.Forms.TableLayoutPanel()
        Me.lblApplicationName = New System.Windows.Forms.Label()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.lblCopyright = New System.Windows.Forms.Label()
        CType(Me.pbAppLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tlpLogo.SuspendLayout()
        Me.tlpTitle.SuspendLayout()
        Me.SuspendLayout()
        '
        'pbAppLogo
        '
        Me.pbAppLogo.BackgroundImage = CType(resources.GetObject("pbAppLogo.BackgroundImage"), System.Drawing.Image)
        Me.pbAppLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.pbAppLogo.Dock = System.Windows.Forms.DockStyle.Fill
        Me.pbAppLogo.Location = New System.Drawing.Point(4, 4)
        Me.pbAppLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.pbAppLogo.Name = "pbAppLogo"
        Me.pbAppLogo.Size = New System.Drawing.Size(459, 396)
        Me.pbAppLogo.TabIndex = 0
        Me.pbAppLogo.TabStop = False
        '
        'tlpLogo
        '
        Me.tlpLogo.ColumnCount = 2
        Me.tlpLogo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.98994!))
        Me.tlpLogo.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.01006!))
        Me.tlpLogo.Controls.Add(Me.pbAppLogo, 0, 0)
        Me.tlpLogo.Controls.Add(Me.tlpTitle, 1, 0)
        Me.tlpLogo.Location = New System.Drawing.Point(1, 0)
        Me.tlpLogo.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpLogo.Name = "tlpLogo"
        Me.tlpLogo.RowCount = 1
        Me.tlpLogo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLogo.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpLogo.Size = New System.Drawing.Size(719, 404)
        Me.tlpLogo.TabIndex = 1
        '
        'tlpTitle
        '
        Me.tlpTitle.ColumnCount = 1
        Me.tlpTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpTitle.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50.0!))
        Me.tlpTitle.Controls.Add(Me.lblApplicationName, 0, 0)
        Me.tlpTitle.Controls.Add(Me.lblVersion, 0, 1)
        Me.tlpTitle.Controls.Add(Me.lblCopyright, 0, 2)
        Me.tlpTitle.Location = New System.Drawing.Point(471, 4)
        Me.tlpTitle.Margin = New System.Windows.Forms.Padding(4)
        Me.tlpTitle.Name = "tlpTitle"
        Me.tlpTitle.RowCount = 3
        Me.tlpTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 88.99522!))
        Me.tlpTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.00478!))
        Me.tlpTitle.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 108.0!))
        Me.tlpTitle.Size = New System.Drawing.Size(244, 396)
        Me.tlpTitle.TabIndex = 1
        '
        'lblApplicationName
        '
        Me.lblApplicationName.AutoSize = True
        Me.lblApplicationName.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.lblApplicationName.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplicationName.Location = New System.Drawing.Point(4, 224)
        Me.lblApplicationName.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblApplicationName.Name = "lblApplicationName"
        Me.lblApplicationName.Size = New System.Drawing.Size(236, 32)
        Me.lblApplicationName.TabIndex = 0
        Me.lblApplicationName.Text = "Application Name"
        '
        'lblVersion
        '
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lblVersion.Font = New System.Drawing.Font("Segoe UI", 11.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVersion.Location = New System.Drawing.Point(4, 256)
        Me.lblVersion.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(236, 31)
        Me.lblVersion.TabIndex = 1
        Me.lblVersion.Text = "Version: "
        '
        'lblCopyright
        '
        Me.lblCopyright.AutoSize = True
        Me.lblCopyright.Font = New System.Drawing.Font("Segoe UI", 9.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCopyright.Location = New System.Drawing.Point(4, 297)
        Me.lblCopyright.Margin = New System.Windows.Forms.Padding(4, 10, 4, 0)
        Me.lblCopyright.Name = "lblCopyright"
        Me.lblCopyright.Size = New System.Drawing.Size(59, 15)
        Me.lblCopyright.TabIndex = 2
        Me.lblCopyright.Text = "Copyright"
        '
        'SplashScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Window
        Me.ClientSize = New System.Drawing.Size(717, 404)
        Me.ControlBox = False
        Me.Controls.Add(Me.tlpLogo)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "SplashScreen"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        CType(Me.pbAppLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tlpLogo.ResumeLayout(False)
        Me.tlpTitle.ResumeLayout(False)
        Me.tlpTitle.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents pbAppLogo As Windows.Forms.PictureBox
    Friend WithEvents tlpLogo As Windows.Forms.TableLayoutPanel
    Friend WithEvents tlpTitle As Windows.Forms.TableLayoutPanel
    Friend WithEvents lblApplicationName As Windows.Forms.Label
    Friend WithEvents lblVersion As Windows.Forms.Label
    Friend WithEvents lblCopyright As Windows.Forms.Label
End Class
