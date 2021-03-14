
using Newtonsoft.Json;
using projectGF;
using System;
using System.Collections;
using UnityEngine;

public class LoginUIModel : UIModelBase
{
    private LoginUI UI
    {
        get { return _ui as LoginUI; }
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

    /*void Update()
    {
        /// 由于多线程调用，在分线程中无法调用主线程中的某些方法或函数，比如协同（StartCoroutine）就不能调用，
        /// 官方 给出解释必须在醒着的Awake 或者 Start 、 Update中调用，所以出此方案，在Update中通过开关来
        /// 协同切换场景，其他使用正常。
        /// 注意： 多线程使用时如遇发现，逻辑正常，但无法调用，可以考虑是否是分线程中无法调用
        if (isIn)
        {
            isIn = false;
            // 进入主场景
            RManager.scene.SetScene(new StudentMainScene(), SceneDefine.Scene_StudentMain, true);
            //RManager.scene.SetScene(new PcStudyScene(), SceneDefine.Scene_PcStudy, true);
        }
    }*/
}
