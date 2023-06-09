﻿using MoreMountains.Tools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public ParticleSystem winParticle;

    [HideInInspector]
    public GameStatus gameStatus;

    private int currentLevel;

    public int CurrentLevel
    {
        get
        {
            return currentLevel;
        }

        set
        {
            currentLevel = value;
            PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        }
    }

    private void Awake()
    {
        instance = this;

        SetInMenu();

        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;

        //currentLevel set
        if (PlayerPrefs.HasKey("CurrentLevel"))
            CurrentLevel = PlayerPrefs.GetInt("CurrentLevel");
        else
        {
            CurrentLevel = 1;
            PlayerPrefs.SetInt("CurrentLevel", CurrentLevel);
        }
    }

    private void OnEnable()
    {
        EventManager.StartListening(Events.endGame , EndGame);
        EventManager.StartListening(Events.die, OnCharacterDie);
    }

    private void OnDisable()
    {
        EventManager.StopListening(Events.endGame, EndGame);
        EventManager.StopListening(Events.die, OnCharacterDie);
    }

    public bool LevelPassed()
    {    
        return false;
    }

    public void ResetScore()
    {
    }

    public void StartGame()
    {
        SetInGame();

        UiManager.instance.EnableGameUi();
        EventManager.TriggerEvent(Events.playGame);

        //LevelManager.instance.GenerateLevel(CurrentLevel);
    }

    public void EndGame(object sender)
    {
        CurrentLevel = CurrentLevel + 1;

        SetInMenu();

        UiManager.instance.EnableEndGameUi();
    }

    public void OnCharacterDie(object sender)
    {
        gameStatus = GameStatus.InRestart;
        UiManager.instance.EnableRetryUi();
    }

    public void RestartGame()
    {        
        SceneManager.LoadScene(1);
    }

    public void SetInGame()
    {
        gameStatus = GameStatus.InGame;
    }

    public void SetInMenu()
    {
        gameStatus = GameStatus.InMenu;
    }

    public bool IsInGameStatus()
    {
        if (gameStatus == GameStatus.InGame)
            return true;

        else
            return false;
    }

    public void DeleteAllSave()
    {
        PlayerPrefs.DeleteAll();

        RestartGame();
    }

    public void OnApplicationQuit()
    {
    }
}

public enum GameStatus
{
    InGame,
    InMenu,
    InRestart
}