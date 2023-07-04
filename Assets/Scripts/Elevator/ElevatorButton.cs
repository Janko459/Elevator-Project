using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorButton : MonoBehaviour
{
    public int callFloor = 0;
    //[SerializeField] private Floor _floorScript;
    [SerializeField] private ElevatorMovement _elevatorMoveScript;
    [SerializeField] private GameObject _animatedButton;
    private Animator anim;
    void Start()
    {
        anim = _animatedButton.GetComponent<Animator>();
    }
    public void CallToFloor()
    {
        _elevatorMoveScript.TravelToFloor(callFloor);
        //_floorScript.ShutDoor();
        anim.SetTrigger("Pushed");
    }
}
