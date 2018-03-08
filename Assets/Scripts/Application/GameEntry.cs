using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// 游戏入口
/// </summary>
[RequireComponent(typeof(ObjectPool))]
[RequireComponent(typeof(SoundManager))]
[RequireComponent(typeof(StaticData))]
public class GameEntry : MonoSingleton<GameEntry>
{
    /// <summary>
    /// 对象池
    /// </summary>
    [HideInInspector]
    public ObjectPool m_ObjectPool;

    /// <summary>
    /// 声音管理
    /// </summary>
    [HideInInspector]
    public SoundManager m_SoundManager;

    /// <summary>
    /// 静态数据
    /// </summary>
    [HideInInspector]
    public StaticData m_StaticData;

    private void Start()
    {
        DontDestroyOnLoad(gameObject);

        m_ObjectPool = ObjectPool.Instance;
        m_SoundManager = SoundManager.Instance;
        m_StaticData = StaticData.Instance;
    }

    /// <summary>
    /// 加载场景
    /// </summary>
    /// <param name="sceneIndex">场景序号</param>
    private void LoadScene(int sceneIndex)
    {
        SceneArgs e = new SceneArgs();
        e.sceneIndex = SceneManager.GetActiveScene().buildIndex;

        SendEvent(Consts.E_ExitScenes, e);

        SceneManager.LoadScene(sceneIndex, LoadSceneMode.Single);
    }

    /// <summary>
    /// 场景加载完成后事件
    /// </summary>
    /// <param name="index">场景序号</param>
    private void OnLevelWasLoaded(int index)
    {
        Debug.Log("加载新场景");
        SceneArgs e = new SceneArgs();
        e.sceneIndex = index;

        SendEvent(Consts.E_EnterScenes, e);
    }

    /// <summary>
    /// 发送事件
    /// </summary>
    /// <param name="eventName">事件名称</param>
    /// <param name="data">用户自定义数据</param>
    private void SendEvent(string eventName, object data)
    {
        MVC.SendCommand(eventName, data);
    }
}
