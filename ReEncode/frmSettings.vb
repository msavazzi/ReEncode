Imports System.ComponentModel
Imports System.IO

Public Class frmSettings

    Private Sub btScanRoot_Click(sender As Object, e As EventArgs) Handles btScanRoot.Click
        Dim folderBrowserDialog1 As FolderBrowserDialog
        folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        folderBrowserDialog1.Description = "Scan root"
        ' Do not allow the user to create New files via the FolderBrowserDialog.
        folderBrowserDialog1.ShowNewFolderButton = False
        ' Default to the My Documents folder.
        If Strings.Len(tbScanRoot.Text) = 0 Then
            folderBrowserDialog1.SelectedPath = Environment.SpecialFolder.MyComputer
        Else
            folderBrowserDialog1.SelectedPath = tbScanRoot.Text
        End If
        Dim result As DialogResult = folderBrowserDialog1.ShowDialog()


        If (result = DialogResult.OK) Then
            tbScanRoot.Text = folderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Sub btnOutputPath_Click(sender As Object, e As EventArgs) Handles btnOutputPath.Click
        Dim folderBrowserDialog1 As FolderBrowserDialog
        folderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        folderBrowserDialog1.Description = "Encoded files output"
        ' Do not allow the user to create New files via the FolderBrowserDialog.
        'folderBrowserDialog1.ShowNewFolderButton = False

        ' Default to the My Documents folder.
        If Strings.Len(tbOutputPath.Text) = 0 Then
            folderBrowserDialog1.SelectedPath = Environment.SpecialFolder.MyComputer
        Else
            folderBrowserDialog1.SelectedPath = tbOutputPath.Text
        End If
        Dim result As DialogResult = folderBrowserDialog1.ShowDialog()


        If (result = DialogResult.OK) Then
            tbOutputPath.Text = folderBrowserDialog1.SelectedPath
        End If

    End Sub

    Private Sub btnHandBrakeCLI_Click(sender As Object, e As EventArgs) Handles btnHandBrakeCLI.Click
        Dim openFileDialog1 As OpenFileDialog
        openFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        If Strings.Len(tbHandBrakeCLI.Text) = 0 Then
            openFileDialog1.InitialDirectory = Environment.SpecialFolder.ProgramFiles
            openFileDialog1.FileName = "HandBrakeCLI.exe"
        Else
            openFileDialog1.InitialDirectory = Path.GetFullPath(tbHandBrakeCLI.Text)
            openFileDialog1.FileName = Path.GetFileName(tbHandBrakeCLI.Text)
        End If
        openFileDialog1.AutoUpgradeEnabled = True
        openFileDialog1.CheckFileExists = True
        openFileDialog1.CheckPathExists = True
        openFileDialog1.Multiselect = False
        openFileDialog1.Title = "HandBrakeCLI executable"

        ' Display the openFile dialog.
        Dim result As DialogResult = openFileDialog1.ShowDialog()

        ' OK button was pressed.
        If (result = DialogResult.OK) Then
            tbHandBrakeCLI.Text = openFileDialog1.FileName
        End If
    End Sub

    Private Sub frmSettings_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tbAudioOpt.Text = My.Settings.AudioOpt
        tbVideoOpt.Text = My.Settings.VideoOpt
        tbSubsOpt.Text = My.Settings.SubsOpt
        tbRes1080.Text = My.Settings.Res1080
        tbRes480.Text = My.Settings.Res480
        tbRes576.Text = My.Settings.Res576
        tbRes720.Text = My.Settings.Res720
        tbResHi.Text = My.Settings.ResHi
        tbResSD.Text = My.Settings.ResSD
        tbOutputExt.Text = My.Settings.OutputExt
        tbOutputPath.Text = My.Settings.OutputPath
        tbHandBrakeCLI.Text = My.Settings.HandBrakeCLI
        tbScanRoot.Text = My.Settings.ScanRoot
        tbScanFilter.Text = My.Settings.ScanFilter
        chkReplace.Checked = My.Settings.ReplaceOri
        chkSmaller.Checked = My.Settings.OnlyIfSmaller
        chkSmaller.Enabled = chkReplace.Checked
        If My.Settings.OutputSel Then
            rbSame.Checked = True
        Else
            rbTemp.Checked = True
        End If
        tbOutputPath.Enabled = rbTemp.Checked
        btnOutputPath.Enabled = rbTemp.Checked
        chkReplace.Enabled = rbTemp.Checked
        chkSmaller.Enabled = rbTemp.Checked
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Me.Close()
    End Sub

    Private Sub btnOk_Click(sender As Object, e As EventArgs) Handles btnOk.Click
        reEncode.logger.Info("Save settings:")
        My.Settings.AudioOpt = tbAudioOpt.Text
        My.Settings.VideoOpt = tbVideoOpt.Text
        My.Settings.SubsOpt = tbSubsOpt.Text
        My.Settings.Res1080 = tbRes1080.Text
        My.Settings.Res480 = tbRes480.Text
        My.Settings.Res576 = tbRes576.Text
        My.Settings.Res720 = tbRes720.Text
        My.Settings.ResHi = tbResHi.Text
        My.Settings.ResSD = tbResSD.Text
        My.Settings.OutputExt = tbOutputExt.Text
        My.Settings.OutputPath = tbOutputPath.Text
        My.Settings.HandBrakeCLI = tbHandBrakeCLI.Text
        My.Settings.ScanRoot = tbScanRoot.Text
        My.Settings.ScanFilter = tbScanFilter.Text
        My.Settings.ReplaceOri = chkReplace.Checked
        My.Settings.OnlyIfSmaller = chkSmaller.Checked
        My.Settings.OutputSel = rbSame.Checked
        My.Settings.Save()
        reEncode.logger.Debug("Scan Root: " & My.Settings.ScanRoot)
        reEncode.logger.Debug("Scan Filter: " & My.Settings.ScanFilter)
        reEncode.logger.Debug("HandbrakeCLI: " & My.Settings.HandBrakeCLI)
        reEncode.logger.Debug("Output Path: " & My.Settings.OutputPath)
        reEncode.logger.Debug("Output Ext: " & My.Settings.OutputExt)
        reEncode.logger.Debug("Output Sel: " & My.Settings.OutputSel)
        reEncode.logger.Debug("Output Replace: " & My.Settings.ReplaceOri)
        reEncode.logger.Debug("Output Smaller: " & My.Settings.OnlyIfSmaller)
        reEncode.logger.Debug("Video Opt: " & My.Settings.VideoOpt)
        reEncode.logger.Debug("ResHi: " & My.Settings.ResHi)
        reEncode.logger.Debug("Res1080: " & My.Settings.Res1080)
        reEncode.logger.Debug("Res720: " & My.Settings.Res720)
        reEncode.logger.Debug("Res576: " & My.Settings.Res576)
        reEncode.logger.Debug("Res480: " & My.Settings.Res480)
        reEncode.logger.Debug("ResSD: " & My.Settings.ResSD)
        reEncode.logger.Debug("Audio Opt: " & My.Settings.AudioOpt)
        reEncode.logger.Debug("Subs Opt: " & My.Settings.SubsOpt)
        Me.Close()
    End Sub

    Private Sub tbScanFilter_Validating(sender As Object, e As CancelEventArgs) Handles tbScanFilter.Validating
        If tbScanFilter.Text.Length = 0 Then
            e.Cancel = True
            ErrorProvider1.SetError(tbScanFilter, "Filter is required.")
        End If
    End Sub

    Private Sub tbScanFilter_Validated(sender As Object, e As EventArgs) Handles tbScanFilter.Validated
        ErrorProvider1.SetError(tbScanFilter, "")
    End Sub

    Private Sub tbOutputPath_Validating(sender As Object, e As CancelEventArgs) Handles tbOutputPath.Validating
        If tbOutputPath.Text.Length = 0 Then
            e.Cancel = True
            ErrorProvider1.SetError(btnOutputPath, "Output path is required.")
        End If
    End Sub

    Private Sub tbOutputPath_Validated(sender As Object, e As EventArgs) Handles tbOutputPath.Validated
        ErrorProvider1.SetError(btnOutputPath, "")
    End Sub


    Private Sub tbHandBrakeCLI_Validating(sender As Object, e As CancelEventArgs) Handles tbHandBrakeCLI.Validating
        If tbHandBrakeCLI.Text.Length = 0 Then
            e.Cancel = True
            ErrorProvider1.SetError(btnHandBrakeCLI, "HandBrakeCLI path is mandatory.")
        End If
    End Sub

    Private Sub tbHandBrakeCLI_Validated(sender As Object, e As EventArgs) Handles tbHandBrakeCLI.Validated
        ErrorProvider1.SetError(btnHandBrakeCLI, "")
    End Sub

    Private Sub tbScanRoot_Validating(sender As Object, e As CancelEventArgs) Handles tbScanRoot.Validating
        If tbScanRoot.Text.Length = 0 Then
            e.Cancel = True
            ErrorProvider1.SetError(btScanRoot, "Root scan path is mandatory.")
        End If

    End Sub

    Private Sub tbScanRoot_Validated(sender As Object, e As EventArgs) Handles tbScanRoot.Validated
        ErrorProvider1.SetError(btScanRoot, "")
    End Sub

    Private Sub chkReplace_CheckedChanged(sender As Object, e As EventArgs) Handles chkReplace.CheckedChanged
        chkSmaller.Enabled = chkReplace.Checked
    End Sub

    Private Sub rbTemp_CheckedChanged(sender As Object, e As EventArgs) Handles rbTemp.CheckedChanged
        tbOutputPath.Enabled = rbTemp.Checked
        btnOutputPath.Enabled = rbTemp.Checked
        chkReplace.Enabled = rbTemp.Checked
        chkSmaller.Enabled = rbTemp.Checked
    End Sub

End Class