using System;

/// <summary>
/// 控制抽象类
/// </summary>
public abstract class Controller
{
    /// <summary>
    /// 执行
    /// </summary>
    /// <param name="data">用户自定义数据</param>
    public abstract void Execute(object data);

    /// <summary>
    /// 获取模型
    /// </summary>
    /// <typeparam name="T">模型类型</typeparam>
    /// <returns>模型类</returns>
    protected T GetModel<T>() where T : Models
    {
        return MVC.GetModel<T>() as T;
    }

    /// <summary>
    /// 获取视图
    /// </summary>
    /// <typeparam name="T">视图类型</typeparam>
    /// <returns>视图类</returns>
    protected T GetView<T>() where T : Views
    {
        return MVC.GetView<T>() as T;
    }

    /// <summary>
    /// 注册模型类
    /// </summary>
    /// <param name="models">模型</param>
    protected void RegisterModel(Models models)
    {
        MVC.RegisterModel(models);
    }

    /// <summary>
    /// 注册视图类
    /// </summary>
    /// <param name="views">视图</param>
    protected void RegisterView(Views views)
    {
        MVC.RegisterView(views);
    }

    /// <summary>
    /// 注册控制类
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="commandType">命令类型</param>
    protected void RegisterController(string eventName, Type commandType)
    {
        MVC.RegisterController(eventName, commandType);
    }
}
