using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnLevel : MonoBehaviour
{
    private const string SAVE_NUMBER_LEVEL = "numberLevel";
    private const string SAVE_BOOLEAN_LEVEL = "booleanLevel";

    public event EventHandler OnVictory;

    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private PausedMenuUI pausedMenuUI;
    [SerializeField] private List<ButtonIcon> listButtonIcon;
    [SerializeField] private Transform sceneUI;
    [SerializeField] private ManagerButtonIcon managerButton;
    [SerializeField] private GameObject SpawnGameObject;  
    
    [SerializeField] private List<SceneLevelUI> sceneLevelUIs;

    public List<ButtonIcon> listSpawnButtonIcons;

    private int numberLevel = 1;
    private int starsScore = 3; // звезды победы

    private int starsScoreNumber_1 = 0;
    private int starsScoreNumber_2 = 0;
    private int starsScoreNumber_3 = 0;

    private int saveNumber;

    public bool clearPrlayerPrefs = false;
    private bool stopGridLayoutGroup = false;


    public List<ButtonIcon> ListSpawnButtonIcons { get => listSpawnButtonIcons; set => listSpawnButtonIcons = value; }
    public GridLayoutGroup GridLayoutGroup { get => gridLayoutGroup; set => gridLayoutGroup = value; }

    private void Awake()
    {
        //if (PlayerPrefs.GetInt(SAVE_NUMBER_LEVEL) == 0)
        //{
        //    PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, numberLevel);
        //}
        //if (PlayerPrefs.GetInt(SAVE_BOOLEAN_LEVEL) == 1)
        //{
        //    PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, PlayerPrefs.GetInt(SAVE_NUMBER_LEVEL) - 1);
        //    PlayerPrefs.SetInt(SAVE_BOOLEAN_LEVEL, 0);
        //}
        //numberLevel = PlayerPrefs.GetInt(SAVE_NUMBER_LEVEL);
        if (SaveBridge.ES3KeyExists(SAVE_BOOLEAN_LEVEL) == false)
        {
            SaveBridge.ES3Save(SAVE_BOOLEAN_LEVEL, 0);
        }
        if (SaveBridge.ES3KeyExists(SAVE_NUMBER_LEVEL) == false)
        {
            SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, 1);
        }
        if (SaveBridge.ES3Load(SAVE_BOOLEAN_LEVEL, saveNumber) == 1)
        {
            SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, SaveBridge.ES3Load(SAVE_NUMBER_LEVEL, saveNumber) - 1);
            SaveBridge.ES3Save(SAVE_BOOLEAN_LEVEL, 0);
            SaveBridge.SaveAllData();
        }
        numberLevel = SaveBridge.ES3Load(SAVE_NUMBER_LEVEL, numberLevel);
        if(numberLevel >= 20)
        {
            numberLevel = 20;
            SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, numberLevel);
            SaveBridge.SaveAllData();
        }

    }

    private void Start()
    {
        managerButton.OnEnabledButton += ManagerButton_OnEnabledButton;
        managerButton.OnDestroyButton += ManagerButton_OnDestroyButton;
        pausedMenuUI.OnClickButtonContinue += PausedMenuUI_OnClickButtonContinue;
        pausedMenuUI.OnClickExitPausedMenu += PausedMenuUI_OnClickExitPausedMenu;
        ListSpawnButtonIcons = new List<ButtonIcon>();
        RestartLevel();
        RestartLevelMore10();
        StartScoreNumber();
        SpawnGameObject.SetActive(false);

    }

    private void PausedMenuUI_OnClickExitPausedMenu(object sender, EventArgs e)
    {
        for (int i = 0; i < listSpawnButtonIcons.Count; i++)
        {
            if (listSpawnButtonIcons[i].Index != 0 && listSpawnButtonIcons[i].IsSelectButton == false)
            {
                listSpawnButtonIcons[i].ButtonsIcons.Select();
                return;
            }

        }
    }

    private void Update()
    {
        if (isVictory() && clearPrlayerPrefs == false)
        {
            //PlayerPrefs.SetInt(SAVE_NUMBER_LEVEL, numberLevel + 1);
            SaveBridge.ES3Save(SAVE_NUMBER_LEVEL, numberLevel + 1);
            //SaveBridge.SaveAllData();
            SaveBridge.SaveOnQuit();
            clearPrlayerPrefs = true;
            SaveLevel.Instan.SetSaveFileLevelInt(GetNumberLevel(), GetStarsScore());
        }
        if (isVictory())
        {
            OnVictory?.Invoke(this, EventArgs.Empty);
        }
        
        if (listSpawnButtonIcons.Count == 20)
        {
            if (listSpawnButtonIcons[0].Is_timerOn() == false && listSpawnButtonIcons[19].Is_timerOn() == false && stopGridLayoutGroup == false)
            {
                for (int i = 0; i < listSpawnButtonIcons.Count; i++)
                {
                    listSpawnButtonIcons[i].ButtonsIcons.enabled = true;
                }
                stopGridLayoutGroup = true;
                //Timer.Instan.SetStartTimer();
                //gridLayoutGroup.enabled = false;

                //stopGridLayoutGroup = true;
                //Timer.Instan.SetStartTimer();
                //gridLayoutGroup.enabled = false;
            }
        }
        Score();
    }
    private void PausedMenuUI_OnClickButtonContinue(object sender, EventArgs e)
    {
        for (int i = 0; i < listSpawnButtonIcons.Count; i++)
        {
            if (listSpawnButtonIcons[i].Index != 0 && listSpawnButtonIcons[i].IsSelectButton == false)
            {
                listSpawnButtonIcons[i].ButtonsIcons.Select();
                return;
            }

        }
    }

    private void ManagerButton_OnDestroyButton(object sender, EventArgs e)
    {
        for (int i = 0; i < listSpawnButtonIcons.Count; i++)
        {
            if (listSpawnButtonIcons[i].Index != 0)
            {
                listSpawnButtonIcons[i].ButtonsIcons.Select();
                return;
            }

        }
    }

    private void ManagerButton_OnEnabledButton(object sender, EventArgs e)
    {
        Invoke("OnEnabledButton", 0.8f);
    }


    private void RestartLevel()
    {

        switch (numberLevel)
        {
            case 1:
                sceneLevelUIs[0].gameObject.SetActive(true);
                sceneLevelUIs[0].ListButton[0].ButtonsIcons.Select();
                sceneLevelUIs[0].ListButton[0].Index = 1;
                sceneLevelUIs[0].ListButton[1].Index = 2;
                listSpawnButtonIcons.Add(sceneLevelUIs[0].GetButton(0));
                listSpawnButtonIcons.Add(sceneLevelUIs[0].GetButton(1));
                break;
            case 2:
                sceneLevelUIs[1].gameObject.SetActive(true);
                sceneLevelUIs[1].ListButton[0].ButtonsIcons.Select();

                for (int i = 0; i < sceneLevelUIs[1].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[1].GetButton(i));
                    sceneLevelUIs[1].ListButton[i].Index = i + 1;
                }
                break;
            case 3:
                sceneLevelUIs[2].gameObject.SetActive(true);
                sceneLevelUIs[2].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[2].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[2].GetButton(i));
                    sceneLevelUIs[2].ListButton[i].Index = i + 1;
                }
                break;
            case 4:
                sceneLevelUIs[3].gameObject.SetActive(true);
                sceneLevelUIs[3].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[3].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[3].GetButton(i));
                    sceneLevelUIs[3].ListButton[i].Index = i + 1;
                }
                break;
            case 5:
                sceneLevelUIs[4].gameObject.SetActive(true);
                sceneLevelUIs[4].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[4].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[4].GetButton(i));
                    sceneLevelUIs[4].ListButton[i].Index = i + 1;
                }
                break;
            case 6:
                sceneLevelUIs[5].gameObject.SetActive(true);
                sceneLevelUIs[5].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[5].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[5].GetButton(i));
                    sceneLevelUIs[5].ListButton[i].Index = i + 1;
                }
                break;
            case 7:
                sceneLevelUIs[6].gameObject.SetActive(true);
                sceneLevelUIs[6].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[6].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[6].GetButton(i));
                    sceneLevelUIs[6].ListButton[i].Index = i + 1;
                }
                break;
            case 8:
                sceneLevelUIs[7].gameObject.SetActive(true);
                sceneLevelUIs[7].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[7].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[7].GetButton(i));
                    sceneLevelUIs[7].ListButton[i].Index = i + 1;
                }
                break;
            case 9:
                sceneLevelUIs[8].gameObject.SetActive(true);
                sceneLevelUIs[8].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[8].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[8].GetButton(i));
                    sceneLevelUIs[8].ListButton[i].Index = i + 1;
                }
                break;

            case 10:
                sceneLevelUIs[9].gameObject.SetActive(true);
                sceneLevelUIs[9].ListButton[0].ButtonsIcons.Select();
                for (int i = 0; i < sceneLevelUIs[9].ListButton.Count; i++)
                {
                    listSpawnButtonIcons.Add(sceneLevelUIs[9].GetButton(i));
                    sceneLevelUIs[9].ListButton[i].Index = i + 1;
                }
                break;

        }
    }

    private void RestartLevelMore10()
    {
        if (numberLevel > 10)
        {
            var random = new System.Random();
            var numbers = Enumerable.Range(0, 10).ToList();
            var numbers2 = Enumerable.Range(0, 10).ToList();
            var numbersCopy = new List<int>(numbers);
            var numbersCopy2 = new List<int>(numbers2);

            int[] arry_1 = new int[10];
            int[] arry_2 = new int[10];
            for (var i = 0; i < numbers.Count; i++)
            {
                var pickIndex = random.Next(numbersCopy.Count);

                var pickIndex2 = random.Next(numbersCopy2.Count);

                var randNumber = numbersCopy[pickIndex];

                var randNumber2 = numbersCopy2[pickIndex2];

                arry_1[i] = randNumber;
                arry_2[i] = randNumber2;

                numbersCopy.RemoveAt(pickIndex);
                numbersCopy2.RemoveAt(pickIndex2);
            }

            var randoms = new System.Random();
            int rang = randoms.Next(0, 4);
            if (rang == 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    ButtonIcon buttonIcon1 = Instantiate(listButtonIcon[arry_1[i]], sceneUI);
                    ButtonIcon buttonIcon2 = Instantiate(listButtonIcon[arry_2[i]], sceneUI);
                    //buttonIcon1.IsStaytButton = true; при старте картинка закрыта
                    //buttonIcon2.IsStaytButton = true; при старте картинка закрыта
                    buttonIcon1.ButtonsIcons.enabled = false;
                    buttonIcon2.ButtonsIcons.enabled = false;
                    buttonIcon1.Index = i + 1;
                    buttonIcon2.Index = i + 1;
                    ListSpawnButtonIcons.Add(buttonIcon1);
                    ListSpawnButtonIcons.Add(buttonIcon2);
                }
            }
            if (rang == 1)
            {
                for (int i = 0; i < 10; i++)
                {
                    ButtonIcon buttonIcon1 = Instantiate(listButtonIcon[arry_1[i] + 10], sceneUI);
                    ButtonIcon buttonIcon2 = Instantiate(listButtonIcon[arry_2[i] + 10], sceneUI);
                    //buttonIcon1.IsStaytButton = true; при старте картинка закрыта
                    //buttonIcon2.IsStaytButton = true; при старте картинка закрыта
                    buttonIcon1.ButtonsIcons.enabled = false;
                    buttonIcon2.ButtonsIcons.enabled = false;
                    buttonIcon1.Index = i + 1;
                    buttonIcon2.Index = i + 1;
                    ListSpawnButtonIcons.Add(buttonIcon1);
                    ListSpawnButtonIcons.Add(buttonIcon2);
                }
            }
            if (rang == 2)
            {
                for (int i = 0; i < 10; i++)
                {
                    ButtonIcon buttonIcon1 = Instantiate(listButtonIcon[arry_1[i] + 20], sceneUI);
                    ButtonIcon buttonIcon2 = Instantiate(listButtonIcon[arry_2[i] + 20], sceneUI);
                    //buttonIcon1.IsStaytButton = true; при старте картинка закрыта
                    //buttonIcon2.IsStaytButton = true; при старте картинка закрыта
                    buttonIcon1.ButtonsIcons.enabled = false;
                    buttonIcon2.ButtonsIcons.enabled = false;
                    buttonIcon1.Index = i + 1;
                    buttonIcon2.Index = i + 1;
                    ListSpawnButtonIcons.Add(buttonIcon1);
                    ListSpawnButtonIcons.Add(buttonIcon2);
                }
            }
            if (rang == 3)
            {
                for (int i = 0; i < 10; i++)
                {
                    ButtonIcon buttonIcon1 = Instantiate(listButtonIcon[arry_1[i] + 30], sceneUI);
                    ButtonIcon buttonIcon2 = Instantiate(listButtonIcon[arry_2[i] + 30], sceneUI);
                    //buttonIcon1.IsStaytButton = true; при старте картинка закрыта
                    //buttonIcon2.IsStaytButton = true; при старте картинка закрыта
                    buttonIcon1.ButtonsIcons.enabled = false;
                    buttonIcon2.ButtonsIcons.enabled = false;
                    buttonIcon1.Index = i + 1;
                    buttonIcon2.Index = i + 1;
                    ListSpawnButtonIcons.Add(buttonIcon1);
                    ListSpawnButtonIcons.Add(buttonIcon2);
                }
            }
            ListSpawnButtonIcons[0].ButtonsIcons.Select();

        }

    }
    private void OnEnabledButton()
    {
        for (int i = 0; i < ListSpawnButtonIcons.Count; i++)
        {
            ListSpawnButtonIcons[i].EnabledButton(true);
        }
    }
    private void StartScoreNumber()
    {
        switch (numberLevel)
        {
            case 1:
                starsScoreNumber_1 = 2;
                managerButton.SetStepValue(starsScoreNumber_1);
                return;
            case 2:
                starsScoreNumber_1 = 4; starsScoreNumber_2 = 6; starsScoreNumber_3 = 8;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 3:
                starsScoreNumber_1 = 8; starsScoreNumber_2 = 10; starsScoreNumber_3 = 12;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 4:
                starsScoreNumber_1 = 12; starsScoreNumber_2 = 16; starsScoreNumber_3 = 22;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 5:
                starsScoreNumber_1 = 16; starsScoreNumber_2 = 20; starsScoreNumber_3 = 24;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 6:
                starsScoreNumber_1 = 18; starsScoreNumber_2 = 22; starsScoreNumber_3 = 26;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 7:
                starsScoreNumber_1 = 22; starsScoreNumber_2 = 26; starsScoreNumber_3 = 30;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 8:
                starsScoreNumber_1 = 26; starsScoreNumber_2 = 30; starsScoreNumber_3 = 34;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 9:
                starsScoreNumber_1 = 28; starsScoreNumber_2 = 34; starsScoreNumber_3 = 38;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 10:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 36; starsScoreNumber_3 = 40;
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 11:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(130);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 12:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(130);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 13:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(120);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 14:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(120);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 15:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(110);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 16:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(110);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 17:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(100);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 18:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(100);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 19:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(90);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;
            case 20:
                starsScoreNumber_1 = 30; starsScoreNumber_2 = 34; starsScoreNumber_3 = 44;
                Timer.Instan.SetTimer(90);
                managerButton.SetStepValue(starsScoreNumber_3);
                return;

        }
    }
    public int GetStarsScore()
    {
        return starsScore;
    }
    public void Score()
    {
        if (starsScoreNumber_1 >= 0)
        {
            starsScore = 3;
        }
        else if (starsScoreNumber_2 >= 0)
        {
            starsScore = 2;
        }
        else if (starsScoreNumber_3 >= 0)
        {
            starsScore = 1;
        }
        else 
        {
            starsScore = 0;
        }
    }
    public void SetStarsScoreNumber_1()
    {
        --starsScoreNumber_1;
    }
    public void SetStarsScoreNumber_2()
    {
        --starsScoreNumber_2;
    }
    public void SetStarsScoreNumber_3()
    {
        --starsScoreNumber_3;
    }
    public int GetNumberLevel()
    {
        return numberLevel;
    }
    
    public bool isVictory()
    {
        if (numberLevel == managerButton.NextLevel() || 10 == managerButton.NextLevel())
        {
            Score();
            return true;
        }
        return false;
    }
}
