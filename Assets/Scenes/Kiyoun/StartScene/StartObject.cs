using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartObject : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * 2f);

        if (transform.position.x > 9f || transform.position.x < -12f)
        {
            transform.Rotate(0f, 180f, 0f);
        }
    }
}
