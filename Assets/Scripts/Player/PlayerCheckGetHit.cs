using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCheckGetHit : MonoBehaviour
{
    public PlayerAction playerAction;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "EnemyWeapon")
        {
            StartCoroutine(onGetHit());
        }
    }

    IEnumerator onGetHit()
    {
        playerAction.rigidBodyChar.AddForce(-playerAction.transform.forward * 300);
        playerAction.AnimController.getHit(true);
        yield return new WaitForEndOfFrame();
        playerAction.AnimController.getHit(false);
    }
}
