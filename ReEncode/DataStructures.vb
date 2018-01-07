Option Explicit On
Option Strict On

Imports System.ComponentModel
Imports System.Xml.Serialization
Imports ReEncode.SortableBindingList

<XmlRoot(ElementName:="Library")>
Public Class Movies

    'Private _Movie As New List(Of Movie)
    Private _Movie As New SortableBindingList(Of Movie)

    <XmlArrayItem(ElementName:="Movie",
        IsNullable:=True,
        Type:=GetType(Movie)),
     XmlArray()>
    Public Property Movies As SortableBindingList(Of Movie)
        Get
            Return _Movie
        End Get
        Set
            _Movie = Value
        End Set
    End Property
End Class

Public Class Movie
    Private _Utils As New Utils

    ' Status variables
    Public _Scanned As Boolean
    Public _Processed As Boolean
    Public _ProcessedResult As Integer
    Public _newSize As Long

    ' Media properties
    Public _Name As String
    Public Duration As Long
    Public Size As Long
    Public _FileName As String
    Public _VideoCount As Integer
    Public _Width As Integer
    Public _Height As Integer
    Public _Interlaced As Boolean
    Public _Codec As String
    Private _Audio As New List(Of AudioTrack)
    Private _Subtitle As New List(Of SubtitleTrack)

    ' XML Serialization needed properties
    <XmlArrayItem(ElementName:="AudioTrack",
        IsNullable:=True,
        Type:=GetType(AudioTrack)),
     XmlArray()>
    Public Property Audio As List(Of AudioTrack)
        Get
            Return _Audio
        End Get
        Set
            _Audio = Value
        End Set
    End Property

    <XmlArrayItem(ElementName:="SubtitleTrack",
        IsNullable:=True,
        Type:=GetType(SubtitleTrack)),
     XmlArray()>
    Public Property Subtitle As List(Of SubtitleTrack)
        Get
            Return _Subtitle
        End Get
        Set
            _Subtitle = Value
        End Set
    End Property

    ' Object binding needed properties. Must not be serialized.
    ' Order of definition is the order shown in the datagrid
    <XmlIgnore>
    Public ReadOnly Property Name As String
        Get
            Return _Name
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property sDuration As String
        Get
            Dim aS1 As String
            If _Scanned Then
                aS1 = _Utils.ConvertDuration(Duration)
            Else
                aS1 = ""
            End If
            Return aS1
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property SizeB As String
        Get
            Dim aS1 As String
            If _Scanned Then
                aS1 = _Utils.ConvertSize(Size)
            Else
                aS1 = ""
            End If
            Return aS1
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property Video As String
        Get
            Dim aS1 As String
            aS1 = ""
            If _Scanned Then
                aS1 = "{" & _Height & "x" & _Width & " " & CType(IIf(_Interlaced, "I", "P"), String) & " - " & _Codec & CType(IIf(_VideoCount > 1, " - " & _VideoCount, ""), String) & "}"
            End If
            Return aS1
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property sAudio As String
        Get
            Dim aS1 As String
            aS1 = ""
            If _Scanned Then
                If Audio.Count > 0 Then
                    For aI = 0 To Audio.Count - 1
                        aS1 = aS1 & " - {" & Audio(aI).Codec & " - " & Audio(aI).CodecFriendly & " - " & Audio(aI).Bitrate & "}"
                    Next
                    aS1 = Strings.Right(aS1, Len(aS1) - 3)
                End If
            End If
            Return aS1
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property sSubtitles As String
        Get
            Dim aS1 As String
            aS1 = ""
            If _Scanned Then
                If Subtitle.Count > 0 Then
                    For aI = 0 To Subtitle.Count - 1
                        aS1 = aS1 & " - {'" & Subtitle(aI).Name & "' - " & Subtitle(aI).Language & " - " & Subtitle(aI).Id & "}"
                    Next
                    aS1 = Strings.Right(aS1, Len(aS1) - 3)
                End If
            End If
            Return aS1
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property ProcessedResult As String
        Get
            Dim aS1 As String
            If _Processed Or Not (_ProcessedResult = 0) Then
                aS1 = _ProcessedResult.ToString
            Else
                aS1 = ""
            End If
            Return aS1
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property NewSize As String
        Get
            Dim aS1 As String
            If _Processed Then
                aS1 = _Utils.ConvertSize(_newSize)
            Else
                aS1 = ""
            End If
            Return aS1
        End Get
    End Property
    <XmlIgnore>
    Public ReadOnly Property sScanned As String
        Get
            Dim aS1 As String
            If _Scanned Then
                aS1 = "X"
            Else
                aS1 = ""
            End If
            Return aS1
        End Get
    End Property
End Class

Public Class AudioTrack
    Public Codec As Integer
    Public CodecFriendly As String
    Public Bitrate As Double
End Class

Public Class SubtitleTrack
    Public Language As String
    Public Name As String
    Public Id As Integer
End Class

Public Class ConversionStatus

    Public Property Converting As Boolean

    Public Property InputFile As String

    Public Property OutputFile As String

    Public Property Percentage As Single

    Public Property CurrentFps As Single

    Public Property AverageFps As Single

    Public Property Estimated As TimeSpan

    Public Overrides Function ToString() As String
        If Not Converting Then Return "Idle"
        Return InputFile & " -> " & OutputFile & " - " & String.Format("{0:00.00}%", Percentage) & " " &
            String.Format("{0:000.00}", CurrentFps) & " fps. " & String.Format("{0:000.00}", AverageFps) & " fps. avg.   " & Estimated.ToString("c") & " time remaining"
    End Function
End Class


