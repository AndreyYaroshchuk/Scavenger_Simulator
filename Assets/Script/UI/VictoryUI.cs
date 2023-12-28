using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryUI : MonoBehaviour
{
    private const string SAVE_BOOLEAN_LEVEL = "booleanLevel";
    private const string SAVE_LOAD_SCENE = "loadScene";
    private const string ANIMATION_SET_TRIGGER = "move";
    private const string SAVE_NUMBER_LEVEL = "numberLevel";

    [SerializeField] private Animator animator; 
    [SerializeField] private Button buttonMainMenu;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonNext;
    [SerializeField] private TextMeshProUGUI levelText;
    [SerializeField] private SpawnLevel spawnLevel;
    [SerializeField] private GameObject levelGameObjectUI;
    [SerializeField] private GameObject buttonAllGameObject;



    [SerializeField] private List<Image> imageList;

    public float timeLeft;

    public bool isPlay;
    private bool isShowVictoryUI = false;
    private bool stopAnimation = false;

    private int numberLevel;
    private void Start()
    {
        gameObject.SetActive(false);
        buttonAllGameObject.SetActive(false);
        spawnLevel.OnVictory += SpawnLevel_OnVictory;

        if(SaveBridge.ES3Load(SAVE_NUMBER_LEVEL, numberLevel) >= 21)
        {
            buttonNext.gameObject.SetActive(false);
        }

        buttonMainMenu.onClick.AddListener(() =>
        {
            //PlayerPrefs.SetString(SAVE_LOAD_SCENE, StartGame.StartMenuScene.ToString());
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, StartGame.StartMenuScene.ToString());
            SaveBridge.SaveAllData();
            SceneManager.LoadScene(1);
        });
        buttonRestart.onClick.AddListener(() =>
        {
            //PlayerPrefs.SetString(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.ES3Save(SAVE_BOOLEAN_LEVEL, 1);
            SaveBridge.SaveAllData();
            SceneManager.LoadScene(1);
            //PlayerPrefs.SetInt(SAVE_BOOLEAN_LEVEL, 1);
        });
        buttonNext.onClick.AddListener(() =>
        {
            //PlayerPrefs.SetString(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.SaveAllData();
            SceneManager.LoadScene(1);
        });
        buttonMainMenu.Select();
    }
    
    private void Update()
    {
        isShowVictoryUI = true;  
        Invoke("MoveLevelUI", 1f);
       
    }
    private void SpawnLevel_OnVictory(object sender, System.EventArgs e)
    {
        levelText.text = spawnLevel.GetNumberLevel().ToString();
        for (int i = 0; i < spawnLevel.GetStarsScore(); i++)
        {
            imageList[i].gameObject.SetActive(true);
        }
    }
    private void MoveLevelUI()
    {
        if(stopAnimation == false)
        {
            animator.SetTrigger(ANIMATION_SET_TRIGGER);
            buttonAllGameObject.SetActive(true);
            stopAnimation = true;
        }
       
    }
    public bool IsShowVictoryUI()
    {
        return isShowVictoryUI;
    }

}
