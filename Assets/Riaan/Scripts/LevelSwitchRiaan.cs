using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchRiaan : MonoBehaviour
{

    // Custom script, to get custom game managager, it is just different from mine (Shaun)
    GameManagerRiaan gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManagerRiaan")[0].GetComponent<GameManagerRiaan>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.levelComplete)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Debug.Log("Lets GOOO");
        }    
            

    }
}
