using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace projectGF
{
    public class KXEditor : MonoBehaviour
    {
        [MenuItem("KXEditor/打开缓存目录")]
        public static void OpenPersistentData()
        {
            System.Diagnostics.Process.Start(Application.persistentDataPath);
        }

        [MenuItem("KXEditor/跳转启动场景")]
        public static void OpenMainScene()
        {
            EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/sysScenes/Start.unity");
        }

        [MenuItem("KXEditor/单元测试场景")]
        public static void OpenTestScene()
        {
            EditorSceneManager.OpenScene(Application.dataPath + "/Scenes/DTtest/DTtest.unity");
        }

        [MenuItem("KXEditor/生成配置文件")]
        public static void CreatConfig()
        {
            //JsonWriteORead.Instance.CretaConfig();
        }
    }
}
