
using projectGF;
using UnityEngine.UI;

public class LoginUI : UIViewBase
{
    public LoginUIModel Model
    {
        get { return _model as LoginUIModel; }
    }

    public InputField userName;
    public InputField passWord;
    public Button LoginBtn;
    //public Button RegisterBtn;
    //public DropDownList1 LoginTypeDdList;
    //public DropDownList1 ServerSelectDdList;
    /// <summary>
    /// 是否登录成功  1成功  0失败
    /// </summary>
    private int isLoginOk = 0;
    public override void Init()
    {
        LoginBtn.onClick.AddListener(OnLoginBtnClick);
        //RegisterBtn.onClick.AddListener(OnRegisterBtnClick);
    }

    /*private void OnRegisterBtnClick()
    {
        UICtrl.Instance.OpenUI(GameAssetsPath.UI_Register_Path);
        this.Close();
    }*/

    private void OnLoginBtnClick()
    {
        string uname = userName.text;
        string pasw = passWord.text;

        RManager.scene.SetScene(new GFMainScene(), SceneDefine.Scene_GFMainScene, true);
    }

    /*private void Update()
    {
        if(Input.GetKeyDown(KeyCode.KeypadEnter)|| Input.GetKeyDown(KeyCode.Return))
        {
            OnLoginBtnClick();
        }
    }*/


    public override void OnShow()
    {
        
    }

    public override void OnHide()
    {
        //throw new System.NotImplementedException();
    }
}