''' <summary>
''' PinchActualDto
''' </summary>
Public Class PinchActualDto

    ''' <summary>
    ''' 日付
    ''' </summary>
    Public Property LectureDate As Date?

    ''' <summary>
    ''' 曜日
    ''' </summary>
    Public Property Youbi As Integer?

    ''' <summary>
    ''' コマ
    ''' </summary>
    Public Property KomaSeq As String

    ''' <summary>
    ''' 教室コード
    ''' </summary>
    Public Property SiteCode As String

    ''' <summary>
    ''' クラスコード
    ''' </summary>
    Public Property ClassCode As String

    ''' <summary>
    ''' 講師コード
    ''' </summary>
    Public Property TeacherCode As String

    ''' <summary>
    ''' 出講名
    ''' </summary>
    Public Property LectureName As String

    ''' <summary>
    ''' 科目
    ''' </summary>
    Public Property Subject As String

    ''' <summary>
    ''' テキスト回
    ''' </summary>
    Public Property NumberOfText As String

    ''' <summary>
    ''' ピンチ区分
    ''' </summary>
    Public Property PinchType As String

    ''' <summary>
    ''' 入力日
    ''' </summary>
    Public Property InputDate As DateTime?


    ''' <summary>
    ''' PinchActualDto の初期化
    ''' </summary>
    Public Overrides Sub Clear()
        LectureDate = Nothing
        Youbi = Nothing
        KomaSeq = ""
        SiteCode = ""
        ClassCode = ""
        TeacherCode = ""
        LectureName = ""
        Subject = ""
        NumberOfText = ""
        PinchType = ""
        InputDate = Nothing
    End Sub
End Class
