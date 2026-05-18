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
                _playerMovement.CanUseDoor(true, this);
            }
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement _playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            if (_playerMovement != null)
            {
                _playerMovement.CanUseDoor(false, this);
            }
        }
    }

    public void ToggleDoor()
    {
        _anim.SetBool("IsOpen", (!_anim.GetBool("IsOpen")));

    }
}
