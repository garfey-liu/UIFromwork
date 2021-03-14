/****************************************************
*
*  事件中转站
*  作者: GarFey
*  日期：2019年10月16日
*
*****************************************************/

using System.Collections.Generic;

namespace projectGF
{
    public class EventDispatcher : SingletonTamplate<EventDispatcher>
    {
        private Queue<KeyValuePair<string, object[]>> m_cached_event;

        private IDictionary<string, System.Action<object[]>> m_event;

        public EventDispatcher()
        {
            m_event = new Dictionary<string, System.Action<object[]>>();
            m_cached_event = new Queue<KeyValuePair<string, object[]>>();
        }

        #region 事件调用---------------------------------

        public static void FireEvent(EventEnum.EventListener k, params object[] var)
        {
            object[] temp;
            if (var == null)
            {
                temp = new object[1];
            }
            else
            {
                temp = new object[var.Length + 1];
                var.CopyTo(temp, 1);
            }
            ///默认事件肯定带参数，第一个也就是数组0一定是消息类型
            temp[0] = k;
            //FireEvent(k, temp);
            FireEvent(k.ToString(), temp);
        }

        public static void FireEvent(string k, params object[] var)
        {
            try
            {
                if (Instance.m_event.ContainsKey(k) && Instance.m_event[k] != null)
                {
                    Instance.m_event[k](var);
                }
                else
                {
                    //WriteLog.LogExcption("can't find event:"+k);
                }
            }
            catch (System.Exception ex)
            {
                string v = "";
                for (int i = 0; i < var.Length; i++)
                {
                    v += "{" + var[i].ToString() + "}";
                }
                //WriteLog.LogError("事件异常" + k.ToString() + v + ex.ToString());
            }
        }

        #endregion --------------------------------------

        #region 事件注册---------------------------------

        public static void AddEvent(EventEnum.EventListener k, System.Action<object[]> v)
        {
            AddEvent(k.ToString(), v);
        }

        public static void AddEvent(string k, System.Action<object[]> v)
        {
            if (Instance.m_event.ContainsKey(k))
            {
                Instance.m_event[k] -= v;
                Instance.m_event[k] += v;
            }
            else
            {
                Instance.m_event.Add(k, v);
            }
        }

        #endregion --------------------------------------

        #region 事件移除---------------------------------

        public static void RemoveEvent(EventEnum.EventListener k, System.Action<object[]> v)
        {
            RemoveEvent(k.ToString(), v);
        }

        public static void RemoveEvent(string k, System.Action<object[]> v)
        {
            if (Instance.m_event.ContainsKey(k))
            {
                Instance.m_event[k] -= v;
                if (Instance.m_event[k] == null)
                {
                    Instance.m_event.Remove(k);
                }
            }
        }

        #endregion --------------------------------------

        #region 暂未使用---------------------------------

        static public void RegiestEvent(string k, System.Action<object[]> v)
        {
            Instance.m_event[k] = v;
        }

        static public void UnregiestEvent(string k)
        {
            if (Instance.m_event.ContainsKey(k))
            {
                Instance.m_event.Remove(k);
            }
        }

        static public void CacheEventWhenCanFire(string k, params object[] var)
        {
            Instance.m_cached_event.Enqueue(new KeyValuePair<string, object[]>(k, var));
        }

        static public void FireCacheedEvent()
        {
            for (int i = 0; i < Instance.m_cached_event.Count; i++)
            {
                var e = Instance.m_cached_event.Dequeue();
                if (Instance.m_event.ContainsKey(e.Key)
                    && Instance.m_event[e.Key] != null)
                {
                    Instance.m_event[e.Key](e.Value);
                }
                else
                {
                    Instance.m_cached_event.Enqueue(e);
                }
            }
        }

        #endregion --------------------------------------

    }
}