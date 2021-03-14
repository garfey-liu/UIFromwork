using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace projectGF
{
    public class QScenesManager: BaseManager
    {
        private SceneBase m_State;

        /// <summary>
        /// 取得当前场景Name
        /// </summary>
        /// <returns></returns>
        public string GetCurrSceneName()
        {
            return m_State.StateName;
        }

        /// <summary>
        /// 切换场景
        /// </summary>
        /// <param name="State">所需要的代码</param>
        /// <param name="LoadSceneName">场景名称</param>
        /// /// <param name="isLogin"> 是否是登录切换 </param>
        public void SetScene(SceneBase State, string LoadSceneName,bool isLogin = false)
        {
            //加载场景
            RManager.Instance.StartCoroutine(LoadScene(State, LoadSceneName, isLogin));
        }

        // 
        /// <summary>
        /// 加载场景
        /// </summary>
        /// <param name="State"></param>
        /// <param name="LoadSceneName"></param>
        /// <param name="isLogin">  </param>
        /// <returns></returns>
        private IEnumerator LoadScene(SceneBase State, string LoadSceneName,bool isLogin)
        {
            if (m_State != null)
            {
                m_State.StateEnd();
            }

            //设置场景
            m_State = State;
            if (isLogin)
            {
                SceneManager.LoadSceneAsync(SceneDefine.Scene_NetLoading);
            }
            else
            {
                SceneManager.LoadSceneAsync(SceneDefine.Scene_Loading);
            }
            
            yield return null;
            Debug.Log("加载场景完成 通知新场景");
            /*if (!string.IsNullOrEmpty(LoadSceneName))
            {
                SceneManager.LoadScene(LoadSceneName);
                yield return null;
            }*/

            // 通知新的场景
            if (m_State != null)
            {
                m_State.StateBegin();
            }
        }
    }

    public class SceneBase
    {
        private string m_StateName = "SceneBase";
        public string StateName
        {
            get { return m_StateName; }
            set { m_StateName = value; }
        }

        public virtual void StateBegin()
        {
            EventDispatcher.FireEvent(EventEnum.EventListener.SysScene_Open, StateName);
        }
        
        public virtual void StateEnd()
        {
            EventDispatcher.FireEvent(EventEnum.EventListener.SysScene_Close, StateName);
        }
    }

}

