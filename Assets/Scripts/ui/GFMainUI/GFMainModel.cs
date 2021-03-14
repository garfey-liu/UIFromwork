using projectGF;
using UnityEngine;

public class GFMainModel : UIModelBase
{
    private GFMainUI UI
    {
        get { return _ui as GFMainUI; }
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
                if (data != null && data.Length > 0)
                {
                    isLoginOk = (int)data[0];
                }
                if (isLoginOk == 0)
                {
                    Debug.LogError("用户Http服务器 登录回复成功了。。。。。User token:");
                    // 登录成功

                }
                else
                {
                    // 登录失败
                    MessageBoxCtrl.Instance.MessageBox_Tips("登录失败！请检查用户名或密码");
                }
                break;
            case EventEnum.EventListener.TcpLoginFinish:
                if (data != null && data.Length > 0)
                {
                    isLoginOk = (int)data[0];
                }
                if (isLoginOk == 0)
                {
                    Debug.LogError("用户Tcp服务器 登录回复成功了。。。。。isLoginOk:" + isLoginOk);
                    // 登录成功
                    isIn = true;
                }
                else
                {
                    // 登录失败
                    MessageBoxCtrl.Instance.MessageBox_Tips("自动登录tcp 服务器登录失败！");
                }
                break;
        }
    }

    #endregion---------------------------------------------------
}
