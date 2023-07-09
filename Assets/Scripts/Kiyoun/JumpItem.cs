using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpItem : MonoBehaviour
{
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player"){
            Debug.Log("JumpItem");
            player.GetComponent<PlayerManager>().isJump = true;
            Destroy(gameObject);
        }
    }


}
