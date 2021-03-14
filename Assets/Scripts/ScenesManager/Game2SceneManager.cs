using projectGF;
using UnityEngine;

public class Game2SceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("开启 Game2SceneManager");
        UICtrl.Instance.OpenUI(GameAssetsPath.UI_BackMain_Path, null, new object[] { "game2" ,false});
    }
    void OnDestroy()
    {
        //Debug.Log("关闭loading  并关闭上一场景开启的所有UI");
        //UICtrl.Instance.CloseAllUIPanel();
        //UICtrl.Instance.CloseUI(ToolsUtil.getUINameForPath(GameAssetsPath.UI_Loading_Path));
    }
}
