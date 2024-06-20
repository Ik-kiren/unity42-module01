using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public GameObject objectToChange;
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision col)
    {
        if (gameObject.layer == 0)
        {
            if (objectToChange.layer == 0)
            {
                objectToChange.layer = col.collider.gameObject.GetComponent<PlayerController>().colorLayer;
                objectToChange.GetComponent<Renderer>().material.color = col.collider.gameObject.GetComponent<Renderer>().material.color;
            }
            gameObject.GetComponent<Renderer>().material.color = col.collider.gameObject.GetComponent<Renderer>().material.color;
        }
    }

    void Update()
    {
        
    }
}
