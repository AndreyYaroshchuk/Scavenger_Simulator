using Rewired;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class MyCharacter : MonoBehaviour
{
    private CharacterController cc;
    private Player player;
    private int playerId = 0;
    private GameObject buttonIcon;
    private void Awake()
    {
        player = ReInput.players.GetPlayer(playerId);
        cc = GetComponent<CharacterController>();
    }
    private void Update()
    {
        if(player.GetButton("Button A"))
        {
            buttonIcon.SetActive(false);
        }
    }
}
