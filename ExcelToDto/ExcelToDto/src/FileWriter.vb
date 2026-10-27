Imports System.IO

''' <summary>
''' ファイル書き込みクラス
''' </summary>
Public Module FileWriter

    ''' <summary>
    ''' UTF-8でファイル出力します。
    ''' </summary>
    ''' <param name="path"></param>
    ''' <param name="code"></param>
    Public Sub WriteToFile(ByVal path As String, ByVal code As String)
        Using sw As New StreamWriter(path, False, System.Text.Encoding.UTF8)
            sw.Write(code)
        End Using
    End Sub
End Module
