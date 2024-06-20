using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        col.collider.gameObject.GetComponent<PlayerController>().gameEnd = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
