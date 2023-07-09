using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopItem : MonoBehaviour
{
    List<GameObject> enemy;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the list
        enemy = new List<GameObject>();

        // Find all game objects with the tag "Enemy" and add them to the list
        GameObject[] enemyObjects = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject obj in enemyObjects)
        {
            enemy.Add(obj);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            foreach (GameObject obj in enemy)
            {
                obj.GetComponent<EnemyMovement>().StopChasing();
            }
        }

    }

}
