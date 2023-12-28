using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public enum StartGame { StartScene, StartMenuScene, StartGameScene }
public class LoadScene : MonoBehaviour
{
    public static LoadScene Instance { get; private set; }

    private const string SAVE_LOAD_SCENE = "loadScene";

    [SerializeField] private Image imageFilled;
    private StartGame startGame;
    private AsyncOperation loadingScene;
    private string saveLoadString;


    private void Awake()
    {
        Instance = this;
        if (SaveBridge.ES3KeyExists(SAVE_LOAD_SCENE) == false)
        {
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, "StartMenuScene");
        }
    }
    private void Start()
    {
        saveLoadString = SaveBridge.ES3Load(SAVE_LOAD_SCENE, saveLoadString);
        if (saveLoadString == "")
        {
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, "StartMenuScene");
            saveLoadString = SaveBridge.ES3Load(SAVE_LOAD_SCENE, saveLoadString);
        }
        if (saveLoadString == "StartMenuScene")
        {
            loadingScene = SceneManager.LoadSceneAsync("MenuScenes");
            loadingScene.allowSceneActivation = false;
        }
        if (saveLoadString == "StartGameScene")
        {
            loadingScene = SceneManager.LoadSceneAsync("GameScene");
            loadingScene.allowSceneActivation = false;

        }
    }
    private void Update()
    {
        imageFilled.fillAmount = loadingScene.progress/*Mathf.RoundToInt(loadingScene.progress * 100).ToString() + " %"*/;
        if (loadingScene.isDone == false)
        {
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, "");
            SaveBridge.SaveAllData();
            loadingScene.allowSceneActivation = true;
        }
    }
}
