using projectGF;
using UnityEngine;
using UnityEngine.UI;

public class UIBackMain : UIViewBase
{
    public UIBackMainModel Model
    {
        get { return _model as UIBackMainModel; }
    }

    public Button backBtn;
    public Text TitleText;
    public GameObject s1Obj;
    public GameObject s2Obj;

    private string gameStr = "";
    private bool isShowG1;

    public override void Init()
    {
        backBtn.onClick.AddListener(OnbackBtnClick);
    }

    public override void OnPushData(object[] data)
    {
        if(data!=null&&data.Length>=2)
        {
            gameStr = (string)data[0];
            isShowG1 = (bool)data[1];
        }
        TitleText.text = gameStr;
        s1Obj.SetActive(isShowG1);
        s2Obj.SetActive(!isShowG1);
    }

    private void OnbackBtnClick()
    {
        RManager.scene.SetScene(new GFMainScene(), SceneDefine.Scene_GFMainScene);
    }


    public override void OnShow()
    {

    }

    public override void OnHide()
    {
        //throw new System.NotImplementedException();
    }
}
