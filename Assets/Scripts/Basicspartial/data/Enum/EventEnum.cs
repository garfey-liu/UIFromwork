/****************************************************
*
*  事件枚举类
*  作者: GarFey
*  日期：2018年7月25日
*
*****************************************************/


public class EventEnum
{
    /// <summary>
    /// 事件监听枚举
    /// </summary>
    public enum EventListener
    {
        NoneEvent = 1,

        /// <summary>
        /// 手柄按下
        /// </summary>
        TriggerDown,

        /// <summary>
        /// 场景打开 消息
        /// </summary>
        SysScene_Open,
        /// <summary>
        /// 场景关闭 消息
        /// </summary>
        SysScene_Close,
        /// <summary>
        /// 关闭UI相机
        /// </summary>
        CloseUICamera,
        /// <summary>
        /// 打开UI相机
        /// </summary>
        OpenUICamera,

        /// <summary>
        /// 手柄菜单键
        /// </summary>
        ApplicationMenu,
        /// <summary>
        /// 侧边键
        /// </summary>
        GripPressed,

        /// <summary>
        /// 下拉列表 触发
        /// </summary>
        DropDownItemClick,

        #region ========== Http Event ===========================================

        /// <summary>
        /// Http登录成功
        /// </summary>
        HttpLoginFinish,
        /// <summary>
        /// Http登出成功
        /// </summary>
        HttpLoginOutFinish,
        /// <summary>
        /// Http用户信息 响应完成
        /// </summary>
        HttpUserInfoRspFinish,
        /// <summary>
        /// Http修改密码完成 
        /// </summary>
        HttpUploadPasswordFinish,

        #endregion

        #region ========== Tcp Event =============================================

        /// <summary>
        /// Tcp服务器登录成功
        /// </summary>
        TcpLoginFinish,
        /// <summary>
        /// Tcp有人进入场景广播
        /// </summary>
        TcpHavePlayerEnterSceneNotify,
        /// <summary>
        /// Tcp有人退出场景广播
        /// </summary>
        TcpHavePlayerQuitSceneNotify,
        /// <summary>
        /// Tcp获取场景玩家列表
        /// </summary>
        TcpGetScenePlayerList,
        /// <summary>
        /// Tcp玩家移动
        /// </summary>
        TcpPlayerMove,
        /// <summary>
        /// Tcp玩家动画状态修改
        /// </summary>
        TcpPlayerChangeState,
        /// <summary>
        /// Tcp进入场景
        /// </summary>
        TcpEnterScene,
        /// <summary>
        /// Tcp退出场景
        /// </summary>
        TcpQuitScene,

        #endregion

        #region ========== 电台消息 =============================================
        /// <summary>
        /// 电台设备 运行状态
        /// </summary>
        EquipRunState,
        /// <summary>
        /// 电台设备 新消息 通知
        /// </summary>
        EquipNewMsg,

        #endregion

    }
}