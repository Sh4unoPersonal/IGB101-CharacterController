using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject _player;

    private UIManager _uiManager;

     void Start()
    {
        _uiManager = GameObject.FindGameObjectsWithTag("UIManager")[0].GetComponent<UIManager>();
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

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        _uiManager.UpdatePickupText(_currentPickups, _maxPickups);
    }

    void LevelCompleteCheck()
    {
        if (_currentPickups >= _maxPickups)
            _levelComplete = true;
        else
            _levelComplete = false;
    }

    

    // Play Audio Samples, when the Player is close.
    //void PlayAudioSamples()
    //{
    //    foreach (AudioSource audioSource in _audioSources)
    //    {
    //        float distance = Vector3.Distance(_player.transform.position, audioSource.transform.position);
    //        if (distance <= _audioProximityThreshold)
    //        {
    //            if (!audioSource.isPlaying)
    //                audioSource.Play();
    //        }
    //        else
    //        {
    //            if (audioSource.isPlaying)
    //                audioSource.Stop();
    //        }
    //    }
    //}
}
