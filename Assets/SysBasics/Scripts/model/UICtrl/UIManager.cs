/**
* @Author GarFey
* 20180723
*/
using System.Collections.Generic;
using UnityEngine;
using System;

namespace projectGF
{
    public class UIManager
    {
        private Transform _uiRoot;
        /// <summary>
        /// UI根目錄
        /// </summary>
        public Transform UIRoot
        {
            get { return _uiRoot; }
        }

        private Camera _uiCamera;
        /// <summary>
        /// UI相機
        /// </summary>
        public Camera UICamera
        {
            get { return _uiCamera; }
        }

        /// <summary>
        /// UI 默认目录
        /// </summary>
        private Transform _uiNormalPath;

        public Transform UINormalPath
        {
            get { return _uiNormalPath; }
        }

        /// <summary>
        ///  UI 场景目录
        /// </summary>
        private Transform _uiScenePath;
        public Transform UIScenePath
        {
            get { return _uiScenePath; }
        }

        /// <summary>
		/// TipsUI 目录
		/// </summary>
		private Transform _uiTipsPath;

        public Transform UItipsPath
        {
            get { return _uiTipsPath; }
        }

        /// <summary>
        /// 是否是隐藏界面
        /// </summary>
        private bool isHide = false;

        /// <summary>
        /// UI 全部列表
        /// </summary>
        private Dictionary<string, UIViewBase> UIMap = new Dictionary<string, UIViewBase>();

        /// <summary>
        /// 正在加载中的UI 列表
        /// </summary>
        private List<string> UILoadList = new List<string>();

        /// <summary>
        /// 隐藏的UI  列表
        /// </summary>
        private Dictionary<string,UIOpenInfo> UIHideDic = new Dictionary<string, UIOpenInfo>();

        /// <summary>
        /// 显示列表
        /// </summary>
        private Dictionary<string, UIOpenInfo> UIShowMap = new Dictionary<string, UIOpenInfo>();

        public void Init()
        {
            _uiRoot = GameObject.Find("Root/UIRoot").transform;
            _uiCamera = GameObject.Find("Root/CameraCtrl/Camera_UI").gameObject.GetComponent<Camera>();
            _uiNormalPath = _uiRoot.Find("NormalUI");
            _uiScenePath = _uiRoot.Find("SceneUI");
            _uiTipsPath = _uiRoot.Find("TipsUI/Canvas");
        }

        /// <summary>
        /// 注册UI
        /// </summary>
        /// <param name="_name">Name.</param>
        /// <param name="_uiView">User interface view.</param>
        public void RegisterUI(string _name, UIViewBase _uiView)
        {
            if (UIMap.ContainsKey(_name))
                UIMap[_name] = _uiView;
            else
                UIMap.Add(_name, _uiView);
        }

        /// <summary>
        /// 注销UI
        /// </summary>
        /// <param name="_name">Name.</param>
        private void UnRegisterUI(string _name)
        {
            if (UIMap.ContainsKey(_name))
            {
                UIMap.Remove(_name);
            }

            if (UIShowMap.ContainsKey(_name))
            {
                UIShowMap.Remove(_name);
            }

            //清除隐藏列表
            if (UIHideDic.ContainsKey(_name))
            {
                UIHideDic.Remove(_name);
            }
        }

        /// <summary>
        /// UI显示列表中是否有该UI
        /// </summary>
        /// <returns><c>true</c>, if user interface show map was gotten, <c>false</c> otherwise.</returns>
        /// <param name="_name">Name.</param>
        public bool GetUIShowMap(string _name)
        {
            if (UIShowMap.ContainsKey(_name))
            {
                return true;
            }

            return false;
        }

        public void OpenUI(ref UIOpenInfo _info)
        {
            if (UIMap.ContainsKey(_info.UIName))
            {
                ShowUI(ref _info);
            }
            else if (UILoadList.IndexOf(_info.UIName) > 0)
            {
                return;
            }
            else
            {
                UILoadList.Add(_info.UIName);
                LoadUI(ref _info);
            }
        }

        public void CloseUI(string _name)
        {
            //顯示列表
            if (UIShowMap.ContainsKey(_name))
            {
                UIOpenInfo tmpUI = UIShowMap[_name];
                GameObject.Destroy(tmpUI.UIObj);
                UnRegisterUI(_name);
                return;
            }
            //隱藏列表
            if(UIHideDic.ContainsKey(_name))
            {
                UIOpenInfo tmpUI = UIHideDic[_name];
                GameObject.Destroy(tmpUI.UIObj);
                UnRegisterUI(_name);
            }
           
        }

        /// <summary>
        /// 隐藏UI
        /// </summary>
        /// <param name="uiName"></param>
        public void HideUI(UIOpenInfo _info)
        {
            if (!UIMap.ContainsKey(_info.UIName)) return;

            UIShowMap.Remove(_info.UIName);
            UIViewBase ui = UIMap[_info.UIName];
            ui.OnHide();
            ui.gameObject.SetActive(false);

            if(UIHideDic.ContainsKey(_info.UIName))
            {
                UIHideDic.Remove(_info.UIName);
            }
            UIHideDic.Add(_info.UIName,_info);
        }

        private void LoadUI(ref UIOpenInfo _info)
        {
            string uiPath = _info.UIPath;
            _info.UIObj = BasicsResLoad.Load<GameObject>(uiPath);
            OnLoadUIPrefabCallBack(ref _info);
        }

        private void OnLoadUIPrefabCallBack(ref UIOpenInfo _info)
        {
            string uiName = _info.UIName;

            if (UILoadList.IndexOf(uiName) > 0)
            {
                UILoadList.Remove(uiName);
            }

            Transform parentTrans = null;
            if (_info.UIParentTrans == null)
            {
                parentTrans = _uiNormalPath;
            }
            else
            {
                parentTrans = _info.UIParentTrans;
            }

            try
            {
                if (parentTrans.Find(_info.UIName) == null)
                {
                    _info.UIObj = (GameObject) MonoBehaviour.Instantiate(_info.UIObj);
                    //_info.UIObj.transform.parent = parentTrans;
                    _info.UIObj.transform.SetParent(parentTrans, false);
                    _info.UIObj.name = _info.UIName;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("UI加载错误：：" + e.ToString());
            }

            ShowUI(ref _info);
        }

        private void ShowUI(ref UIOpenInfo _info)
        {
            if (UIMap.ContainsKey(_info.UIName))
            {
                isHide = false;
                UIViewBase ui = UIMap[_info.UIName];
                if (_info.UIObj == null)
                    _info.UIObj = ui.gameObject;
                // 加入显示列表
                if (!UIShowMap.ContainsKey(_info.UIName))
                {
                    UIShowMap.Add(_info.UIName, _info);
                    UICtrl.Instance.C2CUIOpenCreatSucc(_info);
                }

                //清除隐藏列表
                if (UIHideDic.ContainsKey(_info.UIName))
                {
                    UIHideDic.Remove(_info.UIName);
                    ui.gameObject.SetActive(true);
                    isHide = true;
                }
                    

                try
                {
                    //如果是隐藏界面显示 就不调用初始化了
                    if (isHide) return;

                    ui.OnPushData(_info.ParamsVar);
                    ui.Init();
                    ui.OnShow();
                }
                catch (Exception e)
                {
                    Debug.LogError("UI显示错误：：" + e.ToString());
                }
            }
        }
    }
}
