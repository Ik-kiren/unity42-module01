using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootBullets : MonoBehaviour
{

    public GameObject bullet;

    public int shootTimer = 2;
    float timer = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= shootTimer)
        {
            GameObject clone;
            clone = Instantiate(bullet, gameObject.transform);
            clone.layer = gameObject.layer;
            clone.GetComponent<Renderer>().material.color = gameObject.GetComponent<Renderer>().material.color;
            clone.GetComponent<Rigidbody>().velocity = transform.TransformDirection(Vector3.up * -3);
            timer = 0;
        }
    }
}
