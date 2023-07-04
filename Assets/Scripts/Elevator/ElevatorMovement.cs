using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ElevatorMovement : MonoBehaviour
{
    [SerializeField] private Transform _thisElevator;
    public int currentFloorNumber;
    public int designatedFloorNumber;
    [SerializeField] private List<Transform> _floors;
    [SerializeField] private float _speed;
    private bool _reachedDestination = false;
    [SerializeField] private List<TMPro.TextMeshProUGUI> _floorDisplayPanels;
    [SerializeField] private float _timeToStop = 2.5f;
    [SerializeField] private float _waitForDoorsToClose = 1.5f;
    private Floor _floorScript;
    //sfx
    [SerializeField] private List<AudioSource> _sounds;
    private int _elevatorLoopSFX = 0;
    private int _elevatorStartSFX = 1;
    private int _elevatorOutSFX = 2;

    void Update()
    {
        if (_reachedDestination == false)
        {
            float step = _speed * Time.deltaTime;
            _thisElevator.transform.position = Vector3.MoveTowards(_thisElevator.transform.position, _floors[designatedFloorNumber].position, step);
        }
    }
    void OnTriggerEnter(Collider other) //on touching floor trigger will check if its called floor 
    {
        if (other.GetComponent<Floor>())
        {
            _floorScript = other.GetComponent<Floor>();
            currentFloorNumber = _floorScript.floorNumber;
            for (int i = 0; i < _floorDisplayPanels.Count; i++) //update visual panels displaying on which floor elevator currently is
            {
                    _floorDisplayPanels[i].text = "" + currentFloorNumber;
            }
            if (designatedFloorNumber == currentFloorNumber)
            {
                StartCoroutine(ElevatorStopping());
            }
            else if (designatedFloorNumber != currentFloorNumber)
            {
                _reachedDestination = false;
            }
        }
    }
    IEnumerator ElevatorStopping() //time for elevator to set up properly + open door + change music
    {
        yield return new WaitForSeconds(_timeToStop);
        EmergencyStop();
        _floorScript.OpenDoor();
        _sounds[_elevatorOutSFX].Play();
        //Debug.Log("Welcome on " + currentFloorNumber + " floor!");
    }
    IEnumerator ElevatorStarting(int floorNumber) //waits for closing of the door
    {
        yield return new WaitForSeconds(_waitForDoorsToClose);
        designatedFloorNumber = floorNumber;
        _reachedDestination = false;
        _sounds[_elevatorLoopSFX].volume = 1;
        _sounds[_elevatorStartSFX].Play();
        Debug.Log("Travelling to floor " + floorNumber + "!");
    }
    public void TravelToFloor(int floorNumber) // takes called floor number and sets update function in motion
    {
        if (currentFloorNumber != floorNumber) //checks if elevator isnt already on the called floor
        {
            _floorScript.ShutDoor();
            StartCoroutine(ElevatorStarting(floorNumber));
        }
        else if (currentFloorNumber == floorNumber) //if so, it just opens the door
        {
            _floorScript.OpenDoor();
        }
    }
    public void EmergencyStop()
    {
        _reachedDestination = true;
        _sounds[_elevatorLoopSFX].volume = 0;
    }
}
