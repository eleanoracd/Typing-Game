using UnityEngine;
using TMPro; // Menambahkan namespace untuk TextMeshPro

public class Typer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI targetWordDisplay;     // target word
    [SerializeField] private TextMeshProUGUI playerInputDisplay;    // player input
    
    [SerializeField] private WordList wordList;                     // WordList reference
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private FlashEffect flashEffect;

    private string currentWord;
    private string playerInput;

    void Start()
    {
        
        if (wordList == null || wordList.words.Count == 0)
        {
            Debug.LogError("Empty WordList!");
            return;
        }
        
        SetNewTargetWord();
    }


    void SetNewTargetWord()
    {
        currentWord = wordList.words[Random.Range(0, wordList.words.Count)];
        targetWordDisplay.text = currentWord;
        playerInput = "";
        playerInputDisplay.text = playerInput;
    }


    public void AddLetter(string letter)
    {
        playerInput += letter;
        playerInputDisplay.text = playerInput;

 
        if (playerInput.Length == currentWord.Length)
        {
            CheckWord();
        }
    }


    void CheckWord()
    {
        bool isCorrect = playerInput.Equals(currentWord, System.StringComparison.OrdinalIgnoreCase);

        if (isCorrect)
        {
            soundManager.PlayCorrectSFX();
            wordList.words.Remove(currentWord);
        }
        else
        {
            soundManager.PlayIncorrectSFX();
        }

        flashEffect.PlayFlash(isCorrect);

        SetNewTargetWord();
        playerInput = "";
        playerInputDisplay.text = playerInput;
    }
}