using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LevelUI : MonoBehaviour
{
    private const string SAVE_NUMBER_LEVEL = "numberLevel";


    [SerializeField] private MainMenuUI mainMenuUI;
    [SerializeField] private List<LevelButton> levelButtons;
    [SerializeField] private List<GameObject> levelUIList;
    [SerializeField] private List<Button> leveButtonNext;
    [SerializeField] private List<Button> leveButtonBck;

    private int numberLevel;
    private int levelSave;
    private void Start()
    {
        levelUIList[1].SetActive(false);
        levelUIList[2].SetActive(false);
        levelUIList[3].SetActive(false);
        levelUIList[4].SetActive(false);
        gameObject.SetActive(false);
        UpdateButtonLevel();
        leveButtonNext[0].onClick.AddListener(() =>
        {
            levelUIList[0].SetActive(false);
            levelUIList[1].SetActive(true);
            leveButtonBck[0].Select();
        });
        leveButtonNext[1].onClick.AddListener(() =>
        {
            levelUIList[1].SetActive(false);
            levelUIList[2].SetActive(true);
            leveButtonBck[1].Select();
        });
        leveButtonNext[2].onClick.AddListener(() =>
        {
            levelUIList[2].SetActive(false);
            levelUIList[3].SetActive(true);
            leveButtonBck[2].Select();
        });
        leveButtonNext[3].onClick.AddListener(() =>
        {
            levelUIList[3].SetActive(false);
            levelUIList[4].SetActive(true);
            leveButtonBck[3].Select();
        });
        leveButtonBck[0].onClick.AddListener(() =>
        {
            levelUIList[0].SetActive(true);
            levelUIList[1].SetActive(false);
            leveButtonNext[0].Select();
        });
        leveButtonBck[1].onClick.AddListener(() =>
        {
            levelUIList[1].SetActive(true);
            levelUIList[2].SetActive(false);
            leveButtonNext[1].Select();
        });
        leveButtonBck[2].onClick.AddListener(() =>
        {
            levelUIList[2].SetActive(true);
            levelUIList[3].SetActive(false);
            leveButtonNext[2].Select();
        });
        leveButtonBck[3].onClick.AddListener(() =>
        {
            levelUIList[3].SetActive(true);
            levelUIList[4].SetActive(false);
            leveButtonNext[3].Select();
        });
        mainMenuUI.OnClickButton += MainMenuUI_OnClickButton;
    }

    private void MainMenuUI_OnClickButton(object sender, System.EventArgs e)
    {
        levelUIList[0].SetActive(true);
        levelUIList[1].SetActive(false);
        levelUIList[2].SetActive(false);
        levelUIList[3].SetActive(false);
        levelUIList[4].SetActive(false);
        levelButtons[0].ButtonLevel.Select();
        levelButtons[0].ButtonLevel.enabled = true;
    }

    private void Update()
    {
        UpdateButtonLevel();
    }
    public void UpdateButtonLevel()
    {
        if (SaveBridge.ES3Load(SAVE_NUMBER_LEVEL, numberLevel) > 1 || SaveBridge.ES3KeyExists(LevelName.Level_2.ToString()) == true)
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                //if (i < 19)
                //{
                if (levelButtons[i].GetNumberStar() > 0 && levelButtons[i + 1].GetNumberStar() == 0)
                {

                    levelButtons[i + 1].ButtonLevelHide.gameObject.SetActive(false);
                    levelButtons[i + 1].ButtonLevel.enabled = true;
                    return;
                }
                else if (levelButtons[i].GetNumberStar() == 0 && levelButtons[i + 1].GetNumberStar() == 0)
                {
                    levelButtons[i].ButtonLevelHide.gameObject.SetActive(false);
                    levelButtons[i + 1].ButtonLevel.enabled = true;
                    return;
                }
                //}
            }
        }
        else
        {
            for (int i = 0; i < levelButtons.Count; i++)
            {
                if (i == 0)
                {
                    levelButtons[0].ButtonLevel.gameObject.SetActive(true);
                    levelButtons[0].ButtonLevelHide.gameObject.SetActive(false);
                }
                else
                {
                    levelButtons[i].ButtonLevel.gameObject.SetActive(false);
                    levelButtons[i].ButtonLevelHide.gameObject.SetActive(true);
                    levelButtons[i].ButtonLevel.enabled = false;
                }
                if (i == 1 &&/* SaveBridge.ES3Load(SAVE_NUMBER_LEVEL, numberLevel) >= 1*/SaveBridge.ES3Load(LevelName.Level_1.ToString(), levelSave) != 0)
                {
                    levelButtons[1].ButtonLevel.gameObject.SetActive(true);
                    levelButtons[1].ButtonLevelHide.gameObject.SetActive(false);
                    levelButtons[i].ButtonLevel.enabled = true;
                }

            }
        }
    }


}
