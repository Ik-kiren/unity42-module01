using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    Vector3 initialPosition;
    int direction = -1;
    public float leftOffset = 3;
    public float rightOffset = 3;
    public bool changeAxe = false;

    bool blocked = false;
    void Start()
    {
        initialPosition = gameObject.transform.position;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.collider.gameObject.tag == "Player" &&
            gameObject.transform.position.y > col.collider.gameObject.transform.position.y && direction == 1)
                blocked = true;

    }
    
    void OnCollisionStay(Collision col) 
    {
        if (col.collider.gameObject.tag == "Player" &&
            gameObject.transform.position.y > col.collider.gameObject.transform.position.y && direction == 1)
                blocked = true;
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.gameObject.tag == "Player" &&
            gameObject.transform.position.y > col.collider.gameObject.transform.position.y && direction == 1)
                blocked = false;
    }

    void Update()
    {
        if (!changeAxe && !blocked)
        {
            if (gameObject.transform.position.z < initialPosition.z - leftOffset)
            {
                direction = -1;
            }
            else if (gameObject.transform.position.z > initialPosition.z + rightOffset)
            {
                direction = 1;
            }

            if (direction == -1)
            {
                gameObject.transform.Translate(new Vector3(0, 0, 1) * Time.deltaTime);
            }
            else
            {
                gameObject.transform.Translate(new Vector3(0, 0, -1) * Time.deltaTime);
            }
        }
        else if (!blocked)
        {
            if (gameObject.transform.position.y < initialPosition.y - leftOffset)
            {
                direction = -1;
            }
            else if (gameObject.transform.position.y > initialPosition.y + rightOffset)
            {
                direction = 1;
            }

            if (direction == -1)
            {
                gameObject.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            }
            else
            {
                gameObject.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            }
        }
    }
}
