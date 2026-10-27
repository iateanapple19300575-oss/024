''' <summary>
''' LecturePlanModel
''' </summary>
Public Class LecturePlanModel

    ''' <summary>
    ''' 日付
    ''' </summary>
    Public Property LectureDate As String

    ''' <summary>
    ''' コマ
    ''' </summary>
    Public Property KomaSeq As Integer?

    ''' <summary>
    ''' 教室コード
    ''' </summary>
    Public Property SiteCode As String

    ''' <summary>
    ''' 学年
    ''' </summary>
    Public Property Grade As String

    ''' <summary>
    ''' クラスコード
    ''' </summary>
    Public Property ClassCode As String

    ''' <summary>
    ''' 科目
    ''' </summary>
    Public Property Subject As String

    ''' <summary>
    ''' 講師コード
    ''' </summary>
    Public Property TeacherCode As String

    ''' <summary>
    ''' 出講名
    ''' </summary>
    Public Property LectureName As String

    ''' <summary>
    ''' テキスト回
    ''' </summary>
    Public Property NumberOfText As String


    ''' <summary>
    ''' LecturePlanModel の初期化
    ''' </summary>
    Public Overrides Sub Clear()
        LectureDate = ""
        KomaSeq = Nothing
        SiteCode = ""
        Grade = ""
        ClassCode = ""
        Subject = ""
        TeacherCode = ""
        LectureName = ""
        NumberOfText = ""
    End Sub
End Class
