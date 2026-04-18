using UnityEngine;

public class FootstepSFX : MonoBehaviour
{
    public void PlayFootstep()
    {
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.SFXCharacter + "PlayerFootstep");
    }
}
