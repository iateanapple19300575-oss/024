Imports System.Text

''' <summary>
''' クラス生成クラス
''' </summary>
Public Class ClassGenerator

    ''' <summary>
    ''' 各種クラスを生成します。
    ''' </summary>
    ''' <param name="className"></param>
    ''' <param name="dt"></param>
    ''' <returns></returns>
    Public Function GenerateClass(ByVal className As String, ByVal dt As DataTable) As String
        Dim sb As New StringBuilder()

        sb.AppendLine("''' <summary>")
        sb.AppendLine("''' " & className)
        sb.AppendLine("''' </summary>")
        sb.AppendLine("Public Class " & className)
        'sb.AppendLine("    Inherits EditBaseEntity")
        sb.AppendLine()

        Dim idx As Integer = -1
        For Each row As DataRow In dt.Rows
            Dim colName As String = row("物理名").ToString()
            Dim vbName As String = ToPascalCase(colName)
            Dim vbType As String = ConvertType(row("データ型").ToString())
            Dim logicalName As String = row("論理名").ToString()
            Dim remarks As String = row("備考").ToString()

            If colName = "" OrElse IsCommonItems(colName) Then
                Exit For
            End If

            sb.AppendLine("    ''' <summary>")
            sb.AppendLine("    ''' " & logicalName & "")
            sb.AppendLine("    ''' </summary>")
            sb.AppendLine("    Public Property " & vbName & " As " & vbType & If(vbType = "String", "", "?"))
            sb.AppendLine()
        Next

        sb.AppendLine("")
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' " & className & " の初期化")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    Public Overrides Sub Clear()")

        Dim idx2 As Integer = -1
        For Each row As DataRow In dt.Rows
            Dim colName As String = row("物理名").ToString()
            Dim vbName As String = ToPascalCase(colName)
            Dim vbType As String = ConvertType(row("データ型").ToString())
            Dim logicalName As String = row("論理名").ToString()
            Dim remarks As String = row("備考").ToString()

            If colName = "" OrElse IsCommonItems(colName) Then
                Exit For
            End If

            sb.Append("        " & ToPascalCase(colName) & " = ")

            Select Case vbType.ToLower
                Case "string" : sb.AppendLine("""""")
                Case "integer" : sb.AppendLine("Nothing")
                Case "byte" : sb.AppendLine("Nothing")
                Case "byte()" : sb.AppendLine("RowVersion = New Byte() {0, 0, 0, 0, 0, 0, 0, 0}")
                Case "long" : sb.AppendLine("Nothing")
                Case "decimal" : sb.AppendLine("Nothing")
                Case "date" : sb.AppendLine("Nothing")
                Case "datetime" : sb.AppendLine("Nothing")
                Case "timespan" : sb.AppendLine("Nothing")
                Case Else : sb.AppendLine("Nothing")
            End Select
        Next

        sb.AppendLine("    End Sub")
        sb.AppendLine("End Class")

        Return sb.ToString()
    End Function

End Class
