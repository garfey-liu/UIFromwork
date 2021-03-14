/**
* @Author GarFey
* 20180723
*/
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    public enum CloseType
    {
        DESTORY = 1,
        HIDE,
    }

    public class UIOpenInfo
    {
        /// <summary>
        /// UI 实例 Gameobject
        /// </summary>
        public GameObject UIObj;

        /// <summary>
        /// UI 名称 Name
        /// </summary>
        public string UIName;

        /// <summary>
        /// UI 路径 Path
        /// </summary>
        public string UIPath;

        /// <summary>
        /// UI 放置指定的父级目录 
        /// </summary>
        public Transform UIParentTrans;

        /// <summary>
        /// UI 开启带进来的参数
        /// </summary>
        public object[] ParamsVar;

        public UIOpenInfo(string _path, Transform _parentTrans, params object[] _parms)
        {
            this.UIName = ToolsUtil.getUINameForPath(_path);
            this.UIPath = _path;
            this.UIParentTrans = _parentTrans;
            this.ParamsVar = _parms;
        }
    }

    public class UICtrl : SingletonTamplate<UICtrl>
    {
        private UIManager uiManager = null;

        public UIManager _UIManager
        {
            get
            {
                if (uiManager == null || uiManager.UIRoot == null)
                {
                    uiManager = new UIManager();
                    uiManager.Init();
                }
                return uiManager;
            }
        }

        #region 调用开启，关闭方法---------------------------------------

        public void OpenUI(string _path, Transform _parentTrans = null, params object[] _parms)
        {
            UIOpenInfo tmpUiInfo = new UIOpenInfo(_path, _parentTrans, _parms);
            _UIManager.OpenUI(ref tmpUiInfo);
        }

        public void CloseUIByPath(string path, CloseType closeType = CloseType.DESTORY)
        {
            string uiName = ToolsUtil.getUINameForPath(path);
            CloseUI(uiName, closeType);
        }

        public void CloseUI(string _uiName, CloseType closeType = CloseType.DESTORY)
        {
            UIOpenInfo info = UIOpenList_Find(_uiName);
            if (info != null)
            {
                //把关闭的UI面板从链表里移除
                //UIOpenList_Delete(info.UIName);

                switch (closeType)
                {
                    case CloseType.DESTORY:
                        //把关闭的UI面板从链表里移除
                        UIOpenList_Delete(info.UIName);
                        _UIManager.CloseUI(info.UIName);
                        break;
                    case CloseType.HIDE:
                        _UIManager.HideUI(info);
                        break;
                }
                UIPanelDepthOrder.CloseChildPanelDep(info);
            }
            else
            {
                Debug.Log(" #[UICtrl-UIClose]# 该面板不存在 = " + _uiName);
            }
        }

        

        #endregion ----------------------------------------------------------

        #region  链表控制-------------------------------------------------

            /// <summary>
            /// 游戏界面当前打开的UI面板
            /// </summary>
        private List<UIOpenInfo> _UIOpenList = new List<UIOpenInfo>();

        public List<UIOpenInfo> UIOpenList
        {
            get { return _UIOpenList; }
            set { _UIOpenList = value; }
        }

        /// <summary>
        /// 查找列表中的值
        /// </summary>
        public UIOpenInfo UIOpenList_Find(string uiName)
        {
            foreach (UIOpenInfo uiInfo in _UIOpenList)
            {
                if (uiInfo.UIName.Equals(uiName))
                {
                    return uiInfo;
                }
            }

            return null;
        }

        /// <summary>
        /// 往列表中添加已经打开的UI面板索引
        /// </summary>
        private void UIOpenList_Add(UIOpenInfo uiInfo)
        {
            if (UIOpenList_Find(uiInfo.UIName) == null)
            {
                _UIOpenList.Add(uiInfo);
            }
        }

        /// <summary>
        /// 删除列表中的UI面板索引
        /// </summary>
        private void UIOpenList_Delete(string uiName)
        {
            UIOpenInfo info = UIOpenList_Find(uiName);

            if (info != null)
            {
                _UIOpenList.Remove(info);
            }
        }

        #endregion ----------------------------------------------------------

        #region  开启关闭回调接口-----------------------------------------

        /// <summary>
        /// UI创建成功回调
        /// </summary>
        public void C2CUIOpenCreatSucc(UIOpenInfo data)
        {
            if (data != null)
            {
                //当前UI面板添加进链表
                UIOpenList_Add(data);
                if (data.UIObj != null)
                {
                    //进行深度排序
                    UIPanelDepthOrder.OpenChildPanelDep(data);
                }
            }
            else
            {
                Debug.LogError(" #[UICtrl-C2CUIOpenCreatSucc]# 传递参数为空");
            }
        }

        #endregion ----------------------------------------------------------

        /// <summary>
        /// 关闭exceptUIList之外的所有面板
        /// </summary>
        public void CloseAllUIPanel(List<string> exceptUIList = null)
        {
            List<string> removeNames = new List<string>();

            foreach (UIOpenInfo uiInfo in _UIOpenList)
            {
                if ((exceptUIList == null || exceptUIList.IndexOf(uiInfo.UIName) == -1))
                {
                    removeNames.Add(uiInfo.UIName);
                }
            }

            foreach (string uiName in removeNames)
            {
                CloseUI(uiName, CloseType.DESTORY);
            }

            if (exceptUIList == null)
            {
                _UIOpenList.Clear();
            }
        }

        #region  工具类 ------------------------------------------------------

        /// <summary>
        /// 获取当前堆栈最上面的obj
        /// isBol=true 不要在乎黑片有没有,拿到列表里全部的界面
        /// </summary>
        public GameObject UIStackPeekGet(bool isBol = false)
        {
            UIOpenInfo info = UIStackPeekGetInfo(isBol);
            if (info == null)
                return null;
            else
                return info.UIObj;
        }
        public UIOpenInfo UIStackPeekGetInfo(bool isBol = false)
        {
            UIOpenInfo info = null;

            for (int i = 1; i <= UIOpenList.Count; i++)
            {
                UIOpenInfo temp = UIOpenList[UIOpenList.Count - i];
                info = temp;
            }

            return info;
        }

        #endregion -----------------------------------------------------------
    }
}
