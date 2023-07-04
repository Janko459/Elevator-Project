using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorStopers : MonoBehaviour
{
    private Animator anim;
    [SerializeField] private GameObject _doorWing;
    [SerializeField] private Floor _floorScript;
    [SerializeField] private ElevatorMovement _elevatorScript;
    private bool _sensorsOnline = false;
    void Start()
    {
        anim = _doorWing.GetComponent<Animator>();
    }
    void Update()
    {
        CheckWhileClosing();
    }
    //if doors are closing, there is possibility they might close on player
    //the sensors activate during closing animation, so they will detect player if they touch him
    //the elevator will shut down as an emergency (stop) and doors will open for player to get out, or in
    void CheckWhileClosing()
    {
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("Closing"))
        {
            _sensorsOnline = true;
        }
        else
        {
            _sensorsOnline = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerMovement>()) //sensors are always detecting player, but call function only if sensors are online
        {
            if (_sensorsOnline == true)
            {
                _floorScript.OpenDoor();
                _elevatorScript.EmergencyStop();
            }
        }
    }
}
