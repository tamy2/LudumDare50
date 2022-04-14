using System.Collections;
using System.Collections.Generic;
// System.Runtime;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class TyperNumber : MonoBehaviour
{
    public int timeDelay;
    public Text numberOutput = null;
    private string remainingNumber = string.Empty;
    //private string currentNumber = string.Empty;
    private string currentNumber;

    // Start is called before the first frame update
    private void Start()
    {
        //SetCurrentNumber();
    }

    // Update is called once per frame
    private void Update()
    {
        CheckInput();
        RemoveHyphen();
    }

    public void SetCurrentNumber() {
        currentNumber = GenerateNumber();
        SetRemainingNumber(currentNumber);
    }

    private void SetRemainingNumber(string newString) {
        remainingNumber = newString;
        numberOutput.text = remainingNumber;
    }

    private void CheckInput() {
        if (!IsNumberComplete()) {
            if (Input.anyKeyDown) {
                string keysPressed = Input.inputString;
                if (keysPressed.Length == 1) {
                    EnterNumber(keysPressed);
                }
            }
        }
    }

    private void EnterNumber(string input) {
        if (input.All(char.IsDigit)) {
            if (IsCorrectNumber(input)) {
                RemoveNumber();
                /*
                if (IsNumberComplete()) {
                    SetCurrentNumber();
                }
                */
            } else {
                //print("Number typo!");
                numberOutput.GetComponent<Shake>().StartShake();
            }
        }
    }

    private bool IsCorrectNumber(string input) {
        return remainingNumber.IndexOf(input) == 0;
    }

    private void RemoveNumber() {
        string newString = remainingNumber.Remove(0, 1);
        SetRemainingNumber(newString);
    }

    //this can be used to help score
    private bool IsNumberComplete() {
        return remainingNumber.Length == 0;
    }

    private void RemoveHyphen() {
        if (remainingNumber.Length > 0) {
            if (remainingNumber[0].Equals('-')) {
                SetRemainingNumber(remainingNumber.Remove(0, 1));
            }
        }
    }

    private string GenerateNumber() {
        //Random rnd = new System.Random();
        int number = -1;
        while (number < 0) {
            number = (int) Random.Range(1, 9999999999);
        }
        string numberString = number.ToString();
        for (int i = 0; i < 10 - numberString.Length; i++) {
            numberString = "0" + numberString;
        }
        if (numberString.Length > 10) {
            numberString.Substring(0, 10);
        }
        numberString = numberString.Substring(0, 3) + "-" + numberString.Substring(3, 3) + "-" + numberString.Substring(6);
        /*
        number = Mathf.Abs(number);
        print(number);
        string numberString = string.Format("%10d", number);
        print(numberString);
        numberString = numberString.Substring(0, 3) + "-" + numberString.Substring(3, 6) + "-" + numberString.Substring(6);
        */
        return numberString;
    }
}
