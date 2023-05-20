using System;
using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using TMPro;
using UnityEngine;

public sealed class GameManager : Singleton<GameManager>
{

    [SerializeField] private Camera environmentCamera;
    [SerializeField] private Camera sliceCamera;

    [SerializeField] private TextMeshProUGUI scoreText;

    [SerializeField] private GameObject _menuPrefab;

    [SerializeField] private GameObject[] _easyItems;
    [SerializeField] private GameObject[] _mediumItems;
    [SerializeField] private GameObject[] _hardItems;

    public int score = 0;
    public int lives = 3;


    private readonly Vector3 _menuPosition = new Vector3(22f,-9.7f,49f);
    private readonly Quaternion _menuRotation = Quaternion.Euler(-11f, 207f, 5.5f);
    private readonly Vector3 _gamePosition = new Vector3(0, 4.85f, 81f);
    private readonly Quaternion _gameRotation = Quaternion.Euler(9f, 172f, 0f);

    private Vector3 _targetPosition;
    private Quaternion _targetRotation;


    public void StartMenu() {
        _targetPosition = _menuPosition;
        _targetRotation = _menuRotation;

        Vector3 menuPosition = sliceCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        menuPosition.z = -1f;
        Instantiate(_menuPrefab, menuPosition, Quaternion.identity);

        UIManager.current?.DisableGameUI();
    }

    public void StartGame()
    {
        _targetPosition = _gamePosition;
        _targetRotation = _gameRotation;

        ItemSpawner.current?.StartSpawning(4f, 0.1f, _easyItems);

        UIManager.current?.EnableGameUI();
    }

    

    public void AddScore(int scoreToAdd, Vector3 position)
    {
        UIManager.current?.SpawnScoreEffect(position, scoreToAdd);
        score += scoreToAdd;
        UIManager.current?.UpdateScore();
    }

    public void ResetScore()
    {
        score = 0;
        UIManager.current?.UpdateScore();
    }

    public void RemoveLife()
    {
        Debug.Log("Remove Life");
    }

    public void GameOver()
    {
        Debug.Log("Game Over");
    }

    public void EndGame()
    {
        Debug.Log("End Game");
    }

    public void RestartGame()
    {
        Debug.Log("Restart Game");
    }


    private void Start() 
    {
        StartMenu();
    }

    private void Update()
    {
        environmentCamera.transform.position = Vector3.Lerp(environmentCamera.transform.position, _targetPosition, Time.deltaTime * 2f);
        environmentCamera.transform.rotation = Quaternion.Lerp(environmentCamera.transform.rotation, _targetRotation, Time.deltaTime * 2f);
    }

    private void OnEnable()
    {
        SetCurrent();
        score = 0;
    }
}
