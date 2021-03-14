using projectGF;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingBar : UIViewBase
{
    public Transform Quan;
    public int speed = 600;

    private AsyncOperation async;
    public override void Init()
    {
    }

    public override void OnShow()
    {
    }

    void FixedUpdate()
    {
        Quan.Rotate(-Vector3.forward * Time.deltaTime * speed);
    }

    public override void OnHide()
    {
        //throw new System.NotImplementedException();
    }
}
