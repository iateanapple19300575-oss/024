Imports System.Data.SqlClient


''' <summary>
''' Repository：inchActualRepository
''' </summary>
Public Class inchActualRepository
    Inherits TransactionBase

    ''' <summary>
    ''' コンストラクタ
    ''' </summary>
    ''' <param name="sqDblConn"></param>
    Public Sub New(ByVal sqDblConn As DbTransactionScope)
        MyBase.New(sqDblConn)
    End Sub

    ''' <summary>
    ''' キー指定取得
    ''' </summary>
    ''' <returns></returns>
    Public Function GetAll(ByVal entity As HourlyWageEntity) As DataTable

        ' SQL文の生成
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Length = 0
        sqlString.Append("SELECT").Append(" ")
        sqlString.Append("  Lecture_Date").Append(" ")
        sqlString.Append("  , Youbi").Append(" ")
        sqlString.Append("  , Koma_Seq").Append(" ")
        sqlString.Append("  , Site_Code").Append(" ")
        sqlString.Append("  , Class_Code").Append(" ")
        sqlString.Append("  , Teacher_Code").Append(" ")
        sqlString.Append("  , Lecture_Name").Append(" ")
        sqlString.Append("  , Subject").Append(" ")
        sqlString.Append("  , Number_Of_Text").Append(" ")
        sqlString.Append("  , Pinch_Type").Append(" ")
        sqlString.Append("  , Input_Date").Append(" ")
        sqlString.Append("  , Create_Date").Append(" ")
        sqlString.Append("  , Create_User").Append(" ")
        sqlString.Append("  , Update_Date").Append(" ")
        sqlString.Append("  , Update_User").Append(" ")
        sqlString.Append("FROM").Append(" ")
        sqlString.Append("  M_Hourly_Wage").Append(" ")
        sqlString.Append("WHERE").Append(" ")
        sqlString.Append("  1=1").Append(" ")
        sqlString.Append("ORDER BY").Append(" ")
        sqlString.Append("  ").Append(" ")

        ' パラメタ生成
        Dim params As New List(Of SqlParameter)

        Return ExecuteDataTable(sqlString.ToString(), params.ToArray)
    End Function

    ''' <summary>
    ''' キー指定取得
    ''' </summary>
    ''' <returns></returns>
    Public Function FindByIdAndRowversion(ByVal entity As HourlyWageEntity) As HourlyWageEntity

        ' SQL文の生成
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Length = 0
        sqlString.Append("SELECT").Append(" ")
        sqlString.Append("  Lecture_Date").Append(" ")
        sqlString.Append("  , Youbi").Append(" ")
        sqlString.Append("  , Koma_Seq").Append(" ")
        sqlString.Append("  , Site_Code").Append(" ")
        sqlString.Append("  , Class_Code").Append(" ")
        sqlString.Append("  , Teacher_Code").Append(" ")
        sqlString.Append("  , Lecture_Name").Append(" ")
        sqlString.Append("  , Subject").Append(" ")
        sqlString.Append("  , Number_Of_Text").Append(" ")
        sqlString.Append("  , Pinch_Type").Append(" ")
        sqlString.Append("  , Input_Date").Append(" ")
        sqlString.Append("  , Create_Date").Append(" ")
        sqlString.Append("  , Create_User").Append(" ")
        sqlString.Append("  , Update_Date").Append(" ")
        sqlString.Append("  , Update_User").Append(" ")
        sqlString.Append("FROM").Append(" ")
        sqlString.Append("  M_Hourly_Wage").Append(" ")
        sqlString.Append("WHERE").Append(" ")
        sqlString.Append("  1=1").Append(" ")
        sqlString.Append("  AND Id = @Id").Append(" ")
        sqlString.Append("  AND RowVersion = @RowVersion").Append(" ")

        ' パラメタ生成
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter() With {.ParameterName = "@Id", .Value = entity.Id})
        params.Add(New SqlParameter() With {.ParameterName = "@RowVersion", .Value = entity.RowVersion})

        Return ExecuteQuerySingle(sqlString.ToString(), params.ToArray)
    End Function

    ''' <summary>
    ''' INSERT
    ''' </summary>
    ''' <param name="entity"></param>
     ''' <returns>処理件数</returns>
    Public Function Insert(ByVal entity As HourlyWageEntity) As Integer

        ' SQL文の生成
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Length = 0
        sqlString.Append("INSERT INTO").Append(" ")
        sqlString.Append("  M_Hourly_Wage").Append(" ")
        sqlString.Append("  (").Append(" ")
        sqlString.Append("    Lecture_Date").Append(" ")
        sqlString.Append("    , Youbi").Append(" ")
        sqlString.Append("    , Koma_Seq").Append(" ")
        sqlString.Append("    , Site_Code").Append(" ")
        sqlString.Append("    , Class_Code").Append(" ")
        sqlString.Append("    , Teacher_Code").Append(" ")
        sqlString.Append("    , Lecture_Name").Append(" ")
        sqlString.Append("    , Subject").Append(" ")
        sqlString.Append("    , Number_Of_Text").Append(" ")
        sqlString.Append("    , Pinch_Type").Append(" ")
        sqlString.Append("    , Input_Date").Append(" ")
        sqlString.Append("    , Create_Date").Append(" ")
        sqlString.Append("    , Create_User").Append(" ")
        sqlString.Append("    , Update_Date").Append(" ")
        sqlString.Append("    , Update_User").Append(" ")
        sqlString.Append("  ) VALUES (").Append(" ")
        sqlString.Append("    @Lecture_Date").Append(" ")
        sqlString.Append("    , @Youbi").Append(" ")
        sqlString.Append("    , @Koma_Seq").Append(" ")
        sqlString.Append("    , @Site_Code").Append(" ")
        sqlString.Append("    , @Class_Code").Append(" ")
        sqlString.Append("    , @Teacher_Code").Append(" ")
        sqlString.Append("    , @Lecture_Name").Append(" ")
        sqlString.Append("    , @Subject").Append(" ")
        sqlString.Append("    , @Number_Of_Text").Append(" ")
        sqlString.Append("    , @Pinch_Type").Append(" ")
        sqlString.Append("    , @Input_Date").Append(" ")
        sqlString.Append("    , GETDATE()").Append(" ")
        sqlString.Append("    , @Create_User").Append(" ")
        sqlString.Append("    , NULL").Append("   ")
        sqlString.Append("    , NULL").Append("   ")
        sqlString.Append("  )").Append(" ")

        ' パラメタ生成
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter() With {.ParameterName = "@Lecture_Date", .Value = entity.LectureDate})
        params.Add(New SqlParameter() With {.ParameterName = "@Youbi", .Value = entity.Youbi})
        params.Add(New SqlParameter() With {.ParameterName = "@Koma_Seq", .Value = entity.KomaSeq})
        params.Add(New SqlParameter() With {.ParameterName = "@Site_Code", .Value = entity.SiteCode})
        params.Add(New SqlParameter() With {.ParameterName = "@Class_Code", .Value = entity.ClassCode})
        params.Add(New SqlParameter() With {.ParameterName = "@Teacher_Code", .Value = entity.TeacherCode})
        params.Add(New SqlParameter() With {.ParameterName = "@Lecture_Name", .Value = entity.LectureName})
        params.Add(New SqlParameter() With {.ParameterName = "@Subject", .Value = entity.Subject})
        params.Add(New SqlParameter() With {.ParameterName = "@Number_Of_Text", .Value = entity.NumberOfText})
        params.Add(New SqlParameter() With {.ParameterName = "@Pinch_Type", .Value = entity.PinchType})
        params.Add(New SqlParameter() With {.ParameterName = "@Input_Date", .Value = entity.InputDate})
        params.Add(New SqlParameter() With {.ParameterName = "@Create_User", .Value = entity.CreateUser})

        Return ExecuteNonQuery(sqlString.ToString(), params.ToArray)
    End Function

    ''' <summary>
    ''' UPDATE
    ''' </summary>
    ''' <param name="entity"></param>
     ''' <returns>処理件数</returns>
    Public Function UpdateByIdAndRowversion(ByVal entity As HourlyWageEntity) As Integer

        ' SQL文の生成
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Length = 0
        sqlString.Append("UPDATE").Append(" ")
        sqlString.Append("  M_Hourly_Wage").Append(" ")
        sqlString.Append("  SET").Append(" ")
        sqlString.Append("    Lecture_Date = @Lecture_Date").Append(" ")
        sqlString.Append("    , Youbi = @Youbi").Append(" ")
        sqlString.Append("    , Koma_Seq = @Koma_Seq").Append(" ")
        sqlString.Append("    , Site_Code = @Site_Code").Append(" ")
        sqlString.Append("    , Class_Code = @Class_Code").Append(" ")
        sqlString.Append("    , Teacher_Code = @Teacher_Code").Append(" ")
        sqlString.Append("    , Lecture_Name = @Lecture_Name").Append(" ")
        sqlString.Append("    , Subject = @Subject").Append(" ")
        sqlString.Append("    , Number_Of_Text = @Number_Of_Text").Append(" ")
        sqlString.Append("    , Pinch_Type = @Pinch_Type").Append(" ")
        sqlString.Append("    , Input_Date = @Input_Date").Append(" ")
        sqlString.Append("    , Update_Date = GETDATE()").Append(" ")
        sqlString.Append("    , Update_User = @Update_User").Append(" ")
        sqlString.Append("  WHERE").Append(" ")
        sqlString.Append("    1=1").Append(" ")
        sqlString.Append("    AND Id = @Id").Append(" ")
        sqlString.Append("    AND RowVersion = @RowVersion").Append(" ")

        ' パラメタ生成
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter() With {.ParameterName = "@Lecture_Date", .Value = entity.LectureDate})
        params.Add(New SqlParameter() With {.ParameterName = "@Youbi", .Value = entity.Youbi})
        params.Add(New SqlParameter() With {.ParameterName = "@Koma_Seq", .Value = entity.KomaSeq})
        params.Add(New SqlParameter() With {.ParameterName = "@Site_Code", .Value = entity.SiteCode})
        params.Add(New SqlParameter() With {.ParameterName = "@Class_Code", .Value = entity.ClassCode})
        params.Add(New SqlParameter() With {.ParameterName = "@Teacher_Code", .Value = entity.TeacherCode})
        params.Add(New SqlParameter() With {.ParameterName = "@Lecture_Name", .Value = entity.LectureName})
        params.Add(New SqlParameter() With {.ParameterName = "@Subject", .Value = entity.Subject})
        params.Add(New SqlParameter() With {.ParameterName = "@Number_Of_Text", .Value = entity.NumberOfText})
        params.Add(New SqlParameter() With {.ParameterName = "@Pinch_Type", .Value = entity.PinchType})
        params.Add(New SqlParameter() With {.ParameterName = "@Input_Date", .Value = entity.InputDate})
        params.Add(New SqlParameter() With {.ParameterName = "@Update_User", .Value = entity.UpdateUser})

        Return ExecuteNonQuery(sqlString.ToString(), params.ToArray)
    End Function

    ''' <summary>
    ''' DELETE
    ''' </summary>
    ''' <param name="entity"></param>
     ''' <returns>処理件数</returns>
    Public Function DeleteByIdAndRowversion(ByVal entity As HourlyWageEntity) As Integer

        ' SQL文の生成
        Dim sqlString As New System.Text.StringBuilder
        sqlString.Length = 0
        sqlString.Append("DELETE").Append(" ")
        sqlString.Append("  FROM").Append(" ")
        sqlString.Append("    M_Hourly_Wage").Append(" ")
        sqlString.Append("  WHERE").Append(" ")
        sqlString.Append("    1=1").Append(" ")
        sqlString.Append("    AND Id = @Id").Append(" ")
        sqlString.Append("    AND RowVersion = @RowVersion").Append(" ")

        ' パラメタ生成
        Dim params As New List(Of SqlParameter)
        params.Add(New SqlParameter() With {.ParameterName = "@Id", .Value = entity.Id})
        params.Add(New SqlParameter() With {.ParameterName = "@RowVersion", .Value = entity.RowVersion})

        Return ExecuteNonQuery(sqlString.ToString(), params.ToArray)
    End Function

End Class
