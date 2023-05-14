using System;
using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using TMPro;
using UnityEngine;

public sealed class UIManager : Singleton<UIManager>
{

    [SerializeField] private Camera camera;

    [SerializeField] private GameObject scoreUI;
    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject scoreIncrementEffect;


    public void SpawnScoreEffect(Vector3 position, int scoreToAdd)
    {
        if (scoreIncrementEffect == null)
            return;

        GameObject incrementEffect = Instantiate(scoreIncrementEffect, camera.WorldToScreenPoint(position), Quaternion.identity, UIManager.current.transform);
        TextMeshProUGUI incrementText = incrementEffect.GetComponent<TextMeshProUGUI>();


        if (incrementText == null)
            return;

        incrementText.text = Math.Sign(scoreToAdd) < 0 ? $"- {scoreToAdd}" : $"+ {scoreToAdd}";
    }


    public void EnableGameUI()
    {
        scoreUI.SetActive(true);
    }

    public void DisableGameUI()
    {
        scoreUI.SetActive(false);
    }

    public void UpdateScore(int score)
    {
        scoreText.text = $"Score: {score}";
    }

    private void OnEnable()
    {
        SetCurrent();
        UpdateScore(0);
        EnableGameUI();
    }
}