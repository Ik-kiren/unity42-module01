using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject linkedTeleporter;

    public bool teleporterCooldown = false;
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (!teleporterCooldown)
        {
            col.transform.position = linkedTeleporter.transform.position;
            linkedTeleporter.GetComponent<TeleportPlayer>().teleporterCooldown = true;
        }
    }

    void OnTriggerExit()
    {
        teleporterCooldown = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
