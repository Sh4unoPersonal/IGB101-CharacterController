using UnityEngine;

public class DoorController_SA : MonoBehaviour
{
    private Animator _anim;
    private bool _isDoorOpen = false;
    private UIManager_SA _uiManager;
    private GameManager_SA _gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
        _uiManager = GameObject.FindGameObjectsWithTag("UIManager_SA")[0].GetComponent<UIManager_SA>();
        _gameManager = GameObject.FindGameObjectsWithTag("GameManager_SA")[0].GetComponent<GameManager_SA>();
    }


    public void ToggleDoor()
    {
        _isDoorOpen = !_isDoorOpen;
        _anim.SetBool("IsOpen", _isDoorOpen);
        _uiManager.UpdateDoorText(true, _isDoorOpen);

        // Update objective Text
        _gameManager._hasUsedDoor = true;
        _uiManager.UpdateObjectiveText(_gameManager._hasUsedDoor, _gameManager._levelComplete);
    }

    public bool IsDoorOpen
    {
        get { return _isDoorOpen; }
    }
}
