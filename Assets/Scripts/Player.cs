using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;

    [SerializeField] private float _speed = 1f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private float _fireRate = 0.25F;
    private float _nextFire = 0.0F;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerPosition();
        if (Input.GetKey(KeyCode.Space))
        {
            Shoot();
        }
    }

    private void UpdatePlayerPosition()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * _speed * Time.deltaTime);
        VerifyPlayerPosition();
    }

    private void VerifyPlayerPosition()
    {
        if (transform.position.y >= 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y <= -4.2)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        if (transform.position.x >= 11)
        {
            transform.position = new Vector3(-10.85f, transform.position.y, 0);
        }
        else if (transform.position.x <= -10.85f)
        {
            transform.position = new Vector3(11, transform.position.y, 0);
        }
    }

    private void Shoot()
    {
        if (Time.time > _nextFire)
        {
            _nextFire = Time.time + _fireRate;
            Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);

            if (canTripleShoot)
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(-0.6f, 0.3f, 0), Quaternion.identity);
                Instantiate(_laserPrefab, transform.position + new Vector3(0.6f, 0.3f, 0), Quaternion.identity);
            }
        }

    }

    public void EnableTripeShoot()
    {
        canTripleShoot = true;
        StartCoroutine(TripeShootPowerUpTimer());
    }

    private IEnumerator TripeShootPowerUpTimer()
    {
        yield return new WaitForSeconds(5.0f);
        canTripleShoot = false;
    }

}
