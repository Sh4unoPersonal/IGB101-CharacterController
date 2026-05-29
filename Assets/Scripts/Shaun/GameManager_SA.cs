using UnityEngine;
using UnityEngine.UI;

public class GameManager_SA : MonoBehaviour
{
    public GameObject _player;
    private UIManager_SA _uiManager;

     void Start()
    {
        _uiManager = GameObject.FindGameObjectsWithTag("UIManager_SA")[0].GetComponent<UIManager_SA>();
        _uiManager.UpdatePickupText(_currentPickups, _maxPickups);
    }


    // Audio Proximity Logic
    public AudioSource[] _audioSources;
    public float _audioProximityThreshold;

    // Pickups | Level Completion Logic
    public int _currentPickups = 0;
    [SerializeField]
    private int _maxPickups;
    public bool _levelComplete = false;

    // UI variable
    public bool _hasUsedDoor = false;

    public void GotPickupItem()
    {
        _currentPickups++;

        if (_currentPickups >= _maxPickups)
            _levelComplete = true;
        else
            _levelComplete = false;

        _uiManager.UpdatePickupText(_currentPickups, _maxPickups);
        _uiManager.UpdateObjectiveText(_hasUsedDoor, _levelComplete);

    }

}
