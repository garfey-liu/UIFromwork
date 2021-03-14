/***********************************
* 
* @Author GarFey
* 全局UI弹框Model
* 
*************************************/

using System.Collections.Generic;

namespace projectGF
{
    public class UINoticeModel
    {
        /// <summary>
        /// 弹窗id
        /// </summary>
        public int ID;
        /// <summary>
        /// 弹窗提示标头
        /// </summary>
        public string NoticeTitel = "";
        /// <summary>
        /// 弹窗内容
        /// </summary>
        public string NoticeInfo = "";
        /// <summary>
        /// 弹窗数据
        /// </summary>
        public System.Object Evt = null;
        /// <summary>
        /// 默认倒计时时间  （单位秒）
        /// </summary>
        public int normalTime;

        #region  只有文本弹框 
        /// <summary>
        /// 默认倒计时完成 触发（文本框显示 倒计时完成触发）
        /// </summary>
        public System.Action<System.Object> NormalFinish;
        #endregion

        #region 一个按钮弹框
        /// <summary>
        /// 一个按钮弹框 按钮触发回调
        /// </summary>
        public System.Action<System.Object> OneBtnBack;
        /// <summary>
        /// 弹窗 按钮显示文字
        /// </summary>
        public string OneBtnName = "";
        #endregion

        #region 多个按钮弹框
        /// <summary>
        /// 多个按钮
        /// </summary>
        public List<BtnInfoItem> btnList = new List<BtnInfoItem>();
        #endregion

        #region 多个toggle按钮弹框
        /// <summary>
        /// 多个toggle弹出框
        /// </summary>
        public List<ToggleInfoItem> toggleList = new List<ToggleInfoItem>();
        /// <summary>
        /// 多个toggle确定按钮
        /// </summary>
        public System.Action<System.Object> OneToggleBtnBack;
        #endregion

    }
}
