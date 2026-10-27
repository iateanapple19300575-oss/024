Imports System.Data.OleDb

''' <summary>
''' EXCELのテーブル定義書アクセスクラス
''' </summary>
Public Class ExcelDefinitionReader

    ''' <summary>
    ''' EXCELのテーブル定義書の内容を読み込みます。
    ''' </summary>
    ''' <param name="excelPath"></param>
    ''' <param name="sheetName"></param>
    ''' <returns></returns>
    Public Function ReadDefinition(ByVal excelPath As String, ByVal sheetName As String) As DataTable
        Dim connStr As String =
            "Provider=Microsoft.ACE.OLEDB.12.0;" &
            "Data Source=" & excelPath & ";" &
            "Extended Properties=""Excel 12.0 Xml;HDR=YES"""

        Using conn As New OleDbConnection(connStr)
            conn.Open()
            Dim cmd As New OleDbCommand("SELECT * FROM [" & sheetName & "$]", conn)
            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            Return dt
        End Using
    End Function
End Class
