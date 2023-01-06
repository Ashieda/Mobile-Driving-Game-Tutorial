using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;

public class CarMovement : MonoBehaviour
{
    [SerializeField]
    float _speed = 5f, _speedIncrement = 1f, _turnSpeed = 0f;

    public enum SteerDirection { Left, Right, Straight };
    SteerDirection _currentDirection;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
        _speed += _speedIncrement * Time.deltaTime;

        if (_currentDirection == SteerDirection.Left)
            _turnSpeed = -100f;
        else if (_currentDirection == SteerDirection.Right)
            _turnSpeed = 100f;
        else
            _turnSpeed = 0f;

        transform.Rotate(0f, _turnSpeed * Time.deltaTime, 0f);
    }

    public void Steer(int directionInt)
    {
        switch ((SteerDirection)directionInt)
        {
            case SteerDirection.Left:
                _currentDirection = SteerDirection.Left;
                break;
            case SteerDirection.Right:
                _currentDirection = SteerDirection.Right;
                break;
            case SteerDirection.Straight:
                _currentDirection = SteerDirection.Straight;
                break;
            default:
                throw new UnityException("Inappropriate steer direction received");
        }
    }
}
