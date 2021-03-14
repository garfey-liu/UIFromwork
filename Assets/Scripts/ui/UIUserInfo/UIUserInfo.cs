using projectGF;
using UnityEngine;
using UnityEngine.UI;

public class UIUserInfo : UIViewBase
{
    public UIUserInfoModel Model
    {
        get { return _model as UIUserInfoModel; }
    }

    public Button QuitBtn;
    public Button RloginBtn;
    public Button CloseBtn;

    public override void Init()
    {
        QuitBtn.onClick.AddListener(OnQuitBtnClick);
        RloginBtn.onClick.AddListener(OnRloginBtnClick);
        CloseBtn.onClick.AddListener(OncloseBtnClick);
    }

    private void OnQuitBtnClick()
    {
        Application.Quit();
    }

    private void OnRloginBtnClick()
    {
        RManager.scene.SetScene(new LoginAndRegistScene(), SceneDefine.Scene_LoginAndRegist,true);
    }

    private void OncloseBtnClick()
    {
        this.Close();
    }

    public override void OnShow()
    {

    }

    public override void OnHide()
    {
        //throw new System.NotImplementedException();
    }
}
