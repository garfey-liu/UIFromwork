
namespace projectGF
{
    public class Game2Scene : SceneBase
    {
        public Game2Scene()
        {
            StateName = SceneDefine.Scene_Game2Scene;
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
