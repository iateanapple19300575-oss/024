Imports System.Text

''' <summary>
''' Presenter クラス生成クラス
''' </summary>
Public Class PresenterGenerator

    ''' <summary>
    ''' Presenter クラスを生成します。
    ''' </summary>
    ''' <param name="baseName"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Public Function GeneratePresenter(ByVal baseName As String, ByVal dt As DataTable) As String
        Dim sb As New StringBuilder()

        Dim presenterName As String = baseName & "Presenter"
        Dim serviceName As String = baseName & "Service"
        Dim modelName As String = baseName & "Model"
        Dim dtoName As String = baseName & "Dto"
        Dim mapperName As String = baseName & "Mapper"

        sb.AppendLine("''' <summary>")
        sb.AppendLine("''' Presenter：" & presenterName)
        sb.AppendLine("''' </summary>")
        sb.AppendLine("Public Class " & presenterName)
        sb.AppendLine()
        sb.AppendLine("    ''' <summary>" & baseName & "View</summary>")
        sb.AppendLine("    Private ReadOnly _view As I" & baseName & "View")
        sb.AppendLine()
        sb.AppendLine("    ''' <summary>" & serviceName & "</summary>")
        sb.AppendLine("    Private ReadOnly _service As " & serviceName)
        sb.AppendLine()
        sb.AppendLine("    ''' <summary>コンストラクタ</summary>")
        sb.AppendLine("    Public Sub New(ByVal view As I" & baseName & "View, ByVal service As " & serviceName & ")")
        sb.AppendLine("        _view = view")
        sb.AppendLine("        _service = service")
        sb.AppendLine("    End Sub")
        sb.AppendLine()
        sb.AppendLine("    Public Sub LoadData()")
        sb.AppendLine("        Dim dto As " & dtoName & " = _service.GetData()")
        sb.AppendLine("        Dim model As " & modelName & " = " & mapperName & ".ToModel(dto)")
        sb.AppendLine("        _view.Bind(model)")
        sb.AppendLine("    End Sub")
        sb.AppendLine()
        sb.AppendLine("End Class")

        Return sb.ToString()
    End Function

End Class
