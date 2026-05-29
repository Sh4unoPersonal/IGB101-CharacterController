using UnityEngine;

public class PickupRiaan : MonoBehaviour
{
    GameManagerRiaan gameManager;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManagerRiaan").GetComponent<GameManagerRiaan>();
    }    
    private void OnTriggerEnter(Collider otherObJect)
    {
        if(otherObJect.transform.tag == "Player")
        {
            gameManager.currentPickups += 1;
            Destroy(this.gameObject);
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
