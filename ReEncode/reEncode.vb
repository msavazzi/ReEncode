Option Explicit On
Option Strict On

Imports System.ComponentModel
Imports System.IO
Imports System.Xml.Serialization
Imports MediaInfo
Imports NLog
Imports System.Threading
Imports System.Text.RegularExpressions
Imports System.Globalization
Imports ReEncode.SortableBindingList

Public Class reEncode
    '    Private _Movies As New Movies
    Private _Movies As New Movies()
    Private Dirs As New List(Of String)
    Private _Utils As New Utils
    Private Shared _Pause As Boolean

    Private Shared HandbrakeOutputRegex As Regex = New Regex("Encoding:.*?, (\d{1,3}\.\d{1,2}) %( \((\d{1,4}\.\d{1,2}) fps, avg (\d{1,4}\.\d{1,2}) fps, ETA (\d{2}h\d{2}m\d{2}s)\))?", RegexOptions.Compiled)
    Private Shared _process As Process
    Private Shared _StartInfo As ProcessStartInfo
    Private Shared _out As String
    Private Shared _status As New ConversionStatus
    Private Shared _tcs As TaskCompletionSource(Of Integer)
    Private Shared _Error As New List(Of String)
    Private Shared _pool As New Mutex()
    Private Shared _Converting As Boolean
    Private Shared _WorkingMovie As Movie
    Private Shared _ScanChanged As Boolean = False

    Public Shared logger As Logger = NLog.LogManager.GetCurrentClassLogger()

    Private WithEvents _bwDirScan As New BackgroundWorker
    Private WithEvents _bwFileScan As New BackgroundWorker
    Private WithEvents _bwScanMedia As New BackgroundWorker

#Region "_bwDirScan"
    Private Sub _bwDirScan_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _bwDirScan.DoWork
        If (_bwFileScan.CancellationPending = True) Then
            e.Cancel = True
            e.Result = Nothing
            Exit Sub
        Else
            If Directory.Exists(My.Settings.ScanRoot) Then
                DirSearch(My.Settings.ScanRoot, e)
            Else
                Dim style = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical
                MsgBox("Scan folder does not exist", style, "Critical Error")
                logger.Debug("Abort - Scan folder missing: " & My.Settings.ScanRoot)
            End If
        End If
    End Sub

    Private Sub _bwDirScan_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles _bwDirScan.ProgressChanged
        tsslStatus.Text = "Directory scan - " & Strings.Right("000000" & Dirs.Count, 6)
        Application.DoEvents()
    End Sub

    Private Sub _bwDirScan_RunWorkerCompleted(ByVal sender As System.Object,
    ByVal e As RunWorkerCompletedEventArgs) Handles _bwDirScan.RunWorkerCompleted
        If e.Cancelled = True Then
            logger.Info("_bwDirScan Cancelled")
            tsslStatus.Text = "Canceled!"
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
            If e.Result IsNot Nothing Then
                logger.Debug(CType(e.Result, Exception).Message)
                tsslStatus.Text = "Cancelled Error: " & CType(e.Result, Exception).Message
            End If
        ElseIf e.Error IsNot Nothing Then
            logger.Debug(e.Error.Message)
            tsslStatus.Text = "Error: " & e.Error.Message
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
        Else
            logger.Info("_bwDirScan Completed")
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
            tsslStatus.Text = "File scan"
            tspbComplete.Maximum = Dirs.Count + 1
            Application.DoEvents()
            _Pause = False
            If Not _bwFileScan.IsBusy Then
                logger.Trace("launching _bwFileScan")
                tspbComplete.Value = 0
                btnClearStatus.Enabled = False
                btnPause.Enabled = True
                ' Start the asynchronous operation.
                _bwFileScan.RunWorkerAsync()
            Else
                logger.Error("_bwFileScan IsBusy ")
            End If
        End If
    End Sub

#End Region

