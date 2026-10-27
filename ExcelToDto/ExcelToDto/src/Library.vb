'===========================================================
' 共通モジュール：命名変換・型変換
'===========================================================
Imports System.Data.OleDb
Imports System.IO

Public Module CodeGenCommon

    ''' <summary>
    ''' アンダーバー区切りを PascalCase に変換する
    ''' 例：Seasonal_Period → SeasonalPeriod
    ''' </summary>
    Public Function ToPascalCase(ByVal name As String) As String
        Dim parts() As String = name.Split("_"c)
        Dim sb As New System.Text.StringBuilder()

        For Each p As String In parts
            If p.Length = 0 Then Continue For
            If p.Length = 1 Then
                sb.Append(p.ToUpper())
            Else
                sb.Append(p.Substring(0, 1).ToUpper())
                sb.Append(p.Substring(1).ToLower())
            End If
        Next

        Return sb.ToString()
    End Function

    ''' <summary>
    ''' DB型 → VB型 変換
    ''' </summary>
    Public Function ConvertType(ByVal dbType As String) As String
        dbType = dbType.ToLower()

        If dbType.StartsWith("char") Or dbType.StartsWith("varchar") Then
            Return "String"
        ElseIf dbType.StartsWith("decimal") Then
            Return "Decimal"
        ElseIf dbType = "tinyint" Then
            Return "Integer"
        ElseIf dbType = "datetime" Then
            Return "DateTime"
        ElseIf dbType = "date" Then
            Return "Date"
        ElseIf dbType = "int" Then
            Return "Integer"
        ElseIf dbType = "time" Then
            Return "TimeSpan"
        ElseIf dbType = "byte()" Then
            Return "Byte()"
        End If

        Return "String"
    End Function

    ''' <summary>
    ''' 除外カラム名
    ''' </summary>
    ''' <param name="item"></param>
    ''' <returns></returns>
    Public Function IsCommonItems(ByVal item As String) As Boolean
        Dim commonItems As New List(Of String) From {
            "Id", "Create_Date", "Create_User", "Update_Date", "Update_User", "RowVersion"
        }

        Return commonItems.Contains(item)
    End Function

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="dtSource"></param>
    ''' <param name="baseEName"></param>
    ''' <param name="baseJName"></param>
    ''' <returns></returns>
    Public Function GetTableDefinitions(dtSource As DataTable, ByRef baseEName As String, ByRef baseJName As String) As DataTable

        ' EXCELの列毎のセル値
        dtSource.Columns(0).ColumnName = "No"
        dtSource.Columns(1).ColumnName = "論理名"
        dtSource.Columns(2).ColumnName = "物理名"
        dtSource.Columns(3).ColumnName = "データ型"
        dtSource.Columns(4).ColumnName = "Not Null"
        dtSource.Columns(5).ColumnName = "デフォルト"
        dtSource.Columns(6).ColumnName = "備考"

        ' 論理テーブル名
        baseJName = dtSource.Rows(3).ItemArray(2)

        ' 物理テーブル名
        baseEName = dtSource.Rows(4).ItemArray(2)
        'baseEName = ToPascalCase(dtSource.Rows(4).ItemArray(2)).Substring(1)

        ' コピー先のDataTableの構造（列の定義）をコピー
        Dim dt As DataTable = dtSource.Clone()

        ' 1行ずつループして判定
        Dim getFlag As Boolean = False
        For Each row As DataRow In dtSource.Rows

            ' No列の値を文字列として取得（Null/DBNull 対策として ToString() を安全に呼び出す）
            Dim noValue As String = If(row("No") Is DBNull.Value, "", row("No").ToString())

            ' カラム情報欄を検出
            If noValue = "カラム情報" Then
                getFlag = True
                Continue For
            End If

            ' インデックス情報欄になったらカラム情報取得を終了
            If noValue = "インデックス情報" Then
                Exit For
            End If

            ' カラム情報欄以外は、スキップ
            If Not getFlag Then
                Continue For
            End If

            ' [No]列が数値(整数)に変換できる場合のみ設定値を取得
            Dim dummy As Integer
            If Integer.TryParse(noValue, dummy) Then
                dt.ImportRow(row)
            End If
        Next

        Return dt
    End Function

    ''' <summary>
    ''' Excel のシート名一覧を取得
    ''' </summary>
    Public Function GetSheetNames(ByVal excelPath As String) As List(Of SheetItemData)
        Dim list As New List(Of SheetItemData)

        Dim connStr As String =
            "Provider=Microsoft.ACE.OLEDB.12.0;" &
            "Data Source=" & excelPath & ";" &
            "Extended Properties=""Excel 12.0 Xml;HDR=YES"""

        Using conn As New OleDbConnection(connStr)
            conn.Open()
            Dim dt As DataTable = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, Nothing)

            For Each row As DataRow In dt.Rows
                Dim sheetName As String = row("TABLE_NAME").ToString()
                If sheetName.EndsWith("$") Or sheetName.EndsWith("$'") Then
                    sheetName = sheetName.Replace("'", "").Replace("$", "")

                    ' テーブル定義のシート以外はスキップ
                    If sheetName = "表紙" OrElse
                        sheetName = "変更履歴" OrElse
                        sheetName = "テーブル関連図" OrElse
                        sheetName = "項目整理" OrElse
                        sheetName = "フォーマット" OrElse
                        sheetName = "差分レポート" OrElse
                        sheetName = "テーブル一覧" Then
                        Continue For
                    End If


                    list.Add(New SheetItemData With {.Value = sheetName})
                End If
            Next
        End Using

        Return list
    End Function

    ''' <summary>
    ''' 共通フォルダ選択
    ''' </summary>
    ''' <returns></returns>
    Public Function SelectFolder(ByVal defaultPath As String) As String
        ' FolderBrowserDialog のインスタンスを作成
        Dim folderBrowser As New FolderBrowserDialog()
        ' ダイアログの説明文を設定
        folderBrowser.Description = "フォルダを選択してください。"
        ' ダイアログの初期表示フォルダを設定(デスクトップ)
        If DirectoryExistsSafe(defaultPath) Then
            folderBrowser.SelectedPath = defaultPath
        Else
            folderBrowser.SelectedPath = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory)
        End If
        ' 新しいフォルダ作成ボタンを表示（デフォルトはTrue）
        folderBrowser.ShowNewFolderButton = True

        Dim pathName As String = ""
        If folderBrowser.ShowDialog() = DialogResult.OK Then
            pathName = folderBrowser.SelectedPath
        End If

        Return pathName
    End Function

    Public Function SelectOpenFile(ByVal initFolderPath As String) As String
        Dim dlg As New OpenFileDialog()
        dlg.Filter = "Excelブック(*.xlsx)|*.xlsx"
        dlg.InitialDirectory = If(initFolderPath = "",
                                    System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory),
                                    initFolderPath)

        Dim pathName As String = ""
        If dlg.ShowDialog() = DialogResult.OK Then
            pathName = dlg.FileName
        End If

        Return pathName
    End Function

    ''' <summary>
    ''' ディレクトリが存在するかチェックする。
    ''' </summary>
    ''' <param name="folderPath">ディレクトリパス</param>
    ''' <returns>存在する場合 True</returns>
    Public Function DirectoryExistsSafe(ByVal folderPath As String) As Boolean
        If String.IsNullOrEmpty(folderPath) Then
            Return False
        End If

        Try
            Return Directory.Exists(folderPath)
        Catch
            Return False
            ' TODO: Catch ex As Exception
        End Try
    End Function

End Module
