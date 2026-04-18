using UnityEngine;
using Yarn.Unity;

public class DialogueSFX: Singleton<DialogueSFX>
{
    /*Dialogue*/
    [YarnCommand("EvidenceSFX")]
    public static void EvidenceSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIDialogue + "Evidence");
    }

    [YarnCommand("HintSFX")]
    public static void HintSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIDialogue + "Hint");
    }

    [YarnCommand("SuccessSFX")]
    public static void SuccessSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIDialogue + "Success");
    }

    public static void AdvanceSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIDialogue + "Advance");
    }

    public static void HoverSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIDialogue + "Hover");
    }

    public static void SelectSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIDialogue + "Select");
    }

    /*Opening SFX*/
    [YarnCommand("CrashSFX")]
    public static void CrashSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXOpening + "Crash");
    }

    [YarnCommand("ClopSFX")]
    public static void ClopSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXOpening + "Clop");
    }

    [YarnCommand("FindKeySFX")]
    public static void FindKeySFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXOpening + "FindKey");
    }

    [YarnCommand("OpenDoorSFX")]
    public static void OpenDoorSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXOpening + "OpenDoor");
    }

    [YarnCommand("RattleDoorSFX")]
    public static void RattleDoorSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXOpening + "RattleDoor");
    }

    [YarnCommand("UnlockDoorSFX")]
    public static void UnlockDoorSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXOpening + "UnlockDoor");
    }

    [YarnCommand("FemaleScreamSFX")]
    public static void FemaleScreamSFX()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXOpening + "FemaleScream");
    }
}