#Region "_bwFileScan"
    Private Sub _bwFileScan_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _bwFileScan.DoWork
        Dim aMovie As Movie

        For Each aD In Dirs
            If (_bwFileScan.CancellationPending = True) Then
                logger.Trace("_bwFileScan.CancellationPending")
                e.Cancel = True
                e.Result = Nothing
                Exit For
            Else
                logger.Trace("aD: " & aD)
                Try
                    For Each file In Directory.GetFiles(aD, My.Settings.ScanFilter)
                        logger.Trace(file)
                        aMovie = New Movie
                        aMovie._FileName = file
                        aMovie._Name = Path.GetFileName(file)
                        _Movies.Movies.Add(aMovie)
                    Next
                Catch ex As UnauthorizedAccessException
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                    logger.Debug("Non blocking, Continue")
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                    logger.Debug("Aborting!")
                    e.Cancel = True
                    e.Result = ex
                End Try
                _bwFileScan.ReportProgress(1)
                Application.DoEvents()
            End If
            While _Pause
                Threading.Thread.Sleep(100)
                Application.DoEvents()
            End While
        Next
    End Sub

    Private Sub _bwFileScan_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles _bwFileScan.ProgressChanged
        tspbComplete.Value = tspbComplete.Value + 1
        Application.DoEvents()
    End Sub

    Private Sub _bwFileScan_RunWorkerCompleted(ByVal sender As System.Object,
    ByVal e As RunWorkerCompletedEventArgs) Handles _bwFileScan.RunWorkerCompleted
        If e.Cancelled = True Then
            logger.Info("_bwFileScan Cancelled")
            tsslStatus.Text = "Canceled!"
            btnClearStatus.Enabled = True
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
            If e.Result IsNot Nothing Then
                logger.Debug(CType(e.Result, Exception).Message)
                tsslStatus.Text = "Cancelled Error: " & CType(e.Result, Exception).Message
            End If
        ElseIf e.Error IsNot Nothing Then
            logger.Debug(e.Error.Message)
            tsslStatus.Text = "Error: " & e.Error.Message
            btnClearStatus.Enabled = True
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
        Else
            logger.Info("_bwFileScan Completed")
            btnClearStatus.Enabled = True
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
            tspbComplete.Value = Dirs.Count + 1
            dgvFilePropertiesRefresh(, True)
            tsslStatus.Text = "Saving..."
            Application.DoEvents()
            SaveStatus()
            tsslStatus.Text = "Status"
            tspbComplete.Value = 0
            btnMedia.Enabled = True
            btnProcessOne.Enabled = True
            btnSettings.Enabled = True
            tssslRows.Text = "Rows: " & dgvFileProperties.RowCount
            Application.DoEvents()
            If CheckRows(False) Then
                Dim style = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical
                MsgBox("Warning duplicate file names found. Will overwrite converted files", style, "Error")
            End If
        End If
    End Sub
#End Region

#Region "_bwScanMedia"
    Private Sub DoScanMedia(ByRef aMovie As Movie)
        Dim aMedia As MediaInfoWrapper
        Dim aAudio As AudioTrack
        Dim aSub As SubtitleTrack

        With aMovie
            aMedia = New MediaInfoWrapper(aMovie._FileName)
            .Duration = aMedia.Duration
            .Size = aMedia.Size
            ._Scanned = True
            ._Width = aMedia.VideoStreams(0).Width
            ._Height = aMedia.VideoStreams(0).Height
            ._Interlaced = aMedia.VideoStreams(0).Interlaced
            ._Codec = aMedia.VideoStreams(0).CodecName
            ._VideoCount = aMedia.VideoStreams.Count
            For Each aT In aMedia.AudioStreams
                aAudio = New AudioTrack
                With aAudio
                    .Bitrate = aT.Bitrate
                    .Codec = aT.Codec
                    .CodecFriendly = aT.CodecFriendly
                End With
                .Audio.Add(aAudio)
            Next
            For Each aSu In aMedia.Subtitles
                aSub = New SubtitleTrack
                With aSub
                    .Id = aSu.Id
                    .Language = aSu.Language
                    .Name = aSu.Name
                End With
                .Subtitle.Add(aSub)
            Next
        End With
    End Sub

    Private Sub _bwScanMedia_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles _bwScanMedia.DoWork
        Dim aMovie As Movie

        For Each aMovie In _Movies.Movies
            If (_bwScanMedia.CancellationPending = True) Then
                logger.Trace("_bwScanMedia.CancellationPending")
                e.Cancel = True
                e.Result = Nothing
                Exit For
            Else
                While _Pause
                    Threading.Thread.Sleep(100)
                    Application.DoEvents()
                End While
                With aMovie
                    logger.Trace(.Name & " Is scanned: " & ._Scanned)
                    If Not aMovie._Scanned Then
                        Try
                            DoScanMedia(aMovie)
                            _ScanChanged = True
                        Catch ex As Exception
                            logger.Error(ex, New StackFrame().GetMethod().Name)
                            logger.Debug("Skipping file")
                            ._Scanned = False
                        End Try
                        _bwScanMedia.ReportProgress(1)
                        Application.DoEvents()
                    End If
                End With
            End If
        Next
    End Sub

    Private Sub _bwScanMedia_ProgressChanged(ByVal sender As Object, ByVal e As ProgressChangedEventArgs) Handles _bwScanMedia.ProgressChanged
        tspbComplete.Value = tspbComplete.Value + 1
        If _ScanChanged Then
            dgvFilePropertiesRefresh()
            _ScanChanged = False
        End If
        If ((tspbComplete.Value \ 10) * 10) = tspbComplete.Value Then
            tsslStatus.Text = "Saving..."
            Application.DoEvents()
            SaveStatus()
            tsslStatus.Text = "Media properties scan"
        End If
        Application.DoEvents()
    End Sub

    Private Sub _bwScanMedia_RunWorkerCompleted(ByVal sender As System.Object,
    ByVal e As RunWorkerCompletedEventArgs) Handles _bwScanMedia.RunWorkerCompleted
        If e.Cancelled = True Then
            logger.Info("_bwScanMedia Cancelled")
            tsslStatus.Text = "Canceled!"
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
            If e.Result IsNot Nothing Then
                logger.Debug(CType(e.Result, Exception).Message)
                tsslStatus.Text = "Cancelled Error: " & CType(e.Result, Exception).Message
            End If
        ElseIf e.Error IsNot Nothing Then
            logger.Debug(e.Error.Message)
            tsslStatus.Text = "Error: " & e.Error.Message
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
        Else
            logger.Info("_bwScanMedia Completed")
            btnClearStatus.Enabled = True
            btnPause.Enabled = False
            tsslStatus.Text = "Media properties scan"
            tspbComplete.Value = _Movies.Movies.Count + 1
            Application.DoEvents()
            dgvFilePropertiesRefresh()
            tsslStatus.Text = "Saving..."
            Application.DoEvents()
            SaveStatus()
            tsslStatus.Text = "Status"
            tspbComplete.Value = 0
            btnConvert.Enabled = True
            btnSettings.Enabled = True
            btnProcessOne.Enabled = True
            btnSkipOne.Enabled = True
            Application.DoEvents()
        End If
    End Sub

