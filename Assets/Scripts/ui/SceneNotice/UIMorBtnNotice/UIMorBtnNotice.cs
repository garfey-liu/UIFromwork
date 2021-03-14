using projectGF;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMorBtnNotice : MonoBehaviour
{
    public Text Notice_Content;

    public GameObject BtnGrid;
    public GameObject BtnItem;

    public UINoticeModel Model;

    public void Init()
    {

        Notice_Content.text = Model.NoticeInfo;

        GameObject tmpObj;
        BtnItem tmpBtnItem;
        BtnInfoItem tmpBtnInfo;
        for (int i = 0; i < Model.btnList.Count; i++)
        {
            //print("生成按钮的数量="+i);
            tmpBtnInfo = Model.btnList[i];
            tmpObj = GUITools.AddChild(BtnGrid, BtnItem);
            tmpBtnItem = tmpObj.GetComponent<BtnItem>();
            tmpBtnItem.BtnName.text = tmpBtnInfo.BtnName;
            tmpBtnItem.BtnInfo = tmpBtnInfo;
            tmpBtnItem.OnClick = OnBtnBack;

            tmpObj.SetActive(true);
        }
    }
    private void OnBtnBack(object obj)
    {
        tipClose();
    }

    void tipClose()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
