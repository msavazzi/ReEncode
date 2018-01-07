Option Explicit On
Option Strict On

Imports System.Runtime.InteropServices
Imports Microsoft.VisualBasic.Strings

Public Class Utils
    Public Enum convTo
        B = 0
        KB = 1
        MB = 2
        GB = 3  'Enumerations for file size conversions
        TB = 4
        PB = 5
        EB = 6
        ZI = 7
        YI = 8
    End Enum

    Public Function ConvertSizeToLong(ByVal fileSize As String) As Long
        Dim sizeOfKB As Double = 1024              ' Actual size in bytes of 1KB
        Dim sizeOfMB As Double = 1048576           ' 1MB
        Dim sizeOfGB As Double = 1073741824        ' 1GB
        Dim sizeOfTB As Double = 1099511627776     ' 1TB
        Dim sizeofPB As Double = 1125899906842624  ' 1PB
        Dim aLng As Double

        aLng = CDbl(UCase(Left(Trim(fileSize), Trim(fileSize).Length - 2)))
        Select Case UCase(Right(Trim(fileSize), 2))
            Case "KB"
                Return CLng(Math.Round(aLng * sizeOfKB, 1))
            Case "MB"
                Return CLng(Math.Round(aLng * sizeOfMB, 1))
            Case "GB"
                Return CLng(Math.Round(aLng * sizeOfGB, 1))
            Case "TB"
                Return CLng(Math.Round(aLng * sizeOfTB, 1))
            Case "PB"
                Return CLng(Math.Round(aLng * sizeofPB, 1))
            Case Else
                Return -1
        End Select
    End Function




    Public Function ConvertSize(ByVal fileSize As Long) As String
        Dim sizeOfKB As Long = 1024              ' Actual size in bytes of 1KB
        Dim sizeOfMB As Long = 1048576           ' 1MB
        Dim sizeOfGB As Long = 1073741824        ' 1GB
        Dim sizeOfTB As Long = 1099511627776     ' 1TB
        Dim sizeofPB As Long = 1125899906842624  ' 1PB

        Dim tempFileSize As Double
        Dim tempFileSizeString As String

        Dim myArr() As Char = {CChar("0"), CChar(".")}  'Characters to strip off the end of our string after formating

        If fileSize < sizeOfKB Then 'Filesize is in Bytes
            tempFileSize = ConvertBytes(fileSize, convTo.B)
            If tempFileSize = -1 Then Return Nothing 'Invalid conversion attempted so exit
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr) ' Strip the 0's and 1's off the end of the string
            Return Math.Round(tempFileSize) & " bytes" 'Return our converted value

        ElseIf fileSize >= sizeOfKB And fileSize < sizeOfMB Then 'Filesize is in Kilobytes
            tempFileSize = ConvertBytes(fileSize, convTo.KB)
            If tempFileSize = -1 Then Return Nothing 'Invalid conversion attempted so exit
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize) & " KB"

        ElseIf fileSize >= sizeOfMB And fileSize < sizeOfGB Then ' Filesize is in Megabytes
            tempFileSize = ConvertBytes(fileSize, convTo.MB)
            If tempFileSize = -1 Then Return Nothing 'Invalid conversion attempted so exit
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize, 1) & " MB"

        ElseIf fileSize >= sizeOfGB And fileSize < sizeOfTB Then 'Filesize is in Gigabytes
            tempFileSize = ConvertBytes(fileSize, convTo.GB)
            If tempFileSize = -1 Then Return Nothing
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize, 1) & " GB"

        ElseIf fileSize >= sizeOfTB And fileSize < sizeofPB Then 'Filesize is in Terabytes
            tempFileSize = ConvertBytes(fileSize, convTo.TB)
            If tempFileSize = -1 Then Return Nothing
            tempFileSizeString = Format(fileSize, "Standard").TrimEnd(myArr)
            Return Math.Round(tempFileSize, 1) & " TB"

            'Anything bigger than that is silly ;)

        Else

            Return Nothing 'Invalid filesize so return Nothing

        End If

    End Function

    Public Function ConvertDuration(ByVal Duration As Long) As String
        Dim aMSec As Long
        Dim aSec As Long
        Dim aMin As Long
        Dim aHou As Long

        aHou = Duration \ 3600000
        aMin = (Duration - aHou * 3600000) \ 60000
        aSec = (Duration - (aHou * 3600000 + aMin * 60000)) \ 1000
        aMSec = Duration - (aSec * 1000 + aMin * 60000 + aHou * 3600000)
        Return Right("00" & aHou, 2) & ":" & Right("00" & aMin, 2) & ":" & Right("00" & aSec, 2) & "." & Right("0000" & aMSec, 4)
    End Function

    Public Function ConvertBytes(ByVal bytes As Long, ByVal convertTo As convTo) As Double

        If convTo.IsDefined(GetType(convTo), convertTo) Then

            Return bytes / (1024 ^ convertTo)

        Else

            Return -1 'An invalid value was passed to this function so exit

        End If

    End Function

    <DllImport("kernel32.dll", SetLastError:=True, CharSet:=CharSet.Auto)>
    Private Shared Function GetDiskFreeSpaceEx(lpDirectoryName As String, ByRef lpFreeBytesAvailable As ULong, ByRef lpTotalNumberOfBytes As ULong, ByRef lpTotalNumberOfFreeBytes As ULong) As <MarshalAs(UnmanagedType.Bool)> Boolean
    End Function

    Public Shared Function GetDriveSpace(folderName As String, ByRef freespace As ULong, ByRef totalspace As ULong) As Boolean
        If Not String.IsNullOrEmpty(folderName) Then
            If Not folderName.EndsWith("\") Then
                folderName += "\"
            End If

            Dim free As ULong = 0, total As ULong = 0, dummy2 As ULong = 0
            If GetDiskFreeSpaceEx(folderName, free, total, dummy2) Then
                freespace = free
                totalspace = total
                Return True
            End If
        End If
    End Function
End Class

Public Class DataGridViewNumberedRow
    Inherits DataGridViewRow

    Protected Overrides Sub PaintHeader(graphics As System.Drawing.Graphics, clipBounds As System.Drawing.Rectangle, rowBounds As System.Drawing.Rectangle, rowIndex As Integer, rowState As System.Windows.Forms.DataGridViewElementStates, isFirstDisplayedRow As Boolean, isLastVisibleRow As Boolean, paintParts As System.Windows.Forms.DataGridViewPaintParts)
        MyBase.PaintHeader(graphics, clipBounds, rowBounds, rowIndex, rowState, isFirstDisplayedRow, isLastVisibleRow, paintParts)

        Dim drawFont As Font
        drawFont = SystemFonts.MenuFont
        drawFont = New Font(drawFont, FontStyle.Bold)

        graphics.FillRectangle(New SolidBrush(Color.LightGray), rowBounds)
        graphics.DrawString("    " & rowIndex + 1, drawFont, Brushes.Black, rowBounds)
    End Sub
End Class
