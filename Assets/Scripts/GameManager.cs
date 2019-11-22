using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameoverPanel;
    [SerializeField] GameObject startLogos;
    [SerializeField] Osori osori;
    [SerializeField] Text scoreText;
    [SerializeField] GameObject pipes;
    [SerializeField] FlashImage flashImage;
    int score;
    enum State
    {
        READY, PLAY, OVER
    }

    State state;

    private void Start()
    {
        startLogos.SetActive(true);
        pipes.SetActive(false);
        state = State.READY;
        osori.SetKinematic(true);
        gameoverPanel.SetActive(false);
    }
    public void IncreaseScore()
    {
        score++;
        scoreText.text = "Score: " + score.ToString();
    }
    void Update()
    {
        switch (state)
        {
            case State.READY:
                if (Input.GetButtonDown("Fire1"))
                {
                    GameStart();
                }
                break;
            case State.PLAY:
                if (osori.IsDead) GameOver();
                break;
            case State.OVER:
                if(Input.GetButtonDown("Fire1"))
                {
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                }
                break;
        }
    }
    void GameOver()
    {
        state = State.OVER;
        ScrollObject[] scrollObjects = GameObject.FindObjectsOfType<ScrollObject>();
        foreach (ScrollObject scrollObject in scrollObjects)
        {
            scrollObject.enabled = false;
        }
        flashImage.StartFlash();
    }
    void GameStart()
    {
        scoreText.gameObject.SetActive(true);
        scoreText.text = "Score:  ";
        startLogos.SetActive(false);
        state = State.PLAY;
        osori.SetKinematic(false);
        pipes.SetActive(true);
    }
}

