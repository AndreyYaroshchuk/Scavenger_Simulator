using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenuUI : MonoBehaviour
{
    private const string SAVE_NUMBER_LEVEL = "numberLevel";


    public static MainMenuUI Instance;
    public event EventHandler OnNewGame;
    public event EventHandler OnClickButton;
    public event EventHandler OnClickButtonSettings;

    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonNewGame;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonControls;

    [SerializeField] private Button buttonYesclearFileUI;

    [SerializeField] private SettingsUI settingsUI;
    [SerializeField] private GameObject controlsUI;
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private ClearFileUI clearFileUI;
    [SerializeField] private ButtonFX buttonFX;


    private bool isOpenControls = false;
    private bool isOpenMainMenu = true;
    private bool isClickSetting = false;
    private bool isOpenCkearFileUI = false;
    private bool isNevGame = false;
    private bool isClickYes = false;

    public bool IsClickSetting { get => isClickSetting; set => isClickSetting = value; }
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        if (SaveBridge.ES3KeyExists(SAVE_NUMBER_LEVEL) == true)
        {
            buttonPlay.gameObject.SetActive(true);
            buttonPlay.Select();
            buttonPlay.onClick.AddListener(() =>
            {
                levelUI.gameObject.SetActive(true);
                settingsUI.SaveVolueAudio();
                OnClickButton?.Invoke(this, EventArgs.Empty);
                isOpenMainMenu = false;
            });
        }
        else
        {
            buttonPlay.gameObject.SetActive(false);
            settingsUI.SaveVolueAudio();
            buttonNewGame.Select();
        }
        if (SaveBridge.ES3KeyExists(SAVE_NUMBER_LEVEL) == true)
        {
            buttonNewGame.onClick.AddListener(() =>
        {
            if (clearFileUI != null)
            {
                isOpenCkearFileUI = true;
                buttonPlay.enabled = false;
                buttonNewGame.enabled = false;
                buttonSettings.enabled = false;
                buttonControls.enabled = false;
                clearFileUI.gameObject.SetActive(true);
                buttonYesclearFileUI.Select();
                settingsUI.SaveVolueAudio();
                isNevGame = true;
            }
            else
            {
                isOpenMainMenu = false;
                SaveBridge.DeleteAllData();
                OnNewGame?.Invoke(this, EventArgs.Empty);
                OnClickButton?.Invoke(this, EventArgs.Empty);
                levelUI.gameObject.SetActive(true);
                settingsUI.SaveVolueAudio();
            }
        });
        }
        else
        {
            buttonNewGame.onClick.AddListener(() =>
            {
                isOpenMainMenu = false;
                SaveBridge.DeleteAllData();
                OnNewGame?.Invoke(this, EventArgs.Empty);
                OnClickButton?.Invoke(this, EventArgs.Empty);
                levelUI.gameObject.SetActive(true);
                settingsUI.SaveVolueAudio();

            });
        }
        buttonSettings.onClick.AddListener(() =>
        {
            isOpenMainMenu = false;
            IsClickSetting = true;
            OnClickButtonSettings?.Invoke(this, EventArgs.Empty);
            settingsUI.gameObject.SetActive(true);
        });
        buttonControls.onClick.AddListener(() =>
        {
            isOpenMainMenu = false;
            controlsUI.gameObject.SetActive(true);
            buttonPlay.enabled = false;
            buttonNewGame.enabled = false;
            buttonSettings.enabled = false;
            buttonControls.enabled = false;
            isOpenControls = true;
        });

        clearFileUI.OnClickButtonYes += ClearFileUI_OnClickButtonYes;
        clearFileUI.OnClickButtonNo += ClearFileUI_OnClickButtonNo;
    }

    private void ClearFileUI_OnClickButtonNo(object sender, EventArgs e)
    {
        buttonPlay.enabled = true;
        buttonNewGame.enabled = true;
        buttonSettings.enabled = true;
        buttonControls.enabled = true;
        buttonPlay.Select();
    }

    private void ClearFileUI_OnClickButtonYes(object sender, EventArgs e)
    {
        isClickYes = true;
        isOpenMainMenu = false;
        SaveBridge.DeleteAllData();
        buttonFX.SaveVolueAudio();
        OnNewGame?.Invoke(this, EventArgs.Empty);
        OnClickButton?.Invoke(this, EventArgs.Empty);
        levelUI.gameObject.SetActive(true);
    }

    private void Update()
    {
        if (ReInput.players.GetPlayer(0).GetButtonDown("Button B") && isOpenControls == false && isOpenMainMenu == false)
        {
            buttonPlay.enabled = true;
            buttonNewGame.enabled = true;
            buttonSettings.enabled = true;
            buttonControls.enabled = true;
            settingsUI.SaveVolueAudio();
            levelUI.gameObject.SetActive(false);
            settingsUI.gameObject.SetActive(false);
            controlsUI.gameObject.SetActive(false);
            isOpenMainMenu = true;
            buttonNewGame.Select();

        }
        else if (ReInput.players.GetPlayer(0).GetButtonDown("Button B") && isOpenControls == true)
        {

            buttonPlay.enabled = true;
            buttonNewGame.enabled = true;
            buttonSettings.enabled = true;
            buttonControls.enabled = true;
            buttonPlay.Select();
            settingsUI.SaveVolueAudio();
            levelUI.gameObject.SetActive(false);
            settingsUI.gameObject.SetActive(false);
            controlsUI.gameObject.SetActive(false);
            isOpenControls = false;
            isOpenMainMenu = true;
        }
        if (ReInput.players.GetPlayer(0).GetButtonDown("Button B") && SaveBridge.ES3KeyExists(SAVE_NUMBER_LEVEL) == false)
        {
            buttonNewGame.Select();
        }
        if (ReInput.players.GetPlayer(0).GetButtonDown("Button B") && isOpenCkearFileUI == true)
        {
            clearFileUI.gameObject.SetActive(false);
            isOpenCkearFileUI = false;
            buttonPlay.enabled = true;
            buttonNewGame.enabled = true;
            buttonSettings.enabled = true;
            buttonControls.enabled = true;
            buttonPlay.Select();
        }
        if (ReInput.players.GetPlayer(0).GetButtonDown("Button B") && isNevGame == true)
        {
            if ( isClickYes == true)
            {
                Destroy(clearFileUI);
                buttonPlay.gameObject.SetActive(false);
                isClickYes = false;  
            }
            buttonNewGame.enabled = true;
            buttonSettings.enabled = true;
            buttonControls.enabled = true;
            buttonNewGame.Select();
            isNevGame = false;
        }
    }

}

//buttonNewGame.onClick.AddListener(() =>
//{
//    //PlayerPrefs.DeleteAll();
//    isOpenMainMenu = false;
//    SaveBridge.DeleteAllData();
//    OnNewGame?.Invoke(this, EventArgs.Empty);
//    OnClickButton?.Invoke(this, EventArgs.Empty);
//    levelUI.gameObject.SetActive(true);
//});