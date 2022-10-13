using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpePower : MonoBehaviour
{
    public enum SpePower
    {
        Dash,
    };
    public Player_Main player;
    [Header("特殊能力")]
    public SpePower spePower;
    [Header("特殊能力:冲刺")]
    public bool startDash;

    private void Update()
    {
        if (Input.GetButtonDown("Attack2"))
        {
            UseSpePower();
        }
    }

    private void FixedUpdate()
    {
        if (startDash == true)
        {
            player.theRb.MovePosition(player.theRb.position + player.moveVec * player.autoSpeed * Time.fixedDeltaTime);
        }
    }

    public void UseSpePower()
    {
        switch (spePower)
        {
            case SpePower.Dash:
                player.theAn.Play("PlayerDash");              
                break;

            default:
                break;
        }
    }
}
