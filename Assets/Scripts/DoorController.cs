using UnityEngine;

public class DoorController : MonoBehaviour
{
    private Animator _anim;
    private bool _isDoorOpen = false;
    private UIManager _uiManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _anim = GetComponent<Animator>();
        _uiManager = GameObject.FindGameObjectsWithTag("UIManager")[0].GetComponent<UIManager>();
    }


    public void ToggleDoor()
    {
        _isDoorOpen = !_isDoorOpen;
        _anim.SetBool("IsOpen", _isDoorOpen);
        _uiManager.UpdateDoorText(true, _isDoorOpen);
    }

    public bool IsDoorOpen
    {
        get { return _isDoorOpen; }
    }
}
