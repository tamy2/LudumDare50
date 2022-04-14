using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SequencingManager : MonoBehaviour
{
    public static SequencingManager instance;
    public static bool isGameRunning;
    //public SpriteRenderer overlay;
    public Animator menuAnimator;
    public Animator gameUIAnimator;
    public float timeAlive;
    public TextMeshProUGUI timerReadout;
    public TextMeshProUGUI finalTimerReadout;
    private bool gameOver;

    void Awake()
    {
        instance = this;

    }

    // Start is called before the first frame update
    void Start()
    {
        isGameRunning = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isGameRunning && Input.GetKeyDown(KeyCode.Space)) {
            StartGame();
        }

        if (!gameOver && isGameRunning) {
            timeAlive += Time.deltaTime;
            //timerReadout.text = timeAlive.ToString("F2");
            //finalTimerReadout.text = timeAlive.ToString("F2");
        }

        if (gameOver && Input.GetKeyDown(KeyCode.R)) {
            //Application.LoadLevel(Application.loadedLevel);
            SceneManager.LoadScene("Game");
        }
    }

    void StartGame() {
        isGameRunning = true;
        gameOver = false;
        menuAnimator.SetBool("spacePressed", true);
        //overlay.enabled = false;
        //menuAnimator.SetTrigger("MoveOut");
        //gameUIAnimator.SetTrigger("Show");
    }

    public void End() {
        if (gameOver) {
            return;
        }
        isGameRunning = false;
        //gameUIAnimator.SetTrigger("Game Over");
        gameOver = true;
    }
}
