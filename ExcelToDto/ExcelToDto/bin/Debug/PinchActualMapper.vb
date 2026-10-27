''' <summary>
''' Entity ⇔ Dto ⇔ Model Mapper：PinchActual
''' </summary>
Public Class PinchActualMapper

    ''' <summary>
    ''' Entity → DTO 変換
    ''' PinchActualEntity → PinchActualDto
    ''' </summary>
    Public Shared Function ToDto(ByVal e As PinchActualEntity) As PinchActualDto
        Dim d As New PinchActualDto()
        d.LectureDate = e.LectureDate
        d.Youbi = e.Youbi
        d.KomaSeq = e.KomaSeq
        d.SiteCode = e.SiteCode
        d.ClassCode = e.ClassCode
        d.TeacherCode = e.TeacherCode
        d.LectureName = e.LectureName
        d.Subject = e.Subject
        d.NumberOfText = e.NumberOfText
        d.PinchType = e.PinchType
        d.InputDate = e.InputDate
        d.CreateDate = e.CreateDate
        d.CreateUser = e.CreateUser
        d.UpdateDate = e.UpdateDate
        d.UpdateUser = e.UpdateUser
        Return d
    End Function

    ''' <summary>
    ''' DTO → Entity 変換
    ''' PinchActualDto → PinchActualEntity
    ''' </summary>
    Public Shared Function ToEntity(ByVal d As PinchActualDto) As PinchActualEntity
        Dim e As New PinchActualEntity()
        e.LectureDate = d.LectureDate
        e.Youbi = d.Youbi
        e.KomaSeq = d.KomaSeq
        e.SiteCode = d.SiteCode
        e.ClassCode = d.ClassCode
        e.TeacherCode = d.TeacherCode
        e.LectureName = d.LectureName
        e.Subject = d.Subject
        e.NumberOfText = d.NumberOfText
        e.PinchType = d.PinchType
        e.InputDate = d.InputDate
        e.CreateDate = d.CreateDate
        e.CreateUser = d.CreateUser
        e.UpdateDate = d.UpdateDate
        e.UpdateUser = d.UpdateUser
        Return e
    End Function

    ''' <summary>
    ''' DTO → Model 変換
    ''' PinchActualDto → PinchActualModel
    ''' </summary>
    Public Shared Function ToModel(ByVal d As PinchActualDto) As PinchActualModel
        Dim m As New PinchActualModel()
        m.LectureDate = d.LectureDate
        m.Youbi = d.Youbi
        m.KomaSeq = d.KomaSeq
        m.SiteCode = d.SiteCode
        m.ClassCode = d.ClassCode
        m.TeacherCode = d.TeacherCode
        m.LectureName = d.LectureName
        m.Subject = d.Subject
        m.NumberOfText = d.NumberOfText
        m.PinchType = d.PinchType
        m.InputDate = d.InputDate
        m.CreateDate = d.CreateDate
        m.CreateUser = d.CreateUser
        m.UpdateDate = d.UpdateDate
        m.UpdateUser = d.UpdateUser
        Return m
    End Function

    ''' <summary>
    ''' Model → DTO 変換
    ''' PinchActualModel → PinchActualDto
    ''' </summary>
    Public Shared Function ToDtoFromModel(ByVal m As PinchActualModel) As PinchActualDto
        Dim d As New PinchActualDto()
        d.LectureDate = m.LectureDate
        d.Youbi = m.Youbi
        d.KomaSeq = m.KomaSeq
        d.SiteCode = m.SiteCode
        d.ClassCode = m.ClassCode
        d.TeacherCode = m.TeacherCode
        d.LectureName = m.LectureName
        d.Subject = m.Subject
        d.NumberOfText = m.NumberOfText
        d.PinchType = m.PinchType
        d.InputDate = m.InputDate
        d.CreateDate = m.CreateDate
        d.CreateUser = m.CreateUser
        d.UpdateDate = m.UpdateDate
        d.UpdateUser = m.UpdateUser
        Return d
    End Function

End Class
