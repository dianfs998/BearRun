

/// <summary>
/// 对象池物体可用基类
/// </summary>
public abstract class ReuseableObject : IObjectUseable
{
    /// <summary>
    /// 物体生成
    /// </summary>
    public abstract void OnSpawn();

    /// <summary>
    /// 物体回收
    /// </summary>
    public abstract void OnUnspawn();
}
