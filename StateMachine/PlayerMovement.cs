using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Physics
    private Rigidbody rb;

    private Vector3 movement;
    private Vector3 movementForce;

    [SerializeField] private float speed = 3;
    [SerializeField] private float maxSpeed = 20;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
  
        movement = new Vector3(moveHorizontal, 0, moveVertical);
        movement.Normalize();

        Vector3 tempVect = transform.position + Camera.main.transform.TransformVector(movement);
        Quaternion rot;
        rot = transform.rotation;
        transform.LookAt(tempVect);
        transform.rotation = new Quaternion(rot.x, transform.rotation.y, 0, transform.rotation.w);
    }

    void FixedUpdate()
    {
        Acceleration();
        
        Vector3 tempVect = Camera.main.transform.TransformVector(movement);
        tempVect *= speed;
        tempVect.y = rb.velocity.y;
        rb.velocity = tempVect;
    }

    private void Acceleration()
    {
        if (speed <= maxSpeed)
        {
            float acc = Mathf.Abs(movement.z) + Mathf.Abs(movement.x);

            if (acc > 1)
            {
                acc = 1;
            }

            if (acc > 0.01f)
            {                
                speed += 0.5f * acc;
            }
            else
            {
                if (speed > 0)
                {
                    speed = 0;
                }
            }
        }
    }
}
