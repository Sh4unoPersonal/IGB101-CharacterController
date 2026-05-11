using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameManager _gameManager;
    MeshRenderer _meshRenderer;

    AudioSource _audioSource;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectsWithTag("GameManager")[0].GetComponent<GameManager>();
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _audioSource.Play();
            _gameManager._currentPickups++;
            _meshRenderer.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

}
