using UnityEngine;

/// <summary>
/// 控制道路改变
/// </summary>
public class RoadChange : MonoBehaviour
{
    /// <summary>
    /// 当前路段
    /// </summary>
    private GameObject roadNow;
    /// <summary>
    /// 下一个路段
    /// </summary>
    private GameObject roadNext;
    /// <summary>
    /// 父物体
    /// </summary>
    private GameObject parent;

    private void Start()
    {
        if(parent == null)
        {
            parent = new GameObject("Road");
            parent.transform.position = Vector3.zero;
            parent.transform.localScale = Vector3.one;
        }

        roadNow = GameEntry.Instance.m_ObjectPool.Spawn("Pattern_1", parent.transform);
        roadNext = GameEntry.Instance.m_ObjectPool.Spawn("Pattern_2", parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0f, 0f, 160f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == Tags.Road)
        {
            GameEntry.Instance.m_ObjectPool.Unspawn(other.gameObject);

            SpawnNewRoad();
        }
    }

    /// <summary>
    /// 生成新路段
    /// </summary>
    private void SpawnNewRoad()
    {
        int randomIndex = Random.Range(1, 5);
        roadNow = roadNext;
        roadNext = GameEntry.Instance.m_ObjectPool.Spawn(string.Format("Pattern_{0}", randomIndex), parent.transform);
        roadNext.transform.position = roadNow.transform.position + new Vector3(0f, 0f, 160f);
    }
}
