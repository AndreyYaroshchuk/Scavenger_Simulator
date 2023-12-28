using Rewired;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameSceneUI : MonoBehaviour
{
    public event EventHandler OnClickPauseMenu;

  
    [SerializeField] private SpawnLevel spawnLevel;
    [SerializeField] private TextMeshProUGUI stepValueText;
    [SerializeField] private ManagerButtonIcon managerButtonIcon;
    [SerializeField] private GameOverUI gameOverUI;
    [SerializeField] private VictoryUI victoryUI;
    [SerializeField] private PausedMenuUI pausedMenuUI;
    [SerializeField] private SettingsUI settingsUI;
    
    private void Start()
    {
        managerButtonIcon.OnGameOver += ManagerButtonIcon_OnGameOver;
        spawnLevel.OnVictory += SpawnLevel_OnVictory;
    }

    private void SpawnLevel_OnVictory(object sender, EventArgs e)
    {
        victoryUI.gameObject.SetActive(true);
    }

    private void ManagerButtonIcon_OnGameOver(object sender, EventArgs e)
    {
        gameOverUI.gameObject.SetActive(true);
    }

    private void Update()
    {
        stepValueText.text = managerButtonIcon.StepValue().ToString();
        if (ReInput.players.GetPlayer(0).GetButtonDown("Paused") && gameOverUI.IsShowGameOverUI() == false && victoryUI.IsShowVictoryUI() == false && settingsUI.IsShowSettings() == false)
        {
            Time.timeScale = 0f;
            pausedMenuUI.gameObject.SetActive(true);
            settingsUI.SaveVolueAudio();
            OnClickPauseMenu?.Invoke(this, EventArgs.Empty);
        }
    }
}
