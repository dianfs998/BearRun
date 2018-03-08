using UnityEngine;

/// <summary>
/// 模型抽象类
/// </summary>
public abstract class Models : MonoBehaviour
{
	/// <summary>
    /// 名称标识
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// 发送时间
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="data">用户自定义数据</param>
    protected void SendEvent(string eventName, object data = null)
    {

    }
}
