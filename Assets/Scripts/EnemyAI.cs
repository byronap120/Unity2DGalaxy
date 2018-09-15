using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float _speed = 2.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        VerifyEnemyPosition();
    }

    private void VerifyEnemyPosition()
    {
        if (transform.position.y < -6.4)
        {
            float xPosition = Random.Range(-9.20f, 9.25f);
            transform.position = new Vector3(xPosition, 8.15f, 0);
        }
    }
}
