using System;
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    public class RManager : MonoBehaviour
    {
        private static RManager _Instance;
        public static RManager Instance
        {
            get { return _Instance; }
        }

        /// <summary>
        /// 用于启动时只掉一次的判断  临时
        /// </summary>
        public bool isFirstShow;

        //[HideInInspector]
        //public ClientHttp clientWeb;

        //[HideInInspector]
        //public tcpUpdateMsg TcpUpdateMsg;

        void Awake()
        {
            _Instance = this;
            isFirstShow = true;
            Init();
        }

        #region 删除单例--------------------------------
        void OnDestroy()
        {
            _Instance = null;
        }
        #endregion--------------------------------------

        #region 初始化----------------------------------
        void Init()
        {
            Debug.Log("启动程序 Init");
            DontDestroyOnLoad(this);

            //脚本添加
            RegisterCs();

            //开启启动页显示Prefab
            UICtrl.Instance.OpenUI(GameAssetsPath.UI_Start_Path);
            Debug.Log("开启Start界面");
        }
        #endregion -------------------------------------

        #region 添加脚本--------------------------------

        void RegisterCs()
        {
            //注册脚本
            RegisterManager<QScenesManager>();
        }

        #endregion -------------------------------------

        #region 扩展方法--------------------------------

        /// <summary>
        /// 脚本赋值控制
        /// </summary>
        private T ScriptsDataSet<T>() where T : MonoBehaviour
        {
            T data = gameObject.GetComponent<T>();
            if (data == null)
            {
                data = gameObject.AddComponent<T>();
            }

            return data;
        }
        #endregion---------------------------------------

        #region 场景管理器------------------------------

        private Dictionary<Type, BaseManager> managerDic = new Dictionary<Type, BaseManager>();
        private List<BaseManager> managerList = new List<BaseManager>();

        public static QScenesManager scene
        {
            get
            {
                return GetManager<QScenesManager>();
            }
        }

        /// <summary>
        /// 初始化Manager脚本
        /// </summary>
        private void ManagersInit()
        {
            for (int i = 0; i < managerList.Count; i++)
            {
                // 统一处理 或 初始化
                //managerList[i].Init();
            }
        }

        /// <summary>
        /// 注册Manager脚本
        /// </summary>
        private void RegisterManager<T>() where T : BaseManager, new()
        {
            T manager = new T();
            managerDic[typeof(T)] = manager;
            managerList.Add(manager);
        }

        public static T GetManager<T>() where T : BaseManager
        {
            if (_Instance != null)
            {
                return _Instance._GetManager<T>();
            }
            return default(T);
        }

        public T _GetManager<T>() where T : BaseManager
        {
            BaseManager manager = null;
            managerDic.TryGetValue(typeof(T), out manager);
            return manager as T;
        }

        #endregion--------------------------------------

        void Update()
        {
            Framework.Console.Instance.OnUpdate();
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.Quit();
            }
        }
        public void OnGUI()
        {
            Framework.Console.Instance.OnGUI();
        }
       
    }

}

