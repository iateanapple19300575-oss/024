''' <summary>
''' 登録編集画面専用 Model の基底クラス。
''' </summary>
Public MustInherit Class MasterEditModel
    'Public MustInherit Class BaseEditModel(Of T As New)

    ''' <summary>入力欄を初期化する</summary>
    Public MustOverride Sub Clear()

    ''' <summary>UI → Model の変換</summary>
    Public MustOverride Sub FromUI(form As Form)

    ''' <summary>Model → UI の変換</summary>
    Public MustOverride Sub ToUI(form As Form)

    '''' <summary>Model内容を比較し編集有無を判定する</summary>
    'Public MustOverride Function IsEditChange(model As T) As Boolean

End Class

''' <summary>
''' 登録編集画面専用 Model の基底クラス。
''' </summary>
Public MustInherit Class BasicEditModelBase(Of TDModel As New)

    ''' <summary>全項目を初期化する</summary>
    Public MustOverride Sub Clear()

    Public MustOverride Function Clone() As TDModel

    ''' <summary>Model内容を比較し編集有無を判定する</summary>
    Public MustOverride Function IsEditChange(model As TDModel) As Boolean

End Class
