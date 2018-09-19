using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject[] _powerUps;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(SpawnEnemy());
        StartCoroutine(SpawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpawnEnemy()
    {
        while (true)
        {
            Instantiate(_enemyPrefab, new Vector3(Random.Range(-9.20f, 9.25f), 8.15f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }

    private IEnumerator SpawnPowerUp()
    {
        while (true)
        {
            GameObject powerUp = _powerUps[Random.Range(0, 3)];
            Instantiate(powerUp, new Vector3(Random.Range(-9.20f, 9.25f), 7.38f, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
}
