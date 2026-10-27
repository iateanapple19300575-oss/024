''' <summary>
''' Presenter：LecturePlanPresenter
''' </summary>
Public Class LecturePlanPresenter

    ''' <summary>LecturePlanView</summary>
    Private ReadOnly _view As ILecturePlanView

    ''' <summary>LecturePlanServiceService</summary>
    Private ReadOnly _service As LecturePlanService

    ''' <summary>コンストラクタ</summary>
    Public Sub New(ByVal view As ILecturePlanView, ByVal service As LecturePlanService)
        _view = view
        _service = service
    End Sub

    Public Sub LoadData()
        Dim dto As LecturePlanDto = _service.GetData()
        Dim model As LecturePlanModel = LecturePlanMapper.ToModel(dto)
        _view.Bind(model)
    End Sub

End Class
