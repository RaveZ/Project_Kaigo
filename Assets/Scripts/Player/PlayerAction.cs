using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]

public class PlayerAction : MonoBehaviour
{
    //battle
    [HideInInspector]
    public int currentEnemyTarget = 0;

    public List<GameObject> enemyLock = new List<GameObject>();

    

    //to calculate local direction
    Vector3 prevPos;
    Vector3 Dir;
    Vector3 localDir;

    //character state
    public bool enterBattle { get; set; }
    public bool isDefensing { get; set; }
    public bool canMove { get; set; }
    
    public bool isSprinting { get; set; }
    public bool isDodge { get; set; }


    //move and rotate
    public float walkSpeed;
    public float SprintSpeed;
    private Vector3 MoveDir;


    //turning smooth so character can rotate smoothly
    public float turnSmoothVelocity;
    public float TurnSmoothTime = 0.1f;

    //ground check parameter
    public float onGroundRayDistance;


    //dodge
    public int dodgeSpeed;

    //Camera
    public Transform cam;

    //input
    Vector2 direction;
    private InputMaster input;

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


    private void Awake()
    {
        canMove = true;
        input = new InputMaster();
        myInput();
        rigidBodyChar = GetComponent<Rigidbody>();
    }


    
    void FixedUpdate()
    {

        
    }

   

    private void Update()
    {
        checkAnimationState();


        if (canMove)
        {
            if (enterBattle)
            {

                BattleMode();
            }
            else
            {
                movement();
            }
        }
        
    }

    private void checkAnimationState()
    {
        //check animation state and restrict movement
        if (isPlaying("BasicAttack")) canMove = false;
        else if (AnimController.isPlaying("Defense")) canMove = false;
        else canMove = true;
    }



    private void myInput()
    {
        //direction input value
        input.Player.movement.performed += ctx => direction = ctx.ReadValue<Vector2>();
        input.Player.movement.canceled += _ => direction = new Vector2(0.0f, 0.0f);
        //dashSprintingd
        input.Player.Sprint.started += _ => StartCoroutine(dodge());
        input.Player.Sprint.performed += _ => isSprinting = true;
        //defense
        input.GamePlay.defense.performed += _ => defense(true);
        input.GamePlay.defense.canceled += _ => defense(false) ;
        //change enemy target
        input.GamePlay.LockOnNextTarget.performed += _ => changeEnemyTarget();
        
    }

    #region Player Battle Mode

    private void BattleMode()
    {
        if (isSprinting)
        {
            movement();
        }
        else
        {
            
            if(direction.magnitude >= 0.1f)
            {
                Vector3 target = enemyLock[currentEnemyTarget].transform.position - transform.position;//if changeEnemyTarget(), change target to next enemy
                Vector3 newDir = Vector3.RotateTowards(transform.forward, target, 20 * Time.deltaTime, 0.0f);
                transform.rotation = Quaternion.LookRotation(newDir);
                MoveDir = new Vector3(direction.x, 0, direction.y);
                transform.position += MoveDir.normalized * Time.deltaTime * walkSpeed;
                battleModeAnimation();
            }
            else
            {
                //idle anim
                AnimController.idle();
                isSprinting = false;
            }
        }

    }

    private void battleModeAnimation()
    {
        Dir = transform.position - prevPos;
        localDir = transform.InverseTransformDirection(Dir).normalized;//have to normalized
        localDir.y = 0;

        //for animation when entering battle
        if (localDir.z < -0.5)
        {
            if (localDir.x > 0.5) AnimController.strafeRightBackward();
            else if (localDir.x < -0.5) AnimController.strafeLeftBackward();
            else AnimController.walkBackward();

        }
        else if (localDir.z > 0.5)
        {
            if (localDir.x > 0.5) AnimController.strafeRightForward();
            else if (localDir.x < -0.5) AnimController.strafeLeftForward();
            else AnimController.walkforward();

        }
        else if (localDir.x < -0.5)
        {
            if (localDir.z > 0.5) AnimController.strafeLeftForward();
            else if (localDir.z < -0.5) AnimController.strafeLeftBackward();
            else AnimController.strafeLeft();

        }
        else if (localDir.x > 0.5)
        {
            if (localDir.z > 0.5) AnimController.strafeRightForward();
            else if (localDir.z < -0.5) AnimController.strafeRightBackward();
            else AnimController.strafeRight();
        }
        prevPos = transform.position;
    }
    private void changeEnemyTarget()
    {
        currentEnemyTarget++;
        currentEnemyTarget %= enemyLock.Count;
    }
    #endregion




    private void movement()//for basic movement
    {
        //character movement and rotation   
        float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, TurnSmoothTime);//for smooth rotation
        MoveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

        //for walk and sprinting
        if (direction.magnitude >= 0.1f)
        {
            //check if sprinting or not
            if (isSprinting)
            {
                transform.position += MoveDir.normalized * Time.deltaTime * SprintSpeed;
                AnimController.runForward();
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);// rotate to direction facing
            }
            else
            {
                transform.position += MoveDir.normalized * Time.deltaTime * walkSpeed;
                AnimController.walkforward();
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);// rotate to direction facing
            }

            transform.rotation = Quaternion.Euler(0f, angle, 0f);// rotate to direction facing
        }
        else
        {
            //idle anim
            AnimController.idle();
            isSprinting = false;
        }

    }

    
    private void defense(bool value)
    {
        AnimController.Defense(value);
            
    }

    IEnumerator dodge()//same as sprinting but at initial
    {
        if(AnimController.isPlaying("Dash") == false && isDodge == false)
        {
            isDodge = true;

            //animation
            AnimController.dodge(isDodge);

            float targetAngle = Mathf.Atan2(direction.x, direction.y) * Mathf.Rad2Deg;
            if (direction.x == 0 && direction.y == 0)//if no input direction, dash forward
            {
                rigidBodyChar.velocity += transform.forward * dodgeSpeed;
            }
            else
            {
                transform.rotation = Quaternion.Euler(0f, targetAngle, 0f);// rotate to direction facing
                rigidBodyChar.velocity += transform.forward * dodgeSpeed;
            }

            yield return new WaitForSeconds(.2f);


            //after dash player can continue to run
            isDodge = false;
            if (direction.magnitude == 0) AnimController.isSprinting(false);
            else AnimController.isSprinting(true);
        }
        
    }

    

 /*   private bool checkisGrounded()
    {
        RaycastHit hit;
        Ray GroundRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(GroundRay, out hit, onGroundRayDistance))
        {
            if (hit.collider.tag == "ground")
            {
                return true;
            }
        }
        return false;
    }*/


    public bool isPlaying(string stateTagName)
    {

        if (AnimController.AnimPlayer.GetCurrentAnimatorStateInfo(0).IsTag(stateTagName) &&
            AnimController.AnimPlayer.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    bool isDone(string stateTagName)
    {
        if (AnimController.AnimPlayer.GetCurrentAnimatorStateInfo(0).IsTag(stateTagName) &&
            AnimController.AnimPlayer.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            return true;
        }
        else
        {
            return false;
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
