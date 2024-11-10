using UnityEngine;
using TMPro; // Menambahkan namespace untuk TextMeshPro

public class TypingGameButtonInput : MonoBehaviour
{
    public TextMeshProUGUI targetWordDisplay;     // Menampilkan kata target
    public TextMeshProUGUI playerInputDisplay;    // Menampilkan input pemain
    public TextMeshProUGUI feedbackDisplay;       // Memberi umpan balik benar atau salah
    
    public WordList wordList;                     // Referensi ke ScriptableObject WordList

    private string currentWord;
    private string playerInput;

    void Start()
    {
        // Pastikan ada WordList yang terhubung sebelum mulai
        if (wordList == null || wordList.words.Length == 0)
        {
            Debug.LogError("WordList tidak diatur atau kosong!");
            return;
        }
        
        SetNewTargetWord();
    }

    // Fungsi untuk memilih kata target baru secara acak dari WordList
    void SetNewTargetWord()
    {
        currentWord = wordList.words[Random.Range(0, wordList.words.Length)];
        targetWordDisplay.text = currentWord;
        playerInput = ""; // Mengosongkan input pemain
        playerInputDisplay.text = playerInput;
    }

    // Fungsi yang dipanggil ketika tombol ditekan
    public void AddLetter(string letter)
    {
        playerInput += letter;
        playerInputDisplay.text = playerInput;

        // Jika input pemain sudah sepanjang kata target, cek apakah cocok
        if (playerInput.Length == currentWord.Length)
        {
            CheckWord();
        }
    }

    // Fungsi untuk mengecek apakah input sama dengan kata target
    void CheckWord()
    {
        if (playerInput.Equals(currentWord, System.StringComparison.OrdinalIgnoreCase))
        {
            feedbackDisplay.text = "Benar!";
            SetNewTargetWord(); // Ganti kata target setelah input benar
        }
        else
        {
            feedbackDisplay.text = "Salah, coba lagi!";
        }

        playerInput = ""; // Mengosongkan input pemain setelah pengecekan
        playerInputDisplay.text = playerInput;
    }
}