using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using Yarn.Unity;

public class AudioManager : Singleton<AudioManager>
{
    [Header("BGM")]

    [SerializeField]
    private List<FMODUnity.EventReference> musicList;

    [SerializeField] private int startMusicIndex;


    private FMOD.Studio.Bus MasterBus;
    private FMOD.Studio.EventInstance _musicState;
    private FMOD.Studio.EventInstance pauseSnapshot;

    void Awake()
    {
        InitializeSingleton();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pauseSnapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/Pause");
        MasterBus = FMODUnity.RuntimeManager.GetBus("bus:/");

        _musicState = FMODUnity.RuntimeManager.CreateInstance(musicList[startMusicIndex]);
        _musicState.start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        StopAllSoundEvents();

        //--------------------------------------------------------------------
        // 6: This shows how to release resources when the unity object is 
        //    disabled.
        //--------------------------------------------------------------------
        _musicState.release();
        pauseSnapshot.release();
    }

    void StopAllSoundEvents()
    {
        MasterBus.stopAllEvents(FMOD.Studio.STOP_MODE.IMMEDIATE);
    }

    public void ChangeBGM(int index)
    {
        if (index >= musicList.Count)
        {
            return;
        }

        _musicState.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        _musicState.release();
        _musicState = FMODUnity.RuntimeManager.CreateInstance(musicList[index]);
        _musicState.start();
    }

    public void StopBGM()
    {
        _musicState.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    public void StartBGM()
    {
        _musicState.start();
    }

    public void ChangeLeisure(int value)
    {
        _musicState.setParameterByName("Leisure", value);
    }

    [YarnCommand("StopBGM")]
    public static void YarnStopBGM()
    {
        Instance.StopBGM();
    }

    [YarnCommand("StartBGM")]
    public static void YarnStartBGM()
    {
        Instance.StartBGM();
    }

    [YarnCommand("ChangeBGM")]
    public static void YarnChangeBGM(int index) 
    {
        Instance.ChangeBGM(index);
    }

    [YarnCommand("ChangeLeisure")]
    public static void YarnChangeLeisure(int value)
    {
        Instance.ChangeLeisure(value);
    }

    public void PauseEffect(bool paused)
    {
        if (paused)
        {
            pauseSnapshot.start();
        } else
        {
            pauseSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
