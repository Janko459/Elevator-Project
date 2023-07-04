using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform player;
    private float _mouseX, _mouseY;
    private int _rotationLock = 80;
    private float _zeroValue;
    private Vector3 _angles;
    public float sensitivityX;
    public float sensitivityY;
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void LateUpdate()
    {
        CamControl();
    }
    void CamControl()
    {
        player.rotation = Quaternion.Euler(_zeroValue, _mouseX, _zeroValue);
        float rotationY = Input.GetAxis("Mouse Y") * sensitivityX;
        float rotationX = Input.GetAxis("Mouse X") * sensitivityY;
        if (rotationY > 0)
            _angles = new Vector3(Mathf.MoveTowards(_angles.x, -_rotationLock, rotationY), _angles.y + rotationX, _zeroValue);
        else
            _angles = new Vector3(Mathf.MoveTowards(_angles.x, _rotationLock, -rotationY), _angles.y + rotationX, _zeroValue);
            transform.localEulerAngles = _angles;
    }
}
