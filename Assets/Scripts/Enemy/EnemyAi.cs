using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;

    public float walkSpeed;
    public float chaseSpeed;

    //attack attribute
    bool isAttacking;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Attacking
    public float timeBetweenAttacks;
    bool canAttack;

    //States
    public float sightRange, attackRange, battleModeRange;
    public bool playerInSightRange, playerInAttackRange, isBattleModeArea;

    //animationScript
    private EnemyAnimController m_EnemyAnimController;
    public EnemyAnimController EnemyAnimController
    {
        get
        {
            if (m_EnemyAnimController == null)
            {
                m_EnemyAnimController = GetComponent<EnemyAnimController>();
            }
            return m_EnemyAnimController;
        }
    }

    //PatrolStateScript
    public PatrolState PatrolState;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();
        canAttack = true;
    }

    private void Update()
    {
        //check enemy animation for restriction
        CheckAnimation();
        //Check for sight and AttackRange
        CheckState();
        
        if (isBattleModeArea)
        {
            BattleMode();

        }
        else
        {
            PatrolState.Patrolling();
        }

    }

    private void CheckAnimation()
    {
        if (isPlaying(EnemyAnimController.AnimPlayer, "Attack")) agent.SetDestination(transform.position);
        else if (isDone(EnemyAnimController.AnimPlayer, "Attack")) EnemyAnimController.attack(false);
    }

    private void CheckState()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsPlayer);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        isBattleModeArea = Physics.CheckSphere(transform.position, battleModeRange, whatIsPlayer);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, battleModeRange);
    }


    private void ChasePlayer()
    {
            //Chase Animation
            EnemyAnimController.runForward();
            agent.speed = chaseSpeed;
            agent.SetDestination(player.position);
    }

    private void BattleMode()
    {
        if (canAttack)
        {
            ChasePlayer();
            if (playerInAttackRange)
            {
                StartCoroutine(Attackk());
            }
        }
        else
        {
            if (playerInAttackRange)
            {
                agent.SetDestination(transform.position);
            }
            else
            {
                MovementBattle(1.5f, 1f);
            }
        }
        
    }
    IEnumerator Attackk()
    {
        canAttack = false;
        EnemyAnimController.attack(true);
        yield return new WaitForSeconds(0.2f);
        Invoke(nameof(ResetAttack), timeBetweenAttacks);
    }

    private void Attack()
    {
        //make sure enemy dont move when attack 
        if (canAttack)
        {
            agent.SetDestination(transform.position);
            //attackCode here
            EnemyAnimController.attack(true);
            

            //make enemy lookatPlayer on x and z axis only
            Vector3 target = player.transform.position;
            target.y = transform.position.y;//lock look at on y axis
            transform.LookAt(target);

            canAttack = false;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
        
    }

    private void ResetAttack()//reset attack on interval
    {
        canAttack = true;
    }



    float time;
    float timeYield;
    int moveVariation = 3;
    private void MovementBattle(float timeLimit, float timeRest)
    {
        if(timeLimit > time)
        {
            MovementLocomotion(moveVariation);
            time += Time.deltaTime;
        }
        else if(timeRest > timeYield)
        {
            EnemyAnimController.idle();
            moveVariation = Random.Range(3, 5);//between right and left(3-4)
            timeYield += Time.deltaTime;
        }
        else
        {
            time = 0;
            timeYield = 0;
        }
    }


    private void MovementLocomotion(int val)
    {
        //lookAt player
        Vector3 target = player.position - transform.position;//if changeEnemyTarget(), change target to next enemy
        Vector3 newDir = Vector3.RotateTowards(transform.forward, target, 20 * Time.deltaTime, 0.0f);
        transform.rotation = Quaternion.LookRotation(newDir);
        agent.speed = 0;
        switch (val)
        {
            case 1://move Forward
                transform.position += transform.forward * walkSpeed * Time.deltaTime;
                EnemyAnimController.walkForward();
                break;
            case 2://move backward
                transform.position += -transform.forward * walkSpeed * Time.deltaTime;
                EnemyAnimController.walkBackward();
                break;
            case 3://move right
                transform.position += transform.right * walkSpeed * Time.deltaTime;
                EnemyAnimController.strafeRight();
                break;
            case 4://move left
                transform.position += -transform.right * walkSpeed * Time.deltaTime;
                EnemyAnimController.strafeLeft();
                break;

        }
    }

    bool isPlaying(Animator Anim, string stateTagName)
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsTag(stateTagName) &&
            Anim.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool isDone(Animator Anim, string stateTagName)
    {
        if (Anim.GetCurrentAnimatorStateInfo(0).IsTag(stateTagName) &&
            Anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }



}
