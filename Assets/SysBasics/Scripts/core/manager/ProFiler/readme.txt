该工具的使用,需要分别在 OnGUI() 和 OnUpdate(),中调用两个方法如下：

public void OnGUI()
{
            Framework.Console.Instance.OnGUI();
}
void Update()
{
            Framework.Console.Instance.OnUpdate();
}