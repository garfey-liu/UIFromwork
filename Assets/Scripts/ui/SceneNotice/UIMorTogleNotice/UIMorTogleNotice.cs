using projectGF;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMorTogleNotice : MonoBehaviour
{
    public Text Notice_Content;

    public GameObject BtnGrid;
    public GameObject BtnItem;

    public Button OkBtn;
    public Text BtnText;

    public UINoticeModel Model;

    private void Start()
    {
        OkBtn.onClick.AddListener(OnOkBtnClick);
    }

    private void OnOkBtnClick()
    {
        if (Model.OneToggleBtnBack != null)
        {
            Model.OneToggleBtnBack(Model.Evt);
        }
        tipClose();
    }

    public void Init()
    {

        Notice_Content.text = Model.NoticeInfo;
        BtnText.text = Model.OneBtnName;

        GameObject tmpObj;
        ToggleItem tmpToggleItem;
        ToggleInfoItem tmpToggleInfo;
        for (int i = 0; i < Model.toggleList.Count; i++)
        {
            tmpToggleInfo = Model.toggleList[i];
            tmpObj = GUITools.AddChild(BtnGrid, BtnItem);
            tmpToggleItem = tmpObj.GetComponent<ToggleItem>();
            tmpToggleItem.ToggleName.text = tmpToggleInfo.ToggleName;
            tmpToggleItem.TogInfo = tmpToggleInfo;
            //tmpToggleItem.OnValueChange = OnToggleBack;

            tmpObj.SetActive(true);
        }
    }
    private void OnToggleBack(bool obj)
    {
        
    }

    void tipClose()
    {
        GameObject.DestroyImmediate(gameObject);
    }
}
