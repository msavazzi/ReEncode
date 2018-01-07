<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSettings
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSettings))
        Me.btnOk = New System.Windows.Forms.Button()
        Me.btnCancel = New System.Windows.Forms.Button()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnOutputPath = New System.Windows.Forms.Button()
        Me.chkSmaller = New System.Windows.Forms.CheckBox()
        Me.tbOutputPath = New System.Windows.Forms.TextBox()
        Me.chkReplace = New System.Windows.Forms.CheckBox()
        Me.rbTemp = New System.Windows.Forms.RadioButton()
        Me.rbSame = New System.Windows.Forms.RadioButton()
        Me.tbOutputExt = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.btScanRoot = New System.Windows.Forms.Button()
        Me.tbScanRoot = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.tbScanFilter = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.btnHandBrakeCLI = New System.Windows.Forms.Button()
        Me.tbHandBrakeCLI = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.tbSubsOpt = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.tbAudioOpt = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.tbVideoOpt = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.tbResSD = New System.Windows.Forms.TextBox()
        Me.tbRes720 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.tbRes480 = New System.Windows.Forms.TextBox()
        Me.tbRes1080 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.tbRes576 = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.tbResHi = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnOk
        '
        Me.btnOk.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnOk.Location = New System.Drawing.Point(0, 0)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(125, 33)
        Me.btnOk.TabIndex = 0
        Me.btnOk.Text = "Ok"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'btnCancel
        '
        Me.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnCancel.Dock = System.Windows.Forms.DockStyle.Fill
        Me.btnCancel.Location = New System.Drawing.Point(0, 0)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(132, 33)
        Me.btnCancel.TabIndex = 1
        Me.btnCancel.Text = "Cancel"
        Me.btnCancel.UseVisualStyleBackColor = True
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.IsSplitterFixed = True
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox6)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox7)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox4)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox5)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox2)
        Me.SplitContainer1.Panel1.Controls.Add(Me.GroupBox1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(650, 315)
        Me.SplitContainer1.SplitterDistance = 278
        Me.SplitContainer1.TabIndex = 2
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.Panel1)
        Me.GroupBox6.Controls.Add(Me.tbOutputExt)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Location = New System.Drawing.Point(326, 118)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(314, 109)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Output Options"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnOutputPath)
        Me.Panel1.Controls.Add(Me.chkSmaller)
        Me.Panel1.Controls.Add(Me.tbOutputPath)
        Me.Panel1.Controls.Add(Me.chkReplace)
        Me.Panel1.Controls.Add(Me.rbTemp)
        Me.Panel1.Controls.Add(Me.rbSame)
        Me.Panel1.Location = New System.Drawing.Point(9, 44)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(306, 60)
        Me.Panel1.TabIndex = 15
        '
        'btnOutputPath
        '
        Me.btnOutputPath.Location = New System.Drawing.Point(278, 15)
        Me.btnOutputPath.Name = "btnOutputPath"
        Me.btnOutputPath.Size = New System.Drawing.Size(24, 20)
        Me.btnOutputPath.TabIndex = 18
        Me.btnOutputPath.Text = "..."
        Me.btnOutputPath.UseVisualStyleBackColor = True
        '
        'chkSmaller
        '
        Me.chkSmaller.AutoSize = True
        Me.chkSmaller.Location = New System.Drawing.Point(212, 41)
        Me.chkSmaller.Name = "chkSmaller"
        Me.chkSmaller.Size = New System.Drawing.Size(90, 17)
        Me.chkSmaller.TabIndex = 13
        Me.chkSmaller.Text = "Only if smaller"
        Me.chkSmaller.UseVisualStyleBackColor = True
        '
        'tbOutputPath
        '
        Me.tbOutputPath.Location = New System.Drawing.Point(104, 15)
        Me.tbOutputPath.Name = "tbOutputPath"
        Me.tbOutputPath.Size = New System.Drawing.Size(173, 20)
        Me.tbOutputPath.TabIndex = 17
        '
        'chkReplace
        '
        Me.chkReplace.AutoSize = True
        Me.chkReplace.Location = New System.Drawing.Point(104, 41)
        Me.chkReplace.Name = "chkReplace"
        Me.chkReplace.Size = New System.Drawing.Size(102, 17)
        Me.chkReplace.TabIndex = 13
        Me.chkReplace.Text = "Replace original"
        Me.chkReplace.UseVisualStyleBackColor = True
        '
        'rbTemp
        '
        Me.rbTemp.AutoSize = True
        Me.rbTemp.Location = New System.Drawing.Point(3, 16)
        Me.rbTemp.Name = "rbTemp"
        Me.rbTemp.Size = New System.Drawing.Size(104, 17)
        Me.rbTemp.TabIndex = 15
        Me.rbTemp.TabStop = True
        Me.rbTemp.Text = "Temporary folder"
        Me.rbTemp.UseVisualStyleBackColor = True
        '
        'rbSame
        '
        Me.rbSame.AutoSize = True
        Me.rbSame.Location = New System.Drawing.Point(3, -2)
        Me.rbSame.Name = "rbSame"
        Me.rbSame.Size = New System.Drawing.Size(118, 17)
        Me.rbSame.TabIndex = 16
        Me.rbSame.TabStop = True
        Me.rbSame.Text = "Same as original file"
        Me.rbSame.UseVisualStyleBackColor = True
        '
        'tbOutputExt
        '
        Me.tbOutputExt.Location = New System.Drawing.Point(110, 18)
        Me.tbOutputExt.Name = "tbOutputExt"
        Me.tbOutputExt.Size = New System.Drawing.Size(55, 20)
        Me.tbOutputExt.TabIndex = 11
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 21)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(98, 13)
        Me.Label10.TabIndex = 1
        Me.Label10.Text = "Filename Extension"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.btScanRoot)
        Me.GroupBox7.Controls.Add(Me.tbScanRoot)
        Me.GroupBox7.Controls.Add(Me.Label13)
        Me.GroupBox7.Controls.Add(Me.tbScanFilter)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 181)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(308, 80)
        Me.GroupBox7.TabIndex = 1
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Scan Settings"
        '
        'btScanRoot
        '
        Me.btScanRoot.Location = New System.Drawing.Point(276, 52)
        Me.btScanRoot.Name = "btScanRoot"
        Me.btScanRoot.Size = New System.Drawing.Size(24, 20)
        Me.btScanRoot.TabIndex = 24
        Me.btScanRoot.Text = "..."
        Me.btScanRoot.UseVisualStyleBackColor = True
        '
        'tbScanRoot
        '
        Me.tbScanRoot.Location = New System.Drawing.Point(70, 52)
        Me.tbScanRoot.Name = "tbScanRoot"
        Me.tbScanRoot.Size = New System.Drawing.Size(206, 20)
        Me.tbScanRoot.TabIndex = 23
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 55)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(58, 13)
        Me.Label13.TabIndex = 22
        Me.Label13.Text = "Scan Root"
        '
        'tbScanFilter
        '
        Me.tbScanFilter.Location = New System.Drawing.Point(70, 19)
        Me.tbScanFilter.Name = "tbScanFilter"
        Me.tbScanFilter.Size = New System.Drawing.Size(162, 20)
        Me.tbScanFilter.TabIndex = 4
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 22)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(54, 13)
        Me.Label14.TabIndex = 3
        Me.Label14.Text = "Scan filter"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.btnHandBrakeCLI)
        Me.GroupBox4.Controls.Add(Me.tbHandBrakeCLI)
        Me.GroupBox4.Controls.Add(Me.Label12)
        Me.GroupBox4.Location = New System.Drawing.Point(326, 233)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(314, 49)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "General Configuration"
        '
        'btnHandBrakeCLI
        '
        Me.btnHandBrakeCLI.Location = New System.Drawing.Point(287, 20)
        Me.btnHandBrakeCLI.Name = "btnHandBrakeCLI"
        Me.btnHandBrakeCLI.Size = New System.Drawing.Size(24, 20)
        Me.btnHandBrakeCLI.TabIndex = 15
        Me.btnHandBrakeCLI.Text = "..."
        Me.btnHandBrakeCLI.UseVisualStyleBackColor = True
        '
        'tbHandBrakeCLI
        '
        Me.tbHandBrakeCLI.Location = New System.Drawing.Point(114, 20)
        Me.tbHandBrakeCLI.Name = "tbHandBrakeCLI"
        Me.tbHandBrakeCLI.Size = New System.Drawing.Size(172, 20)
        Me.tbHandBrakeCLI.TabIndex = 14
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 22)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(102, 13)
        Me.Label12.TabIndex = 13
        Me.Label12.Text = "HandBrakeCLI Path"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.tbSubsOpt)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(326, 65)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(314, 47)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Subtitle Options"
        '
        'tbSubsOpt
        '
        Me.tbSubsOpt.Location = New System.Drawing.Point(90, 19)
        Me.tbSubsOpt.Name = "tbSubsOpt"
        Me.tbSubsOpt.Size = New System.Drawing.Size(206, 20)
        Me.tbSubsOpt.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(6, 22)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(78, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Common Audio"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.tbAudioOpt)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Location = New System.Drawing.Point(326, 12)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(314, 47)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Audio Options"
        '
        'tbAudioOpt
        '
        Me.tbAudioOpt.Location = New System.Drawing.Point(90, 19)
        Me.tbAudioOpt.Name = "tbAudioOpt"
        Me.tbAudioOpt.Size = New System.Drawing.Size(206, 20)
        Me.tbAudioOpt.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(78, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Common Audio"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.tbVideoOpt)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(308, 163)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Video Options"
        '
        'tbVideoOpt
        '
        Me.tbVideoOpt.Location = New System.Drawing.Point(90, 19)
        Me.tbVideoOpt.Name = "tbVideoOpt"
        Me.tbVideoOpt.Size = New System.Drawing.Size(206, 20)
        Me.tbVideoOpt.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Common Video"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.tbResSD)
        Me.GroupBox3.Controls.Add(Me.tbRes720)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.tbRes480)
        Me.GroupBox3.Controls.Add(Me.tbRes1080)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.tbRes576)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.tbResHi)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(20, 46)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(250, 107)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Video Resulution dependant"
        '
        'tbResSD
        '
        Me.tbResSD.Location = New System.Drawing.Point(171, 74)
        Me.tbResSD.Name = "tbResSD"
        Me.tbResSD.Size = New System.Drawing.Size(53, 20)
        Me.tbResSD.TabIndex = 8
        '
        'tbRes720
        '
        Me.tbRes720.Location = New System.Drawing.Point(57, 74)
        Me.tbRes720.Name = "tbRes720"
        Me.tbRes720.Size = New System.Drawing.Size(53, 20)
        Me.tbRes720.TabIndex = 5
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(134, 77)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(22, 13)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "SD"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(20, 77)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(25, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "720"
        '
        'tbRes480
        '
        Me.tbRes480.Location = New System.Drawing.Point(171, 48)
        Me.tbRes480.Name = "tbRes480"
        Me.tbRes480.Size = New System.Drawing.Size(53, 20)
        Me.tbRes480.TabIndex = 7
        '
        'tbRes1080
        '
        Me.tbRes1080.Location = New System.Drawing.Point(57, 48)
        Me.tbRes1080.Name = "tbRes1080"
        Me.tbRes1080.Size = New System.Drawing.Size(53, 20)
        Me.tbRes1080.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(134, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(25, 13)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "480"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(20, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "1080"
        '
        'tbRes576
        '
        Me.tbRes576.Location = New System.Drawing.Point(171, 22)
        Me.tbRes576.Name = "tbRes576"
        Me.tbRes576.Size = New System.Drawing.Size(53, 20)
        Me.tbRes576.TabIndex = 6
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(134, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(25, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "576"
        '
        'tbResHi
        '
        Me.tbResHi.Location = New System.Drawing.Point(57, 22)
        Me.tbResHi.Name = "tbResHi"
        Me.tbResHi.Size = New System.Drawing.Size(53, 20)
        Me.tbResHi.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(20, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(17, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Hi"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.IsSplitterFixed = True
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(650, 33)
        Me.SplitContainer2.SplitterDistance = 385
        Me.SplitContainer2.TabIndex = 0
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.IsSplitterFixed = True
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.btnOk)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.btnCancel)
        Me.SplitContainer3.Size = New System.Drawing.Size(261, 33)
        Me.SplitContainer3.SplitterDistance = 125
        Me.SplitContainer3.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'frmSettings
        '
        Me.AcceptButton = Me.btnOk
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.btnCancel
        Me.ClientSize = New System.Drawing.Size(650, 315)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSettings"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Settings"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btnOk As Button
    Friend WithEvents btnCancel As Button
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents tbVideoOpt As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents tbResSD As TextBox
    Friend WithEvents tbRes720 As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents tbRes480 As TextBox
    Friend WithEvents tbRes1080 As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents tbRes576 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents tbResHi As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents tbOutputExt As TextBox
    Friend WithEvents Label10 As Label
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents tbSubsOpt As TextBox
    Friend WithEvents Label9 As Label
    Friend WithEvents tbAudioOpt As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents btnHandBrakeCLI As Button
    Friend WithEvents tbHandBrakeCLI As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents tbScanFilter As TextBox
    Friend WithEvents Label14 As Label
    Friend WithEvents ErrorProvider1 As ErrorProvider
    Friend WithEvents btScanRoot As Button
    Friend WithEvents tbScanRoot As TextBox
    Friend WithEvents Label13 As Label
    Friend WithEvents chkSmaller As CheckBox
    Friend WithEvents chkReplace As CheckBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnOutputPath As Button
    Friend WithEvents tbOutputPath As TextBox
    Friend WithEvents rbTemp As RadioButton
    Friend WithEvents rbSame As RadioButton
End Class
