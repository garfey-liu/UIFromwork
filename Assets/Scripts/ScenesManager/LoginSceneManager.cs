using UnityEngine;

namespace projectGF
{
    public class LoginSceneManager : MonoBehaviour
    {
        void Awake()
        {
            Debug.Log("登录 场景打开");
        }
        // Start is called before the first frame update
        void Start()
        {
            UICtrl.Instance.OpenUI(GameAssetsPath.UI_Login_Path);
        }
    }
}

