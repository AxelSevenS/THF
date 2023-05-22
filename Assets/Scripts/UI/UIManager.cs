using System;
using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[DefaultExecutionOrder(10)]
public sealed class UIManager : Singleton<UIManager>
{

    [SerializeField] private Camera camera;

    [Header(header: "Score Effects")]

    [SerializeField] private GameObject scoreUI;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject scoreIncrementEffect;

    [Header("Lives Effects")]

    [SerializeField] private GameObject livesUI;
    [SerializeField] private LifeUI life1UI;
    [SerializeField] private LifeUI life2UI;
    [SerializeField] private LifeUI life3UI;

    [Header("Pause Effects")]
    
    [SerializeField] private GameObject pauseUI;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button volumeButton;

    [Header("End Game Effects")]

    [SerializeField] private GameObject endGameUI;
    [SerializeField] private TextMeshProUGUI titleText;
    [SerializeField] private TextMeshProUGUI endGameScoreText;

    [SerializeField] private Button restartButton;
    [SerializeField] private Button mainMenuButton;



    public void DisplayGameOver()
    {
        endGameUI.SetActive(true);
        titleText.text = "Game Over";
        endGameScoreText.text = $"Score: {GameManager.current.score}";
        Time.timeScale = 0f;

        DisablePause();
        VolumeManager.current.DisableVolumeMenu();
    }

    public void DisplayGameWon()
    {
        endGameUI.SetActive(true);
        titleText.text = "You Won!";
        endGameScoreText.text = $"Score: {GameManager.current.score}";
        Time.timeScale = 0f;

        DisablePause();
        VolumeManager.current.DisableVolumeMenu();
    }

    public void EnablePause()
    {
        Time.timeScale = 0f;
        pauseUI.SetActive(true);
    }

    public void DisablePause()
    {
        Time.timeScale = 1f;
        pauseUI.SetActive(false);
        VolumeManager.current.DisableVolumeMenu();
    }

    public void TogglePause()
    {
        if ( pauseUI.activeSelf ){
            DisablePause();
        }
        else
        {
            EnablePause();
        }
    }


    public void SpawnScoreEffect(Vector3 position, int scoreToAdd)
    {
        if (scoreIncrementEffect == null)
            return;

        GameObject incrementEffect = Instantiate(scoreIncrementEffect, camera.WorldToScreenPoint(position), Quaternion.identity, UIManager.current.transform);
        TextMeshProUGUI incrementText = incrementEffect.GetComponent<TextMeshProUGUI>();


        if (incrementText == null)
            return;

        if (scoreToAdd < 0)
            incrementText.color = Color.red;
        else
            incrementText.color = Color.green;

        incrementText.text = scoreToAdd < 0 ? $"- {Mathf.Abs(scoreToAdd)}" : $"+ {scoreToAdd}";
    }


    public void EnableGameUI()
    {
        scoreUI.SetActive(true);
        livesUI.SetActive(true);
        pauseButton.gameObject.SetActive(true);
        volumeButton.gameObject.SetActive(false);
        endGameUI.SetActive(false);
    }

    public void DisableGameUI()
    {
        scoreUI.SetActive(false);
        livesUI.SetActive(false);
        pauseButton.gameObject.SetActive(false);
        volumeButton.gameObject.SetActive(true);
        endGameUI.SetActive(false);
    }

    public void UpdateScore()
    {
        scoreText.text = $"Score: {GameManager.current.score}";
    }

    public void UpdateLives()
    {
        int lives = GameManager.current?.lives ?? 0;
        if (lives < 3)
            life1UI?.RemoveLife();

        if (lives < 2)
            life2UI?.RemoveLife();

        if (lives < 1)
            life3UI?.RemoveLife();
    }

    public void UpdateLivesImmediate()
    {
        life1UI.GiveLifeImmediate();
        life2UI.GiveLifeImmediate();
        life3UI.GiveLifeImmediate();

        UpdateLives();
    }

    private void OnEnable()
    {
        SetCurrent();
        UpdateScore();
        EnableGameUI();
    }
}
