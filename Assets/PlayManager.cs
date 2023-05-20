using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class PlayManager : MonoBehaviour
{
    [SerializeField] GameObject finishedCanvas;
    [SerializeField] GameObject nextLevelButton;
    [SerializeField] TMP_Text finishedText;
    [SerializeField] TMP_Text scoreText; 
    [SerializeField] CustomEvent gameOverEvent;
    [SerializeField] CustomEvent playerWinEvent;
    
    public UnityEvent<int> OnCoinChange = new UnityEvent<int>();
    int coin;

    private void OnEnable()
    {
        gameOverEvent.OnInvoked.AddListener(GameOver);
        playerWinEvent.OnInvoked.AddListener(PlayerWin);
    }

    private void OnDisable()
    {
        gameOverEvent.OnInvoked.RemoveListener(GameOver);
        playerWinEvent.OnInvoked.RemoveListener(PlayerWin);
    }

    public void GameOver()
    {
        finishedText.text = "Game Over";
        nextLevelButton.SetActive(false);
        finishedCanvas.SetActive(true);
    }

    public void PlayerWin()
    {
        finishedText.text = "You Win\nScore: " + GetScore();
        finishedCanvas.SetActive(true);
    }

    private int GetScore()
    {
        return coin * 10;
    }

    public void AddCoin(int value)
    {
        coin += value;
        OnCoinChange.Invoke(GetScore());
    }
    
    public void UpdateScoreText(int value)
    {
        scoreText.text = "Score: " + value;
    }
}
