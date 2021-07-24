using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefenseDetector : MonoBehaviour
{
    private InputMaster input;
    public PlayerAction playerAction;
    BoxCollider defenseCollider;
    public GameObject sparkFX;

    //for parry momentum
    float parryTimer;
    bool canParry;

    void Awake()
    {
        input = new InputMaster();
        myInput();
        defenseCollider = GetComponent<BoxCollider>();
    }


    private void myInput()
    {
        input.GamePlay.defense.performed += _ => setDefense(true);
        input.GamePlay.defense.canceled += _ => setDefense(false);
    }
    // Update is called once per frame
    void Update()
    {
        if (canParry) parryTimer += Time.deltaTime;
        else parryTimer = 0;
    }

    public void Parry()
    {
        if(parryTimer <= 0.15f)
        {
            print("parry!");
            print(parryTimer);
        }
    }

    #region Defense Function
    private void setDefense(bool value)
    {
        
        if (value)
        {
            canParry = true;
            switchDefense(value);
        }
        else
        {
            switchDefense(value);
            canParry = false;
        }
    }

    private void switchDefense(bool val)//enable and disable collider
    {
        defenseCollider.enabled = val;

    }

    private void DefenseHit(Transform hitPosition)
    {
        int defenseVariation = Random.Range(0, 2);
        StartCoroutine(onDefenseHit(defenseVariation));
        GameObject spark = Instantiate(sparkFX, transform.position, transform.rotation) as GameObject;
    }

    IEnumerator onDefenseHit(int val)
    {
        playerAction.rigidBodyChar.AddForce(-playerAction.transform.forward * 300);
        playerAction.AnimController.DefenseHit(val);
        yield return new WaitForEndOfFrame();//need change
        yield return new WaitForEndOfFrame();//need change

        playerAction.AnimController.DefenseHit(-1);

    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        //if hit, trigger animation
      
        DefenseHit(other.transform);
        Parry();
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
