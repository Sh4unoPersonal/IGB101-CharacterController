using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject _player;

    public Text _pickupText;

    // Audio Proximity Logic
    public AudioSource[] _audioSources;
    public float _audioProximityThreshold;

    // Pickups | Level Completion Logic
    public int _currentPickups = 0;
    public int _maxPickups;
    public bool _levelComplete = false;

    // Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGUI();
        //PlayAudioSamples();
    }

    void LevelCompleteCheck()
    {
        if (_currentPickups >= _maxPickups)
            _levelComplete = true;
        else
            _levelComplete = false;
    }

    void UpdateGUI()
    {
        _pickupText.text = "Pickups: " + _currentPickups + "/" + _maxPickups;

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
