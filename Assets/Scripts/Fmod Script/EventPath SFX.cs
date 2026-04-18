using UnityEngine;

public class EventPathSFX : Singleton<EventPathSFX>
{
    public static string EventPath = "event:/";
    public static string AmbiencePath = EventPath + "Ambience/";
    public static string UIDialogue = EventPath + "UI/Dialogue/";
    public static string SFXObject = EventPath + "SFX/Object/";
    public static string SFXOpening = EventPath + "SFX/Opening/";
    public static string SFXCharacter = EventPath + "SFX/Character/";
    public static string UIClueBoard = EventPath + "UI/ClueBoard/";
}
