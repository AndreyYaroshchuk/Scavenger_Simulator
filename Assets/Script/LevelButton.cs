using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelButton : MonoBehaviour
{
    private const string SAVE_NUMBER_LEVEL = "numberLevel";
    private const string SAVE_LOAD_SCENE = "loadScene";


    public LevelName levelName;

    [SerializeField] private Button buttonLevel;
    [SerializeField] private Button buttonLevelHide; 
    [SerializeField] private TextMeshProUGUI textTime;
    [SerializeField] private GameObject imageTimer;
    [SerializeField] private List<Image> imageStarList;

    private int numberStar;

    public Button ButtonLevelHide { get => buttonLevelHide; set => buttonLevelHide = value; }
    public Button ButtonLevel { get => buttonLevel; set => buttonLevel = value; }

    private string test;
    private void Awake()
    {
        buttonLevel.enabled = false; 
        buttonLevelHide.enabled = false;
    }

    private void Start()
    {
        StartLevelIcon();
        ButtonLevel.onClick.AddListener(() =>
        {
            RestartLevel();

            //PlayerPrefs.SetString(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());

            SaveBridge.ES3Save(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.SaveAllData();
            SceneManager.LoadScene(1);

        });
        MainMenuUI.Instance.OnNewGame += MainMenuUI_OnNewGame;
    }
    private void StartLevelIcon()
    {
        numberStar = SaveLevel.Instan.GetSaveFileLevel(levelName);
        if (numberStar != 0)
        {

            buttonLevel.enabled = true;
            ButtonLevelHide.gameObject.SetActive(false);
            imageStarList[numberStar - 1].gameObject.SetActive(true);
        }
        //if (SaveLevel.Instan.GetSaveFileLevelString(levelName) != "" && SaveLevel.Instan.GetSaveFileLevelString(levelName) != "null" && SaveLevel.Instan.IsGetFile(levelName) == true)
        //{
        //    imageTimer.SetActive(true);
        //    textTime.text = SaveLevel.Instan.GetSaveFileLevelString(levelName);
        //}
    }
    private void MainMenuUI_OnNewGame(object sender, System.EventArgs e)
    {
        //numberStar = SaveLevel.Instan.GetSaveFileLevel(levelName);

        //if (numberStar == 0)
        //{

        //    buttonLevel.enabled = false;
        //    ButtonLevelHide.gameObject.SetActive(true);
        //    imageStarList[0].gameObject.SetActive(false);
        //    imageStarList[1].gameObject.SetActive(false);
        //    imageStarList[2].gameObject.SetActive(false);
        //    if (SaveLevel.Instan.GetSaveFileLevelString(levelName) != "" /*||*//* SaveLevel.Instan.IsGetFile(levelName) == false*/)
        //    {
        //        imageTimer.SetActive(false);
        //    }
        //}


        ////////////////////////////////////////////////////////////////
        //if (levelName == LevelName.Level_1)
        //{
        //    imageStarList[0].gameObject.SetActive(false);
        //    imageStarList[1].gameObject.SetActive(false);
        //    imageStarList[2].gameObject.SetActive(false);
        //}
        //else
        //{
        //    buttonLevel.enabled = false;
        //    ButtonLevelHide.gameObject.SetActive(true);
        //    imageStarList[0].gameObject.SetActive(false);
        //    imageStarList[1].gameObject.SetActive(false);
        //    imageStarList[2].gameObject.SetActive(false);
        //}

        if (levelName == LevelName.Level_1)
        {

            imageStarList[0].gameObject.SetActive(false);
            imageStarList[1].gameObject.SetActive(false);
            imageStarList[2].gameObject.SetActive(false);
            buttonLevelHide.gameObject.SetActive(false);
        }
        else
        {
            buttonLevel.enabled = false;
            ButtonLevelHide.gameObject.SetActive(true);
            imageStarList[0].gameObject.SetActive(false);
            imageStarList[1].gameObject.SetActive(false);
            imageStarList[2].gameObject.SetActive(false);
        }
    }

    private void RestartLevel()
    {
        switch (levelName)
        {
            case LevelName.Level_1:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 1);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 1);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_2:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 2);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 2);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_3:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 3);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 3);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_4:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 4);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 4);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_5:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 5);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 5);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_6:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 6);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 6);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_7:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 7);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 7);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_8:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 8);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 8);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_9:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 9);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 9);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_10:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 10);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 10);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_11:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 11);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 11);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_12:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 12);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 12);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_13:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 13);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 13);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_14:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 14);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 14);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_15:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 15);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 15);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_16:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 16);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 16);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_17:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 17);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 17);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_18:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 18);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 18);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_19:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 19);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 19);
                SaveBridge.SaveAllData();
                return;
            case LevelName.Level_20:
                //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, 20);
                SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 20);
                SaveBridge.SaveAllData();
                return;
        }
    }
    public int GetNumberStar()
    {
        return numberStar;
    }

}
