using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using projectGF;

public class BtnItem : MonoBehaviour
{

    public Text BtnName;

    public Button Btn;

    public BtnInfoItem BtnInfo;
    
    public System.Action<System.Object> OnClick;
    // Start is called before the first frame update
    void Start()
    {
        Btn.onClick.AddListener(OnBtnClick);
    }

    private void OnBtnClick()
    {
        if(BtnInfo.OnBtnBack!=null)
        {
            BtnInfo.OnBtnBack(BtnInfo.evt);
        }
        OnClick(null);
    }
}
