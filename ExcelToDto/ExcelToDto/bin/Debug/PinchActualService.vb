''' <summary>
''' Service：PinchActualService
''' </summary>
Public Class PinchActualService

    ''' <summary>リポジトリ</summary>
    Private ReadOnly _repo As PinchActualRepository

    ''' <summary>コンストラクタ</summary>
    Public Sub New(ByVal repo As PinchActualRepository)
        _repo = repo
    End Sub

    Public Function GetData() As PinchActualDto
        Dim e As PinchActualEntity = _repo.Find()
        Return PinchActualMapper.ToDto(e)
    End Function

End Class
