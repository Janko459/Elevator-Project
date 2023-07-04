using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
    public int floorNumber;
    private Animator anim;
    [SerializeField] private GameObject _door;
    [SerializeField] private float _timeToShutDoor = 5f;
    private bool _reset = false;
    void Awake()
    {
        anim = _door.GetComponent<Animator>();
    }
    public void CloseDoor()
    {
        if (_reset == false)
        {
            anim.SetBool("Close", true);
            anim.SetBool("Open", false);
        }
    }
    public void OpenDoor()
    {
        anim.SetBool("Open", true);
        anim.SetBool("Close", false);
        StartCoroutine(CloseAutomatically());
    }
    public void ShutDoor() //force shut door immediately
    {
        anim.SetBool("Close", true);
        anim.SetBool("Open", false);
    }
    IEnumerator CloseAutomatically()
    {
        _reset = true;
        yield return new WaitForSeconds(_timeToShutDoor);
        _reset = false;
        CloseDoor();
    }
}
