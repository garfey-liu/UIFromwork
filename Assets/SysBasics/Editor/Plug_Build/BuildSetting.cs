using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace projectGF
{
    public class BuildSetting
    {
        #region 打包类型
        public enum EnumBuidleType
        {
            ZhengShi,   // 正式
            Debug,     // 测试
            OffLineDebug, // 无需连接服务器测试
            OffHTTP // 无需连接http服务器

        }
        #endregion

        #region 宏定义
        /************************************************************************/
        /* 
         * __DEBUG_LOG                  : 打印日志     
         * __OFFLINE                    : 无需连接服务器
         * __OFFHTTP                    : 无需连接HTTP服务器
         * 
         */
        /************************************************************************/


        //版本 ==============================
        //正式版 - 带所有插件，所有功能 
        public const string DEFINE_ZhengShi = "__DEBUG_LOG;";
        //测试版 - 带所有插件，所有功能 （需连接服务器）
        public const string DEFINE_DEBUG = "__DEBUG_LOG;";
        //测试版 - 带所有插件，所有功能 （无需连接服务器）
        public const string DEFINE_NOLINE_DEBUG = "__DEBUG_LOG;__OFFLINE;";
        //测试版 - 只关闭连接http服务器
        public const string DEFINE_OFFHTTP_DEBUG = "__DEBUG_LOG;__OFFHTTP";

        #endregion

        /// <summary>
        /// 出包目录
        /// </summary>
        public const string TARGET_DIR = "Target";
        /// <summary>
        /// 版本号
        /// </summary>
        public const string CURRENT_VERSION = "1.0.0.1001";
        /// <summary>
        /// 打包名称
        /// </summary>
        public const string BUILD_NAME = "340Client";


        [MenuItem("KXEditor/Build/打包离线PC")]
        public static void BuildWinNoLine()
        {
            BuidlePCByType(EnumBuidleType.OffLineDebug, true);
        }

        [MenuItem("KXEditor/Build/打包正式PC")]
        public static void BuildWin64()
        {
            BuidlePCByType(EnumBuidleType.ZhengShi, true);
        }

        [MenuItem("KXEditor/Build/打包测试PC")]
        public static void BuildWinDebug()
        {
            BuidlePCByType(EnumBuidleType.Debug, true);
        }

        [MenuItem("KXEditor/设置宏/离线测试")]
        public static void SetWinNoLine()
        {
            setDefine(GetDefine(EnumBuidleType.OffLineDebug));
        }

        [MenuItem("KXEditor/设置宏/正常测试")]
        public static void SetWinDebug()
        {
            setDefine(GetDefine(EnumBuidleType.Debug));
        }

        [MenuItem("KXEditor/设置宏/OffHttp测试")]
        public static void SetWinOffHttp()
        {
            setDefine(GetDefine(EnumBuidleType.OffHTTP));
        }


        static void setDefine(string symble)
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(GetBuildTargetGroup(BuildTarget.StandaloneWindows), symble);
            AssetDatabase.Refresh();
        }



        /// <summary>
        /// PC 打包函数
        /// </summary>
        /// <param name="buidleType"></param>
        /// <param name="isClearPath"></param>
        private static void BuidlePCByType(EnumBuidleType buidleType, bool isClearPath = false)
        {
            BuidleByType(buidleType, BuildTarget.StandaloneWindows, isClearPath);
        }

        /// <summary>
        /// 通用打包函数
        /// </summary>
        /// <param name="buidleType"></param>
        /// <param name="type"></param>
        /// <param name="BuildName"></param>
        /// <param name="isClearPath"></param>
        private static void BuidleByType(EnumBuidleType buidleType, BuildTarget type, bool isClearPath = false)
        {
            //取得保存路径  
            string savePath = GetTargetDirPath();
            //取得保存exe路径
            string saveExEPath = savePath + GetSavePath(buidleType, type);

            savePath = savePath + buidleType.ToString();

            if (isClearPath)
            {
                //清空目录
                ClearPath(saveExEPath);
            }

            //删除已经存在的游戏包
            if (System.IO.File.Exists(saveExEPath))
            {
                System.IO.File.Delete(saveExEPath);
            }

            //创建目录
            MakePath(saveExEPath);
            UnityEngine.Debug.Log("保存路径" + saveExEPath);


            //UnityEngine.Debug.Log("TYPE" + (type == BuildTarget.iOS));

            //设置预先配置信息
            PerSetting(buidleType);

            ////刷新Unity保存
            //AssetDatabase.Refresh();
            //设置宏定义
            SetBuildingDefine(GetBuildTargetGroup(type), GetDefine(buidleType));

            //取得打包Options
            BuildPlayerOptions option = GetBuildPlayerOptions(type, saveExEPath);

            //打包
            BuildForPlatform(option, savePath);

        }

        /// <summary>
        /// 取得目标目录
        /// </summary>
        /// <returns></returns>
        static string GetTargetDirPath()
        {
            return GetProjectDirPath()
                  + TARGET_DIR
                  + System.IO.Path.DirectorySeparatorChar;
        }

        /// <summary>
        /// 取得保存 目的地址
        /// </summary>
        /// <param name="type"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        private static string GetSavePath(EnumBuidleType type, BuildTarget target)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            switch (target)
            {
                case BuildTarget.StandaloneWindows:
                case BuildTarget.StandaloneWindows64:
                    sb.Append(type.ToString());
                    sb.Append("\\");
                    sb.Append(Application.productName);
                    sb.Append(".");
                    sb.Append(CURRENT_VERSION);
                    sb.Append(".");
                    sb.Append(type.ToString());
                    sb.Append(".exe");
                    break;
                default:
                    break;
            }
            return sb.ToString();
        }

        /// <summary>
        /// 清除目录
        /// </summary>
        /// <param name="path"></param>
        static void ClearPath(string path)
        {
            string apath = path;
            string sp = System.IO.Path.DirectorySeparatorChar.ToString();
            if (!path.EndsWith(sp))
            {
                apath = path.Substring(0, path.LastIndexOf(sp));
            }

            if (System.IO.Directory.Exists(apath))
            {
                System.IO.Directory.Delete(apath, true);
            }
        }

        /// <summary>
        /// 创建目录
        /// </summary>
        /// <param name="path"></param>
        static void MakePath(string path)
        {
            string apath = path;
            string sp = System.IO.Path.DirectorySeparatorChar.ToString();

            if (!path.EndsWith(sp))
            {
                apath = path.Substring(0, path.LastIndexOf(sp));
            }

            if (!System.IO.Directory.Exists(apath))
            {
                System.IO.Directory.CreateDirectory(apath);
            }
        }

        /// <summary>
        /// Unity配置预先设置
        /// </summary>
        /// <param name="type"></param>
        static void PerSetting(EnumBuidleType type)
        {
            PlayerSettings.productName = BUILD_NAME; //GetBuildName(type);
                                                     //设置版本号
            PlayerSettings.bundleVersion = CURRENT_VERSION; // GetVersion();
                                                            //PlayerSettings.Android.bundleVersionCode = GetAndroidVersionCode();
                                                            //设置开发版
                                                            //EditorUserBuildSettings.development = IS_DEVELOPER;
                                                            //设置可否调试
                                                            //EditorUserBuildSettings.allowDebugging = ALLOW_DEBUG;
                                                            //设置游戏质量
                                                            //QualitySettings.antiAliasing = ANTI_ALIASING;
                                                            //抗锯齿 可设置为 0,2,4,8 对应每个像素使用多重采样的数量
            QualitySettings.vSyncCount = 0;
            //更新版本号
            //VersionClient.Versionclient_Update(GetVersion());
            //刷新Unity保存
            AssetDatabase.Refresh();
        }

        /// <summary>
        /// 设置宏定义
        /// </summary>
        /// <param name="gp"></param>
        /// <param name="symble"></param>
        public static void SetBuildingDefine(BuildTargetGroup gp, string symble)
        {
            PlayerSettings.SetScriptingDefineSymbolsForGroup(gp, symble);
        }

        /// <summary>
        /// 取得目标平台
        /// </summary>
        /// <param name="target"></param>
        /// <returns></returns>
        public static BuildTargetGroup GetBuildTargetGroup(BuildTarget target)
        {
            switch (target)
            {
                case BuildTarget.Android:
                    return BuildTargetGroup.Android;
                case BuildTarget.iOS:
                    return BuildTargetGroup.iOS;
            }
            return BuildTargetGroup.Standalone;
        }

        /// <summary>
        /// 取得项目目录
        /// </summary>
        /// <returns></returns>
        static string GetProjectDirPath()
        {
            DirectoryInfo directory = new DirectoryInfo(Application.dataPath);
            return directory.Parent.FullName
                  + System.IO.Path.DirectorySeparatorChar;
        }

        /// <summary>
        /// 取得宏定义
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static string GetDefine(EnumBuidleType type)
        {
            string result = string.Empty;
            //配置宏定义
            switch (type)
            {
                case EnumBuidleType.ZhengShi:
                    result = DEFINE_ZhengShi;
                    break;
                case EnumBuidleType.Debug:
                    result = DEFINE_DEBUG;
                    break;
                case EnumBuidleType.OffLineDebug:
                    result = DEFINE_NOLINE_DEBUG;
                    break;
                case EnumBuidleType.OffHTTP:
                    result = DEFINE_OFFHTTP_DEBUG;
                    break;

            }
            return result;
        }

        /// <summary>
        /// 取得打包Options
        /// </summary>
        /// <param name="target"></param>
        /// <param name="savePath"></param>
        /// <returns></returns>
        private static BuildPlayerOptions GetBuildPlayerOptions(BuildTarget target, string savePath)
        {
            BuildOptions option = BuildOptions.None;
            if (target == BuildTarget.iOS)
            {
                option = BuildOptions.AcceptExternalModificationsToPlayer;
            }
            //option = BuildOptions.Development | BuildOptions.AutoRunPlayer | BuildOptions.ConnectWithProfiler | BuildOptions.AllowDebugging;

            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = GetBuildScenes();
            buildPlayerOptions.locationPathName = savePath;
            buildPlayerOptions.target = target;
            buildPlayerOptions.options = option;
            return buildPlayerOptions;
        }

        /// <summary>
        /// 取得打包场景
        /// </summary>
        /// <returns></returns>
        static string[] GetBuildScenes()
        {
            List<string> names = new List<string>();
            foreach (EditorBuildSettingsScene e in EditorBuildSettings.scenes)
            {
                if (e == null)
                    continue;
                if (e.enabled)
                    names.Add(e.path);
            }
            return names.ToArray();
        }

        /// <summary>
        /// 打包函数
        /// </summary>
        /// <param name="tag"></param>
        /// <param name="savePath"></param>
        static void BuildForPlatform(BuildPlayerOptions option, string savePath)
        {
            string buildFinish = string.Empty;
            //打包
            buildFinish = BuildPipeline.BuildPlayer(option).name;
            if (string.IsNullOrEmpty(buildFinish))
            {
                //BuildUpdateEditor.OneKeyBuildView.GetInstance.BuildFinish(savePath, "");
                BuildFinish(savePath, "");
            }
        }

        /// <summary>
        /// Build完成
        /// </summary>
        /// <param name="path">完成包路径</param>
        /// <param name="name">包名称</param>
        static void BuildFinish(string path, string name)
        {
            string localDir = "";
            /*if(name != "")
            {
                localDir = path.Replace(name, "");
            }else
            {
                localDir = path;
            }*/

            localDir = name != "" ? path.Replace(name, "") : path;

            Debug.Log("打包完成 " + localDir);

            if (Directory.Exists(localDir))
            {
                System.Diagnostics.Process.Start(localDir);
            }
        }

    }
}
