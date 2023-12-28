using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : MonoBehaviour
{
    private const string ANIMATION_SET_TRIGGER = "move";
    private const string SAVE_LOAD_SCENE = "loadScene";

    [SerializeField] private Animator animator;
    [SerializeField] private ManagerButtonIcon managerButtonIcon;
    [SerializeField] private Button buttonRestart;
    [SerializeField] private Button buttonMainMenu;
    [SerializeField] private SpawnLevel spawnLevel;
    [SerializeField] private GameObject buttonAllGameObject;
    [SerializeField] private GameObject ImageStar;
    [SerializeField] private TextMeshProUGUI textNumberLevel;

    private bool isShowGameOverUI = false;
    private void Start()
    {
        gameObject.SetActive(false);
        ImageStar.gameObject.SetActive(false);
        buttonAllGameObject.SetActive(false);
        buttonRestart.onClick.AddListener(() => {

            //PlayerPrefs.SetString(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, StartGame.StartGameScene.ToString());
            SaveBridge.SaveAllData();
            SceneManager.LoadScene(1);
        });
        buttonMainMenu.onClick.AddListener(() =>
        {
            //PlayerPrefs.SetString(SAVE_LOAD_SCENE, StartGame.StartMenuScene.ToString());
            SaveBridge.ES3Save(SAVE_LOAD_SCENE, StartGame.StartMenuScene.ToString());
            SaveBridge.SaveAllData();
            SceneManager.LoadScene(1); 
        });

        managerButtonIcon.OnGameOver += ManagerButtonIcon_OnGameOver;
    }

    private void ManagerButtonIcon_OnGameOver(object sender, System.EventArgs e)
    {
        if(isShowGameOverUI == false)
        {
            buttonRestart.Select();
        }
        isShowGameOverUI = true;
    }

    private void Update()
    {
        Invoke("MoveLevelUI", 1f);
        textNumberLevel.text = spawnLevel.GetNumberLevel().ToString();
    }
    private void MoveLevelUI()
    {
        animator.SetTrigger(ANIMATION_SET_TRIGGER);
        ImageStar.SetActive(true);  
        buttonAllGameObject.SetActive(true);
    }

    public bool IsShowGameOverUI()
    {
        return isShowGameOverUI;
    }

}
