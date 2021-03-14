/**
* @Author GarFey
* 20190730
*/
using System.Collections.Generic;

namespace projectGF
{
    public partial class MKey
    {
        // TODO. 定义key
    }
    public partial class MemoryData : SingletonTamplate<MemoryData>
    {
        private IDictionary<string, object> m_data;

        public MemoryData()
        {
            m_data = new Dictionary<string, object>();
        }

        /// <summary>
        /// 不销毁的memoryData
        /// </summary>
		static private readonly string[] REMAIN_DATA = new string[]
        {
			//MKey.USER_WALLOW_TIME
        };

        public object this[string index]
        {
            get
            {
                object oj = null;
                if (!m_data.TryGetValue(index, out oj))
                {
                    //QLoger.ERROR("获取属性出错，没有{0}属性存在，返回NULL",index);
                }
                return oj;
            }
            set { m_data[index] = value; }
        }

        static public T Get<T>(string key)
        {
            try
            {
                return (T)Instance[key];
            }
            catch (System.Exception ex)
            {
                //WriteLog.LogError(string.Format("获取内存数据出错，无法获取类型{0}的数据(类型不匹配:{1})",typeof(T),ex));
            }
            return default(T);
        }

        static public void Set(string k, object v)
        {

            if (k == null)
            {
                return;
            }

            bool change = !Instance.m_data.ContainsKey(k);

            if (!change)
            {
                if (Instance[k] == null)
                {
                    change = v != null;
                }
                else
                {
                    change = !Instance[k].Equals(v);
                }
            }
            Instance[k] = v;
        }

        static private void Init(string[] key, object[] vars)
        {
            for (int i = 0; i < key.Length; i++)
            {
                MemoryData.Set(key[i], vars[i]);
            }
        }

        static public void Reset()
        {
            object[] vars = new object[REMAIN_DATA.Length];
            for (int i = 0; i < REMAIN_DATA.Length; i++)
            {
                vars[i] = MemoryData.Get<object>(REMAIN_DATA[i]);
            }
            MemoryData.Instance.m_data.Clear();
            MemoryData.Init(REMAIN_DATA, vars);
        }
    }
}