#End Region

#Region "ConvertMedia Process Handling"
    Private Async Function DoConvertMedia() As Task
        Dim aMedia As MediaInfoWrapper
        Dim aOut As String
        Dim aSt As String
        Dim aSuccess As Integer
        Dim aOpts As String
        Dim aCopyOk As Boolean
        Dim lpFreeBytesAvailable As ULong
        Dim lpTotalNumberOfBytes As ULong

        _Utils.GetDriveSpace(My.Settings.OutputPath, lpFreeBytesAvailable, lpTotalNumberOfBytes)
        While lpFreeBytesAvailable < _WorkingMovie.Size
            logger.Trace("waiting free space")
            tsslStatus.Text = "Waiting for free space"
            'Await Task.Delay(100)
            Thread.Sleep(100)
            Application.DoEvents()
            _Utils.GetDriveSpace(My.Settings.OutputPath, lpFreeBytesAvailable, lpTotalNumberOfBytes)
        End While
        lpFreeBytesAvailable = 0
        tsslStatus.Text = "Convert Media"
        With _WorkingMovie
            Try
                If My.Settings.OutputSel Then
                    aOut = Path.Combine(Path.GetDirectoryName(._FileName), Path.GetFileNameWithoutExtension(._FileName) & My.Settings.OutputExt)
                Else
                    aOut = Path.Combine(My.Settings.OutputPath, Path.GetFileNameWithoutExtension(._FileName) & My.Settings.OutputExt)
                End If
                aOpts = My.Settings.AudioOpt & " " & My.Settings.SubsOpt & " " & My.Settings.VideoOpt
                If (._Width > 1920) Or (._Height > 1080) Then
                    aOpts = aOpts & " " & My.Settings.ResHi
                ElseIf (._Width > 1280) Or (._Height > 720) Then
                    aOpts = aOpts & " " & My.Settings.Res1080
                ElseIf (._Height > 576) Then
                    aOpts = aOpts & " " & My.Settings.Res720
                ElseIf (._Height > 480) Then
                    aOpts = aOpts & " " & My.Settings.Res576
                ElseIf (._Height > 360) Then
                    aOpts = aOpts & " " & My.Settings.Res480
                Else
                    aOpts = aOpts & " " & My.Settings.ResSD
                End If
                aSt = " -i " & """" & ._FileName & """" & " -o " & """" & aOut & """" & " " & aOpts

                logger.Trace(aSt)

                _status.InputFile = Path.GetFileName(._FileName)
                _status.OutputFile = Path.GetFileName(aOut)
                _StartInfo = New ProcessStartInfo(My.Settings.HandBrakeCLI, aSt)
                _StartInfo.RedirectStandardOutput = True
                _StartInfo.UseShellExecute = False
                _StartInfo.CreateNoWindow = True
                _StartInfo.RedirectStandardError = True

                While _Pause
                    Thread.Sleep(100)
                    Application.DoEvents()
                End While

                PrintStatus()
                'PrintError()
                _process = New Process() With {.EnableRaisingEvents = True, .StartInfo = _StartInfo}

                AddHandler _process.OutputDataReceived, AddressOf HandbrakeCLIOutputHandler
                AddHandler _process.ErrorDataReceived, AddressOf HandbrakeCLIErrorHandler
                AddHandler _process.Exited, AddressOf Exited
                Try
                    aSuccess = Await AwaitProcess()
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                End Try
                _process = Nothing
                tsslAvgFPS.Text = ""
                tsslETA.Text = ""
                tsslFiles.Text = ""
                tsslFPS.Text = ""
                tsslPercentage.Text = ""
                ._ProcessedResult = aSuccess
                If aSuccess = 0 Then
                    ._Processed = True
                    Try
                        aMedia = New MediaInfoWrapper(aOut)
                        ._newSize = aMedia.Size
                        If (My.Settings.ReplaceOri And ((Not My.Settings.OnlyIfSmaller) Or (My.Settings.OnlyIfSmaller And (.Size > ._newSize)))) Then
                            Try
                                _Utils.GetDriveSpace(Path.GetDirectoryName(._FileName), lpFreeBytesAvailable, lpTotalNumberOfBytes)
                                While lpFreeBytesAvailable < ._newSize
                                    logger.Trace("waiting destination free space")
                                    tsslStatus.Text = "Waiting for destination free space"
                                    'Await Task.Delay(100)
                                    Thread.Sleep(100)
                                    Application.DoEvents()
                                    _Utils.GetDriveSpace(Path.GetDirectoryName(._FileName), lpFreeBytesAvailable, lpTotalNumberOfBytes)
                                End While
                                aSt = Path.Combine(Path.GetDirectoryName(._FileName), Path.GetFileNameWithoutExtension(._FileName) & My.Settings.OutputExt)
                                aCopyOk = True
                                File.Copy(aOut, aSt)
                            Catch ex As Exception
                                aCopyOk = False
                                logger.Error(ex, New StackFrame().GetMethod().Name)
                                logger.Debug("Unable to copy : " & aOut & " to " & aSt)
                            End Try
                            If aCopyOk Then
                                Try
                                    File.Delete(._FileName)
                                Catch ex As Exception
                                    logger.Error(ex, New StackFrame().GetMethod().Name)
                                    logger.Debug("Unable to delete : " & ._FileName)
                                End Try
                                Try
                                    File.Delete(aOut)
                                Catch ex As Exception
                                    logger.Error(ex, New StackFrame().GetMethod().Name)
                                    logger.Debug("Unable to delete : " & aOut)
                                End Try
                            End If
                        End If
                    Catch ex As Exception
                        ._newSize = -1
                    End Try
                    logger.Info("Processed: " & .Name)
                    tsslStatus.Text = "Saving..."
                    dgvFilePropertiesRefresh(True)
                    Application.DoEvents()
                    SaveStatus()
                    tsslStatus.Text = "Media properties scan"
                    Application.DoEvents()
                Else
                    logger.Error("Error: " & aSuccess)
                End If
                While _Error.Count > 0
                    Await Task.Delay(100)
                End While
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
                logger.Debug("Skipping file")
                ._Processed = False
            End Try
        End With
    End Function

    Private Async Sub DoConvertMovies()
        Dim aMovie As Movie
        Dim aCount As Integer

        For Each aMovie In _Movies.Movies
            dgvFileProperties.Rows(aCount).Selected = True
            dgvFileProperties.FirstDisplayedScrollingRowIndex = dgvFileProperties.CurrentRow.Index
            aCount = aCount + 1
            Application.DoEvents()
            While _Pause
                Thread.Sleep(100)
                Application.DoEvents()
            End While
            logger.Trace(aMovie.Name & " Is Processed: " & aMovie._Processed)
            If aMovie._Scanned And Not aMovie._Processed Then
                _WorkingMovie = aMovie
                _Converting = True
                Try
                    Await DoConvertMedia()
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                End Try
                _Converting = False
                aMovie = _WorkingMovie
                dgvFilePropertiesRefresh(True)
            Else
                logger.Trace("Skipping :" & aMovie.Name & " Scanned (" & aMovie._Scanned & ") Processed (" & aMovie._Processed & ")")
            End If
            tspbComplete.Value = tspbComplete.Value + 1
            Application.DoEvents()
        Next
        logger.Info("_bwConvertMedia Completed")
        tspbComplete.Value = _Movies.Movies.Count + 1
        tsslAvgFPS.Text = ""
        tsslETA.Text = ""
        tsslFiles.Text = ""
        tsslFPS.Text = ""
        tsslPercentage.Text = ""
        Application.DoEvents()
    End Sub

    Private Async Sub DoConvertMovie()
        Dim aRow As DataGridViewRow
        aRow = dgvFileProperties.SelectedRows(0)
        Dim selectedValues As SortableBindingList(Of Movie) = _Movies.Movies.FindAll("Name", aRow.Cells(0).Value)
        If selectedValues.Count > 1 Then
            Dim style = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical
            MsgBox("Duplicate file names found. Impossible to proceed", style, "Error")
            Exit Sub
        End If
        logger.Trace("Scanning Media")
        _WorkingMovie = selectedValues(0)
        _WorkingMovie.Audio.Clear()
        _WorkingMovie.Subtitle.Clear()
        DoScanMedia(_WorkingMovie)
        selectedValues(0) = _WorkingMovie
        dgvFilePropertiesRefresh()
        logger.Trace("Converting Media")
        _Converting = True
        Await DoConvertMedia()
        _Converting = False
        selectedValues(0) = _WorkingMovie
        tsslPercentage.Text = String.Format("{0:00.00}%", 100)
        dgvFilePropertiesRefresh(True)
        btnPause.Enabled = False
        tsslStatus.Text = "Saving..."
        Application.DoEvents()
        SaveStatus()
        btnSettings.Enabled = True
        tsslStatus.Text = "Status"
        tspbComplete.Value = 0
        btnMedia.Enabled = CBool(btnMedia.Tag)
        btnConvert.Enabled = CBool(btnConvert.Tag)
        btnProcessOne.Enabled = True
        btnSettings.Enabled = True
        btnClearStatus.Enabled = True
        btnReproOne.Enabled = True
        Application.DoEvents()
    End Sub

    Private Shared Async Sub Exited(sender As Object, eventArgs As EventArgs)
        If _process IsNot Nothing Then
            logger.Trace("HanbrakeCLI process Exited")
            While Not _process.HasExited
                Thread.Sleep(100)
                Application.DoEvents()
            End While
            RemoveHandler _process.Exited, AddressOf Exited
            _status.Converting = False
            Try
                _tcs.SetResult(_process.ExitCode)
            Catch ex As Exception
                logger.Error(ex, New StackFrame().GetMethod().Name)
                logger.Debug("If after process kill is ok")
            End Try
        Else
            logger.Error("HanbrakeCLI process Exited Process is NOTHING")
        End If
    End Sub

    Private Shared Async Function AwaitProcess() As Task(Of Integer)
        _tcs = New TaskCompletionSource(Of Integer)
        _status.Converting = True
        _status.Percentage = 0
        _status.CurrentFps = 0
        _status.AverageFps = 0
        _Error.Clear()
        _process.Start()
        _process.BeginErrorReadLine()
        _process.BeginOutputReadLine()

        Return Await _tcs.Task
    End Function

    Private Shared Sub HandbrakeCLIErrorHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)
        logger.Debug("E->" & outLine.Data)
        '_pool.WaitOne()
        '_Error.Add(outLine.Data)
        '_pool.ReleaseMutex()
    End Sub

    Private Shared Sub HandbrakeCLIOutputHandler(sendingProcess As Object, outLine As DataReceivedEventArgs)

        ' Collect the sort command output.
        If Not String.IsNullOrEmpty(outLine.Data) Then
            logger.Trace(outLine.Data)
            If String.IsNullOrEmpty(outLine.Data) Then
                Return
            End If
            Dim match = HandbrakeOutputRegex.Match(outLine.Data)
            If Not match.Success Then
                Return
            End If
            _status.Percentage = Single.Parse(match.Groups(1).Value, NumberStyles.Float, CultureInfo.InvariantCulture)
            If Not match.Groups(2).Success Then
                Return
            End If
            _status.CurrentFps = Single.Parse(match.Groups(3).Value, NumberStyles.Float, CultureInfo.InvariantCulture)
            _status.AverageFps = Single.Parse(match.Groups(4).Value, NumberStyles.Float, CultureInfo.InvariantCulture)
            _status.Estimated = TimeSpan.ParseExact(match.Groups(5).Value, "h\hm\ms\s", CultureInfo.InvariantCulture)
        End If
    End Sub

    Private Async Sub PrintStatus()
        Dim _RepTimespan As TimeSpan

        While _Converting
            logger.Trace(_status.ToString)
            tsslAvgFPS.Text = String.Format("AVG {0:000.00 fps}", _status.AverageFps)
            tsslETA.Text = _status.Estimated.ToString("c")
            tsslFiles.Text = _status.InputFile & " -> " & _status.OutputFile
            tsslFPS.Text = String.Format("{0:000.00 fps}", _status.CurrentFps)
            tsslPercentage.Text = String.Format("{0:00.00}%", _status.Percentage)
            Application.DoEvents()
            Await Task.Delay(100)
        End While
    End Sub

    'Private Shared Async Sub PrintError()
    '    While True
    '        If _Error.Count > 0 Then
    '            _pool.WaitOne()
    '            For Each aSt In _Error
    '                Form1.RichTextBox2.Text = Form1.RichTextBox2.Text & "(" & _current & "/" & _total & ") -> " & aSt & vbCrLf
    '                Application.DoEvents()
    '            Next
    '            _Error.Clear()
    '            _pool.ReleaseMutex()
    '        End If
    '        Await Task.Delay(100)
    '        If (_current > _total) And _Error.Count = 0 Then
    '            Exit While
    '        End If
    '    End While
    'End Sub

