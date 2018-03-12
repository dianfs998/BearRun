using System;
using System.Collections.Generic;

/// <summary>
/// MVC类
/// </summary>
public static class MVC
{
    public static Dictionary<string, Models> Models = new Dictionary<string, Models>();
    public static Dictionary<string, Views> Views = new Dictionary<string, Views>();
    public static Dictionary<string, Type> CommandsMap = new Dictionary<string, Type>();

    /// <summary>
    /// 注册模型类
    /// </summary>
    /// <param name="models">模型类</param>
    public static void RegisterModel(Models models)
    {
        Models[models.Name] = models;
    }

    /// <summary>
    /// 注册视图类
    /// </summary>
    /// <param name="views">试图类</param>
    public static void RegisterView(Views views)
    {
        if (Views.ContainsKey(views.Name))
        {
            Views.Remove(views.Name);
        }

        views.RegisterAttentionList();
        Views[views.Name] = views;
    }

    /// <summary>
    /// 注册命令类
    /// </summary>
    /// <param name="eventName">命令名称</param>
    /// <param name="commandType">命令类型</param>
    public static void RegisterController(string eventName, Type commandType)
    {
        CommandsMap[eventName] = commandType;
    }

    /// <summary>
    /// 获取模型类
    /// </summary>
    /// <typeparam name="T">模型类类型</typeparam>
    /// <returns>模型类</returns>
    public static T GetModel<T>() where T : Models
    {
        foreach(Models m in Models.Values)
        {
            if(m is Models)
            {
                return (T)m;
            }
        }

        return null;
    }

    /// <summary>
    /// 获取视图类
    /// </summary>
    /// <typeparam name="T">视图类类型</typeparam>
    /// <returns>视图类</returns>
    public static T GetView<T>() where T : Views
    {
        foreach(Views v in Views.Values)
        {
            if(v is Views)
            {
                return (T)v;
            }
        }

        return null;
    }

    /// <summary>
    /// 发送命令
    /// </summary>
    /// <param name="eventName">命令名称</param>
    /// <param name="data">用户自定义数据</param>
    public static void SendCommand(string eventName, object data)
    {
        if (CommandsMap.ContainsKey(eventName))
        {
            Type commandType = CommandsMap[eventName];
            Controller controller = Activator.CreateInstance(commandType) as Controller;
            controller.Execute(data);
        }

        foreach(Views view in Views.Values)
        {
            if (view.AttentionList.Contains(eventName))
            {
                view.HandleEvent(eventName, data);
            }
        }
    }
}
