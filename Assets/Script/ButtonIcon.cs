using System;
using UnityEngine;
using UnityEngine.Switch;
using UnityEngine.UI;

public enum ButtonIconName { Level_1, Level_2, Level_3, Level_4, Level_5, Level_6, Level_7, Level_8, Level_9, Level_10, Level_11, Level_12, Level_13, Level_14, Level_15, Level_16, Level_17, Level_18, Level_19, Level_20 }
public class ButtonIcon : MonoBehaviour
{

    //private const string SET_TRIGGER_CLOSE_BUTTON = "Close";
    ////private const string SET_TRIGGER_OPEN_BUTTON = "Open";

    //private const string SET_TRIGGER_CLICK_BUTTON = "Click";



    //public static event EventHandler OnClicButtonIcon;

    //[SerializeField] private Animator animator;
    //[SerializeField] private Button buttonIconOpen;
    //[SerializeField] private Button buttonIconClose;


    //[SerializeField] private float time = 10;

    //private float _timeLeft = 0f;
    //private bool _timerOn = false;
    //private bool startCloseButton = true;

    //private float rot_speed = 5f;
    //private float custom_angle = 180f;
    //public bool isOpenButton = false;
    //private bool isStaytButton = false; // состояние карточек
    //public bool isCloseButton = false;

    //public ButtonIconName buttonIconName;
    //public int numberID;

    //private void Start()
    //{
    //    numberID = UnityEngine.Random.Range(0, 999999);
    //_timeLeft = time;
    //    _timerOn = true;

    //    //buttonIconOpen.onClick.AddListener(() =>
    //    //{
    //    //    //CloseButtonAnimation();


    //    //    //OnClicButtonIcon?.Invoke(this, EventArgs.Empty);
    //    //});

    //    buttonIconClose.onClick.AddListener(() =>
    //    {
    //        //animator.SetTrigger(SET_TRIGGER_OPEN_BUTTON);


    //        //buttonIconOpen.gameObject.SetActive(true);

    //        //buttonIconClose.gameObject.SetActive(false);

    //        isOpenButton = true;

    //        OnClicButtonIcon?.Invoke(this, EventArgs.Empty);
    //    });

    //    if (isStaytButton)
    //    {
    //        buttonIconOpen.gameObject.SetActive(true);
    //        buttonIconClose.gameObject.SetActive(false);
    //    }
    //    else
    //    {
    //        buttonIconOpen.gameObject.SetActive(false);
    //        buttonIconClose.gameObject.SetActive(true);
    //    }
    //}


    //private void Update()
    //{
    //    TimeUpdate();
    //    //CloseButtonToStart();
    //    OpenButtonIcon();
    //    CloceButtonIcon();

    //}


    //private void OpenButtonIcon()
    //{

    //    if (isOpenButton == true)
    //    {
    //        Invoke("SetIsOpenButton", 2f);
    //        buttonIconOpen.gameObject.SetActive(true);
    //        buttonIconClose.gameObject.SetActive(false);

    //        buttonIconOpen.transform.rotation = Quaternion.Slerp(buttonIconOpen.transform.rotation, Quaternion.Euler(0, custom_angle, 0), rot_speed * Time.deltaTime);
    //        buttonIconClose.transform.rotation = Quaternion.Slerp(buttonIconClose.transform.rotation, Quaternion.Euler(0, custom_angle, 0), rot_speed * Time.deltaTime);
    //    }

    //}
    //private void CloceButtonIcon()
    //{


    //    if (isCloseButton == true)
    //    {
    //        Invoke("SetIsCloseButton", 2f);
    //        if (buttonIconOpen.transform.rotation.y <= 90)
    //        {

    //            buttonIconOpen.gameObject.SetActive(false);
    //            buttonIconClose.gameObject.SetActive(true);
    //        }
    //        buttonIconOpen.transform.rotation = Quaternion.Slerp(buttonIconOpen.transform.rotation, Quaternion.Euler(0, 0, 0), rot_speed * Time.deltaTime);
    //        buttonIconClose.transform.rotation = Quaternion.Slerp(buttonIconClose.transform.rotation, Quaternion.Euler(0, 0, 0), rot_speed * Time.deltaTime);
    //    }
    //}
    //private void SetIsCloseButton()
    //{
    //    isCloseButton = false;
    //}

    //private void SetIsOpenButton()
    //{
    //    isOpenButton = false;
    //}
    //private void UpdateTimeText()
    //{
    //    if (_timeLeft < 0)
    //        _timeLeft = 0;

    //    float minutes = Mathf.FloorToInt(_timeLeft / 60);
    //    float seconds = Mathf.FloorToInt(_timeLeft % 60);
    //    Debug.Log(string.Format("{0:00} : {1:00}", minutes, seconds));
    //}
    //private void TimeUpdate()
    //{
    //    if (_timerOn)
    //    {
    //        if (_timeLeft > 0)
    //        {
    //            _timeLeft -= Time.deltaTime;
    //            //UpdateTimeText();
    //        }
    //        else
    //        {
    //            _timeLeft = time;
    //            _timerOn = false;
    //        }
    //    }
    //}

