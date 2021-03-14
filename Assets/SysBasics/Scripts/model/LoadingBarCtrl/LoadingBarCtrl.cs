using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    public class LoadingBarCtrl : SingletonTamplate<LoadingBarCtrl>
    {
        NoticeTipMgr loadingBar = new NoticeTipMgr();
        /// <summary>
        /// 显示 等待 旋转圈
        /// </summary>
        public void ShowLoading_Bar()
        {
            //Debug.LogError("显示 等待 旋转圈");
            loadingBar.ShwoLoadingBar();
        }

        /// <summary>
        /// 关闭 等待圈
        /// </summary>
        public void HideLoading_Bar()
        {
            //Debug.LogError("关闭 等待圈");
            loadingBar.HideLoadingBar();
        }
    }
}
