using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 视图抽象类
/// </summary>
public abstract class Views : MonoBehaviour
{
    /// <summary>
    /// 名称标识
    /// </summary>
    public abstract string Name { get; }

    /// <summary>
    /// 关心的事件列表
    /// </summary>
    [HideInInspector]
    public List<string> AttentionList = new List<string>();

    /// <summary>
    /// 注册关心的事件列表
    /// </summary>
    public void RegisterAttentionList()
    {

    }

    /// <summary>
    /// 处理事件
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="data">用户自定义数据</param>
    public abstract void HandleEvent(string eventName, object data);

    /// <summary>
    /// 发送时间
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="data">用户自定义数据</param>
    protected void SendEvent(string eventName, object data = null)
    {

    }

    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T">模型类型</typeparam>
    /// <returns>模型类</returns>
    protected T GetModel<T>() where T : Models
    {
        return MVC.GetModel<T>() as T;
    }
}
