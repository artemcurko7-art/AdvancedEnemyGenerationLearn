using Unity.VisualScripting;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Transform _target;

    public virtual void Initialize(Transform target)
    {
        _target = target;
    }

    public virtual void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, _target.position, _speed * Time.deltaTime);
    }
}
