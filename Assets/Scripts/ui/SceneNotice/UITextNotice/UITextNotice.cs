using projectGF;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UITextNotice : MonoBehaviour
{
    public Text Notice_Content;

    public UINoticeModel Model;

    /// <summary>
    /// 持续时间   单位秒 s
    /// </summary>
    private int times = 1;
    private Coroutine mStartTimeC = null;


    public void Init()
    {
        Notice_Content.text = Model.NoticeInfo;
        times = Model.normalTime;
        _startCoroutine(times);
    }


    void tipClose()
    {
        if(Model.NormalFinish!=null)
        {
            Model.NormalFinish(Model.Evt);
        }
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
            while (count >= 0)
            {
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
