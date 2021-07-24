using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombatSkill : MonoBehaviour
{
    public bool isBasicAttack { get; set; }
    int attackForm;
    int init;
    float attackTimer;
    bool canAttack = false;
    public float timeLimit;

    private InputMaster input;
    public PlayerAction playerAction;
    void Awake()
    {
        attackTimer = timeLimit;
        input = new InputMaster();
        myInput();
    }

    // Update is called once per frame
    void Update()
    {


        attackInputTimer();
    }

    private void myInput()
    {
        //Attack
        input.GamePlay.BasicAttack.started += _ => resetTimer();
    }

    void resetTimer()
    {
        attackTimer = 0;
    }

    void attackInputTimer()
    {
       
        attackTimer += Time.deltaTime;


        if (attackTimer < timeLimit)
        {
            isBasicAttack = true;
        }
        else
        {
            isBasicAttack = false;
        }

        playerAction.AnimController.BasicAttack(isBasicAttack);
    }

    IEnumerator SetAttack()
    {
        isBasicAttack = true;
        StartCoroutine(BasicAttack());
        
        yield return new WaitForSeconds(0.3f);
        init++;
        isBasicAttack = false;

    }

    IEnumerator BasicAttack()
    {
        if(init == 0)
        {
            playerAction.canMove = false;
            playerAction.AnimController.BasicAttack(true);
            yield return new WaitForSeconds(.2f);
            playerAction.canMove = true;
        }
        
    }

    private void OnEnable()
    {
        input.Enable();
    }

    private void OnDisable()
    {
        input.Disable();
    }
}
