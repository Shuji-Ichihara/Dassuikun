using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// BGM の種類の羅列
/// </summary>
public enum BGMType
{
    TitleBGM,
    GameBGM,
    ResultBGM,
}

/// <summary>
/// SE の種類の羅列
/// </summary>
public enum SEType
{
    Gacha,
    CountDown,
    RollGachaBall,
    CollideGachaBall,
    CollideWall,
    Oil,
}

/// <summary>
/// BGM の音声アセットの詳細設定
/// </summary>
[System.Serializable]
public struct BGMData
{
    [Header("BGM の種類")]
    public BGMType BGMType;
    [Header("音声アセット")]
    public AudioClip Clip;
    [Header("BGM のボリューム")]
    [Range(0.0f, 1.0f)]
    public float Volume;
    [Header("ループの可否")]
    public bool IsLoop;
}

/// <summary>
/// SE の音声アセットの詳細設定
/// </summary>
[System.Serializable]
public struct SEData
{
    [Header("SE の種類")]
    public SEType SeType;
    [Header("音声アセット")]
    public AudioClip Clip;
    [Header("SE のボリューム")]
    [Range(0.0f, 1.0f)]
    public float Volume;
}

public class AudioManager : SingletonMonoBehaviour<AudioManager>
{
    #region Refarences
    // BGM を再生するソース
    [SerializeField]
    private AudioSource _bgmAudioSource = null;
    // SE を再生するソース
    [SerializeField]
    private AudioSource _seAudioSource = null;
    // SE をループ再生するソース
    [SerializeField]
    private AudioSource _loopSeAudioSource = null;
    #endregion
    #region AudioData
    // BGM データのリスト
    [SerializeField]
    private List<BGMData> _bgmDataList = new List<BGMData>();
    // SE データのリスト
    [SerializeField]
    private List<SEData> _seDataList = new List<SEData>();
    #endregion

    private void Start()
    {
        // null チェック
        if (_bgmAudioSource == null)
            _bgmAudioSource = GameObject.Find("BGMSource").GetComponent<AudioSource>();
        if (_seAudioSource == null)
            _seAudioSource = GameObject.Find("SESource").GetComponent<AudioSource>();
        if(_loopSeAudioSource == null)
            _loopSeAudioSource = GameObject.Find("LoopSESource").GetComponent<AudioSource>();
        _bgmAudioSource.transform.SetParent(transform);
        _seAudioSource.transform.SetParent(transform);
        _loopSeAudioSource.transform.SetParent(transform);
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// BGM を再生
    /// </summary>
    /// <param name="type">再生する BGM の種類</param>
    public void PlayBGM(BGMType type)
    {
        var bgmData = _bgmDataList[(int)type];
        _bgmAudioSource.clip = bgmData.Clip;
        _bgmAudioSource.volume = bgmData.Volume;
        _bgmAudioSource.loop = bgmData.IsLoop;
        _bgmAudioSource.Play();
    }

    /// <summary>
    /// BGM の再生をを停止
    /// </summary>
    public void StopBGM()
    {
        _bgmAudioSource.Stop();
    }

    /// <summary>
    /// SE を再生
    /// </summary>
    /// <param name="type">再生する SE の種類</param>
    public void PlaySE(SEType type)
    {
        var seData = _seDataList[(int)type];
        _seAudioSource.clip = seData.Clip;
        _seAudioSource.volume = seData.Volume;
        _seAudioSource.PlayOneShot(seData.Clip);
    }

    /// <summary>
    /// ループする SE 再生
    /// </summary>
    /// <param name="type">再生する SE の種類</param>
    public void PlayLoopSE(SEType type)
    {
        var seData = _seDataList[(int)type];
        _loopSeAudioSource.clip = seData.Clip;
        _loopSeAudioSource.volume = seData.Volume;
        _loopSeAudioSource.loop = true;
        _loopSeAudioSource.Play();
    }

    /// <summary>
    /// ループする SE 停止
    /// </summary>
    public void PauseLoopSE()
    {
        _loopSeAudioSource.Pause();
    }
}
