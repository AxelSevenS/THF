using System;
using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using TMPro;
using UnityEngine;

[DefaultExecutionOrder(10)]
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

        if (scoreToAdd < 0)
            incrementText.color = Color.red;
        else
            incrementText.color = Color.green;

        incrementText.text = scoreToAdd < 0 ? $"- {Mathf.Abs(scoreToAdd)}" : $"+ {scoreToAdd}";
    }


    public void EnableGameUI()
    {
        scoreUI.SetActive(true);
    }

    public void DisableGameUI()
    {
        scoreUI.SetActive(false);
    }

    public void UpdateScore()
    {
        scoreText.text = $"Score: {GameManager.current.score}";
    }

    public void UpdateLife()
    {

    }

    private void OnEnable()
    {
        SetCurrent();
        UpdateScore();
        EnableGameUI();
    }

    private void Start()
    {
    }
}
