using projectGF;

public class UIActiveModel : UIModelBase
{
    private UIActive UI
    {
        get { return _ui as UIActive; }
    }

    #region override--------------------------------------------

    protected override EventEnum.EventListener[] FocusNetWorkData()
    {
        return new EventEnum.EventListener[]
        {
            EventEnum.EventListener.HttpLoginFinish,
            EventEnum.EventListener.TcpLoginFinish,
        };
    }

    protected override void OnNetWorkDataCallBack(EventEnum.EventListener msgEnum, object[] data)
    {
        switch (msgEnum)
        {
            case EventEnum.EventListener.HttpLoginFinish:

                break;
            case EventEnum.EventListener.TcpLoginFinish:

                break;
        }
    }

    #endregion---------------------------------------------------
}
