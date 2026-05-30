using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerRiaan : MonoBehaviour
{
    public GameObject Player;
    //Pickup and Level Completion Logic
    public int currentPickups = 0;
    public int maxPickups = 5;
    public bool levelComplete = false;

    private void LevelCompleteCheck()
    {
        if (currentPickups >= maxPickups)
                levelComplete = true;
        else 
            levelComplete = false;
    }

    //Update is called once per frame
    void Update()
    {
        LevelCompleteCheck();
        UpdateGui();
    }
    public Text pickupText;

    private void UpdateGui()
    {
        pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;
    }
    //Audio Proximity Logic
    public AudioSource[] audioSources;
    public float audioProximity = 5.0f;

    //Loop for playing audio proximity events - AudioSource based
    private void PlayAudioSamples()
    {
        for (int i = 0; i < audioSources.Length; i++)
        {
            if(Vector3.Distance(Player.transform.position, audioSources[i].transform.position) <= audioProximity)
            {
                if (!audioSources[i].isPlaying)

                    audioSources[i].Play();
            }
        }
    }

    
}
