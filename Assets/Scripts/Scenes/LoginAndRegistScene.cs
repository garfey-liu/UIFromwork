
namespace projectGF
{
    public class LoginAndRegistScene : SceneBase
    {
        public LoginAndRegistScene()
        {
            StateName = SceneDefine.Scene_LoginAndRegist;
        }
        public override void StateBegin()
        {
            //关闭语音
            base.StateBegin();
        }

        public override void StateEnd()
        {
            base.StateEnd();
            //todo close all ui        
        }
    }
}

