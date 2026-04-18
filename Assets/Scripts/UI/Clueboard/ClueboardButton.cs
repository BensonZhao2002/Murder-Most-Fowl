using UnityEngine;
using UnityEngine.UI;

public class ClueboardButton : MonoBehaviour
{
    [SerializeField]
    private Sprite _toOverworld;
    [SerializeField] 
    private Sprite _toClueboard;

    [SerializeField] 
    private Image _buttonImage;

    private FMOD.Studio.EventInstance clueBoardSnapshot;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CloseClueBoard(true);
        clueBoardSnapshot = FMODUnity.RuntimeManager.CreateInstance("snapshot:/ClueBoard");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        clueBoardSnapshot.release();
    }

    public void OpenClueBoard()
    {
        _buttonImage.sprite = _toOverworld;
        FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIClueBoard + "Button/OpenClueBoard");
        clueBoardSnapshot.start();
    }

    public void CloseClueBoard(bool ifSilent = false)
    {
        _buttonImage.sprite = _toClueboard;
        if (!ifSilent)
        {
            FMODUnity.RuntimeManager.PlayOneShot(EventPathSFX.UIClueBoard + "Button/CloseClueBoard");
            clueBoardSnapshot.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }
}
