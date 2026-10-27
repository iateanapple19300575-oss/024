''' <summary>
''' Entity ⇔ Dto ⇔ Model Mapper：LecturePlan
''' </summary>
Public Class LecturePlanMapper

    ''' <summary>
    ''' Entity → DTO 変換
    ''' LecturePlanEntity → LecturePlanDto
    ''' </summary>
    Public Shared Function ToDto(ByVal e As LecturePlanEntity) As LecturePlanDto
        Dim d As New LecturePlanDto()
        d.LectureDate = e.LectureDate
        d.KomaSeq = e.KomaSeq
        d.SiteCode = e.SiteCode
        d.Grade = e.Grade
        d.ClassCode = e.ClassCode
        d.Subject = e.Subject
        d.TeacherCode = e.TeacherCode
        d.LectureName = e.LectureName
        d.NumberOfText = e.NumberOfText
        d.CreateDate = e.CreateDate
        d.CreateUser = e.CreateUser
        d.UpdateDate = e.UpdateDate
        d.UpdateUser = e.UpdateUser
        Return d
    End Function

    ''' <summary>
    ''' DTO → Entity 変換
    ''' LecturePlanDto → LecturePlanEntity
    ''' </summary>
    Public Shared Function ToEntity(ByVal d As LecturePlanDto) As LecturePlanEntity
        Dim e As New LecturePlanEntity()
        e.LectureDate = d.LectureDate
        e.KomaSeq = d.KomaSeq
        e.SiteCode = d.SiteCode
        e.Grade = d.Grade
        e.ClassCode = d.ClassCode
        e.Subject = d.Subject
        e.TeacherCode = d.TeacherCode
        e.LectureName = d.LectureName
        e.NumberOfText = d.NumberOfText
        e.CreateDate = d.CreateDate
        e.CreateUser = d.CreateUser
        e.UpdateDate = d.UpdateDate
        e.UpdateUser = d.UpdateUser
        Return e
    End Function

    ''' <summary>
    ''' DTO → Model 変換
    ''' LecturePlanDto → LecturePlanModel
    ''' </summary>
    Public Shared Function ToModel(ByVal d As LecturePlanDto) As LecturePlanModel
        Dim m As New LecturePlanModel()
        m.LectureDate = d.LectureDate
        m.KomaSeq = d.KomaSeq
        m.SiteCode = d.SiteCode
        m.Grade = d.Grade
        m.ClassCode = d.ClassCode
        m.Subject = d.Subject
        m.TeacherCode = d.TeacherCode
        m.LectureName = d.LectureName
        m.NumberOfText = d.NumberOfText
        m.CreateDate = d.CreateDate
        m.CreateUser = d.CreateUser
        m.UpdateDate = d.UpdateDate
        m.UpdateUser = d.UpdateUser
        Return m
    End Function

    ''' <summary>
    ''' Model → DTO 変換
    ''' LecturePlanModel → LecturePlanDto
    ''' </summary>
    Public Shared Function ToDtoFromModel(ByVal m As LecturePlanModel) As LecturePlanDto
        Dim d As New LecturePlanDto()
        d.LectureDate = m.LectureDate
        d.KomaSeq = m.KomaSeq
        d.SiteCode = m.SiteCode
        d.Grade = m.Grade
        d.ClassCode = m.ClassCode
        d.Subject = m.Subject
        d.TeacherCode = m.TeacherCode
        d.LectureName = m.LectureName
        d.NumberOfText = m.NumberOfText
        d.CreateDate = m.CreateDate
        d.CreateUser = m.CreateUser
        d.UpdateDate = m.UpdateDate
        d.UpdateUser = m.UpdateUser
        Return d
    End Function

End Class
