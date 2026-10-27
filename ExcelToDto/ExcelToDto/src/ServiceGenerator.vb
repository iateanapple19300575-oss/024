Imports System.Text

''' <summary>
''' Service 生成クラス
''' </summary>
Public Class ServiceGenerator

    ''' <summary>
    ''' Service クラスを生成します。
    ''' </summary>
    ''' <param name="baseName"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Public Function GenerateService(ByVal baseName As String, ByVal dt As DataTable) As String
        Dim sb As New StringBuilder()

        Dim serviceName As String = baseName & "Service"
        Dim repoName As String = baseName & "Repository"
        Dim entityName As String = baseName & "Entity"
        Dim dtoName As String = baseName & "Dto"
        Dim mapperName As String = baseName & "Mapper"

        sb.AppendLine("''' <summary>")
        sb.AppendLine("''' Service：" & serviceName)
        sb.AppendLine("''' </summary>")
        sb.AppendLine("Public Class " & serviceName)
        sb.AppendLine()
        sb.AppendLine("    ''' <summary>リポジトリ</summary>")
        sb.AppendLine("    Private ReadOnly _repo As " & repoName)
        sb.AppendLine()
        sb.AppendLine("    ''' <summary>コンストラクタ</summary>")
        sb.AppendLine("    Public Sub New(ByVal repo As " & repoName & ")")
        sb.AppendLine("        _repo = repo")
        sb.AppendLine("    End Sub")
        sb.AppendLine()
        sb.AppendLine("    Public Function GetData() As " & dtoName)
        sb.AppendLine("        Dim e As " & entityName & " = _repo.Find()")
        sb.AppendLine("        Return " & mapperName & ".ToDto(e)")
        sb.AppendLine("    End Function")
        sb.AppendLine()
        sb.AppendLine("End Class")

        Return sb.ToString()
    End Function

End Class
