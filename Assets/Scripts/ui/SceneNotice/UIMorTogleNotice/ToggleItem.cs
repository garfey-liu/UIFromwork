using projectGF;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleItem : MonoBehaviour
{
    public Text ToggleName;

    public Toggle Tog;

    public ToggleInfoItem TogInfo;

    public System.Action<System.Boolean> OnValueChange;
    // Start is called before the first frame update
    void Start()
    {
        Tog.onValueChanged.AddListener(OnToggleClick);
    }

    private void OnToggleClick(bool arg0)
    {
        if(TogInfo.OnToggleBack!=null)
        {
            TogInfo.OnToggleBack(arg0);
        }

        //OnValueChange(arg0);
    }
}
