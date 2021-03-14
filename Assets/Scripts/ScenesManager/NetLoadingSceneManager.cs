using projectGF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetLoadingSceneManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("开启Netloading");
        UICtrl.Instance.OpenUI(GameAssetsPath.UI_NetLoading_Path);
    }

    void OnDestroy()
    {
        Debug.Log("关闭loading  并关闭上一场景开启的所有UI");
        UICtrl.Instance.CloseAllUIPanel();
        //UICtrl.Instance.CloseUI(ToolsUtil.getUINameForPath(GameAssetsPath.UI_Loading_Path));
    }
}
