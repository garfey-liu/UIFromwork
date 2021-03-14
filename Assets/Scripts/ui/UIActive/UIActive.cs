using projectGF;
using UnityEngine.UI;

public class UIActive : UIViewBase
{
    public UIActiveModel Model
    {
        get { return _model as UIActiveModel; }
    }

    public Button closeBtn;

    public override void Init()
    {
        closeBtn.onClick.AddListener(OncloseBtnClick);
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
