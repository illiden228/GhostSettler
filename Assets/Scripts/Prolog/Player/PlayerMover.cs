using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _stepSize;
    [SerializeField] private float _minWidth;
    [SerializeField] private float _maxWidth;

    private Vector3 _targetPosition;

    private void Start()
    {
        _targetPosition = transform.position;
    }

    private void Update()
    {
        if(transform.position != _targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _moveSpeed * Time.deltaTime);
        }
    }

    private void SetNextPosition(float stepSize)
    {
        _targetPosition = new Vector2(_targetPosition.x + stepSize, _targetPosition.y);
    }

    public void TryMoveLeft()
    {
        if (_targetPosition.x > _minWidth)
        {
            SetNextPosition(-_stepSize);
        }
    }

    public void TryMoveRight()
    {
        if (_targetPosition.x < _maxWidth)
        {
            SetNextPosition(_stepSize);
        }
    }
}
