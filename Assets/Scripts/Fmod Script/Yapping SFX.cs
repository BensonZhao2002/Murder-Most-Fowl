using UnityEngine;
using FMOD.Studio;

public class YappingSFX : Singleton<YappingSFX>
{
    private static EventInstance Yapper;
    private int count;

    void Awake()
    {
        InitializeSingleton();
    }

    void Start()
    {
        Yapper = FMODUnity.RuntimeManager.CreateInstance(EventPathSFX.SFXCharacter + "Yapping");
        count = 0;
    }

    public void TypedCount()
    {
        count++;
        if (count >= 5)
        {
            Yapping();
            count = 0;
        }
    }

    void Yapping()
    {
        Yapper.start();
    }

    void OnDestroy()
    {
        Yapper.release();
    }
}
