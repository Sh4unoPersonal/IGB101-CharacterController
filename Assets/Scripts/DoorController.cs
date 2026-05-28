using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _anim;
    private bool _isDoorOpen = false;
    private UIManager _uiManager;
    private GameManager _gameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
        _uiManager = GameObject.FindGameObjectsWithTag("UIManager")[0].GetComponent<UIManager>();
        _gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
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
