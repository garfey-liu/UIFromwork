/***************
* 
* @Author GarFey
* 20181107
* 消息处理类
* 
****************/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace projectGF
{
    public partial class ModelNetWorker : SingletonTamplate<ModelNetWorker>
    {
        Dictionary<System.Type, System.Action<object>> m_netReciveActions;

        public ModelNetWorker()
        {
            m_netReciveActions = new Dictionary<System.Type, System.Action<object>>();
        }

        public void Init()
        {
            initDefaultHandle();
        }

        private void initDefaultHandle()
        {
            var mos = this.GetType().GetMethods();
            for (int i = 0; i < mos.Length; i++)
            {
                if (mos[i].Name.StartsWith("initDefaultHandleOf")
                    && mos[i].GetParameters().Length == 0)
                {
                    mos[i].Invoke(this, new System.Type[] { });
                }
            }
        }

        /// <summary>
        /// 消息注册
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="action"></param>
        public static void Regiest<T>(System.Action<object> action)
        {
            System.Type type = typeof(T);
            Instance.m_netReciveActions[type] = action;
        }

        public void initDefaultHandleOfGenerial()
        {

        }

        /// <summary>
        /// http 触发已注册的消息
        /// </summary>
        /// <param name="msg"></param>
        /*public void httphandle(RspProtoMessage msg)
        {
            Debug.Log("handle msg.m_cmd_no == " + msg.request_id);
            var type = HttpDataHandler.GetProtobufType(msg.request_id);
            //var protodata = HttpDataHandler.DeSerializeProtoData(msg.data);
            var protodata = msg;
            if (type == null)
            {
                Debug.LogError("[ModleNetWorker] 无法解析数据{0},无法找到相应的指令对象" + msg.request_id);
                return;
            }
            System.Action<object> action = null;
            if (m_netReciveActions.TryGetValue(type, out action))
            {
                action(protodata);
            }
            else
            {
                Debug.LogError("[ModleNetWorker] 没有找到指令{" + type + "}的解析方法<{" + protodata + "}>");
                return;
            }
        }*/

        /// <summary>
        /// tcp 触发已注册的消息
        /// </summary>
        /// <param name="msg"></param>
        /*public void tcpHandle(TcpProtoMessage msg)
        {
            //Debug.Log("handle msg.m_cmd_no == " + msg.m_cmd_no);
            try
            {
                var type = TcpDataHandler.GetProtobufType(msg.m_cmd_no);
                var protodata = TcpDataHandler.DeSerializeProtoData(msg.m_cmd_data, type);
                if (type == null)
                {
                    //WriteLog.LogError("[ModleNetWorker] 无法解析数据{0},无法找到相应的指令对象" + msg.m_cmd_no.ToString());
                    Debug.LogError("[ModleNetWorker] 无法解析数据{0},无法找到相应的指令对象" + msg.m_cmd_no.ToString());
                    return;
                }
                System.Action<object> action = null;
                if (m_netReciveActions.TryGetValue(type, out action))
                {
                    action(protodata);
                }
                else
                {
                    //WriteLog.LogError("[ModleNetWorker] 没有找到指令{" + type + "}的解析方法<{" + protodata + "}>");
                    Debug.LogError("[ModleNetWorker] 没有找到指令{" + type + "}的解析方法<{" + protodata + "}>");
                    return;
                }
            }
            catch (Exception  e)
            {
                Debug.LogError("tcpHandle Error :: " + e.ToString());
            }
            
        }*/

        /// <summary>
        /// http 发送请求
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="_httpUrl"></param>
        /*public void HttpSend(IMsgData msg, string _httpUrl)
        {
            RManager.Instance.clientWeb.SendMsg(msg, _httpUrl);
        }*/

        /// <summary>
        /// tcp 发送请求
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="_httpUrl"></param>
        public void TcpSend()
        {
            //RManager.Instance.clientWeb.SendMsg(msg, _httpUrl);
        }
    }
}
