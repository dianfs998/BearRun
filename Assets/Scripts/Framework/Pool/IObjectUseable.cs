

/// <summary>
/// 对象池物体可用接口
/// </summary>
public interface IObjectUseable
{
    /// <summary>
    /// 物体生成
    /// </summary>
    void OnSpawn();

    /// <summary>
    /// 物体回收
    /// </summary>
    void OnUnspawn();
}
