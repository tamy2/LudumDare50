using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WordBank : MonoBehaviour
{
    private List<string> easyWords = new List<string>() {
        "call", "email", "contact", "promo", "award",
        "deal", "boss", "owner", "work", "fire", "cut",
        "bill", "cash", "money", "asset", "supply", "demand"
    };
    private List<string> mediumWords = new List<string>() {
        "schedule", "business", "contract", "present", "promote",
        "congrats", "manager", "company", "product", "produce",
        "employ", "director", "meeting", "capital", "invest",
        "balance", "documents", "revenue", "forecast", "impostor"
    };
    private List<string> hardWords = new List<string>() {
        "profitable", "lucrative", "presentation", "documentation",
        "promotional", "advertising", "campaign", "bankruptcy",
        "liquidity", "affordable", "coordinator", "manufacturing",
        "industrialization", "palletization", "reconnaissance"
    };

    /*
    private List<string> insaneWords = new List<string>() {
    };
    */

    private int iteration = 0;
    private List<string> workingWords = new List<string>();


    void Awake()
    {
        //iteration = 0;
        workingWords.AddRange(easyWords);
        Shuffle(workingWords);
        //ConverToLower(workingWords);
    }

    private void Shuffle(List<string> list) {
        for (int i = 0; i < list.Count; i++) {
            int random = Random.Range(i, list.Count);
            string temp = list[i];
            list[i] = list[random];
            list[random] = temp;
        }
    }

    public string GetWord() {
        string newWord = string.Empty;
        if (workingWords.Count != 0) {
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        } else {
            RenewWords();
            newWord = workingWords.Last();
            workingWords.Remove(newWord);
        }
        return newWord;
    }

    public void RenewWords() {
        if (iteration < 0) {
            workingWords.AddRange(easyWords);
        } else if (iteration < 1) {
            workingWords.AddRange(easyWords);
            workingWords.AddRange(mediumWords);
        } else if (iteration < 2) {
            workingWords.AddRange(mediumWords);
            workingWords.AddRange(hardWords);
        } else {
            workingWords.AddRange(hardWords);
        }
        Shuffle(workingWords);
        iteration++;
    }
}
