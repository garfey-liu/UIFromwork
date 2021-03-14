
namespace projectGF
{
    public class GFMainScene : SceneBase
    {
        public GFMainScene()
        {
            StateName = SceneDefine.Scene_GFMainScene;
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

