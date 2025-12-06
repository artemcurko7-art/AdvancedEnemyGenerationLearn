using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Transform _target;
    [SerializeField] private float _repeatRate;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private Vector3 GetRandomPosition()
    {
        int indexPosition = Random.Range(0, _spawnPoint.childCount);
        Vector3 position = _spawnPoint.GetChild(indexPosition).position;

        return position;
    }

    private IEnumerator SpawnEnemies()
    {
        while (enabled)
        {
            yield return new WaitForSeconds(_repeatRate);

            var enemy = Instantiate(_enemy, GetRandomPosition(), Quaternion.identity);
            enemy.Initialize(_target);
        }
    }
}
