using projectGF;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIOneBtnNotice : MonoBehaviour
{
    public Text Notice_Content;

    public Text BtnText;

    public Button Btn;

    public UINoticeModel Model;


    private void Awake()
    {
        Btn.onClick.AddListener(OnBtnClick);
    }

    public void Init()
    {
        Notice_Content.text = Model.NoticeInfo;
        BtnText.text = Model.OneBtnName;
    }

    private void OnBtnClick()
    {
        if(Model.OneBtnBack !=null)
        {
            Model.OneBtnBack(Model.Evt);
        }
        tipClose();
    }

    void tipClose()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
