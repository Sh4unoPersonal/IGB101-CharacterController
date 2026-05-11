using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour{

    public Animator anim;

    public float rotSpeed = 10;

    // Door 
    private bool _canOpenDoor = false;
    private DoorController _doorController;

    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update(){

        ForwardMovement();

        Turning();

        Actions();

        TryOpenDoor();

    }

    void TryOpenDoor()
    {
        if (Input.GetKeyDown("e") && _canOpenDoor)
        {
            if (_doorController != null)
            {
                {
                    _doorController.OpenDoor();
                }
            }
            else if (Input.GetKeyUp("e"))
            {
                //anim.SetBool("Opening Door", false);
            }
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
    private void Actions(){
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

    public void CanOpenDoor(DoorController doorController)
    {
        _canOpenDoor = true;
        _doorController = doorController;
    }
}
