Imports System.Data.OleDb

''' <summary>
''' 全シートジェネレーター
''' </summary>
Public Class MultiSheetGenerator

    Dim baseJName As String = ""
    Dim baseEName As String = ""

    ''' <summary>
    ''' Excel の複数シートを読み取り、各シートから全クラスを自動生成してファイル出力する
    ''' </summary>
    Public Sub GenerateAll(ByVal excelPath As String, ByVal outputDir As String, ByVal values As List(Of SheetItemData))
        Dim sheetNames As List(Of SheetItemData) = GetSheetNames(excelPath)
        Dim reader As New ExcelDefinitionReader()
        Dim classGen As New ClassGenerator()
        Dim mapperGen As New MapperGenerator()
        Dim presenterGen As New PresenterGenerator()
        Dim serviceGen As New ServiceGenerator()
        Dim viewGen As New ViewGenerator()
        Dim repoGen As New RepositoryGenerator()


        For Each sheet As SheetItemData In sheetNames

            ' テーブル定義のシート以外はスキップ
            If sheet.Value = "表紙" OrElse
                    sheet.Value = "変更履歴" OrElse
                    sheet.Value = "テーブル関連図" OrElse
                    sheet.Value = "項目整理" OrElse
                    sheet.Value = "フォーマット" OrElse
                    sheet.Value = "差分レポート" OrElse
                    sheet.Value = "テーブル一覧" Then
                Continue For
            End If

            Dim flg As Boolean = False
            For Each item As SheetItemData In values
                If item.Value = sheet.Value Then
                    flg = True
                    Exit For
                End If
            Next
            If Not flg Then
                Continue For
            End If

            ' 
            Dim dtSource As DataTable = reader.ReadDefinition(excelPath, sheet.Value)
            Dim dt As DataTable = GetTableDefinitions(dtSource, baseEName, baseJName)
            Dim tableName As String = baseEName
            baseEName = ToPascalCase(baseEName).Substring(1)


            Dim baseName As String = baseEName

            '===========================
            ' Entity / DTO / Model
            '===========================
            FileWriter.WriteToFile(outputDir & "\" & baseName & "Entity.vb", classGen.GenerateClass(baseName & "Entity", dt))
            FileWriter.WriteToFile(outputDir & "\" & baseName & "Dto.vb", classGen.GenerateClass(baseName & "Dto", dt))
            FileWriter.WriteToFile(outputDir & "\" & baseName & "Model.vb", classGen.GenerateClass(baseName & "Model", dt))
            FileWriter.WriteToFile(outputDir & "\" & baseName & "Mapper.vb", mapperGen.GenerateMapper(baseName, dt))
            FileWriter.WriteToFile(outputDir & "\" & baseName & "Service.vb", serviceGen.GenerateService(baseName, dt))
            FileWriter.WriteToFile(outputDir & "\" & baseName & "Presenter.vb", presenterGen.GeneratePresenter(baseName, dt))
            FileWriter.WriteToFile(outputDir & "\" & baseName & "View.vb", viewGen.GenerateViewInterface(baseName))
            FileWriter.WriteToFile(outputDir & "\" & baseName & "Repository.vb", repoGen.GenerateRepository(baseName, dt, tableName))
        Next
    End Sub

End Class
