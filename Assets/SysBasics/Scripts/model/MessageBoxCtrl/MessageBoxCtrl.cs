using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    public class MessageBoxCtrl : SingletonTamplate<MessageBoxCtrl>
    {
        NoticeTipMgr tBox = new NoticeTipMgr();
        /// <summary>
        /// Tips框提示
        /// </summary>
        public void MessageBox_Tips(string info)
        {
            tBox.TipsShow(info);
        }
    }
}
