using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 子对象池类
/// </summary>
public class SubPool
{
    /// <summary>
    /// 子对象池中对象集合
    /// </summary>
    private List<GameObject> m_Objects;
    /// <summary>
    /// 子对象池中对象所依赖的预制体
    /// </summary>
    private GameObject m_Prefab;
    /// <summary>
    /// 子对象池中对象的父物体的Transform
    /// </summary>
    private Transform m_Parent;

    /// <summary>
    /// 子对象池中对象所依赖的预制体的名称
    /// </summary>
    public string Name
    {
        get { return m_Prefab.name; }
    }

    /// <summary>
    /// 初始化子对象池类的新实例
    /// </summary>
    /// <param name="parent">子对象池中对象的父物体的Transform</param>
    /// <param name="prefab">子对象池中对象所依赖的预制体</param>
    public SubPool(Transform parent, GameObject prefab)
    {
        m_Parent = parent;
        m_Prefab = prefab;
    }

    /// <summary>
    /// 生成对象
    /// </summary>
    /// <returns>生成的对象</returns>
    public GameObject Spawn()
    {
        GameObject go = null;
        foreach(GameObject obj in m_Objects)
        {
            if (!obj.activeSelf)
            {
                go = obj;
            }
        }

        if(go == null)
        {
            go = GameObject.Instantiate<GameObject>(m_Prefab);
            go.transform.SetParent(m_Parent);
            m_Objects.Add(go);
        }

        go.SetActive(true);
        go.SendMessage("OnSpawn", SendMessageOptions.DontRequireReceiver);

        return go;
    }

    /// <summary>
    /// 回收对象
    /// </summary>
    /// <param name="go">需要回收的对象</param>
    public void Unspawn(GameObject go)
    {
        if (m_Objects.Contains(go))
        {
            go.SendMessage("OnUnspawn", SendMessageOptions.DontRequireReceiver);
            go.SetActive(false);
        }
    }

    /// <summary>
    /// 回收所有对象
    /// </summary>
    public void UnspawnAll()
    {
        foreach(GameObject obj in m_Objects)
        {
            if (obj.activeSelf)
            {
                Unspawn(obj);
            }
        }
    }
}
