using UnityEngine;

public class Pickup : MonoBehaviour
{
    GameManager_SA _gameManager;
    MeshRenderer _meshRenderer;
    AudioSource _audioSource;

    void Start()
    {
        _gameManager = GameObject.FindGameObjectsWithTag("GameManager_SA")[0].GetComponent<GameManager_SA>();
        _audioSource = GetComponent<AudioSource>();
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && _meshRenderer.enabled)
        {
            _audioSource.Play();
            _gameManager.GotPickupItem();
            _meshRenderer.enabled = false;
            Destroy(gameObject, 1f);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    

}
