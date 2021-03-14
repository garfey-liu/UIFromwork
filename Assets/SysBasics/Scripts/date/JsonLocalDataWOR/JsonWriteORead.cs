using Newtonsoft.Json;
using System.IO;
using System.Text;
using UnityEngine;

namespace projectGF
{
    /// <summary>
    /// json 格式 读写本地数据
    /// </summary>
    public class JsonWriteORead : SingletonTamplate<JsonWriteORead>
    {
        
        /// <summary>
        /// 创建本地配置文件
        /// </summary>
        public void CretaConfig(object _classObj,string _jsonPath)
        {
            // 配置文件夹
            if (!Directory.Exists(_jsonPath))
            {
                // 如果文件不存在，则创建一个文件到指定位置
                Directory.CreateDirectory(_jsonPath);
            }
            //jsonPath = GameAssetsPath.Instance.Config_LocalData_Path;
            Debug.Log("jsonPath:: " + _jsonPath);

            WirteJsonToLocal(_classObj, _jsonPath);
        }


        /*void Write()
        {
            LocalData ld = new LocalData();
            ServerInfo sin1 = new ServerInfo();
            sin1.ServerName = "tcp服务器";
            sin1.ServerIp = "192.168.1.107";
            sin1.ServerPort = "8333";

            /*ServerInfo sin2 = new ServerInfo();
            sin2.ServerName = "服务器2";
            sin2.ServerIp = "192.168.1.107";
            sin2.ServerPort = "8333";

            ld.sinfoList.Add(sin1);
            //ld.sinfoList.Add(sin2);

            WirteJsonToLocal(ld);
        }*/

        /*void Read<T>(string _jsonPath)
        {
            T ld = ReadJsonFormLocal<T>(_jsonPath);
            if (ld != null)
            {
                ServerInfo tmpInfo;
                for (int i = 0; i < ld.sinfoList.Count; i++)
                {
                    tmpInfo = ld.sinfoList[i];
                    Debug.Log(tmpInfo.ServerName + "  " + tmpInfo.ServerIp + "  " + tmpInfo.ServerPort);
                }
            }
        }*/


        /// <summary>
        /// 读取本地文件
        /// </summary>
        public T ReadJsonFormLocal<T>(string jsonPath)
        {
            if (System.IO.File.Exists(jsonPath))
            {
                StreamReader streamReader = new StreamReader(jsonPath, Encoding.Default);
                string jsonRoot = streamReader.ReadToEnd();  //读全部json        
                T ObjRoot = JsonConvert.DeserializeObject<T>(jsonRoot);  //转json对象   

                return ObjRoot;

            }
            else
            {
                Debug.LogError("NullFile 找不到文件 ::" + jsonPath);
            }
            object obj = null;
            return (T)obj;
        }

        /// <summary>
        /// 写本地文件
        /// </summary>
        /// <param name="jsonObj"></param>
        /// <param name="_targetJsonPath"> 需要完整路径包括文件后缀名 </param>
        public void WirteJsonToLocal(object jsonObj,string _targetJsonPath)
        {
            try
            {
                string output = JsonConvert.SerializeObject(jsonObj);

                FileStream fs = new FileStream(_targetJsonPath, FileMode.Create);
                StreamWriter sw = new StreamWriter(fs);
                sw.WriteLine(output);
                sw.Close();
                fs.Close();
            }
            catch { }
        }
    }
}
