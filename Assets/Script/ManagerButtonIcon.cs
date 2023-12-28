using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ManagerButtonIcon : MonoBehaviour
{
    public event EventHandler OnGameOver;
    public event EventHandler OnEnabledButton;
    public event EventHandler OnDestroyButton;

    [SerializeField] private List<ButtonIcon> buttonIcons;
    [SerializeField] private SpawnLevel spawnLevel;

    private int countTrueAnswers = 2; // кол нажатий для победы
    private int startCountTrueAnswers = 0;
    private int nextLevel = 0;
    private int stepValue = 40; // кол шагов
    private bool isGameOver = false;
    private int count = 0;

    private ButtonIcon buttonIcon_1;
    private ButtonIcon buttonIcon_2;
    private void Start()
    {
        ButtonIcon.OnClicButtonIcon += ButtonIcon_OnClicButtonIcon;
    }
    private void OnDestroy()
    {
        ButtonIcon.OnClicButtonIcon -= ButtonIcon_OnClicButtonIcon;
    }
    private void ButtonIcon_OnClicButtonIcon(object sender, System.EventArgs e)
    {
        buttonIcons.Add(sender as ButtonIcon);
        if(Timer.Instan.Play() == false)
        {
            Timer.Instan.SetStartTimer();
            spawnLevel.GridLayoutGroup.enabled = false;
        }
        ++startCountTrueAnswers;
        buttonIcons[0].IsSelectButton = true;
        buttonIcons[0].ButtonsIcons.enabled = false;
        if (buttonIcons.Count > 1)
        {
            if (buttonIcons[0].Number() != buttonIcons[1].Number())
            {
                stepValue--;
                spawnLevel.SetStarsScoreNumber_1();
                spawnLevel.SetStarsScoreNumber_2();
                spawnLevel.SetStarsScoreNumber_3();
            }
        }
        else
        {
            spawnLevel.SetStarsScoreNumber_1();
            spawnLevel.SetStarsScoreNumber_2();
            spawnLevel.SetStarsScoreNumber_3();
            stepValue--;
        }
        for (int i = 0; i < spawnLevel.ListSpawnButtonIcons.Count; i++)
        {
            if (spawnLevel.ListSpawnButtonIcons[i].Index != 0)
            {
                if (spawnLevel.ListSpawnButtonIcons[i].IsSelectButton == false)
                {
                    spawnLevel.ListSpawnButtonIcons[i].ButtonsIcons.Select();
                    return;
                }
            }

        }


    }
    private void Update()
    {
        PressCheck();
        if (GameOver())
        {
            //SaveLevel.Instan.SetSaveFileLevel(spawnLevel.GetNumberLevel(),spawnLevel.GetStarsScore());
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
        
        if(Timer.Instan.GetTimeLeft()<= 0 && spawnLevel.GetNumberLevel() > 10)
        {
            isGameOver = true;
             
        }
        if(isGameOver == true)
        {
            OnGameOver?.Invoke(this, EventArgs.Empty);
        }
    }
    private void PressCheck() // проверка совпадения картинок
    {
        if (startCountTrueAnswers == countTrueAnswers)
        {
            if (buttonIcons[0].buttonIconName == buttonIcons[1].buttonIconName && /*buttonIcons[0].gameObject != buttonIcons[1].gameObject*/ buttonIcons[0].Number() != buttonIcons[1].Number())
            {
                startCountTrueAnswers = 0;

                //buttonIcons[0].gameObject.SetActive(false);
                //buttonIcons[1].gameObject.SetActive(false);
                buttonIcons[0].ButtonsIcons.enabled = false;
                buttonIcons[1].ButtonsIcons.enabled = false;
                buttonIcons[0].Index = 0;
                buttonIcons[1].Index = 0;
                buttonIcon_1 = buttonIcons[0];
                buttonIcon_2 = buttonIcons[1];
                for (int i = buttonIcons.Count - 1; i >= 0; i--)
                {
                    buttonIcons.Remove(buttonIcons[i]);
                }
                OnDestroyButton?.Invoke(this, EventArgs.Empty);
                Invoke("HideVict", 0.5f);
                nextLevel++;

            }
            else
            {
                OnEnabledButton?.Invoke(this, EventArgs.Empty);
                for (int i = 0; i < spawnLevel.ListSpawnButtonIcons.Count; i++)
                {
                    buttonIcons[0].IsSelectButton = false;
                    spawnLevel.ListSpawnButtonIcons[i].EnabledButton(false);
                }
                Invoke("test", 0.5f);
                startCountTrueAnswers = 0;


            }
        }
    }

    private void HideVict()
    {
        buttonIcon_1.ButtonsIcons.enabled = false; 
        buttonIcon_2.ButtonsIcons.enabled = false;
        buttonIcon_1.gameObject.SetActive(false);
        buttonIcon_2.gameObject.SetActive(false);
    }
    private void test()
    {
        for (int i = buttonIcons.Count - 1; i >= 0; i--)
        {
            buttonIcons[i].IsCloseButton();
            buttonIcons.Remove(buttonIcons[i]);
        }

    }
    public int StepValue()
    {
        return stepValue;
    }
    public bool GameOver()
    {
        if(spawnLevel.GetNumberLevel() >= 10)
        {
            if (stepValue == 0 && nextLevel != 10 /*spawnLevel.GetNumberLevel()*/)
            {
                return true;
            }
        }
        else
        {
            if (stepValue == 0 && nextLevel != spawnLevel.GetNumberLevel())
            {
                return true;
            }
        }

        return false;
    }
    public void SetStepValue(int step)
    {
        stepValue = step;
    }
    public int NextLevel()
    {
        return nextLevel;
    }
}
