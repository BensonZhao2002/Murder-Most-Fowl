using UnityEngine;
using Yarn.Unity;
using FMOD.Studio;

public class EnvironmentSFX : Singleton<EnvironmentSFX>
{
    private static EventInstance TrainMoveSFX;
    void Awake()
    {
        InitializeSingleton();
    }
    
    void Start()
    {
        TrainMoveSFX = FMODUnity.RuntimeManager.CreateInstance(EventPathSFX.AmbiencePath + "TrainMove");
        TrainMoveSFXStart();
        SetTrainLocationSFX("Room");
    }

    [YarnCommand("TrainMoveSFXStart")]
    public static void TrainMoveSFXStart()
    {
        TrainMoveSFX.start();
    }

    [YarnCommand("TrainMoveSFXStop")]
    public static void TrainMoveSFXStop()
    {
        TrainMoveSFX.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
    }

    [YarnCommand("SetTrainLocationSFX")]
    public static void SetTrainLocationSFX(string label) 
    {
        TrainMoveSFX.setParameterByNameWithLabel("TrainLocation", label);
    }

    void OnDestroy()
    {
        TrainMoveSFX.release();
    }
}
