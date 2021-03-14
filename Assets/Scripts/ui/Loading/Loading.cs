using System.Collections;
using System.Collections.Generic;
using projectGF;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Loading : UIViewBase
{
    public Slider processBar;
    public Text procesText;
    public Transform Quan;
    public int speed = 600;

    private AsyncOperation async;

    private int nowProcess;

    public override void Init()
    {
        Debug.Log("打开Loading 加载要加载的场景");
        StartCoroutine(loadScene());
    }

    public override void OnShow()
    {
        
    }

    /// <summary>
    /// 加载完场景后就会跳转
    /// </summary>
    /// <returns></returns>
    IEnumerator loadScene()
    {
        Debug.Log("要异步加载的场景 名称： " + RManager.scene.GetCurrSceneName());
        async = SceneManager.LoadSceneAsync(RManager.scene.GetCurrSceneName());
        async.allowSceneActivation = false;

        int toProcess;
        while (async.progress < 0.9f)
        {
            toProcess = (int)async.progress * 100;
            // 如果滑动条的当前进度，小于，当前加载场景的方法返回的进度 
            if (nowProcess < toProcess)
            {
                nowProcess++;
            }
            setProcess(nowProcess);

            yield return new WaitForEndOfFrame();
        }
        toProcess = 100;
        while (nowProcess < toProcess)
        {
            ++nowProcess;
            setProcess(nowProcess);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(1);

        Debug.Log("loading Scene 加载完成");
        async.allowSceneActivation = true;
        yield return async;
    }
    /// <summary>
    /// 设置Loading显示数据
    /// </summary>
    /// <param name="process">Process.</param>
    private void setProcess(int process)
    {
        processBar.value = process / 100f;
        procesText.text = "正在加载..." + process + "%";
    }

    void FixedUpdate()
    {
        Quan.Rotate(-Vector3.forward * Time.deltaTime * speed);
    }
    void OnDestroy()
    {
        Debug.Log("关闭loading 自身打印 并关闭上一场景开启的所有UI");
        //UICtrl.Instance.CloseAllUIPanel();
        //UICtrl.Instance.CloseUI(ToolsUtil.getUINameForPath(GameAssetsPath.UI_Loading_Path));
    }

    public override void OnHide()
    {
        //throw new System.NotImplementedException();
    }
}