    //public void IsCloseButton()
    //{
    //    isOpenButton = false;
    //    isCloseButton = true;
    //}

    //public void EnabledButton(bool key)
    //{
    //    if (key == false)
    //    {
    //        buttonIconOpen.enabled = false;
    //        buttonIconClose.enabled = false;
    //    }
    //    else
    //    {
    //        buttonIconOpen.enabled = true;
    //        buttonIconClose.enabled = true;
    //    }


    //}
    //public int Number()
    //{

    //    return numberID;
    //}

    public static event EventHandler OnClicButtonIcon;

    [SerializeField] Button buttonIcons;
    [SerializeField] Sprite spriteClose;
    [SerializeField] Sprite spriteOpen;
    [SerializeField] Image imageButtonOpen;
    [SerializeField] private float time = 10;
   

    private float rot_speed = 5f;
    private float custom_angle = 180f;

    private bool isStaytButton = false; // состояние карточек


    public ButtonIconName buttonIconName;


    private bool isSelectButton;

    private float _timeLeft = 0f;
    private bool _timerOn = true;

   

    public bool isOpenButton = false;
    public bool isCloseButton = false;
    
    private int index;

    public int numberID;

    public Button ButtonsIcons { get => buttonIcons; set => buttonIcons = value; }
    public bool IsStaytButton { get => isStaytButton; set => isStaytButton = value; }
    public int Index { get => index; set => index = value; }
    public bool IsSelectButton { get => isSelectButton; set => isSelectButton = value; }

    private void Start()
    {
        numberID = UnityEngine.Random.Range(0, 999999);

        _timeLeft = time;
        _timerOn = true;

        ButtonsIcons.onClick.AddListener(() =>
        {
            isOpenButton = true;

            OnClicButtonIcon?.Invoke(this, EventArgs.Empty);
        });

        if (IsStaytButton)
        {
            ButtonsIcons.image.sprite = spriteOpen;
            imageButtonOpen.sprite = spriteOpen;
        }
        else
        {
            ButtonsIcons.image.sprite = spriteClose;
            imageButtonOpen.sprite = spriteOpen;
        }
    }


    private void Update()
    {
        OpenButtonIcon();
        CloceButtonIcon();
        TimeUpdate();
    }

    private void OpenButtonIcon()
    {

        if (isOpenButton == true)
        {
            Invoke("SetIsOpenButton", 0.5f);
            imageButtonOpen.gameObject.SetActive(true);
            ButtonsIcons.image.sprite = spriteOpen;
            ButtonsIcons.transform.rotation = Quaternion.Slerp(ButtonsIcons.transform.rotation, Quaternion.Euler(0, custom_angle, 0), rot_speed * UnityEngine.Time.deltaTime);
        }

    }
    private void CloceButtonIcon()
    {
        if (isCloseButton == true)
        {
            Invoke("SetIsCloseButton", 0.5f);
            imageButtonOpen.gameObject.SetActive(false);
            ButtonsIcons.image.sprite = spriteClose;
            ButtonsIcons.transform.rotation = Quaternion.Slerp(ButtonsIcons.transform.rotation, Quaternion.Euler(0, 0, 0), rot_speed * UnityEngine.Time.deltaTime);
        }
    }


    private void UpdateTimeText()
    {
        if (_timeLeft < 0)
            _timeLeft = 0;

        float minutes = Mathf.FloorToInt(_timeLeft / 60);
        float seconds = Mathf.FloorToInt(_timeLeft % 60);
        Debug.Log(string.Format("{0:00} : {1:00}", minutes, seconds));
    }
    private void TimeUpdate()
    {
        if (_timerOn && IsStaytButton == true )
        {
            if (_timeLeft > 0)
            {
                _timeLeft -= UnityEngine.Time.deltaTime;
                UpdateTimeText();
            }
            else
            {
                IsStaytButton = false;
                isCloseButton = true;
                _timeLeft = time;
                _timerOn = false;
                buttonIcons.enabled = true;
            }
        }
    }




    private void SetIsOpenButton()
    {
        isOpenButton = false;
    }

    private void SetIsCloseButton()
    {
        isCloseButton = false;
    }

    public void IsCloseButton()
    {
        isOpenButton = false;
        isCloseButton = true;
    }

    public void EnabledButton(bool key)
    {
        if (key == false)
        {

            ButtonsIcons.enabled = false;
        }
        else
        {

            ButtonsIcons.enabled = true;
        }
    }
    public bool Is_timerOn()
    {
        return false;
    }
    //public bool Is_timerOn()
    //{
    //    return _timerOn;
    //}
    public int Number()
    {

        return numberID;
    }
 
}
