using UnityEngine;

namespace projectGF
{
    public class LoadingScenesManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            Debug.Log("开启loading");
            UICtrl.Instance.OpenUI(GameAssetsPath.UI_Loading_Path);
        }

        void OnDestroy()
        {
            Debug.Log("关闭loading  并关闭上一场景开启的所有UI");
            UICtrl.Instance.CloseAllUIPanel();
        }
    }
}

