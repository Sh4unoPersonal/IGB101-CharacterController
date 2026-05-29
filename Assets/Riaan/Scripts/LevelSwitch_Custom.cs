using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch_Custom : MonoBehaviour
{
    GameManagerRiaan gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManagerRiaan")[0].GetComponent<GameManagerRiaan>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager.levelComplete)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        Debug.Log("Player has entered the level switch trigger.");
    }
}
