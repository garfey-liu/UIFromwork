using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    public class BasicsResLoad : SingletonTamplate<BasicsResLoad>
    {
        /// <summary>
        /// 通用同步加载
        /// </summary>
        public static T Load<T>(string path) where T : UnityEngine.Object
        {
            return Resources.Load<T>(path);
        }
    }
}
