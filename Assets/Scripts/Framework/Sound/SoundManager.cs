using UnityEngine;

/// <summary>
/// 声音管理类
/// </summary>
public class SoundManager :  MonoSingleton<SoundManager>
{
    /// <summary>
    /// 声音资源目录
    /// </summary>
    private static string ResourceDirectory = "";

    /// <summary>
    /// 背景音乐源组件
    /// </summary>
    private AudioSource m_BackAudio;

    /// <summary>
    /// 音效音乐源组件
    /// </summary>
    private AudioSource m_EffectAudio;

    protected override void Awake()
    {
        base.Awake();

        m_BackAudio = gameObject.AddComponent<AudioSource>();
        m_BackAudio.playOnAwake = false;
        m_BackAudio.loop = true;

        m_EffectAudio = gameObject.AddComponent<AudioSource>();
    }

    /// <summary>
    /// 播放背景声音
    /// </summary>
    public void PlayBackAudio()
    {
        if(m_BackAudio.clip == null)
        {
            return;
        }

        m_BackAudio.Play();
    }

    /// <summary>
    /// 播放背景声音
    /// </summary>
    /// <param name="audioClipName">声音片段名称</param>
    public void PlayBackAudio(string audioClipName)
    {
        if(string.IsNullOrEmpty(audioClipName))
        {
            return;
        }

        if(m_BackAudio.clip.name != audioClipName)
        {
            string path = string.Format("{0}/{1}", ResourceDirectory, audioClipName);
            m_BackAudio.clip = Resources.Load<AudioClip>(path);
        }

        if(m_BackAudio.clip != null)
        {
            m_BackAudio.Play();
        }
    }

    /// <summary>
    /// 停止播放背景声音
    /// </summary>
    public void StopBackAudio()
    {
        if (m_BackAudio.clip == null)
        {
            return;
        }

        m_BackAudio.Stop();
    }

    /// <summary>
    /// 播放音效
    /// </summary>
    /// <param name="audioClipName">声音片段名称</param>
    public void PlayEffectAudio(string audioClipName, float volume = 1f)
    {
        if (string.IsNullOrEmpty(audioClipName))
        {
            return;
        }

        string path = string.Format("{0}/{1}", ResourceDirectory, audioClipName);
        AudioClip clip = Resources.Load<AudioClip>(path);

        if(clip != null)
        {
            m_EffectAudio.PlayOneShot(clip, volume);
        }
    }
}
