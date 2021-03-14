using UnityEngine;
using System.Collections;
using projectGF;
using System.Collections.Generic;

namespace projectGF
{
    public class NoticeTipMgr
    {
        #region 创建-------------------------

        /// <summary>
        /// 创建Tip框
        /// </summary>
        private GameObject CreatTips(GameObject parentObj)
        {
            GameObject go = null;
            if (parentObj == null)
            {
                parentObj = UICtrl.Instance._UIManager.UICamera.gameObject;
            }
            if(parentObj.activeSelf)
            {
                GameObject prefab = BasicsResLoad.Load<GameObject>(GameAssetsPath.Prefab_UINoticeTip_Path);
                go = GUITools.AddChild(parentObj, prefab);
            }

            return go;
        }

        /// <summary>
        /// 创建场景Notice
        /// </summary>
        /// <param name="parentObj"></param>
        /// <param name="_path"></param>
        /// <returns></returns>
        private GameObject CreatNotice(GameObject parentObj, string _path)
        {
            if (parentObj == null)
            {
                parentObj = UICtrl.Instance._UIManager.UIScenePath.gameObject;
            }

            GameObject prefab = BasicsResLoad.Load<GameObject>(_path);
            GameObject go = GUITools.AddChild(parentObj, prefab);
            return go;
        }

        /// <summary>
        /// 创建 与服务器交互 等待圈
        /// </summary>
        /// <param name="parentObj"></param>
        /// <returns></returns>
        private GameObject CreatLoadingBar(GameObject parentObj)
        {
            if (parentObj == null)
            {
                parentObj = UICtrl.Instance._UIManager.UICamera.gameObject;
            }

            GameObject prefab = BasicsResLoad.Load<GameObject>(GameAssetsPath.Prafab_LoadingBar_Path);
            GameObject go = GUITools.AddChild(parentObj, prefab);
            return go;
        }


        #endregion---------------------------------

        #region Tops框调用-------------------------

        /// <summary>
        /// 调用Tips入口
        /// </summary>
        public GameObject TipsShow(string desc, GameObject parent = null)
        {
            GameObject tip = CreatTips(parent);
            if(tip !=null)
            {
                UINoticeTip boxMgr = tip.GetComponent<UINoticeTip>();
                boxMgr.Tip_ContentValue = desc;
            }
            return tip;
        }

        #endregion---------------------------------


        #region 场景弹框 =========================================================

        /// <summary>
        ///  文本弹出框
        /// </summary>
        /// <param name="desc"> 文本信息 </param>
        /// <param name="_times"> 时间 一定时间消失（默认5s）</param>
        /// <param name="parent"> 弹出根目录 </param>
        /// <returns></returns>
        public GameObject TextNoticeShow(string desc, System.Action<System.Object> normalFinishBack = null,int _times = 2, GameObject parent = null)
        {

            UINoticeModel tmpNotModel = new UINoticeModel();
            tmpNotModel.NormalFinish = normalFinishBack;
            tmpNotModel.normalTime = _times;
            tmpNotModel.NoticeInfo = desc;


            GameObject notic = CreatNotice(parent,GameAssetsPath.SceneUI_TextNotice_Path);
            notic.name = notic.name.Replace("(Clone)", "");

            UITextNotice textNotic = notic.GetComponent<UITextNotice>();
            textNotic.Model = tmpNotModel;
            textNotic.Init();

            return notic;
        }

        /// <summary>
        /// 有一个按钮触发的弹出框
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public GameObject OneBtnNoticeShow(string desc, string btnName,System.Action<System.Object> oneBtnBack = null, System.Object evt = null, GameObject parent = null)
        {
            UINoticeModel tmpNotModel = new UINoticeModel();
            tmpNotModel.NoticeInfo = desc;
            tmpNotModel.OneBtnName = btnName;
            tmpNotModel.OneBtnBack = oneBtnBack;
            tmpNotModel.Evt = evt;

            GameObject notic = CreatNotice(parent, GameAssetsPath.SceneUI_OneBtnNotice_Path);
            notic.name = notic.name.Replace("(Clone)", "");

            UIOneBtnNotice textNotic = notic.GetComponent<UIOneBtnNotice>();
            textNotic.Model = tmpNotModel;
            textNotic.Init();

            return notic;
        }

        /// <summary>
        /// 多个按钮触发的弹出框
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="btnList"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public GameObject MorBtnNoticeShow(string desc, List<BtnInfoItem> btnList, GameObject parent = null)
        {
            UINoticeModel tmpNotModel = new UINoticeModel();
            tmpNotModel.btnList = btnList;
            tmpNotModel.NoticeInfo = desc;


            GameObject notic = CreatNotice(parent, GameAssetsPath.SceneUI_MorBtnNotice_Path);
            notic.name = notic.name.Replace("(Clone)", "");

            UIMorBtnNotice textNotic = notic.GetComponent<UIMorBtnNotice>();
            textNotic.Model = tmpNotModel;
            textNotic.Init();

            return notic;
        }

        /// <summary>
        /// 多个toggle按钮 弹出框
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public GameObject MorToggleNoticeShow(string desc, List<ToggleInfoItem> togList, string btnName, System.Action<System.Object> oneBtnBack = null, System.Object evt = null, GameObject parent = null)
        {
            UINoticeModel tmpNotModel = new UINoticeModel();
            tmpNotModel.toggleList.Clear();
            tmpNotModel.toggleList = togList;
            tmpNotModel.NoticeInfo = desc;
            tmpNotModel.OneBtnName = btnName;
            tmpNotModel.OneToggleBtnBack = oneBtnBack;
            tmpNotModel.Evt = evt;

            GameObject notic = CreatNotice(parent, GameAssetsPath.SceneUI_MorToggleNotc_Path);
            notic.name = notic.name.Replace("(Clone)", "");

            UIMorTogleNotice textNotic = notic.GetComponent<UIMorTogleNotice>();
            textNotic.Model = tmpNotModel;
            textNotic.Init();

            return notic;
        }

        #endregion  ===================================================================



        #region  等待 旋转圈 ==========================================================

        GameObject loadingBar = null;
        /// <summary>
        /// 显示等待圈
        /// </summary>
        public void ShwoLoadingBar(GameObject parent = null)
        {
            if(loadingBar == null )
            {
                loadingBar = CreatLoadingBar(parent);
            }
        }
        /// <summary>
        /// 关闭等待圈
        /// </summary>
        public void HideLoadingBar()
        {
            if (loadingBar != null)
            {
                GameObject.DestroyImmediate(loadingBar);
               loadingBar = null;
            }
        }


        #endregion   ===================================================================

    }
}