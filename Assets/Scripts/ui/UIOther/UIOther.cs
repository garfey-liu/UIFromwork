using System;
using projectGF;
using UnityEngine.UI;

public class UIOther : UIViewBase
{
    public UIOtherModel Model
    {
        get { return _model as UIOtherModel; }
    }

    public Button closeBtn;
    public Button s1Btn;
    public Button s2Btn;

    public override void Init()
    {
        closeBtn.onClick.AddListener(OncloseBtnClick);
        s1Btn.onClick.AddListener(OnS1BtnClick);
        s2Btn.onClick.AddListener(OnS2BtnClick);
    }

    private void OnS1BtnClick()
    {
        RManager.scene.SetScene(new Game1Scene(), SceneDefine.Scene_Game1Scene);
    }
    private void OnS2BtnClick()
    {
        RManager.scene.SetScene(new Game2Scene(), SceneDefine.Scene_Game2Scene);
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
