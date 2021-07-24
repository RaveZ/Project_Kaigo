using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckEnemy : MonoBehaviour
{
    private InputMaster input;
    public PlayerAction playerAction;
    private void Awake()
    {
        input = new InputMaster();
        myInput();
    }


    private void Update()
    {
        
    }
    


    private void myInput()
    {
        input.GamePlay.LockOn.performed += _ => LockOnEnemy();
    }

    //tell playerAction to lock on enemy
    private void LockOnEnemy()
    {
        if (playerAction.enemyLock.Count != 0)
        {
            if (playerAction.enterBattle)
            {
                playerAction.enterBattle = false;
            }
            else
            {
                playerAction.enterBattle = true;
            }

        }

    }

    //trigger if enemy get on the field
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("isEnemy"))
        {
            playerAction.enemyLock.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
         if(other.gameObject.layer == LayerMask.NameToLayer("isEnemy"))
        {
            playerAction.enemyLock.Remove(other.gameObject);
            if (playerAction.enemyLock.Count == 0)
            {
                playerAction.enterBattle = false;
            }
        }
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
        playerAction.enemyLock.Clear();
    }
}