#End Region

#Region "Private Procedures"
    Private Sub dgvFilePropertiesRefresh(Optional _Check As Boolean = False, Optional _DataSource As Boolean = False)
        Try
            dgvFileProperties.SuspendLayout()
            If _DataSource Then
                dgvFileProperties.DataSource = _Movies.Movies
            End If
            dgvFileProperties.Refresh()
            If dgvFileProperties.Columns("sScanned") IsNot Nothing Then
                dgvFileProperties.Columns.Remove(dgvFileProperties.Columns("sScanned"))
            End If
            dgvFileProperties.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader)
            CheckRows(_Check)
            dgvFileProperties.ResumeLayout()
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
        End Try
    End Sub

    Private Function CheckRows(bCheckSize As Boolean) As Boolean
        Dim aI As Integer
        Dim aL1 As Long
        Dim aL2 As Long
        Dim aDupFound As Boolean = False
        Dim aRow As DataGridViewRow

        If dgvFileProperties.Rows.Count > 0 Then
            For aI = 0 To dgvFileProperties.Rows.Count - 1
                aRow = dgvFileProperties.Rows(aI)
                Dim selectedValues As SortableBindingList(Of Movie) = _Movies.Movies.FindAll("Name", aRow.Cells(0).Value)
                If selectedValues.Count > 1 Then
                    aDupFound = True
                    aRow.DefaultCellStyle.BackColor = Color.LightCoral
                End If
                If bCheckSize Then
                    If CType(aRow.Cells(6).Value, String) = "0" Then
                        aL1 = _Utils.ConvertSizeToLong(CType(aRow.Cells(2).Value, String))
                        aL2 = _Utils.ConvertSizeToLong(CType(aRow.Cells(7).Value, String))
                        If aL1 <= aL2 Then
                            aRow.DefaultCellStyle.BackColor = Color.IndianRed
                        End If
                    End If
                End If
            Next
            Return aDupFound
        End If
    End Function

    Private Sub DirSearch(ByVal sDir As String, ByRef e As System.ComponentModel.DoWorkEventArgs)
        Dirs.Add(sDir)
        _bwDirScan.ReportProgress(1)
        While _Pause
            Threading.Thread.Sleep(100)
            Application.DoEvents()
        End While
        If (_bwDirScan.CancellationPending = True) Then
            logger.Trace("_bwDirScan.CancellationPending")
            e.Cancel = True
            e.Result = Nothing
            Exit Sub
        Else
            For Each aDir In Directory.GetDirectories(sDir)
                logger.Trace("aDir: " & aDir)
                Try
                    DirSearch(aDir, e)
                Catch ex As Exception
                    logger.Error(ex, New StackFrame().GetMethod().Name)
                    Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical
                    Dim response = MsgBox("Error: " & ex.Message & vbCrLf & "Path: " & aDir & vbCrLf & "Continue?", style, "Error")

                    ' Take some action based on the response.
                    If response = MsgBoxResult.No Then
                        logger.Debug("User choice: Aborting!")
                        e.Cancel = True
                        e.Result = ex
                        Exit Sub
                    Else
                        logger.Debug("User choice: Continue")
                    End If
                End Try
            Next
        End If
    End Sub

    Private Sub SaveStatus()
        Try
            Dim serializer As New XmlSerializer(GetType(Movies))
            Dim aS1 As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ReEncode", "status.xml")
            Dim fs As New StreamWriter(aS1)

            serializer.Serialize(fs, _Movies)
            fs.Close()
            btnClearStatus.Enabled = True
        Catch ex As Exception
            logger.Error(ex, New StackFrame().GetMethod().Name)
            logger.Debug("Save Error")
        End Try
    End Sub
