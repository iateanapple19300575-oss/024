Imports System.Text

''' <summary>
''' Mapper 生成クラス
''' </summary>
Public Class MapperGenerator

    ''' <summary>
    ''' マッパークラスを生成します。
    ''' </summary>
    ''' <param name="baseName"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Public Function GenerateMapper(ByVal baseName As String, ByVal dt As DataTable) As String
        Dim sb As New StringBuilder()

        Dim entityName As String = baseName & "Entity"
        Dim dtoName As String = baseName & "Dto"
        Dim modelName As String = baseName & "Model"

        sb.AppendLine("''' <summary>")
        sb.AppendLine("''' Entity ⇔ Dto ⇔ Model Mapper：" & baseName)
        sb.AppendLine("''' </summary>")
        sb.AppendLine("Public Class " & baseName & "Mapper")
        sb.AppendLine()

        '===========================
        ' Entity → DTO
        '===========================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' Entity → DTO 変換")
        sb.AppendLine("    ''' " & entityName & " → " & dtoName & "")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    Public Shared Function ToDto(ByVal e As " & entityName & ") As " & dtoName)
        sb.AppendLine("        Dim d As New " & dtoName & "()")

        For Each row As DataRow In dt.Rows
            Dim vbName As String = ToPascalCase(row("物理名").ToString())
            If String.IsNullOrEmpty(vbName) Then
                Continue For
            End If
            sb.AppendLine("        d." & vbName & " = e." & vbName)
        Next

        sb.AppendLine("        Return d")
        sb.AppendLine("    End Function")
        sb.AppendLine()

        '===========================
        ' DTO → Entity
        '===========================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' DTO → Entity 変換")
        sb.AppendLine("    ''' " & dtoName & " → " & entityName & "")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    Public Shared Function ToEntity(ByVal d As " & dtoName & ") As " & entityName)
        sb.AppendLine("        Dim e As New " & entityName & "()")

        For Each row As DataRow In dt.Rows
            Dim vbName As String = ToPascalCase(row("物理名").ToString())
            If String.IsNullOrEmpty(vbName) Then
                Continue For
            End If
            sb.AppendLine("        e." & vbName & " = d." & vbName)
        Next

        sb.AppendLine("        Return e")
        sb.AppendLine("    End Function")
        sb.AppendLine()

        '===========================
        ' DTO → Model
        '===========================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' DTO → Model 変換")
        sb.AppendLine("    ''' " & dtoName & " → " & modelName & "")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    Public Shared Function ToModel(ByVal d As " & dtoName & ") As " & modelName)
        sb.AppendLine("        Dim m As New " & modelName & "()")

        For Each row As DataRow In dt.Rows
            Dim vbName As String = ToPascalCase(row("物理名").ToString())
            If String.IsNullOrEmpty(vbName) Then
                Continue For
            End If
            sb.AppendLine("        m." & vbName & " = d." & vbName)
        Next

        sb.AppendLine("        Return m")
        sb.AppendLine("    End Function")
        sb.AppendLine()

        '===========================
        ' Model → DTO
        '===========================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' Model → DTO 変換")
        sb.AppendLine("    ''' " & modelName & " → " & dtoName & "")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    Public Shared Function ToDtoFromModel(ByVal m As " & modelName & ") As " & dtoName)
        sb.AppendLine("        Dim d As New " & dtoName & "()")

        For Each row As DataRow In dt.Rows
            Dim vbName As String = ToPascalCase(row("物理名").ToString())
            If String.IsNullOrEmpty(vbName) Then
                Continue For
            End If
            sb.AppendLine("        d." & vbName & " = m." & vbName)
        Next

        sb.AppendLine("        Return d")
        sb.AppendLine("    End Function")
        sb.AppendLine()

        sb.AppendLine("End Class")

        Return sb.ToString()
    End Function

End Class
