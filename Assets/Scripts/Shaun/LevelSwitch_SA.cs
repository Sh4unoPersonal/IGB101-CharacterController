using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch_SA : MonoBehaviour
{
    GameManager_SA gameManager;
    public string nextLevelName;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.FindGameObjectsWithTag("GameManager_SA")[0].GetComponent<GameManager_SA>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && gameManager._levelComplete)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
