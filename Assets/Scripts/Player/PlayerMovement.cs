using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[DisallowMultipleComponent]
public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float movementSpeed = 50f;
    [SerializeField] float turnSpeed = 60f;
    [SerializeField] Thruster[] thruster;


    Transform myTransform;

    // Use this for initialization
    void Start()
    { 
        myTransform = transform;
    }


    // Update is called once per frame
    void Update ()
    {
        Turn();
        Thrust();
        

        if (Input.GetKey(KeyCode.LeftShift) == true || Input.GetKey("joystick button 4"))
        {
            movementSpeed = 100f;
        }
        else
        {
            movementSpeed = 50f;
        }
    }

    void Turn()
    {
        float yaw = turnSpeed * Time.deltaTime * Input.GetAxis("Horizontal"); //input * turn speed * Time
        float pitch = turnSpeed * Time.deltaTime * Input.GetAxis("Pitch"); 
        float roll = turnSpeed * Time.deltaTime * Input.GetAxis("Roll"); 

        myTransform.Rotate(-pitch, yaw, -roll);
    }

    void Thrust()
    {
        //if we start to thrust, call Thruster.Activate()
        //when we stop thrusting, call Thruster.Activate(false)

        if (Input.GetAxis("Vertical") > 0)
        {


            myTransform.position += myTransform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical");
            foreach (Thruster t in thruster)
            {
                t.Intensity(Input.GetAxis("Vertical"));
            }
        }

       /* if(Input.GetKeyDown(KeyCode.W))
        {
            foreach (Thruster t in thruster)
            {
                t.Activate();
            }
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            foreach (Thruster t in thruster)
            {
                t.Activate(false);
            }
        }*/
    }
}
  