#End Region

#Region "Form Controls"
    Private Sub BtnScan_Click(sender As Object, e As EventArgs) Handles btnScan.Click
        tsslStatus.Text = "Directory scan"
        tspbComplete.Value = 0
        Application.DoEvents()
        Dirs.Clear()
        If Not _bwDirScan.IsBusy Then
            logger.Trace("launching _bwDirScan")
            btnScan.Enabled = False
            btnSettings.Enabled = False
            btnProcessOne.Enabled = False
            btnClearStatus.Enabled = False
            btnPause.Enabled = True
            tspbComplete.Value = 0
            ' Start the asynchronous operation.
            _bwDirScan.RunWorkerAsync()
        Else
            logger.Error("_bwDirScan IsBusy ")
        End If
    End Sub

    Private Sub BtnMedia_Click(sender As Object, e As EventArgs) Handles btnMedia.Click
        tsslStatus.Text = "Media properties scan"
        tspbComplete.Value = 0
        tspbComplete.Maximum = _Movies.Movies.Count + 1
        Application.DoEvents()
        If Not _bwScanMedia.IsBusy Then
            logger.Trace("launching _bwScanMedia")
            btnMedia.Enabled = False
            btnSettings.Enabled = False
            btnProcessOne.Enabled = False
            btnClearStatus.Enabled = False
            btnPause.Enabled = True
            tspbComplete.Value = 0
            ' Start the asynchronous operation.
            _bwScanMedia.RunWorkerAsync()
        Else
            logger.Error("_bwScanMedia IsBusy ")
        End If
    End Sub

    Private Sub BtnConvert_Click(sender As Object, e As EventArgs) Handles btnConvert.Click
        tsslStatus.Text = "Convert Media"
        tspbComplete.Value = 0
        tspbComplete.Maximum = _Movies.Movies.Count + 1
        Application.DoEvents()
        logger.Trace("launching DoConvertMovies")
        btnConvert.Enabled = False
        btnProcessOne.Enabled = False
        btnSettings.Enabled = False
        btnClearStatus.Enabled = False
        btnPause.Enabled = True
        tspbComplete.Value = 0
        ' Start the asynchronous operation.
        DoConvertMovies()
    End Sub

    Private Sub btnSkipOne_Click(sender As Object, e As EventArgs) Handles btnSkipOne.Click
        Dim aRow As DataGridViewRow
        aRow = dgvFileProperties.SelectedRows(0)
        Dim selectedValues As SortableBindingList(Of Movie) = _Movies.Movies.FindAll("Name", aRow.Cells(0).Value)
        If selectedValues.Count > 1 Then
            Dim style = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical
            MsgBox("Duplicate file names found. Impossible to proceed", style, "Error")
            Exit Sub
        End If
        selectedValues(0)._ProcessedResult = -2
        selectedValues(0)._Processed = True
        selectedValues(0)._newSize = 0

        dgvFilePropertiesRefresh()
        tsslStatus.Text = "Saving..."
        Application.DoEvents()
        SaveStatus()
        btnSettings.Enabled = True
        tsslStatus.Text = "Status"
        tspbComplete.Value = 0
        selectedValues = _Movies.Movies.FindAll("sScanned", "")
        btnConvert.Enabled = False
        btnReproOne.Enabled = False
        btnMedia.Enabled = False
        If selectedValues.Count = 0 Then
            btnConvert.Enabled = True
            selectedValues = _Movies.Movies.FindAll("ProcessedResult", "")
            If selectedValues.Count < _Movies.Movies.Count Then
                btnReproOne.Enabled = True
            End If
        Else
            btnMedia.Enabled = True
        End If
        btnProcessOne.Enabled = True
        btnSettings.Enabled = True
        btnClearStatus.Enabled = True
        Application.DoEvents()

    End Sub

    Private Sub BtnProcessOne_Click(sender As Object, e As EventArgs) Handles btnProcessOne.Click, Button1.Click, btnSkipOne.Click
        tsslStatus.Text = "Convert One Media"
        tspbComplete.Value = 0
        Application.DoEvents()
        btnMedia.Tag = btnMedia.Enabled
        btnMedia.Enabled = False
        btnConvert.Tag = btnConvert.Enabled
        btnConvert.Enabled = False
        btnProcessOne.Enabled = False
        btnSettings.Enabled = False
        btnClearStatus.Enabled = False
        btnPause.Enabled = True
        DoConvertMovie()
    End Sub

    Private Sub btnReproOne_Click(sender As Object, e As EventArgs) Handles btnReproOne.Click
        Dim aRow As DataGridViewRow
        aRow = dgvFileProperties.SelectedRows(0)
        Dim selectedValues As SortableBindingList(Of Movie) = _Movies.Movies.FindAll("Name", aRow.Cells(0).Value)
        If selectedValues.Count > 1 Then
            Dim style = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical
            MsgBox("Duplicate file names found. Impossible to proceed", style, "Error")
            Exit Sub
        End If
        selectedValues(0)._ProcessedResult = 0
        selectedValues(0)._Processed = False
        selectedValues(0)._newSize = 0

        dgvFilePropertiesRefresh()
        tsslStatus.Text = "Saving..."
        Application.DoEvents()
        SaveStatus()
        btnSettings.Enabled = True
        tsslStatus.Text = "Status"
        tspbComplete.Value = 0
        selectedValues = _Movies.Movies.FindAll("sScanned", "")
        btnConvert.Enabled = False
        btnReproOne.Enabled = False
        btnMedia.Enabled = False
        If selectedValues.Count = 0 Then
            btnConvert.Enabled = True
            selectedValues = _Movies.Movies.FindAll("ProcessedResult", "")
            If selectedValues.Count < _Movies.Movies.Count Then
                btnReproOne.Enabled = True
            End If
        Else
            btnMedia.Enabled = True
        End If
        btnProcessOne.Enabled = True
        btnSettings.Enabled = True
        btnClearStatus.Enabled = True
        Application.DoEvents()
    End Sub

    Private Sub BtnClearStatus_Click(sender As Object, e As EventArgs) Handles btnClearStatus.Click
        Dim style = MsgBoxStyle.YesNo Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Exclamation
        Dim response = MsgBox("Are you sure you want to clear all status and start from scratch?", style, "Confirmation")
        Dim aSt As String
        ' Take some action based on the response.
        If response = MsgBoxResult.Yes Then
            logger.Debug("User choice: Reset everything!")
            dgvFileProperties.DataSource = Nothing

            dgvFilePropertiesRefresh()
            _Movies = Nothing
            _Movies = New Movies
            Dirs.Clear()
            btnScan.Enabled = True
            btnProcessOne.Enabled = False
            btnConvert.Enabled = False
            btnMedia.Enabled = False
            btnPause.Enabled = False
            btnSkipOne.Enabled = False
            tsslStatus.Text = "Status"
            btnClearStatus.Enabled = False
            tsslFiles.Text = ""
            tspbComplete.Value = 0
            tssslRows.Text = ""
            Try
                aSt = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ReEncode", "status.xml")
                If File.Exists(aSt) Then
                    File.Delete(aSt)
                End If
            Catch ex As Exception
                logger.Error("Unable to delete: " & aSt)
            End Try
            Application.DoEvents()
            Exit Sub
        End If
    End Sub

    Private Sub BtnPause_Click(sender As Object, e As EventArgs) Handles btnPause.Click
        If _Pause Then
            logger.Trace("Resume")
            'in pause
            btnPause.Text = "Pause"
            _Pause = False
        Else
            logger.Trace("Pause")
            btnPause.Text = "Resume"
            _Pause = True
        End If
    End Sub

    Private Sub BtnSettings_Click(sender As Object, e As EventArgs) Handles btnSettings.Click
        frmSettings.ShowDialog()
    End Sub
