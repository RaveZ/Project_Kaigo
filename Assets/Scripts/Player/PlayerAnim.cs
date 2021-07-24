using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator AnimPlayer;
    private float runSpeed;
    [HideInInspector]
    public float velocityX;
    [HideInInspector]
    public float velocityZ;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float deceleration;


    private void Awake()
    {
    }


    #region Player Locomotion Animation
    public void idle()
    {
        blendMovement(ref velocityX, 0);
        blendMovement(ref velocityZ, 0);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void walkforward()
    {
        blendMovement(ref velocityX, 0);
        blendMovement(ref velocityZ, 0.7f);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void runForward()
    {
        blendMovement(ref velocityX, 0);
        blendMovement(ref velocityZ, 1);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void walkBackward()
    {
        blendMovement(ref velocityX, 0);
        blendMovement(ref velocityZ, -1);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void strafeLeft()
    {
        blendMovement(ref velocityX, -1);
        blendMovement(ref velocityZ, 0);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void strafeRight()
    {
        blendMovement(ref velocityX, 1);
        blendMovement(ref velocityZ, 0);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void strafeRightBackward()
    {
        blendMovement(ref velocityX, 0.5f);
        blendMovement(ref velocityZ, -1);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }
    public void strafeLeftBackward()
    {
        blendMovement(ref velocityX, -0.5f);
        blendMovement(ref velocityZ, -1);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void strafeLeftForward()
    {
        blendMovement(ref velocityX, -1);
        blendMovement(ref velocityZ, 0.5f);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void strafeRightForward()
    {
        blendMovement(ref velocityX, 1);
        blendMovement(ref velocityZ, 0.5f);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }
    #endregion

    #region Player Defense n Parry Animation
    //enter substate(defense)
    public void Defense(bool value)
    {
        AnimPlayer.SetBool("canDefense", value);
    }

    public void DefenseHit(int value)
    {
        AnimPlayer.SetInteger("DefenseHit", value);
    }

    #endregion 

    public void dodge(bool value)
    {
        AnimPlayer.SetBool("canDodge", value);
    }

    public void isSprinting(bool value)
    {
        AnimPlayer.SetBool("isSprinting", value);
    }

    public void getHit(bool value)
    {
        AnimPlayer.SetBool("getHit", value);
    }


    public void BasicAttack(bool value)
    {
        AnimPlayer.SetBool("isBasicAttack", value);
    }
    public void blendMovement(ref float velocity, float treshold)// parameter by reference to velocity so it changed directly
    {
        if(velocity < treshold)
        {
            velocity += Time.deltaTime * acceleration;
            if(velocity > treshold)
            {
                velocity = treshold;
            }
        }else if(velocity > treshold)
        {
            velocity += Time.deltaTime * deceleration;
            if(velocity < treshold)
            {
                velocity = treshold;
            }
        }
        
    }

    private void Update()
    {
    }

    public bool isPlaying(string stateTagName)
    {
        
        if (AnimPlayer.GetCurrentAnimatorStateInfo(0).IsTag(stateTagName) &&
            AnimPlayer.GetCurrentAnimatorStateInfo(0).normalizedTime < 1.0f)
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
        if (AnimPlayer.GetCurrentAnimatorStateInfo(0).IsTag(stateTagName) &&
            AnimPlayer.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

}
