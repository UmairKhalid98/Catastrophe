using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private PlayerMovement move;
    private Vector3 attackDir;

    [SerializeField]
    private int attackRange;    
    private int attack;
    [SerializeField]
    private float forceAmount;
    [SerializeField]
    private float forceMultiplier;
    void Start()
    {
       
       
       attack = 0;
        move = GetComponent<PlayerMovement>();
        attackDir = new Vector3();
    }


        void Update() {
            // attackDir = Vector3.ClampMagnitude(attackDir,6);
            //        Debug.DrawRay(transform.position,attackDir,Color.blue);
            attackInputs();

            Debug.DrawRay(transform.position,attackDir,Color.blue);

            // Debug.Log((attackDir + transform.forward * attackRange).magnitude);

        }
    void FixedUpdate()
    {
        RaycastHit hit;
         // Bit shift the index of the layer (8) to get a bit mask
        int layerMask = 1 << 8;

        // This would cast rays only against colliders in layer 8.
        //We want to collide againast layer 8

        attackDir = move.getLookDirection();
        // attackDir = Vector3.ClampMagnitude(attack)
        if(Physics.Raycast(transform.position,attackDir,out hit,Mathf.Infinity,layerMask))
        {
                    //attack in look direction
                    if(attack == 1)
                    {
                            hit.transform.GetComponent<Rigidbody>().AddForce(attackDir * forceAmount * forceMultiplier * Time.fixedDeltaTime ,ForceMode.Impulse);
                    }
        }
    }
    void attackInputs()
    {
        //left mouse click to attack
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
                attack = 1;
        }
        else
        {
                attack = 0;
        }
    }

}