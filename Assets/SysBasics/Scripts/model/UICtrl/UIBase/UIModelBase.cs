

using UnityEngine;

namespace projectGF
{
    public abstract class UIModelBase : MonoBehaviour
    {
        [HideInInspector]
        public UIViewBase _ui;

        public void RegistEvent()
        {
            //注册消息
            EventEnum.EventListener[] tempCmNo = FocusNetWorkData();
            if (tempCmNo != null && tempCmNo.Length > 0)
            {
                for (int i = 0; i < tempCmNo.Length; ++i)
                {
                    EventDispatcher.AddEvent(tempCmNo[i].ToString(), NetWorkDataCallBack);
                }
            }
        }

        public void UnRegistEvent()
        {
            EventEnum.EventListener[] tempCmNo = FocusNetWorkData();
            if (tempCmNo != null && tempCmNo.Length > 0)
            {
                for (int i = 0; i < tempCmNo.Length; ++i)
                {
                    EventDispatcher.RemoveEvent(tempCmNo[i].ToString(), NetWorkDataCallBack);
                }
            }
        }

        #region 网络消息 -------------------------------------------

        /// <summary>
        /// 需要注册的消息
        /// </summary>
        protected virtual EventEnum.EventListener[] FocusNetWorkData()
        {
            return null;
        }

        /// <summary>
        /// 消息的回调
        /// </summary>
        protected virtual void OnNetWorkDataCallBack(EventEnum.EventListener msgEnum, object[] data) { }

        #endregion --------------------------------------------------

        #region Event -----------------------------------------------

        private void NetWorkDataCallBack(object[] data)
        {
            /// 这里由于消息参数数组中0是消息类型
            /// 所以这里会把消息类型参数剔除出来，保证使用顺序不变
            object[] temp = new object[data.Length - 1];
            for (int i = 0; i < temp.Length; ++i)
            {
                temp[i] = data[i + 1];
            }
            OnNetWorkDataCallBack((EventEnum.EventListener)data[0], temp);
        }

        public virtual void OnEnable()
        {
            this.RegistEvent();
        }

        public virtual void OnDisable()
        {
            this.UnRegistEvent();
        }

        #endregion --------------------------------------------------



    }
}
