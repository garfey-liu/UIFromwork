

using System;
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    /// <summary>
    /// 按钮信息
    /// </summary>
    public class BtnInfoItem
    {
        public string BtnName;
        public System.Action<System.Object> OnBtnBack = null;
        public System.Object evt = null;
    }

    /// <summary>
    /// toggle 信息
    /// </summary>
    public class ToggleInfoItem
    {
        public string ToggleName;
        public System.Action<System.Boolean> OnToggleBack = null;

        public bool isOn;
    }

    public class SceneNoticeCtrl : SingletonTamplate<SceneNoticeCtrl>
    {
        NoticeTipMgr notice = new NoticeTipMgr();
        /// <summary>
        /// 只有文本提示的 框  
        /// </summary>
        /// <param name="info"></param>
        public void TextNotice(string info, System.Action<System.Object> normalFinish = null, int _times = 2, GameObject parent = null)
        {
            notice.TextNoticeShow(info, normalFinish, _times, parent);
        }

        /// <summary>
        /// 有一个按钮的 框
        /// </summary>
        /// <param name="info"></param>
        public void OneBtnNotice(string info,string btnName, System.Action<System.Object> oneBtnBack = null, System.Object evt = null, GameObject parent = null)
        {
            notice.OneBtnNoticeShow(info, btnName, oneBtnBack, evt, parent);
        }

        /// <summary>
        /// 多个按钮 框
        /// </summary>
        /// <param name="info"></param>
        /// <param name="btnList"></param>
        /// <param name="parent"></param>
        public void MorBtnNotice(string info, List<BtnInfoItem> btnList,GameObject parent = null)
        {
            notice.MorBtnNoticeShow(info, btnList, parent);
        }

        /// <summary>
        /// 多个Toggle 按钮框
        /// </summary>
        /// <param name="info"> 弹框描述内容 </param>
        /// <param name="togList"> togglebtn列表 </param>
        /// <param name="btnName"> 一个确定按钮的按钮名称 </param>
        /// <param name="oneBtnBack"> 确定按钮回调 </param>
        /// <param name="evt"> 确定按钮传参 </param>
        /// <param name="parent"> 面板父物体 </param>
        public void MorToggleNotice(string info, List<ToggleInfoItem> togList, string btnName, System.Action<System.Object> oneBtnBack = null, System.Object evt = null,GameObject parent = null)
        {
            notice.MorToggleNoticeShow(info, togList, btnName, oneBtnBack, evt, parent);
        }
    }
}
