using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public GameObject left;
    public bool leftCollision = false;
    public GameObject right;
    public bool rightCollision = false;
    public int colorLayer = 0;
    public string colorName;
    bool isJumping = false;
    Rigidbody rb;
    public Vector3 jumpForce = new Vector3(0, 150, 0);
    public bool gameEnd = false;
    public bool isOut = false;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.layer == colorLayer && col.name == left.name)
            leftCollision = true;
        if (col.gameObject.layer == colorLayer && col.name == right.name)
            rightCollision = true;

        if (col.tag == "OutCollision")
            isOut = true;
        if (col.tag == "StageBorder")
            gameEnd = true;
    }

    void OnCollisionStay(Collision col)
    {
        isJumping = false;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.layer == colorLayer && col.name == left.name)
            leftCollision = false;
        if (col.gameObject.layer == colorLayer && col.name == right.name)
            rightCollision = false;

        isJumping = true;
    }

    void Update()
    {
        float xVel = Input.GetAxis("Horizontal");

        gameObject.transform.Translate(new Vector3(0, 0, xVel) * Time.deltaTime * speed);

        if (!isJumping && Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(jumpForce);
            isJumping = true;
        }
    }
}
