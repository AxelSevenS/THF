using System;
using System.Collections;
using System.Collections.Generic;
using SevenGame.Utility;
using TMPro;
using UnityEngine;

public sealed class GameManager : Singleton<GameManager>
{


    public AudioSource audioSource;

    [SerializeField] private Camera environmentCamera;
    [SerializeField] private Camera sliceCamera;

    [Header("Difficulty Menu")]

    [SerializeField] private GameObject _menuContainer;
    [SerializeField] private GameObject _easyOptionPrefab;
    [SerializeField] private GameObject _mediumOptionPrefab;
    [SerializeField] private GameObject _hardOptionPrefab;

    [Header("Difficulty-Specific Items")]

    [SerializeField] private GameObject[] _easyItems;
    [SerializeField] private GameObject[] _mediumItems;
    [SerializeField] private GameObject[] _hardItems;

    [SerializeField] private GameObject[] _bonusItems;
    [SerializeField] private GameObject[] _penaltyItems;

    [Header("Game Variables")]

    public int score = 0;
    public int lives = 3;


    private readonly Vector3 _menuPosition = new Vector3(22f,-9.7f,49f);
    private readonly Quaternion _menuRotation = Quaternion.Euler(-11f, 207f, 5.5f);
    private readonly Vector3 _gamePosition = new Vector3(0, 4.85f, 81f);
    private readonly Quaternion _gameRotation = Quaternion.Euler(9f, 172f, 0f);

    private GameDifficulty currentDifficulty = GameDifficulty.Easy;

    private Vector3 _targetPosition;
    private Quaternion _targetRotation;



    public void StartMenu()
    {
        Time.timeScale = 1f;

        ItemSpawner.current?.StopSpawning();

        _targetPosition = _menuPosition;
        _targetRotation = _menuRotation;

        Vector3 menuPosition = sliceCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        menuPosition.z = -1f;
        Instantiate(_easyOptionPrefab, _menuContainer.transform);
        Instantiate(_mediumOptionPrefab, _menuContainer.transform);
        Instantiate(_hardOptionPrefab, _menuContainer.transform);

        UIManager.current?.DisableGameUI();

        audioSource.Stop();
        
        ResetSliceables();
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        ItemSpawner.current?.StopSpawning();

        _targetPosition = _gamePosition;
        _targetRotation = _gameRotation;

        UIManager.current?.EnableGameUI();

        switch (currentDifficulty)
        {
            case GameDifficulty.Easy:
                EasyGame();
                break;
            case GameDifficulty.Medium:
                MediumGame();
                break;
            case GameDifficulty.Hard:
                HardGame();
                break;
        }

        lives = 3;
        UIManager.current?.UpdateLivesImmediate();

        score = 0;
        UIManager.current?.UpdateScore();

        audioSource.Play();

        ResetSliceables();

        void EasyGame()
        {
            ItemSpawner.current?.StartSpawning(1f, 0.1f, _easyItems, _bonusItems, _penaltyItems, 0.10f, 0.05f);
        }

        void MediumGame()
        {
            ItemSpawner.current?.StartSpawning(0.6f, 0.15f, _mediumItems, _bonusItems, _penaltyItems, 0.05f, 0.05f);
        }

        void HardGame()
        {
            ItemSpawner.current?.StartSpawning(0.35f, 0.3f, _hardItems, _bonusItems, _penaltyItems, 0.05f, 0.10f);
        }
    }

    private static void ResetSliceables()
    {
        Sliceable[] sliceables = SliceManager.sliceables.ToArray();
        foreach (Sliceable sliceable in sliceables)
        {
            GameUtility.SafeDestroy(sliceable.gameObject);
        }
    }

    public void StartGame(GameDifficulty difficulty)
    {
        Time.timeScale = 1f;

        currentDifficulty = difficulty;

        StartGame();
    }

    

    public void AddScore(int scoreToAdd, Vector3 position)
    {
        if ( scoreToAdd <= 0 )
        {
            // if the score is negative, spawn the effect at the center of the screen
            position = sliceCamera.ScreenToWorldPoint(new Vector3(Screen.width / 2f, Screen.height / 2f, 0f));
        }

        UIManager.current?.SpawnScoreEffect(position, scoreToAdd);
        score += scoreToAdd;
        UIManager.current?.UpdateScore();
    }

    public void ResetScore()
    {
        score = 0;
        UIManager.current?.UpdateScore();
    }

    public void AddLife(int amount = 1)
    {
        lives = Mathf.Clamp(lives + amount, 0, 3);
        UIManager.current?.UpdateLives();
    }

    public void RemoveLife(int amount = 1)
    {
        lives = Mathf.Clamp(lives - amount, 0, 3);
        UIManager.current?.UpdateLives();
        if ( lives <= 0 )
        {
            GameManager.current?.GameOver();
        }
    }

    public void GameOver()
    {
        UIManager.current?.DisplayGameOver();
    }

    public void EndGame()
    {
        UIManager.current?.DisplayGameWon();
    }

    public void RestartGame()
    {
        StartGame();
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



    public enum GameDifficulty
    {
        Easy,
        Medium,
        Hard
    }
}
