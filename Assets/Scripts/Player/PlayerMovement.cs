using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _fpsCamera;
    [SerializeField] float _maxSpeed = 200f;
    [SerializeField] private float _moveSpeed;
    private float _backwardsSpeed;
    [SerializeField] private float _rotSpeed;
    private float _rotBackSpeed;
    [SerializeField] private AudioSource _stepsSFX;
    private bool _wandering = true;
    private Rigidbody rb;
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        _backwardsSpeed = -_moveSpeed;
        _rotBackSpeed = -_rotSpeed;
    }
    void Update()
    {
        if (_wandering == true)
        {
            _stepsSFX.volume = 1;
        }
        else if (_wandering == false)
        {
            _stepsSFX.volume = 0;
        }
    }
    void FixedUpdate()
    {
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, _maxSpeed);
        if (Input.GetKey(KeyCode.W))
        {
            MovementVertical(_moveSpeed);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovementVertical(_backwardsSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            MovementHorizontal(_moveSpeed);
            //Rotation(_rotSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            MovementHorizontal(_backwardsSpeed);
            //Rotation(_rotBackSpeed);
        }
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            _wandering = true;
        }
        else
        {
            _wandering = false;
        }
    }
    void MovementHorizontal(float speed)
    {
        rb.AddForce(_fpsCamera.transform.right * speed * Time.deltaTime, ForceMode.Impulse);
    }
    void MovementVertical(float speed)
    {
        rb.AddForce(_fpsCamera.transform.forward * speed * Time.deltaTime, ForceMode.Impulse);
    }
    void Rotation(float speed)
    {
        transform.Rotate(0, speed, 0);
    }
}
