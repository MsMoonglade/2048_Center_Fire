using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public GameObject levelParent;

    public GameObject[] gameLevel;

    private void Awake()
    {
        instance = this;

        GenerateLevel();
    }

    private void GenerateLevel()
    {
        int currentLevel = GameManager.instance.CurrentLevel;

        if (currentLevel < gameLevel.Length)
        {
            Debug.Log("Normal");
            Instantiate(gameLevel[currentLevel - 1], Vector3.zero, Quaternion.identity, levelParent.transform);
        }
        else
        {
            Debug.Log("Ext");
            Instantiate(gameLevel[gameLevel.Length -1], Vector3.zero, Quaternion.identity, levelParent.transform);
        }
    }
}