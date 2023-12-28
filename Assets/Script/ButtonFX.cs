using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    private const string SAVE_AUDIO_MUSIC_VOLUE = "SourceMusic";
    private const string SAVE_AUDIO_SOUND_VOLUE = "SourceSound";


    [SerializeField] private SpawnLevel spawnLevel;
    [SerializeField] private ManagerButtonIcon managerButtonIcon;
    [SerializeField] private AudioSource audioSourceSound;
    [SerializeField] private AudioSource audioSourceMusic;
    [SerializeField] private List<AudioClip> listAudioClipMusic;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioClip audioClipVictory;
    [SerializeField] private AudioClip audioClipGameOver;

    private bool stopPlay;
    private float volue;

    private void Awake()
    {
        if (listAudioClipMusic != null)
        {
            audioSourceMusic.clip = listAudioClipMusic[Random.Range(0, listAudioClipMusic.Count)];

            if (SaveBridge.ES3KeyExists(SAVE_AUDIO_MUSIC_VOLUE) == true)
            {
                volue = SaveBridge.ES3Load(SAVE_AUDIO_MUSIC_VOLUE, volue);
                audioSourceMusic.volume = volue;
            }
            audioSourceMusic.Play();
        }


        if (SaveBridge.ES3KeyExists(SAVE_AUDIO_SOUND_VOLUE) == true)
        {
            volue = SaveBridge.ES3Load(SAVE_AUDIO_SOUND_VOLUE, volue);
            audioSourceSound.volume = volue;
        }
    }
    private void Start()
    {
        if (spawnLevel != null)
        {
            spawnLevel.OnVictory += SpawnLevel_OnVictory;
        }
        if (managerButtonIcon != null)
        {
            managerButtonIcon.OnGameOver += ManagerButtonIcon_OnGameOver;
        }
    }

    private void ManagerButtonIcon_OnGameOver(object sender, System.EventArgs e)
    {
        if (stopPlay == false)
        {
            {
                audioSourceMusic.clip = audioClipGameOver;
                audioSourceMusic.Pause();
                audioSourceMusic.PlayOneShot(audioClipGameOver);
                stopPlay = true;
            }
        }      
    }

    private void SpawnLevel_OnVictory(object sender, System.EventArgs e)
    {
        if (stopPlay == false)
        {
            {
                audioSourceMusic.clip = audioClipVictory;
                audioSourceMusic.Pause();
                audioSourceMusic.PlayOneShot(audioClipVictory);
                stopPlay = true;
            }

        }
    }

    public void HoherOund()
    {
        audioSourceSound.PlayOneShot(clip);
    }

    public void SaveVolueAudio()
    {
        SaveBridge.ES3Save(SAVE_AUDIO_MUSIC_VOLUE, audioSourceMusic.volume);
        SaveBridge.ES3Save(SAVE_AUDIO_SOUND_VOLUE, audioSourceSound.volume);
        SaveBridge.SaveAllData();
    }

}
