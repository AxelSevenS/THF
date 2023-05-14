using System;
using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using TMPro;
using UnityEngine;

public sealed class GameManager : Singleton<GameManager>
{

    [SerializeField] private TextMeshProUGUI scoreText;

    public int score = 0;

    

    public void AddScore(int scoreToAdd, Vector3 position)
    {
        UIManager.current?.SpawnScoreEffect(position, scoreToAdd);
        score += scoreToAdd;
        UIManager.current?.UpdateScore(score);
    }

    public void ResetScore()
    {
        score = 0;
        UIManager.current?.UpdateScore(0);
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
    }
    

    private void OnEnable()
    {
        SetCurrent();
        score = 0;
    }
}
