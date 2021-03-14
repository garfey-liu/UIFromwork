using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

namespace projectGF
{
    [RequireComponent(typeof(BoxCollider))]
    public abstract class EventTriggerBase : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {

            //获取或添加EventTrigger组件
            EventTrigger trigger = transform.GetComponent<EventTrigger>();
            if (trigger == null)
            {
                trigger = transform.gameObject.AddComponent<EventTrigger>();
            }

            //初始化EventTrigger.Entry的数组 如果这里初始化了事件触发数组，那么在ide静态添加的事件会丢失
            //trigger.triggers = new List<EventTrigger.Entry>();
            //创建各种 EventTrigger.Entry的类型
            EventTrigger.Entry entryPointerEnter = new EventTrigger.Entry();
            entryPointerEnter.eventID = EventTriggerType.PointerEnter; //设置Entry的eventID类型 即EventTriggerType的各种枚举（比如鼠标点击，滑动，拖动等）
            UnityAction<BaseEventData> PointerEnterCallback = new UnityAction<BaseEventData>(OnPointerEnter); //注册代理
            entryPointerEnter.callback.AddListener(PointerEnterCallback); //添加代理事件到EventTrigger.Entry

            EventTrigger.Entry entryPointerDown = new EventTrigger.Entry();
            entryPointerDown.eventID = EventTriggerType.PointerDown;
            UnityAction<BaseEventData> PointerDownCallback = new UnityAction<BaseEventData>(OnPointerDown);
            entryPointerDown.callback.AddListener(PointerDownCallback);

            EventTrigger.Entry entryPointerUp = new EventTrigger.Entry();
            entryPointerUp.eventID = EventTriggerType.PointerUp;
            UnityAction<BaseEventData> PointerUpCallback = new UnityAction<BaseEventData>(OnPointerUp);
            entryPointerUp.callback.AddListener(PointerUpCallback);

            EventTrigger.Entry entryPointerExit = new EventTrigger.Entry();
            entryPointerExit.eventID = EventTriggerType.PointerExit;
            UnityAction<BaseEventData> PointerExitCallback = new UnityAction<BaseEventData>(OnPointerExit);
            entryPointerExit.callback.AddListener(PointerExitCallback);

            EventTrigger.Entry entryPointerClick = new EventTrigger.Entry();
            entryPointerClick.eventID = EventTriggerType.PointerClick;
            UnityAction<BaseEventData> PointerClickCallback = new UnityAction<BaseEventData>(OnPointerClick);
            entryPointerClick.callback.AddListener(PointerClickCallback);

            //在EventTrigger.Entry的数组添加EventTrigger.Entry
            trigger.triggers.Add(entryPointerEnter);
            trigger.triggers.Add(entryPointerExit);
            trigger.triggers.Add(entryPointerUp);
            trigger.triggers.Add(entryPointerDown);
            trigger.triggers.Add(entryPointerClick);
        }

        /// <summary>
        /// 移入
        /// </summary>
        /// <param name="evt"></param>
        public virtual void OnPointerEnter(BaseEventData evt)
        {
            //Debug.Log("OnPointerEnter");
        }

        /// <summary>
        /// 移出
        /// </summary>
        /// <param name="evt"></param>
        public virtual void OnPointerExit(BaseEventData evt)
        {
            //Debug.Log("OnPointerExit");
        }

        /// <summary>
        /// 按下
        /// </summary>
        /// <param name="evt"></param>
        public virtual void OnPointerDown(BaseEventData evt)
        {
            //Debug.Log("OnPointerDown");
        }

        /// <summary>
        /// 抬起
        /// </summary>
        /// <param name="evt"></param>
        public virtual void OnPointerUp(BaseEventData evt)
        {
            //Debug.Log("OnPointerUp");
        }
       

        /// <summary>
        /// 单击
        /// </summary>
        /// <param name="evt"></param>
        public virtual void OnPointerClick(BaseEventData evt)
        {
            //Debug.Log("OnPointerClick");
        }

    }
}
