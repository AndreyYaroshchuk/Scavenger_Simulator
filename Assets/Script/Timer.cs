using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Switch;

public class Timer : MonoBehaviour
{
    private const string SAVE_NUMBER_LEVEL = "numberLevel";

    public static Timer Instan;

    public float time = 0f;
    [SerializeField] TextMeshProUGUI textTimer;

    private bool startTimer = false;
    private float _timeLeft = 0f;
    private bool _timerOn = false;
    private int numberLevel;
    private bool play = false;
    private void Awake()
    {
        Instan = this;
    }
    private void Start()
    {
        if (SaveBridge.ES3Load(SAVE_NUMBER_LEVEL, numberLevel) <= 10)
        {
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        TimeUpdate();      
    }
    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        textTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    private void TimeUpdate()
    {
        if (_timerOn && startTimer == true)
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= UnityEngine.Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                startTimer = false;
                _timeLeft = time;
                _timerOn = false;
            }
        }
    }
    public void SetTimer(float tim)
    {
        time = tim;
        _timeLeft = time;
        _timerOn = true;
        
        gameObject.SetActive(true);

    }
    public void SetStartTimer()
    {
        startTimer = true;
    }
    public string GetTimer()
    {
        startTimer = false;
        return textTimer.text;
    }
    public float GetTimeLeft()
    {
        return _timeLeft;
    }
    public bool Play()
    {
        if(play == false)
        {
            play = true;
            return false;
        }
        return play;
        
    }
}
