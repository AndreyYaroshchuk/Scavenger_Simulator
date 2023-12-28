using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PausedMenuUI : MonoBehaviour
{
    private const string SAVE_LOAD_SCENE = "loadScene";

    public event EventHandler OnClickButton;
    public event EventHandler OnClickButtonContinue;
    public event EventHandler OnClickExitPausedMenu;


    [SerializeField] private GameSceneUI gameSceneUI;
    [SerializeField] private Button buttonContinue;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonNextControls;
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private SettingsUI settingsUI;
    [SerializeField] private ButtonFX buttonFX;
    
    private bool isOpenSettings = false;
    private bool isOpenControls = false;
    private bool isClickSetting = false;

    public bool IsClickSetting { get => isClickSetting; set => isClickSetting = value; }

    private void Start()
    {
        gameObject.SetActive(false);
        gameSceneUI.OnClickPauseMenu += GameSceneUI_OnClickPauseMenu;
        buttonContinue.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            gameObject.SetActive(false);
            settingsUI.SaveVolueAudio();
            OnClickButtonContinue?.Invoke(this, EventArgs.Empty);
          
        });
        buttonNewGame.onClick.AddListener(() =>
        {
            Time.timeScale = 1f;
            settingsUI.SaveVolueAudio();
            //PlayerPrefs.SetString(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, StartGame.StartMenuScene.ToString());
            SaveBridge.SaveAllData();
            SceneManager.LoadScene(1);
        });
        buttonSettings.onClick.AddListener(() =>
        {
            Time.timeScale = 0f;
            
            isOpenSettings = true;
            IsClickSetting = true; 
            OnClickButton?.Invoke(this, EventArgs.Empty);
            settingsUI.gameObject.SetActive(true);
            settingsUI.IsShow = true;
            
        });
        buttonNextControls.onClick.AddListener(() =>
        {
            Time.timeScale = 0f;
            isOpenControls = true;
            buttonContinue.enabled = false;
            buttonNewGame.enabled = false;
            buttonSettings.enabled = false;
            buttonNextControls.enabled = false;
            controlsUI.SetActive(true);

        });
    }
    private void Update()
    {
        if(ReInput.players.GetPlayer(0).GetButtonDown("Button B") && isOpenSettings == true)
        { 
            isOpenSettings = false;
            buttonContinue.enabled = true;
            buttonNewGame.enabled = true;
            buttonSettings.enabled = true;
            buttonNextControls.enabled = true;
            buttonContinue.Select();
            settingsUI.gameObject.SetActive(false);
            settingsUI.IsShow = false;
            buttonFX.SaveVolueAudio();
        }
        else if (ReInput.players.GetPlayer(0).GetButtonDown("Button B") && isOpenControls == true)
        {
            isOpenControls = false;
            buttonContinue.enabled = true;
            buttonNewGame.enabled = true;
            buttonSettings.enabled = true;
            buttonNextControls.enabled = true;
            buttonContinue.Select();
            controlsUI.SetActive(false);
        }
         else if (ReInput.players.GetPlayer(0).GetButtonDown("Button B") && isOpenSettings == false && isOpenControls == false)
        {
            Time.timeScale = 1f;
            buttonContinue.enabled = true;
            buttonNewGame.enabled = true;
            buttonSettings.enabled = true;
            buttonNextControls.enabled = true;

            controlsUI.SetActive(false);
            settingsUI.gameObject.SetActive(false);
            gameObject.SetActive(false);
            settingsUI.SaveVolueAudio();
            settingsUI.IsShow = false;
            OnClickExitPausedMenu?.Invoke(this, EventArgs.Empty);
        }
       
    }
    private void GameSceneUI_OnClickPauseMenu(object sender, System.EventArgs e)
    {
        buttonContinue.Select();
    }
}
