using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearFileUI : MonoBehaviour
{
    public static ClearFileUI Instan;
    public event EventHandler OnClickButtonNo;
    public event EventHandler OnClickButtonYes;

    [SerializeField] private LevelUI levelUI;
    [SerializeField] private Button buttonYes;
    [SerializeField] private Button buttonNo;
    private void Awake()
    {
        Instan = this;
    }
    private void Start()
    {
        gameObject.SetActive(false);
        buttonYes.onClick.AddListener(() =>
        {
            OnClickButtonYes?.Invoke(this, EventArgs.Empty); 
            gameObject.SetActive(false);
        });
        buttonNo.onClick.AddListener(() =>
        {
            gameObject.SetActive(false);
            OnClickButtonNo?.Invoke(this, EventArgs.Empty);
        });
    }
}
