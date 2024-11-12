using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WordList", menuName = "ScriptableObjects/WordList", order = 1)]
public class WordList : ScriptableObject
{
    public List<string> words = new List<string>();
}