using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    NavMeshAgent enemyAgent;
    Transform targetTransform;
    public bool isChasing;
    // Start is called before the first frame update
    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();   
        targetTransform = GameObject.FindWithTag("Player").transform;
        isChasing = true;
        InvokeRepeating("IncreaseSpeed", 3f, 3f);
    }
    // Update is called once per frame
    void Update()
    {
        enemyAgent.SetDestination(targetTransform.position);
        //increase speed every 3 seconds
    }

    public void ChasePlayer(){
        enemyAgent.isStopped = false;
    }
    public void StopChasing(){
        enemyAgent.isStopped = true;
        Invoke("ChasePlayer", 3f);
    }
    void IncreaseSpeed(){
        enemyAgent.speed += 0.05f;
        enemyAgent.angularSpeed += 5f;
    }
}
