using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement_SA : MonoBehaviour{

    public Animator anim;

    public float rotSpeed = 10;

    private CharacterController _characterController;

    // Door 
    private bool _canUseDoor = false;
    private DoorController_SA _doorController;

    // Swimming
    private bool _isSwimming = false;
    [SerializeField]
    private float _swimSpeed = 3f;

    // Start is called before the first frame update
    void Start()
    {
        _characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){

        ForwardMovement();

        Turning();

        // Allow emotes on land
        if (!anim.GetBool("Swimming"))
        {
            Emotes();
        }
        

        TryToggleDoor();

        if (_isSwimming)
        {
            SwimmingMovement();
        }
            

    }

    void TryToggleDoor()
    {
        if (Input.GetKeyDown("e") && _canUseDoor)
        {
            if (_doorController != null)
            {
                {
                    _doorController.ToggleDoor();
                }
            }
            else if (Input.GetKeyUp("e"))
            {
                //anim.SetBool("Opening Door", false);
            }
        }
    }

    void SwimmingMovement()
    {
        if (Input.GetKey("w"))
        {
            _characterController.Move(transform.forward * _swimSpeed * Time.deltaTime);
            anim.SetBool("TreadingWater", false);
        }
        else if (Input.GetKeyUp("w"))
        {
            anim.SetBool("TreadingWater", true);
        }

    }

    private void ForwardMovement(){
        if(Input.GetKey("w")){
            anim.SetBool("Walking", true);
            if (Input.GetKey(KeyCode.LeftShift)){
                anim.SetBool("Running", true);
            } else{
                anim.SetBool("Running", false);
            }
        } else if (Input.GetKeyUp("w")) {
            anim.SetBool("Walking", false);
            anim.SetBool("Running", false);
        }
    }

    private void Turning(){
        if (Input.GetKey("a")) {
            transform.Rotate(0, -rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Left", true);
        } else if (Input.GetKey("d")) {
            transform.Rotate(0, rotSpeed * 15 * Time.deltaTime, 0, Space.World);
            anim.SetBool("Turn Right", true);
        } else {
            anim.SetBool("Turn Left", false);
            anim.SetBool("Turn Right", false);
        }
    }

    // Custom emotes.
    // Custom input mapping.
    private void Emotes(){
        if(Input.GetKeyDown("1"))
        { 
            anim.SetBool("Emoting", true);
            anim.SetInteger("EmoteID", 0);
        }
        else if(Input.GetKeyDown("2"))
        {
            anim.SetBool("Emoting", true);
            anim.SetInteger("EmoteID", 1);
        }
        else
        {
            anim.SetBool("Emoting", false);
        }
    }

    public void CanUseDoor(bool canUseDoor, DoorController_SA doorController)
    {
        _canUseDoor = canUseDoor;
        _doorController = doorController;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            anim.SetBool("Swimming", true);
            _isSwimming = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            anim.SetBool("Swimming", false);
            _isSwimming = false;
        }
    } 
}
