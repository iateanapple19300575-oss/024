Imports System.IO

Public Class Form1

    Dim baseJName As String = ""
    Dim baseEName As String = ""

    ''' <summary>
    ''' []
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim excelFilePath As String = txtExcelPath.Text
        Dim sheetName As String = dgvList.CurrentRow.Cells(0).Value.ToString()


        ' EXCELのテーブル定義を読み込み
        Dim reader As New ExcelDefinitionReader()
        Dim dtSource As DataTable = reader.ReadDefinition(excelFilePath, sheetName)

        ' １テーブル分の定義情報を取得
        Dim dt As DataTable = GetTableDefinitions(dtSource, baseEName, baseJName)
        baseEName = ToPascalCase(baseEName).Substring(1)

        ' クラス生成
        Dim classGen As New ClassGenerator()

        ' マッパー生成
        Dim mapperGen As New MapperGenerator()

        ' プレゼンター生成
        Dim presenterGen As New PresenterGenerator()

        ' サービス生成
        Dim serviceGen As New ServiceGenerator()

        ' ビュー生成
        Dim viewGen As New ViewGenerator()

        '　リポジトリ生成
        Dim repoGen As New RepositoryGenerator()

        ' 
        Dim outputFolder As String = txtOutputFolder.Text
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "Entity.vb"), classGen.GenerateClass(baseEName & "Entity", dt))
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "Dto.vb"), classGen.GenerateClass(baseEName & "Dto", dt))
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "Model.vb"), classGen.GenerateClass(baseEName & "Model", dt))
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "Mapper.vb"), mapperGen.GenerateMapper(baseEName, dt))
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "Service.vb"), serviceGen.GenerateService(baseEName, dt))
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "Presenter.vb"), presenterGen.GeneratePresenter(baseEName, dt))
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "View.vb"), viewGen.GenerateViewInterface(baseEName))
        FileWriter.WriteToFile(Path.Combine(outputFolder, baseEName & "Repository.vb"), repoGen.GenerateRepository(baseEName, dt, "M_Hourly_Wage"))
    End Sub

    ''' <summary>
    ''' []
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        ' 全シート出力
        Dim excelFilePath As String = txtExcelPath.Text
        Dim outputFolder As String = txtOutputFolder.Text
        Dim gen As New MultiSheetGenerator()

        Dim values As New List(Of SheetItemData)
        For Each row As DataGridViewRow In dgvList.SelectedRows
            If row.IsNewRow = False Then
                Dim item As New SheetItemData With {
                    .Value = Convert.ToString(row.Cells(0).Value)
                }
                values.Add(item)
            End If
        Next

        gen.GenerateAll(excelFilePath, outputFolder, values)
    End Sub

    ''' <summary>
    ''' 
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim list As List(Of SheetItemData) = GetSheetNames(txtExcelPath.Text)
        Dim bs As New BindingSource()
        bs.DataSource = list
        dgvList.DataSource = bs
        dgvList.RowHeadersWidth = 20
        dgvList.MultiSelect = True
        dgvList.ReadOnly = True
        dgvList.AllowUserToAddRows = False
        dgvList.Columns(0).Width = 500
        dgvList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvList.SelectionMode = DataGridViewSelectionMode.FullRowSelect
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim path As String = SelectOpenFile("")
        If Not String.IsNullOrEmpty(path) Then
            txtExcelPath.Text = path
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim path As String = SelectFolder("")
        If Not String.IsNullOrEmpty(path) Then
            txtOutputFolder.Text = path
        End If
    End Sub
End Class
