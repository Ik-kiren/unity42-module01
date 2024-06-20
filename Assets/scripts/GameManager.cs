using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Camera sceneCamera;
    public Behaviour johnBehaviour;
    public Behaviour claireBehaviour;
    public Behaviour thomasBehaviour;
    Behaviour currentBehaviourActive;

    bool johnOnExit = false;
    bool claireOnExit = false;
    bool thomasOnExit = false;

    Scene currentScene;

    void CheckPlayersOnExit()
    {
        if (thomasBehaviour.gameObject.GetComponent<PlayerController>().rightCollision && thomasBehaviour.gameObject.GetComponent<PlayerController>().leftCollision)
            thomasOnExit = true;
        else
            thomasOnExit = false;

        if (johnBehaviour.gameObject.GetComponent<PlayerController>().rightCollision && johnBehaviour.gameObject.GetComponent<PlayerController>().leftCollision)
            johnOnExit = true;
        else
            johnOnExit = false;

        if (claireBehaviour.gameObject.GetComponent<PlayerController>().rightCollision && claireBehaviour.gameObject.GetComponent<PlayerController>().leftCollision)
            claireOnExit = true;
        else
            claireOnExit = false;

    }

    void Start()
    {
        currentScene = SceneManager.GetActiveScene();

        currentBehaviourActive = thomasBehaviour;
        johnBehaviour.enabled = false;
        claireBehaviour.enabled = false;
    }

    void Update()
    {
        if (!currentBehaviourActive.GetComponent<PlayerController>().isOut)
            sceneCamera.transform.position = new Vector3(sceneCamera.transform.position.x, currentBehaviourActive.gameObject.transform.position.y, currentBehaviourActive.gameObject.transform.position.z);
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentBehaviourActive != claireBehaviour)
        {
            currentBehaviourActive.enabled = false;
            claireBehaviour.enabled = true;
            currentBehaviourActive = claireBehaviour;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && currentBehaviourActive != thomasBehaviour)
        {
            currentBehaviourActive.enabled = false;
            thomasBehaviour.enabled = true;
            currentBehaviourActive = thomasBehaviour;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && currentBehaviourActive != johnBehaviour)
        {
            currentBehaviourActive.enabled = false;
            johnBehaviour.enabled = true;
            currentBehaviourActive = johnBehaviour;
        }

        if (Input.GetKey(KeyCode.R))
            SceneManager.LoadScene(currentScene.name);

        CheckPlayersOnExit();

        if (thomasOnExit && claireOnExit && johnOnExit)
        {
            if (currentScene.buildIndex + 1 >= SceneManager.sceneCountInBuildSettings)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(currentScene.buildIndex + 1);
        }

        if (currentBehaviourActive.gameObject.GetComponent<PlayerController>().gameEnd)
            SceneManager.LoadScene(currentScene.name);
    }
}
