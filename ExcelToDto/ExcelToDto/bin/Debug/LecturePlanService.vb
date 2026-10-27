''' <summary>
''' Service：LecturePlanService
''' </summary>
Public Class LecturePlanService

    ''' <summary>リポジトリ</summary>
    Private ReadOnly _repo As LecturePlanRepository

    ''' <summary>コンストラクタ</summary>
    Public Sub New(ByVal repo As LecturePlanRepository)
        _repo = repo
    End Sub

    Public Function GetData() As LecturePlanDto
        Dim e As LecturePlanEntity = _repo.Find()
        Return LecturePlanMapper.ToDto(e)
    End Function

End Class
