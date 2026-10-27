''' <summary>
''' Presenter：PinchActualPresenter
''' </summary>
Public Class PinchActualPresenter

    ''' <summary>PinchActualView</summary>
    Private ReadOnly _view As IPinchActualView

    ''' <summary>PinchActualService</summary>
    Private ReadOnly _service As PinchActualService

    ''' <summary>コンストラクタ</summary>
    Public Sub New(ByVal view As IPinchActualView, ByVal service As PinchActualService)
        _view = view
        _service = service
    End Sub

    Public Sub LoadData()
        Dim dto As PinchActualDto = _service.GetData()
        Dim model As PinchActualModel = PinchActualMapper.ToModel(dto)
        _view.Bind(model)
    End Sub

End Class
