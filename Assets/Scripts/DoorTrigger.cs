using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private UIManager _uiManager;
    private DoorController _doorController; // Weidly, the controller is the child, so that the trigger will not rotate with the door.

    void Start()
    {
        _doorController = GetComponentInChildren<DoorController>();
        _uiManager = GameObject.FindGameObjectsWithTag("UIManager")[0].GetComponent<UIManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement _playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            DoorController _doorController = GetComponentInChildren<DoorController>();
            if (_playerMovement != null && _doorController != null)
            {
                _playerMovement.CanUseDoor(true, _doorController);
            }

            _uiManager.UpdateDoorText(true, _doorController.IsDoorOpen);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement _playerMovement = other.gameObject.GetComponent<PlayerMovement>();
            DoorController _doorController = GetComponentInChildren<DoorController>();
            if (_playerMovement != null && _doorController != null)
            {
                _playerMovement.CanUseDoor(false, _doorController);
            }

            _uiManager.UpdateDoorText(false, false); // No need to specify a real unused second parameter, but it is required by the method signature.
        }
    }
}
