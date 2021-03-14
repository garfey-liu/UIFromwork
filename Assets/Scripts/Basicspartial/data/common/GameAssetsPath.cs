


using UnityEngine;
/**
* @Author GarFey
* 20180723
*/
namespace projectGF
{
    public class GameAssetsPath : SingletonTamplate<GameAssetsPath>
    {
        #region  config 配置文件路劲 ===================================

        /// <summary>
        /// 本地配置文件存放的文件夹
        /// </summary>
        public string Config_LocalFile_Path = Application.dataPath + "/config/";
        /// <summary>
        /// 本地配置文件全名
        /// </summary>
        public string Config_Name = "config.cfg";
        /// <summary>
        /// 本地配置文件完整目录
        /// </summary>
        public string Config_LocalData_Path
        {
            get { return  Config_LocalFile_Path+ Config_Name; }
        }


        #endregion =====================================================

        #region AnimatorController ===========================================


        #endregion

        #region Prefab-----------------------------
        /// <summary>
        /// 主角Prefab
        /// </summary>
        public const string Prefab_Player_Path = "Prefabs/Player/Player";

        /// <summary>
        /// Tips弹框
        /// </summary>
        public const string Prefab_UINoticeTip_Path = "Prefabs/SystemBox/NoticeTip/NoticeTip";//

        /// <summary>
        /// 与服务器交互 等待圈
        /// </summary>
        public const string Prafab_LoadingBar_Path = "Prefabs/SystemBox/LoadingBar/LoadingBar";

        #endregion---------------------------------

        #region UI-----------------------------

        /// <summary>
        /// UI Start
        /// </summary>
        public const string UI_Start_Path = "ui/StartScene/StartScene";

        /// <summary>
        /// UI Loading
        /// </summary>
        public const string UI_Loading_Path = "ui/Loading/Loading";

        /// <summary>
        /// 网络等待 Loading
        /// </summary>
        public const string UI_NetLoading_Path = "ui/NetLoading/NetLoading";

        /// <summary>
        /// GFMainUI
        /// </summary>
        public const string UI_GFMain_Path = "ui/GFMainUI/GFMainUI";

        /// <summary>
        /// UI登录
        /// </summary>
        public const string UI_Login_Path = "ui/LoginUI/LoginUI";

        /// <summary>
        /// UI 用户信息界面
        /// </summary>
        public const string UI_UserInfo_Path = "ui/UIUserInfo/UIUserInfo";

        /// <summary>
        /// 活动页面
        /// </summary>
        public const string UI_Active_Path = "ui/UIActive/UIActive";

        /// <summary>
        /// 建筑规划界面
        /// </summary>
        public const string UI_JZGH_Path = "ui/UIJZGH/UIJZGH";

        /// <summary>
        /// 其它 界面
        /// </summary>
        public const string UI_Other_Path = "ui/UIOther/UIOther";

        /// <summary>
        /// 返回主场景 示例界面
        /// </summary>
        public const string UI_BackMain_Path = "ui/UIBackMain/UIBackMain";

        /// <summary>
        /// 场景中 弹出框 界面
        /// </summary>
        public const string UI_SceneTips_Path = "ui/SceneTipsUI/SceneTipsUI";


        #endregion---------------------------------

        #region SceneUI Path 场景UI路径

        /// <summary>
        /// 只有文本的 弹出框
        /// </summary>
        public const string SceneUI_TextNotice_Path = "uiscene/UITextNotice/UITextNotice";

        /// <summary>
        /// 一个btn的 弹出框
        /// </summary>
        public const string SceneUI_OneBtnNotice_Path = "uiscene/UIOneBtnNotice/UIOneBtnNotice";

        /// <summary>
        /// 多个but的 弹出框
        /// </summary>
        public const string SceneUI_MorBtnNotice_Path = "uiscene/UIMorBtnNotice/UIMorBtnNotice";

        /// <summary>
        /// 多个Toggle的 弹出框
        /// </summary>
        public const string SceneUI_MorToggleNotc_Path = "uiscene/UIMorTogleNotice/UIMorTogleNotice";

        #endregion

        #region Music-----------------------------

        public const string Mic_Tishi_Path = "Sounds/tishi";

        #endregion---------------------------------
    }
}
