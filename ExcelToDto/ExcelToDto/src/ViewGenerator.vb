''' <summary>
''' View InterFace 生成クラス
''' </summary>
Public Class ViewGenerator

    ''' <summary>
    ''' View Interface を生成します。
    ''' </summary>
    ''' <param name="baseName"></param>
    ''' <returns></returns>
    Public Function GenerateViewInterface(ByVal baseName As String) As String
        Dim modelName As String = baseName & "Model"

        Dim sb As New System.Text.StringBuilder()
        sb.AppendLine("''' <summary>")
        sb.AppendLine("''' View インターフェース")
        sb.AppendLine("''' </summary>")
        sb.AppendLine("Public Interface I" & baseName & "View")
        sb.AppendLine("    Sub Bind(ByVal model As " & modelName & ")")
        sb.AppendLine("End Interface")

        Return sb.ToString()
    End Function
End Class
