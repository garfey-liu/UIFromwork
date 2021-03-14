
namespace projectGF
{
    public class Game1Scene : SceneBase
    {
        public Game1Scene()
        {
            StateName = SceneDefine.Scene_Game1Scene;
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
