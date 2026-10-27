''' <summary>
''' テーブルデータ編集専用 Entity の基底クラス。
''' </summary>
Public MustInherit Class MasterEditEntityBase
    Implements IMasterEditEntityBase

    ''' <summary>
    ''' Id
    ''' </summary>
    Public Property Id As Long?

    ''' <summary>
    ''' 作成日
    ''' </summary>
    Public Property CreateDate As DateTime?

    ''' <summary>
    ''' 作成者
    ''' </summary>
    Public Property CreateUser As String

    ''' <summary>
    ''' 更新日
    ''' </summary>
    Public Property UpdateDate As DateTime?

    ''' <summary>
    ''' 更新者
    ''' </summary>
    Public Property UpdateUser As String

    ''' <summary>
    ''' RowVersion
    ''' </summary>
    Public Property RowVersion As Byte()


    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    Public Sub New()
        Id = Nothing
        CreateDate = Nothing
        CreateUser = ""
        UpdateDate = Nothing
        UpdateUser = ""
        RowVersion = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}

        Clear()
    End Sub

    ''' <summary>
    ''' EditBaseEntity の初期化
    ''' </summary>
    Public Overridable Sub Clear() Implements IMasterEditEntityBase.Clear
    End Sub

End Class
