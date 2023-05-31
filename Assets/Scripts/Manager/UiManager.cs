using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MoreMountains.Feedbacks;
using DG.Tweening;
using TMPro;

public class UiManager : MonoBehaviour
{
    public static UiManager instance;

    public GameObject mainMenuUi;
    public GameObject gameUi;
    public GameObject endGameUi;
    public GameObject retryUi;

    public TMP_Text currentLevlText;

    public MMF_Player enableRetryFeedback;
    public MMF_Player disableRetryFeedback;
    public MMF_Player enableEndGameFeedback;
    public MMF_Player disableEndGameFeedback;

    private void Awake()
    {
        instance = this;

        //     DisableAllUi();
        //     EnableMainMenuUi();

        currentLevlText.text = "LEVEL " + GameManager.instance.CurrentLevel.ToString();
    }

    private void Start()
    {
    }

    private void Update()
    {
    }

    public void EnableGameUi()
    {
        //endGameUi.SetActive(false);
        mainMenuUi.SetActive(false);
        gameUi.SetActive(true);
    }

    public void EnableEndGameUi()
    {
        mainMenuUi.SetActive(false);
        gameUi.SetActive(false);
        endGameUi.SetActive(true);
        enableEndGameFeedback.PlayFeedbacks();
    }

    public void EnableRetryUi()
    {        
        mainMenuUi.SetActive(false);
        gameUi.SetActive(false);
        endGameUi.SetActive(false);
        retryUi.SetActive(true);
        enableRetryFeedback.PlayFeedbacks();
    }

    public void DisableAllUi()
    {
        mainMenuUi.SetActive(false);
        endGameUi.SetActive(false);
        gameUi.SetActive(false);
    }
}