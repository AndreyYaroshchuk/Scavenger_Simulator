using Rewired;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class SettingsUI : MonoBehaviour
{
    private const string SAVE_AUDIO_MUSIC_VOLUE = "SourceMusic";
    private const string SAVE_AUDIO_SOUND_VOLUE = "SourceSound";

    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private AudioSource audioSourceSound;
    [SerializeField] private MainMenuUI mainMenuUI;
    [SerializeField] private PausedMenuUI pausedMenuUI;
    [SerializeField] private Button buttonSound;
    [SerializeField] private Button buttonSoundPls;
    [SerializeField] private Button buttonSoundMinus;
    [SerializeField] private Button buttonMusicPls;
    [SerializeField] private Button buttonMusicMinus;
    [SerializeField] private TextMeshProUGUI textMusic;
    [SerializeField] private TextMeshProUGUI textSound;
    [SerializeField] private List<AudioClip> listAudioClipMusic;
    

    private float volueMusic;
    private float volueSound;
    private bool isShow = false;
    private bool activ = false;
    public bool IsShow { get => isShow; set => isShow = value; }


    private void Awake()
    {
        //if (SaveBridge.ES3KeyExists(SAVE_AUDIO_MUSIC_VOLUE) == true)
        //{
        //    volueMusic = SaveBridge.ES3Load(SAVE_AUDIO_MUSIC_VOLUE, volueMusic);
        //    audioSourceMusic.volume = volueMusic;
        //}
        //if (SaveBridge.ES3KeyExists(SAVE_AUDIO_SOUND_VOLUE) == true)
        //{
        //    volueSound = SaveBridge.ES3Load(SAVE_AUDIO_SOUND_VOLUE, volueSound);
        //    audioSourceSound.volume = volueSound;
        //}
       
    }
   
    private void Start()
    {
       
        textMusic.text = Mathf.Round(audioSourceMusic.volume * 100).ToString() + " %";
        textSound.text = Mathf.Round(audioSourceSound.volume * 100).ToString() + " %" ;

        buttonSoundPls.Select();
        if(mainMenuUI != null)
        {
            mainMenuUI.OnClickButtonSettings += MainMenuUI_OnClickButtonSettings;
            activ = false;
        }
        else
        {
            pausedMenuUI.OnClickButton += PausedMenuUI_OnClickButton;
            activ = true;
        }
       
        buttonSoundPls.onClick.AddListener(() =>
        {
            audioSourceSound.volume += 0.05f;
            
            textSound.text = Mathf.Round(audioSourceSound.volume * 100).ToString() + " %";
        });
        buttonSoundMinus.onClick.AddListener(() =>
        {
            audioSourceSound.volume -= 0.05f;
            
            textSound.text = Mathf.Round(audioSourceSound.volume * 100).ToString() + " %";
        });
        buttonMusicPls.onClick.AddListener(() =>
        {
            audioSourceMusic.volume += 0.05f;
           
            textMusic.text = Mathf.Round(audioSourceMusic.volume * 100).ToString() + " %";
        });
        buttonMusicMinus.onClick.AddListener(() =>
        {
            audioSourceMusic.volume -= 0.05f;
            
            textMusic.text = Mathf.Round(audioSourceMusic.volume * 100).ToString() + " %";
        });
    }

    private void Update()
    {
        if(activ == false)
        {
            if (mainMenuUI.IsClickSetting == true)
            {
                buttonSoundPls.Select();
                mainMenuUI.IsClickSetting = false;
            }
        }
        else
        {
            if (pausedMenuUI.IsClickSetting == true)
            {
                buttonSoundPls.Select();
                pausedMenuUI.IsClickSetting = false;
            }
        }
       
    }
    private void PausedMenuUI_OnClickButton(object sender, System.EventArgs e)
    {
        buttonSound.Select();
    }

    private void MainMenuUI_OnClickButtonSettings(object sender, System.EventArgs e)
    {
        buttonSound.Select();
    }
    public void SaveVolueAudio()
    {
        volueSound = audioSourceSound.volume;
        volueMusic = audioSourceMusic.volume;
        SaveBridge.ES3Save(SAVE_AUDIO_MUSIC_VOLUE, volueMusic);
        SaveBridge.ES3Save(SAVE_AUDIO_SOUND_VOLUE, volueSound);
        SaveBridge.SaveAllData();
        SaveBridge.SaveOnQuit();
    }
    public bool IsShowSettings()
    {
        return IsShow;
    }
  
}
