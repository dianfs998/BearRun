using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 对象池类
/// </summary>
public class ObjectPool : MonoSingleton<ObjectPool>
{
    /// <summary>
    /// 对象池资源目录
    /// </summary>
    public static string ResourceDirectory = "Objects";

    /// <summary>
    /// 资源池字典
    /// </summary>
    private Dictionary<string, SubPool> m_Pools;

    protected override void Awake()
    {
        base.Awake();

        m_Pools = new Dictionary<string, SubPool>();
    }

    /// <summary>
    /// 生成子对象池
    /// </summary>
    /// <param name="name">对象名称</param>
    /// <param name="transform"></param>
    /// <returns>生成的子对象池中生成的对象</returns>
    public GameObject Spawn(string name, Transform transform)
    {
        SubPool subPool = null;
        if (!m_Pools.ContainsKey(name))
        {
            Register(name, transform);
        }

        subPool = m_Pools[name];
        return subPool.Spawn();
    }

    /// <summary>
    /// 回收子对象池
    /// </summary>
    /// <param name="go">回收子对象池中的对象</param>
    public void Unspawn(GameObject go)
    {
        SubPool subPool = null;
        foreach(SubPool pool in m_Pools.Values)
        {
            if (pool.Contains(go))
            {
                subPool = pool;
                break;
            }
        }
        
        if(subPool != null)
        {
            subPool.Unspawn(go);
        }
    }

    /// <summary>
    /// 回收所有子对象池
    /// </summary>
    public void UnspawnAll()
    {
        foreach(SubPool pool in m_Pools.Values)
        {
            pool.UnspawnAll();
        }
    }

    /// <summary>
    /// 注册新子对象池类
    /// </summary>
    /// <param name="name"></param>
    /// <param name="transform"></param>
    private void Register(string name, Transform transform)
    {
        if(name == null)
        {
            return;
        }

        string path = string.Format("{0}/{1}", ResourceDirectory, name);
        GameObject prefab = Resources.Load<GameObject>(path);
        SubPool subPool = new SubPool(transform, prefab);
        m_Pools.Add(subPool.Name, subPool);
    }
}
