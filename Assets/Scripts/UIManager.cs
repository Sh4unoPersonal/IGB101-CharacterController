using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private Text _pickupText;
    private Text _doorText;

    void Awake()
    {
        _pickupText = GameObject.Find("PickupText").GetComponent<Text>();
        _doorText = GameObject.Find("DoorText").GetComponent<Text>();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        UpdateDoorText(false, false); // Don't care about second variable here
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdatePickupText(int currentPickups, int maxPickups)
    {
        _pickupText.text = "Pickups: " + currentPickups + "/" + maxPickups;

    }

    public void UpdateDoorText(bool canUseDoor, bool isDoorOpen)
    {
        if (canUseDoor)
            _doorText.text = isDoorOpen ? "Press E to close the door" : "Press E to open the door";
        else
            _doorText.text = "";
    }
     
}
