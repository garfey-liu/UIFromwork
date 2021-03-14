using System;
using projectGF;
using UnityEngine;
using UnityEngine.UI;

public class GFMainUI : UIViewBase
{
    public GFMainModel Model
    {
        get { return _model as GFMainModel; }
    }

    public Button UserInfoBtn;
    public Button JzghBtn;
    public Button workBtn;
    public Button yiliaoBtn;
    public Button fanganBtn;
    public Button yanjiuBtn;
    public Button renwuBtn;
    public Button otherBtn;

    public override void Init()
    {
        UserInfoBtn.onClick.AddListener(OnUserInfoBtnClick);
        JzghBtn.onClick.AddListener(OnJzghBtnClick);
        workBtn.onClick.AddListener(OnWorkBtnClick);
        yiliaoBtn.onClick.AddListener(OnyiliaoBtnClick);
        fanganBtn.onClick.AddListener(OnfanganBtnClick);
        yanjiuBtn.onClick.AddListener(OnyanjiuBtnClick);
        renwuBtn.onClick.AddListener(OnrenwuBtnClick);
        otherBtn.onClick.AddListener(OnotherBtnClick);
        if(RManager.Instance.isFirstShow)
        {
            Invoke("showActive", 2);
            RManager.Instance.isFirstShow = false;
        }
        
    }

    private void OnotherBtnClick()
    {
        UICtrl.Instance.OpenUI(GameAssetsPath.UI_Other_Path);
    }

    private void OnrenwuBtnClick()
    {
        MessageBoxCtrl.Instance.MessageBox_Tips("任务！详细功能在研发喽");
    }

    private void OnyanjiuBtnClick()
    {
        MessageBoxCtrl.Instance.MessageBox_Tips("研究！详细功能在研发喽");
    }

    private void OnfanganBtnClick()
    {
        MessageBoxCtrl.Instance.MessageBox_Tips("方案！详细功能在研发喽");
    }

    private void OnyiliaoBtnClick()
    {
        MessageBoxCtrl.Instance.MessageBox_Tips("医疗！详细功能在研发喽");
    }

    private void OnWorkBtnClick()
    {
        MessageBoxCtrl.Instance.MessageBox_Tips("工作！详细功能在研发喽");
    }

    void showActive()
    {
        UICtrl.Instance.OpenUI(GameAssetsPath.UI_Active_Path, UICtrl.Instance._UIManager.UItipsPath);
    }

    private void OnUserInfoBtnClick()
    {
        UICtrl.Instance.OpenUI(GameAssetsPath.UI_UserInfo_Path);
    }

    private void OnTipBtnClick()
    {
        MessageBoxCtrl.Instance.MessageBox_Tips("Tips功能已生效！");
    }

    private void OnJzghBtnClick()
    {
        UICtrl.Instance.OpenUI(GameAssetsPath.UI_JZGH_Path);
    }


    public override void OnShow()
    {

    }

    public override void OnHide()
    {
        //throw new System.NotImplementedException();
    }
}
