using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement _playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (_playerMovement != null)
            {
                _playerMovement.CanOpenDoor(this);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Add door closing logic here, such as playing an animation or changing the door's state.
            Debug.Log("Player has exited the door trigger.");
        }
    }

    public void OpenDoor()
    {
        _anim.SetTrigger("OpenDoor");
    }
}