#End Region

#Region "Form Events"
    Private Sub ReEncode_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim aS1 As String
        logger.Info("====ReEncode starting up====")
        logger.Info(String.Format("====Version {0}.{1}.{2}.{3}====", My.Application.Info.Version.Major, My.Application.Info.Version.Minor, My.Application.Info.Version.Build, My.Application.Info.Version.Revision))
        logger.Debug("Scan Root: " & My.Settings.ScanRoot)
        logger.Debug("Scan Filter: " & My.Settings.ScanFilter)
        logger.Debug("HandbrakeCLI: " & My.Settings.HandBrakeCLI)
        logger.Debug("Output Path: " & My.Settings.OutputPath)
        logger.Debug("Output Ext: " & My.Settings.OutputExt)
        logger.Debug("Output Replace: " & My.Settings.ReplaceOri)
        logger.Debug("Output Smaller: " & My.Settings.OnlyIfSmaller)
        logger.Debug("Video Opt: " & My.Settings.VideoOpt)
        logger.Debug("ResHi: " & My.Settings.ResHi)
        logger.Debug("Res1080: " & My.Settings.Res1080)
        logger.Debug("Res720: " & My.Settings.Res720)
        logger.Debug("Res576: " & My.Settings.Res576)
        logger.Debug("Res480: " & My.Settings.Res480)
        logger.Debug("ResSD: " & My.Settings.ResSD)
        logger.Debug("Audio Opt: " & My.Settings.AudioOpt)
        logger.Debug("Subs Opt: " & My.Settings.SubsOpt)

        If My.Settings.WindowLocation.X = -1 And My.Settings.WindowLocation.Y = -1 Then
        Else
            Dim Sect As New Rectangle(My.Settings.WindowLocation, CType(My.Settings.WindowSize, Size))
            If Screen.AllScreens.Any(Function(screen) screen.WorkingArea.IntersectsWith(Sect)) Then
                Location = My.Settings.WindowLocation
                Size = CType(My.Settings.WindowSize, Size)
            End If
        End If

        dgvFileProperties.RowTemplate = New DataGridViewNumberedRow
        _bwDirScan.WorkerReportsProgress = True
        _bwDirScan.WorkerSupportsCancellation = True
        _bwFileScan.WorkerReportsProgress = True
        _bwFileScan.WorkerSupportsCancellation = True
        _bwScanMedia.WorkerReportsProgress = True
        _bwScanMedia.WorkerSupportsCancellation = True
        btnClearStatus.Enabled = False
        btnPause.Enabled = False
        btnScan.Enabled = False
        btnMedia.Enabled = False
        btnConvert.Enabled = False
        btnProcessOne.Enabled = False
        btnSettings.Enabled = True
        btnReproOne.Enabled = False
        btnSkipOne.Enabled = False

        tsslAvgFPS.Text = ""
        tsslETA.Text = ""
        tsslFiles.Text = ""
        tsslFPS.Text = ""
        tsslPercentage.Text = ""
        dgvFileProperties.MultiSelect = False
        dgvFileProperties.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvFileProperties.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

        aS1 = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "ReEncode", "status.xml")
        If File.Exists(aS1) Then
            logger.Debug("Loading : " & aS1)
            tsslStatus.Text = "Loading..."
            Application.DoEvents()
            Try
                Dim serializer As New XmlSerializer(GetType(Movies))
                Dim myReader As New StreamReader(aS1)

                _Movies = CType(serializer.Deserialize(myReader), Movies)
                myReader.Close()
                Dim selectedValues As SortableBindingList(Of Movie) = _Movies.Movies.FindAll("sScanned", "")
                If selectedValues.Count = 0 Then
                    btnConvert.Enabled = True
                    selectedValues = _Movies.Movies.FindAll("ProcessedResult", "")
                    If selectedValues.Count < _Movies.Movies.Count Then
                        btnReproOne.Enabled = True
                    End If
                Else
                    btnMedia.Enabled = True
                End If
                btnProcessOne.Enabled = True
                btnClearStatus.Enabled = True

                dgvFilePropertiesRefresh(, True)
                tsslStatus.Text = "Status"
                tspbComplete.Value = 0
                btnClearStatus.Enabled = True
                Application.DoEvents()
                tssslRows.Text = "Rows: " & dgvFileProperties.RowCount
            Catch ex As Exception
                _Movies = New Movies
                dgvFileProperties.DataSource = Nothing
                btnScan.Enabled = True
                tsslStatus.Text = "Status"
                tspbComplete.Value = 0
                Application.DoEvents()
                tssslRows.Text = ""
                logger.Error(ex, New StackFrame().GetMethod().Name)
            End Try
        Else
            btnScan.Enabled = True
            tsslStatus.Text = "Status"
            btnClearStatus.Enabled = False
            tsslFiles.Text = ""
            tspbComplete.Value = 0
            Application.DoEvents()
            tssslRows.Text = ""
        End If
    End Sub

    Private Sub ReEncode_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If _process IsNot Nothing Then
            _process.Kill()
            _process = Nothing
            _Converting = False
        End If
        If WindowState = FormWindowState.Normal Then
            My.Settings.WindowLocation = Location
            My.Settings.WindowSize = CType(Size, Point)
        Else
            My.Settings.WindowLocation = RestoreBounds.Location
            My.Settings.WindowSize = CType(RestoreBounds.Size, Point)
        End If

        My.Settings.Save()
    End Sub

    Private Sub reEncode_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        If dgvFileProperties.RowCount > 0 Then
            If CheckRows(True) Then
                Dim style = MsgBoxStyle.OkOnly Or MsgBoxStyle.DefaultButton1 Or MsgBoxStyle.Critical
                MsgBox("Warning duplicate file names found. Will overwrite converted files", style, "Error")
            End If
        End If
    End Sub

#End Region
End Class
