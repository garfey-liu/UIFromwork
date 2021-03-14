using projectGF;

public class UIUserInfoModel : UIModelBase
{
    private UIUserInfo UI
    {
        get { return _ui as UIUserInfo; }
    }

    /// <summary>
    ///  分线程调用开关
    /// </summary>
    private bool isIn = false;

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
        int isLoginOk = 0;
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
