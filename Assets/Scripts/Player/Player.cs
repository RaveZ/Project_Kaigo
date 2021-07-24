using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerAction))]
public class Player : MonoBehaviour
{
    public static class PlayerMain
    {
        public static float PlayerHealth;
    }
    public float maxHealth;
    public float maxStamina;
    public float health { get; set; }
    public float stamina { get; set; }

    


      



    //method tab
    private void Awake()
    {

        health = maxHealth;
        stamina = maxStamina;
    }

    
    void FixedUpdate()
    {

        
        
    }

    private void Update()
    {

    }

    

    

    
}
 