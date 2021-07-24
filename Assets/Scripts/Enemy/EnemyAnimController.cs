using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public Animator AnimPlayer;
    private float runSpeed;
    private float velocityX;
    private float velocityZ;
    [SerializeField]
    private float acceleration;
    [SerializeField]
    private float deceleration;


    private void Awake()
    {
    }



    public void idle()
    {
        blendMovement(ref velocityX, 0);
        blendMovement(ref velocityZ, 0);
        AnimPlayer.SetFloat("VelocityX", velocityX);
        AnimPlayer.SetFloat("VelocityZ", velocityZ);
    }

    public void walkForward()
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

    //combat animation
    public void attack(bool val)
    {
        if(val) AnimPlayer.SetBool("canAttack", true);
        else AnimPlayer.SetBool("canAttack", false);

    }


    public void blendMovement(ref float velocity, float treshold)// parameter by reference to velocity so it changed directly
    {
        if (velocity < treshold)
        {
            velocity += Time.deltaTime * acceleration;
            if (velocity > treshold)
            {
                velocity = treshold;
            }
        }
        else if (velocity > treshold)
        {
            velocity += Time.deltaTime * deceleration;
            if (velocity < treshold)
            {
                velocity = treshold;
            }
        }

    }

    private void Update()
    {
    }
}
