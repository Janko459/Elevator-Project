using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorSummonButton : MonoBehaviour
{
    [SerializeField] private ElevatorMovement _elevatorMoveScript;
    [SerializeField] private int _thisFloorNumber = 0;
    private bool _buttonActive = false;

    public void SummonElevator()
    {
        _elevatorMoveScript.TravelToFloor(_thisFloorNumber); //calls elevator script and gives it this floor number while also starting up elevator
    }
    void Update()
    {
        if(_buttonActive == true) //if button zone is active an player is in it, he will be able to press F to summon elevator
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                SummonElevator();
            }
        }
    }
    void OnTriggerEnter(Collider other) //activates button to press when player enters button press zone
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _buttonActive = true; 
            if (InfoManager.infoManagerInstance != null) //calls single manager, as to not connect display to every single button zone present on scene in inspector
            {
                InfoManager.infoManagerInstance.PressButtonInfo();
            }
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerMovement>())
        {
            _buttonActive = false;
            if (InfoManager.infoManagerInstance != null)
            {
                InfoManager.infoManagerInstance.UnpressButtonInfo();
            }
        }
    }
}
