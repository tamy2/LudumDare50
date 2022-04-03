using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TyperWord : MonoBehaviour
{
    public WordBank wordBank;
    //public Shake shake;
    public Text wordOutput = null;
    private string remainingWord = string.Empty;
    //private string currentWord = string.Empty;
    private string currentWord;

    // Start is called before the first frame update
    private void Start()
    {
        /*
        wordOutput.text = currentWord;
        remainingWord = currentWord;
        */
        SetCurrentWord();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckInput();
    }

    private void SetCurrentWord() {
        currentWord = wordBank.GetWord();
        SetRemainingWord(currentWord);
    }

    private void SetRemainingWord(string newString) {
        remainingWord = newString;
        wordOutput.text = remainingWord;
    }

    private void CheckInput() {
        if (Input.anyKeyDown) {
            string keysPressed = Input.inputString;
            if (keysPressed.Length == 1) {
                EnterLetter(keysPressed);
            }
        }
    }

    private void EnterLetter(string input) {
        if (input.All(char.IsLetter)) {
            if (IsCorrectLetter(input)) {
                RemoveLetter();
                if (IsWordComplete()) {
                    SetCurrentWord();
                }
            }  else {
                //print("Letter typo!");
                wordOutput.GetComponent<Shake>().StartShake();
            }
        }
    }

    private bool IsCorrectLetter(string input) {
        return remainingWord.IndexOf(input) == 0;
    }

    private void RemoveLetter() {
        string newString = remainingWord.Remove(0, 1);
        SetRemainingWord(newString);
    }

    private bool IsWordComplete() {
        return remainingWord.Length == 0;
    }
}
