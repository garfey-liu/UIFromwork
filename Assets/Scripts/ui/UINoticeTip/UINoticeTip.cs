using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace projectGF
{
    public class UINoticeTip : MonoBehaviour
    {
        public Image Tip_Bg;
        public Text Tip_Content;
        public GameObject Tip_Obj;

        /// <summary>
        /// 持续时间
        /// </summary>
        public int times = 1;
        public int upSpeed = 100;
        private Coroutine mStartTimeC = null;
        private Vector3 targetPos;

        void Awake()
        {
            targetPos = new Vector3(this.Tip_Obj.transform.localPosition.x,
                this.Tip_Obj.transform.localPosition.y + 100f,
                this.Tip_Obj.transform.localPosition.z);
        }

        public string Tip_ContentValue
        {
            get
            {
                return Tip_Content.text;
            }
            set
            {
                Tip_Content.text = value;
                _startCoroutine(times);
            }
        }

        void tipClose()
        {
            GameObject.DestroyImmediate(gameObject);
        }

        #region timer
        /// <summary>
        /// 开始倒计时
        /// </summary>
        /// <param name="_Stime"></param>
        void _startCoroutine(int _Stime)
        {
            if (_Stime > 0)
            {
                if (mStartTimeC == null)
                {
                    mStartTimeC = StartCoroutine(startTime(_Stime));
                }
            }
        }
        /// <summary>
        /// 结束倒计时
        /// </summary>
        void _stopCoroutine()
        {
            if (mStartTimeC != null)
            {
                StopCoroutine(mStartTimeC);
                mStartTimeC = null;
            }
        }

        IEnumerator startTime(int count)
        {
            if (count > 0)
            {
                while (count>=0)
                {
                    while (this.Tip_Obj.transform.localPosition != targetPos)
                    {
                        this.Tip_Obj.transform.localPosition = Vector3.MoveTowards(
                            this.Tip_Obj.transform.localPosition,
                            targetPos, upSpeed * Time.deltaTime);
                        yield return 0;
                    }
                    if (count <= 0)
                    {
                        _stopCoroutine();
                        tipClose();
                        break;
                    }
                    count--;
                    yield return new WaitForSeconds(1.0f);
                }
            }
        }
        #endregion
    }
}