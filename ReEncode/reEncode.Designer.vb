<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class reEncode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(reEncode))
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.btnSkipOne = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.btnProcessOne = New System.Windows.Forms.Button()
        Me.btnConvert = New System.Windows.Forms.Button()
        Me.btnMedia = New System.Windows.Forms.Button()
        Me.btnScan = New System.Windows.Forms.Button()
        Me.SplitContainer4 = New System.Windows.Forms.SplitContainer()
        Me.btnSettings = New System.Windows.Forms.Button()
        Me.btnClearOne = New System.Windows.Forms.Button()
        Me.btnClearErrors = New System.Windows.Forms.Button()
        Me.btnClearStatus = New System.Windows.Forms.Button()
        Me.btnPause = New System.Windows.Forms.Button()
        Me.dgvFileProperties = New System.Windows.Forms.DataGridView()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.tsslStatus = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tspbComplete = New System.Windows.Forms.ToolStripProgressBar()
        Me.tsslFiles = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslPercentage = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslFPS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslAvgFPS = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tsslETA = New System.Windows.Forms.ToolStripStatusLabel()
        Me.tssslRows = New System.Windows.Forms.ToolStripStatusLabel()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer4.Panel2.SuspendLayout()
        Me.SplitContainer4.SuspendLayout()
        CType(Me.dgvFileProperties, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.SplitContainer1)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.StatusStrip1)
        Me.SplitContainer2.Panel2MinSize = 19
        Me.SplitContainer2.Size = New System.Drawing.Size(1057, 460)
        Me.SplitContainer2.SplitterDistance = 431
        Me.SplitContainer2.TabIndex = 1
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer1.Panel1MinSize = 35
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.dgvFileProperties)
        Me.SplitContainer1.Panel2.Padding = New System.Windows.Forms.Padding(5)
        Me.SplitContainer1.Size = New System.Drawing.Size(1057, 431)
        Me.SplitContainer1.SplitterDistance = 35
        Me.SplitContainer1.TabIndex = 1
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel1
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnSkipOne)
        Me.SplitContainer3.Panel1.Controls.Add(Me.Button1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnProcessOne)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnConvert)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnMedia)
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnScan)
        Me.SplitContainer3.Panel1MinSize = 528
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.SplitContainer4)
        Me.SplitContainer3.Size = New System.Drawing.Size(1057, 35)
        Me.SplitContainer3.SplitterDistance = 529
        Me.SplitContainer3.TabIndex = 5
        '
        'btnSkipOne
        '
        Me.btnSkipOne.Location = New System.Drawing.Point(426, 2)
        Me.btnSkipOne.Name = "btnSkipOne"
        Me.btnSkipOne.Size = New System.Drawing.Size(100, 31)
        Me.btnSkipOne.TabIndex = 4
        Me.btnSkipOne.Text = "Skip One"
        Me.btnSkipOne.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(426, 3)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(100, 31)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Process One"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'btnProcessOne
        '
        Me.btnProcessOne.Location = New System.Drawing.Point(320, 2)
        Me.btnProcessOne.Name = "btnProcessOne"
        Me.btnProcessOne.Size = New System.Drawing.Size(100, 31)
        Me.btnProcessOne.TabIndex = 4
        Me.btnProcessOne.Text = "Process One"
        Me.btnProcessOne.UseVisualStyleBackColor = True
        '
        'btnConvert
        '
        Me.btnConvert.Location = New System.Drawing.Point(214, 2)
        Me.btnConvert.Name = "btnConvert"
        Me.btnConvert.Size = New System.Drawing.Size(100, 31)
        Me.btnConvert.TabIndex = 4
        Me.btnConvert.Text = "Convert Media"
        Me.btnConvert.UseVisualStyleBackColor = True
        '
        'btnMedia
        '
        Me.btnMedia.Location = New System.Drawing.Point(108, 2)
        Me.btnMedia.Name = "btnMedia"
        Me.btnMedia.Size = New System.Drawing.Size(100, 31)
        Me.btnMedia.TabIndex = 2
        Me.btnMedia.Text = "Media Properties"
        Me.btnMedia.UseVisualStyleBackColor = True
        '
        'btnScan
        '
        Me.btnScan.Location = New System.Drawing.Point(2, 2)
        Me.btnScan.Name = "btnScan"
        Me.btnScan.Size = New System.Drawing.Size(100, 31)
        Me.btnScan.TabIndex = 3
        Me.btnScan.Text = "Scan"
        Me.btnScan.UseVisualStyleBackColor = True
        '
        'SplitContainer4
        '
        Me.SplitContainer4.Dock = System.Windows.Forms.DockStyle.Right
        Me.SplitContainer4.FixedPanel = System.Windows.Forms.FixedPanel.Panel2
        Me.SplitContainer4.IsSplitterFixed = True
        Me.SplitContainer4.Location = New System.Drawing.Point(-9, 0)
        Me.SplitContainer4.Name = "SplitContainer4"
        '
        'SplitContainer4.Panel2
        '
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnSettings)
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnClearOne)
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnClearErrors)
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnClearStatus)
        Me.SplitContainer4.Panel2.Controls.Add(Me.btnPause)
        Me.SplitContainer4.Panel2MinSize = 245
        Me.SplitContainer4.Size = New System.Drawing.Size(533, 35)
        Me.SplitContainer4.SplitterDistance = 119
        Me.SplitContainer4.TabIndex = 0
        '
        'btnSettings
        '
        Me.btnSettings.Image = CType(resources.GetObject("btnSettings.Image"), System.Drawing.Image)
        Me.btnSettings.Location = New System.Drawing.Point(371, 3)
        Me.btnSettings.Name = "btnSettings"
        Me.btnSettings.Size = New System.Drawing.Size(36, 31)
        Me.btnSettings.TabIndex = 3
        Me.btnSettings.UseVisualStyleBackColor = True
        '
        'btnClearOne
        '
        Me.btnClearOne.Location = New System.Drawing.Point(3, 3)
        Me.btnClearOne.Name = "btnClearOne"
        Me.btnClearOne.Size = New System.Drawing.Size(86, 31)
        Me.btnClearOne.TabIndex = 4
        Me.btnClearOne.Text = "Clear One"
        Me.btnClearOne.UseVisualStyleBackColor = True
        '
        'btnClearErrors
        '
        Me.btnClearErrors.Location = New System.Drawing.Point(95, 3)
        Me.btnClearErrors.Name = "btnClearErrors"
        Me.btnClearErrors.Size = New System.Drawing.Size(86, 31)
        Me.btnClearErrors.TabIndex = 4
        Me.btnClearErrors.Text = "Clear Errors"
        Me.btnClearErrors.UseVisualStyleBackColor = True
        '
        'btnClearStatus
        '
        Me.btnClearStatus.Location = New System.Drawing.Point(187, 3)
        Me.btnClearStatus.Name = "btnClearStatus"
        Me.btnClearStatus.Size = New System.Drawing.Size(86, 31)
        Me.btnClearStatus.TabIndex = 4
        Me.btnClearStatus.Text = "Clear All"
        Me.btnClearStatus.UseVisualStyleBackColor = True
        '
        'btnPause
        '
        Me.btnPause.Location = New System.Drawing.Point(279, 3)
        Me.btnPause.Name = "btnPause"
        Me.btnPause.Size = New System.Drawing.Size(86, 31)
        Me.btnPause.TabIndex = 2
        Me.btnPause.Text = "Pause"
        Me.btnPause.UseVisualStyleBackColor = True
        '
        'dgvFileProperties
        '
        Me.dgvFileProperties.AllowUserToAddRows = False
        Me.dgvFileProperties.AllowUserToDeleteRows = False
        Me.dgvFileProperties.AllowUserToOrderColumns = True
        Me.dgvFileProperties.AllowUserToResizeRows = False
        Me.dgvFileProperties.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.dgvFileProperties.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvFileProperties.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvFileProperties.Location = New System.Drawing.Point(5, 5)
        Me.dgvFileProperties.Margin = New System.Windows.Forms.Padding(3, 3, 3, 0)
        Me.dgvFileProperties.Name = "dgvFileProperties"
        Me.dgvFileProperties.ReadOnly = True
        Me.dgvFileProperties.Size = New System.Drawing.Size(1047, 382)
        Me.dgvFileProperties.TabIndex = 0
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslStatus, Me.tspbComplete, Me.tsslFiles, Me.tsslPercentage, Me.tsslFPS, Me.tsslAvgFPS, Me.tsslETA, Me.tssslRows})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 3)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(1057, 22)
        Me.StatusStrip1.TabIndex = 2
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslStatus
        '
        Me.tsslStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tsslStatus.Name = "tsslStatus"
        Me.tsslStatus.Size = New System.Drawing.Size(120, 17)
        Me.tsslStatus.Text = "ToolStripStatusLabel1"
        '
        'tspbComplete
        '
        Me.tspbComplete.Name = "tspbComplete"
        Me.tspbComplete.Size = New System.Drawing.Size(100, 16)
        '
        'tsslFiles
        '
        Me.tsslFiles.Name = "tsslFiles"
        Me.tsslFiles.Size = New System.Drawing.Size(468, 17)
        Me.tsslFiles.Spring = True
        Me.tsslFiles.Text = "ToolStripStatusLabel1"
        Me.tsslFiles.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tsslPercentage
        '
        Me.tsslPercentage.AutoSize = False
        Me.tsslPercentage.Name = "tsslPercentage"
        Me.tsslPercentage.Size = New System.Drawing.Size(60, 17)
        Me.tsslPercentage.Text = "000.00%"
        Me.tsslPercentage.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsslFPS
        '
        Me.tsslFPS.AutoSize = False
        Me.tsslFPS.Name = "tsslFPS"
        Me.tsslFPS.Size = New System.Drawing.Size(65, 17)
        Me.tsslFPS.Text = "000.00 fps"
        Me.tsslFPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsslAvgFPS
        '
        Me.tsslAvgFPS.AutoSize = False
        Me.tsslAvgFPS.Name = "tsslAvgFPS"
        Me.tsslAvgFPS.Size = New System.Drawing.Size(95, 17)
        Me.tsslAvgFPS.Text = "AVG 000.00 fps"
        Me.tsslAvgFPS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tsslETA
        '
        Me.tsslETA.AutoSize = False
        Me.tsslETA.Name = "tsslETA"
        Me.tsslETA.Size = New System.Drawing.Size(75, 17)
        Me.tsslETA.Text = " 00h00m00s"
        Me.tsslETA.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tssslRows
        '
        Me.tssslRows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text
        Me.tssslRows.Name = "tssslRows"
        Me.tssslRows.Size = New System.Drawing.Size(57, 17)
        Me.tssslRows.Text = "tssslRows"
        Me.tssslRows.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'reEncode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1057, 460)
        Me.Controls.Add(Me.SplitContainer2)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "reEncode"
        Me.Text = "ReEncode"
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        Me.SplitContainer2.Panel2.PerformLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        Me.SplitContainer4.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer4.ResumeLayout(False)
        CType(Me.dgvFileProperties, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SDurationDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SizeBDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FileNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VideoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SAudioDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SSubtitlesDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btnClearStatus As Button
    Friend WithEvents btnSettings As Button
    Friend WithEvents btnPause As Button
    Friend WithEvents dgvFileProperties As DataGridView
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tsslStatus As ToolStripStatusLabel
    Friend WithEvents tspbComplete As ToolStripProgressBar
    Friend WithEvents tsslFiles As ToolStripStatusLabel
    Friend WithEvents tsslPercentage As ToolStripStatusLabel
    Friend WithEvents tsslFPS As ToolStripStatusLabel
    Friend WithEvents tsslAvgFPS As ToolStripStatusLabel
    Friend WithEvents tsslETA As ToolStripStatusLabel
    Friend WithEvents tssslRows As ToolStripStatusLabel
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents btnConvert As Button
    Friend WithEvents btnMedia As Button
    Friend WithEvents btnScan As Button
    Friend WithEvents SplitContainer4 As SplitContainer
    Friend WithEvents btnProcessOne As Button
    Friend WithEvents btnClearOne As Button
    Friend WithEvents btnSkipOne As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents btnClearErrors As Button
End Class
