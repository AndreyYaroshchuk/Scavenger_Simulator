using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLevelUI : MonoBehaviour
{
    [SerializeField] private List<ButtonIcon> listButton;

    public List<ButtonIcon> ListButton { get => listButton; set => listButton = value; }

    public ButtonIcon GetButton(int index)
    {
        return ListButton[index];
    }
}
