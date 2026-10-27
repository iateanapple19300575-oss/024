Imports System.Text

''' <summary>
''' Repository　生成クラス
''' </summary>
Public Class RepositoryGenerator

    ''' <summary>
    ''' Repository クラスを生成します。
    ''' </summary>
    ''' <param name="baseName"></param>
    ''' <param name="dt"></param>
    ''' <param name="tableName"></param>
    ''' <returns></returns>
    Public Function GenerateRepository(ByVal baseName As String, ByVal dt As DataTable, ByVal tableName As String) As String
        Dim sb As New StringBuilder()

        Dim repoName As String = baseName.Substring(1) & "Repository"
        Dim entityName As String = ToPascalCase(tableName).Substring(1) & "Entity"

        ' PK列抽出
        Dim pkList As New List(Of String)
        For Each row As DataRow In dt.Rows
            Dim notNull As String = row("Not Null").ToString().Trim().ToLower()
            Dim remarks As String = row("備考").ToString().Trim()

            If notNull = "yes" Or notNull = "true" Or remarks.Contains("PK") Then
                pkList.Add(row("物理名").ToString())
            End If
        Next

        If pkList.Count = 0 And dt.Rows.Count > 0 Then
            pkList.Add(dt.Rows(0)("物理名").ToString())
        End If

        Dim colNames As New List(Of String)
        For Each row As DataRow In dt.Rows
            colNames.Add(row("物理名").ToString())
        Next


        sb.AppendLine("Imports System.Data.SqlClient")
        sb.AppendLine("")
        sb.AppendLine("")

        sb.AppendLine("''' <summary>")
        sb.AppendLine("''' Repository：" & repoName)
        sb.AppendLine("''' </summary>")
        sb.AppendLine("Public Class " & repoName)
        sb.AppendLine("    Inherits TransactionBase")
        sb.AppendLine()
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' コンストラクタ")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    ''' <param name=""sqDblConn""></param>")
        sb.AppendLine("    Public Sub New(ByVal sqDblConn As DbTransactionScope)")
        sb.AppendLine("        MyBase.New(sqDblConn)")
        sb.AppendLine("    End Sub")
        sb.AppendLine()

        '===========================================================
        ' GetAll
        '===========================================================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' キー指定取得")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    ''' <returns></returns>")
        sb.AppendLine("    Public Function GetAll(ByVal entity As " & entityName & ") As DataTable")
        sb.AppendLine("")
        sb.AppendLine("        ' SQL文の生成")
        sb.AppendLine("        Dim sqlString As New System.Text.StringBuilder")
        sb.AppendLine("        sqlString.Length = 0")
        sb.AppendLine("        sqlString.Append(""SELECT"").Append("" "")")

        For i = 0 To colNames.Count - 1
            If String.IsNullOrEmpty(colNames(i)) Then
                Continue For
            End If

            sb.Append("        sqlString.Append(""  ")
            If i > 0 Then
                sb.Append(", ")
            End If
            sb.AppendLine("" & colNames(i) & """).Append("" "")")
        Next

        sb.AppendLine("        sqlString.Append(""FROM"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  " & tableName & """).Append("" "")")
        sb.AppendLine("        sqlString.Append(""WHERE"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  1=1"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""ORDER BY"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  "").Append("" "")")
        sb.AppendLine("")
        sb.AppendLine("        ' パラメタ生成")
        sb.AppendLine("        Dim params As New List(Of SqlParameter)")
        sb.AppendLine("")
        sb.AppendLine("        Return ExecuteDataTable(sqlString.ToString(), params.ToArray)")
        sb.AppendLine("    End Function")
        sb.AppendLine("")

        '===========================================================
        ' GetByKey
        '===========================================================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' キー指定取得")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    ''' <returns></returns>")
        sb.AppendLine("    Public Function FindByIdAndRowversion(ByVal entity As " & entityName & ") As " & entityName)
        sb.AppendLine("")
        sb.AppendLine("        ' SQL文の生成")
        sb.AppendLine("        Dim sqlString As New System.Text.StringBuilder")
        sb.AppendLine("        sqlString.Length = 0")
        sb.AppendLine("        sqlString.Append(""SELECT"").Append("" "")")

        For i = 0 To colNames.Count - 1
            If String.IsNullOrEmpty(colNames(i)) Then
                Continue For
            End If

            sb.Append("        sqlString.Append(""  ")
            If i > 0 Then
                sb.Append(", ")
            End If
            sb.AppendLine("" & colNames(i) & """).Append("" "")")
        Next

        sb.AppendLine("        sqlString.Append(""FROM"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  " & tableName & """).Append("" "")")
        sb.AppendLine("        sqlString.Append(""WHERE"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  1=1"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  AND Id = @Id"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  AND RowVersion = @RowVersion"").Append("" "")")
        sb.AppendLine("")
        sb.AppendLine("        ' パラメタ生成")
        sb.AppendLine("        Dim params As New List(Of SqlParameter)")
        sb.AppendLine("        params.Add(New SqlParameter() With {.ParameterName = ""@Id"", .Value = entity.Id})")
        sb.AppendLine("        params.Add(New SqlParameter() With {.ParameterName = ""@RowVersion"", .Value = entity.RowVersion})")
        sb.AppendLine("")
        sb.AppendLine("        Return ExecuteQuerySingle(sqlString.ToString(), params.ToArray)")
        sb.AppendLine("    End Function")
        sb.AppendLine("")

        '===========================================================
        ' Insert
        '===========================================================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' INSERT")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    ''' <param name=""entity""></param>")
        sb.AppendLine("     ''' <returns>処理件数</returns>")
        sb.AppendLine("    Public Function Insert(ByVal entity As " & entityName & ") As Integer")
        sb.AppendLine("")
        sb.AppendLine("        ' SQL文の生成")
        sb.AppendLine("        Dim sqlString As New System.Text.StringBuilder")
        sb.AppendLine("        sqlString.Length = 0")
        sb.AppendLine("        sqlString.Append(""INSERT INTO"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  " & tableName & """).Append("" "")")
        sb.AppendLine("        sqlString.Append(""  ("").Append("" "")")

        For i = 0 To colNames.Count - 1
            If String.IsNullOrEmpty(colNames(i)) Then
                Continue For
            End If

            sb.Append("        sqlString.Append(""    ")
            If i > 0 Then
                sb.Append(", ")
            End If
            sb.AppendLine("" & colNames(i) & """).Append("" "")")
        Next
        sb.AppendLine("        sqlString.Append(""  ) VALUES ("").Append("" "")")
        For i = 0 To colNames.Count - 1
            If String.IsNullOrEmpty(colNames(i)) Then
                Continue For
            End If

            sb.Append("        sqlString.Append(""    ")
            If i > 0 Then
                sb.Append(", ")
            End If

            If colNames(i) = "Create_Date" Then
                sb.AppendLine("GETDATE()"").Append("" "")")
            ElseIf colNames(i) = "Update_Date" OrElse colNames(i) = "Update_User" Then
                sb.AppendLine("NULL"").Append(""   "")")
            Else
                sb.AppendLine("@" & colNames(i) & """).Append("" "")")
            End If
        Next
        sb.AppendLine("        sqlString.Append(""  )"").Append("" "")")

        sb.AppendLine("")
        sb.AppendLine("        ' パラメタ生成")
        sb.AppendLine("        Dim params As New List(Of SqlParameter)")

        For i = 0 To colNames.Count - 1
            If colNames(i) = "Create_Date" OrElse colNames(i) = "Update_Date" OrElse colNames(i) = "Update_User" Then
                Continue For
            End If

            If String.IsNullOrEmpty(colNames(i)) Then
                Continue For
            End If

            sb.AppendLine("        params.Add(New SqlParameter() With {.ParameterName = ""@" & colNames(i) & """, .Value = entity." & ToPascalCase(colNames(i)) & "})")
        Next

        sb.AppendLine("")
        sb.AppendLine("        Return ExecuteNonQuery(sqlString.ToString(), params.ToArray)")
        sb.AppendLine("    End Function")
        sb.AppendLine("")

        '===========================================================
        ' Update
        '===========================================================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' UPDATE")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    ''' <param name=""entity""></param>")
        sb.AppendLine("     ''' <returns>処理件数</returns>")
        sb.AppendLine("    Public Function UpdateByIdAndRowversion(ByVal entity As " & entityName & ") As Integer")
        sb.AppendLine("")
        sb.AppendLine("        ' SQL文の生成")
        sb.AppendLine("        Dim sqlString As New System.Text.StringBuilder")
        sb.AppendLine("        sqlString.Length = 0")
        sb.AppendLine("        sqlString.Append(""UPDATE"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  " & tableName & """).Append("" "")")
        sb.AppendLine("        sqlString.Append(""  SET"").Append("" "")")

        For i = 0 To colNames.Count - 1
            If colNames(i) = "Create_Date" OrElse colNames(i) = "Create_User" Then
                Continue For
            End If

            If String.IsNullOrEmpty(colNames(i)) Then
                Continue For
            End If

            sb.Append("        sqlString.Append(""    ")
            If i > 0 Then
                sb.Append(", ")
            End If

            If colNames(i) = "Update_Date" Then
                sb.AppendLine("" & colNames(i) & " = GETDATE()"").Append("" "")")
            Else
                sb.AppendLine("" & colNames(i) & " = @" & colNames(i) & """).Append("" "")")
            End If
        Next
        sb.AppendLine("        sqlString.Append(""  WHERE"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""    1=1"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""    AND Id = @Id"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""    AND RowVersion = @RowVersion"").Append("" "")")

        sb.AppendLine("")
        sb.AppendLine("        ' パラメタ生成")
        sb.AppendLine("        Dim params As New List(Of SqlParameter)")

        For i = 0 To colNames.Count - 1
            If colNames(i) = "Create_Date" OrElse colNames(i) = "Create_User" OrElse colNames(i) = "Update_Date" Then
                Continue For
            End If

            If String.IsNullOrEmpty(colNames(i)) Then
                Continue For
            End If

            sb.AppendLine("        params.Add(New SqlParameter() With {.ParameterName = ""@" & colNames(i) & """, .Value = entity." & ToPascalCase(colNames(i)) & "})")
        Next

        sb.AppendLine("")
        sb.AppendLine("        Return ExecuteNonQuery(sqlString.ToString(), params.ToArray)")
        sb.AppendLine("    End Function")
        sb.AppendLine("")

        '===========================================================
        ' Delete
        '===========================================================
        sb.AppendLine("    ''' <summary>")
        sb.AppendLine("    ''' DELETE")
        sb.AppendLine("    ''' </summary>")
        sb.AppendLine("    ''' <param name=""entity""></param>")
        sb.AppendLine("     ''' <returns>処理件数</returns>")
        sb.AppendLine("    Public Function DeleteByIdAndRowversion(ByVal entity As " & entityName & ") As Integer")
        sb.AppendLine("")
        sb.AppendLine("        ' SQL文の生成")
        sb.AppendLine("        Dim sqlString As New System.Text.StringBuilder")
        sb.AppendLine("        sqlString.Length = 0")
        sb.AppendLine("        sqlString.Append(""DELETE"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""  FROM"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""    " & tableName & """).Append("" "")")
        sb.AppendLine("        sqlString.Append(""  WHERE"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""    1=1"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""    AND Id = @Id"").Append("" "")")
        sb.AppendLine("        sqlString.Append(""    AND RowVersion = @RowVersion"").Append("" "")")
        sb.AppendLine("")
        sb.AppendLine("        ' パラメタ生成")
        sb.AppendLine("        Dim params As New List(Of SqlParameter)")
        sb.AppendLine("        params.Add(New SqlParameter() With {.ParameterName = ""@Id"", .Value = entity.Id})")
        sb.AppendLine("        params.Add(New SqlParameter() With {.ParameterName = ""@RowVersion"", .Value = entity.RowVersion})")
        sb.AppendLine("")
        sb.AppendLine("        Return ExecuteNonQuery(sqlString.ToString(), params.ToArray)")
        sb.AppendLine("    End Function")
        sb.AppendLine("")
        sb.AppendLine("End Class")

        Return sb.ToString()
    End Function

End Class
