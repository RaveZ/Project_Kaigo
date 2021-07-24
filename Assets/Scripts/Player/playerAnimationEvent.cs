using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class playerAnimationEvent : MonoBehaviour
{
    public PlayerAction playerAction;
    public PlayerCombatSkill playerCombat;
    //rigidbody
    public Rigidbody rigidBodyChar { get; set; }

    //animation
    private PlayerAnim m_AnimController;
    public PlayerAnim AnimController
    {
        get
        {
            if (m_AnimController == null)
            {
                m_AnimController = GetComponent<PlayerAnim>();
            }
            return m_AnimController;
        
        
        }
    }

    public GameObject sparkFX;
    void Awake()
    {
        rigidBodyChar = GetComponent<Rigidbody>();
    }

    public void checkPlayerBasicAttack()
    {
        if (playerCombat.isBasicAttack)
        {
            AnimController.BasicAttack(true);
        }
        else
        {
            AnimController.BasicAttack(false);
        }
    }

    void dontMove()
    {
        playerAction.canMove = false;
    }

    void canMove()
    {
        playerAction.canMove = true;
    }

    void forceForward()
    {
        playerAction.rigidBodyChar.AddForce(playerAction.transform.forward * 600);
    }



    void cancelDodge()
    {
        playerAction.AnimController.dodge(false);
    }
    
}
