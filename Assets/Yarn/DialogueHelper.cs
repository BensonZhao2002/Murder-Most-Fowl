using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Yarn.Unity;

public class DialogueHelper : Singleton<DialogueHelper>
{
    [Serializable]
    public struct SpriteItem
    {
        public string name;
        public Sprite sprite;
    }

    [Header("Yarn Components")] 
    [SerializeField] private DialogueRunner _dialogueRunner;

    [Header("Dialogue UI")]
    [SerializeField] private GameObject _background;
    [SerializeField] private Image _leftCharacter;
    [SerializeField] private Image _rightCharacter;
    [SerializeField] private List<SpriteItem> _spriteList;

    public DialogueRunner DialogueRunner
    {
        get => _dialogueRunner;
    }

    private static Image _left;
    private static Image _right;
    private static List<SpriteItem> _sprites;

    void Awake()
    {
        InitializeSingleton();

        _left = _leftCharacter;
        _right = _rightCharacter;
        _sprites = _spriteList;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartDialogue()
    {
        ClueBoardManager.Instance.ClueBoardCanvas.enabled = false;
        _background.SetActive(true);
    }

    public void EndDialogue()
    {
        ClueBoardManager.Instance.ClueBoardCanvas.enabled = true;
        _background.SetActive(false);
    }

    // TODO
    // Generalize these commands

    [YarnCommand("ChangeLeftCharacter")]
    public static void ChangeLeft(string name = null)
    {
        if (name == null)
        {
            _left.gameObject.SetActive(false);
            return;
        }

        _left.gameObject.SetActive(true);
        SpriteItem spriteItem = _sprites.Find(e => e.name == name);

        // TODO
        // Add Error Handling
        _left.sprite = spriteItem.sprite;
    }

    [YarnCommand("ChangeRightCharacter")]
    public static void ChangeRight(string name = null)
    {
        if (name == null)
        {
            _right.gameObject.SetActive(false);
            return;
        }

        _right.gameObject.SetActive(true);
        SpriteItem spriteItem = _sprites.Find(e => e.name == name);

        // TODO
        // Add Error Handling
        _right.sprite = spriteItem.sprite;
    }
}
