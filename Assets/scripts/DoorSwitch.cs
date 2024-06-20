using UnityEngine;

public class DoorSwitch : MonoBehaviour
{

    public GameObject door;
    Vector3 doorInitalPosition;
    public bool openUp = false;
    void Start()
    {
        doorInitalPosition = door.transform.position;
    }

    void OnCollisionEnter(Collision col) 
    {
        if (door.tag == col.gameObject.GetComponent<PlayerController>().colorName)
        {
            if (!openUp)
                door.transform.position = new Vector3(doorInitalPosition.x - 4, doorInitalPosition.y, doorInitalPosition.z);
            else
                door.transform.position = new Vector3(doorInitalPosition.x , doorInitalPosition.y + 2, doorInitalPosition.z);
        }

    }

    void OnCollisionExit()
    {
        door.transform.position = doorInitalPosition;
    }

    void Update()
    {
        
    }
}
