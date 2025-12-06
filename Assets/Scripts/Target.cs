using System.Net.WebSockets;
using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private float _speed;

    private Vector3 _currentDirection;

    private void Start()
    {
        _currentDirection = GetRandomPosition();
    }

    private void Update()
    {
        Movement();
    }

    private void Movement()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetDirection(), _speed * Time.deltaTime);
    }

    private Vector3 GetDirection()
    {
        if (transform.position == _currentDirection)
            _currentDirection = GetRandomPosition();

        return _currentDirection;
    }

    private Vector3 GetRandomPosition()
    {
        int indexPosition = Random.Range(0, _target.childCount);
        Vector3 position = _target.GetChild(indexPosition).position;

        return position;
    }
}
