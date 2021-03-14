using UnityEngine;

namespace projectGF
{
    public class StartScene : UIViewBase
    {
        public override void Init()
        {
            Invoke("StartInit", 1);
        }

        public override void OnHide()
        {
            //throw new System.NotImplementedException();
        }

        public override void OnShow()
        {

        }

        public void StartInit()
        {
            Debug.Log("logo播放完成，加载登录注册场景");
            RManager.scene.SetScene(new LoginAndRegistScene(), SceneDefine.Scene_LoginAndRegist);
            //this.Close();
        }
    }
}

