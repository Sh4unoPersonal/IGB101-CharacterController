using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitchRiaan : MonoBehaviour
{
    GameManagerRiaan GameManager;
    public string nextLevel;

    //Start is called before the first frame update
    void Start()
    {
        GameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerRiaan>();
    }

    private void OnTriggerEnter(Collider otherObject)
    {
        if(otherObject.transform.tag == "Player")
        {
            if (GameManager.levelComplete)
            {
                SceneManager.LoadScene(nextLevel);
            }
        }
    }
}
