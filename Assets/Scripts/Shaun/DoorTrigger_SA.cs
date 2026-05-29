using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    private UIManager_SA _uiManager;
    private DoorController_SA _doorController; // Weidly, the controller is the child, so that the trigger will not rotate with the door.

    void Start()
    {
        _doorController = GetComponentInChildren<DoorController_SA>();
        _uiManager = GameObject.FindGameObjectsWithTag("UIManager_SA")[0].GetComponent<UIManager_SA>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement_SA _playerMovement = other.gameObject.GetComponent<PlayerMovement_SA>();
            DoorController_SA _doorController = GetComponentInChildren<DoorController_SA>();
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
            PlayerMovement_SA _playerMovement = other.gameObject.GetComponent<PlayerMovement_SA>();
            DoorController_SA _doorController = GetComponentInChildren<DoorController_SA>();
            if (_playerMovement != null && _doorController != null)
            {
                _playerMovement.CanUseDoor(false, _doorController);
            }

            _uiManager.UpdateDoorText(false, false); // No need to specify a real unused second parameter, but it is required by the method signature.
        }
    }
}
