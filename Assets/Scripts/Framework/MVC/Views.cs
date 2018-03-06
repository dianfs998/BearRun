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
    /// 处理事件
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="data">用户自定义数据</param>
    public abstract void HandleEvent(string eventName, object data);
}
