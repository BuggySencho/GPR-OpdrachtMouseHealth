using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;

    private Vector3 movement;
    [SerializeField] private float speed = 3;
    [SerializeField] private float turnSpeed = 3;

    private bool grounded = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        movement = new Vector3(0, 0, Input.GetAxis("Vertical"));

        transform.Rotate(0, Input.GetAxis("Horizontal") * turnSpeed, 0);

        //RaycastHit hit;
        //if (Physics.SphereCast(transform.position, 2f, -transform.up, out hit, 0.7f))
        //{
        //    if (!hit.collider.isTrigger)
        //    {
        //        Quaternion quat = Quaternion.LookRotation(Vector3.Cross(transform.right, hit.normal));
        //        grounded = true;
        //        transform.rotation = new Quaternion(quat.x, transform.rotation.y, quat.z, transform.rotation.w);
        //    }
        //}
        //else
        //{
        //    grounded = false;
        //    transform.rotation = new Quaternion(0, transform.rotation.y, 0, transform.rotation.w);
        //}
    }

    private void FixedUpdate()
    {
        Vector3 localVel = transform.TransformVector(movement);
        localVel *= speed;
        localVel.y = rb.velocity.y;

        rb.velocity = localVel;
    }
}
