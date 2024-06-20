using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == 12)
            Destroy(gameObject);
        if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<PlayerController>().colorLayer == gameObject.layer)
        {
            col.gameObject.GetComponent<PlayerController>().gameEnd = true;
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
