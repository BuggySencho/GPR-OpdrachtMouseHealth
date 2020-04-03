using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStates : MonoBehaviour
{
    public enum states { PATROL, CHASE, ATTACK};
    
    public states CurrentState { get; set; }

    private Transform player;
    public Transform Player { get { return player; } }

    [SerializeField] private float[] distances = { 5, 15};

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        //Debug.Log(distance);

        if (distance > distances[1])
        {
            CurrentState = states.PATROL;
        }
        else if(distance >= distances[0] && distance <= distances[1])
        {
            CurrentState = states.CHASE;
        }
        else
        {
            CurrentState = states.ATTACK;
        }        
    }
}
