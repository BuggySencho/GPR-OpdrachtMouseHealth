using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyStates statesScript;

    private Rigidbody rb;

    [SerializeField] private float speed = 3;
    [SerializeField] private int rotation = 0;

    private bool alreadyStarted = false;

    // Start is called before the first frame update
    void Start()
    {
        statesScript = GetComponent<EnemyStates>();
        rb = GetComponent<Rigidbody>();
        rotation = Random.Range(0, 360);

        StartCoroutine(DirectionChooser());
    }

    private void Update()
    {
        if (statesScript.CurrentState == EnemyStates.states.PATROL)
        {
            speed = 3;
            if (!alreadyStarted)
            {
                StartCoroutine(DirectionChooser());
            }

            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.y = rotation;
            Debug.Log(newRotation);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(newRotation), 0.3f);
        }
        else
        {
            speed = 6;
            transform.LookAt(new Vector3(statesScript.Player.position.x, transform.position.y, statesScript.Player.position.z));
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 newVel = transform.forward;
        newVel.y = rb.velocity.y;

        rb.velocity = newVel * speed;
    }  

    private IEnumerator DirectionChooser()
    {
        alreadyStarted = true;
        while (statesScript.CurrentState == EnemyStates.states.PATROL)
        {
            yield return new WaitForSeconds(10);

            if (statesScript.CurrentState == EnemyStates.states.PATROL)
            {
                rotation = Random.Range(0, 360);
            }            
        }

        alreadyStarted = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            collision.transform.GetComponent<PlayerHealth>().Damage(1);
        }
    }
}
