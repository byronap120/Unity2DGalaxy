﻿using System.Collections;
using UnityEngine;

public class Player : MonoBehaviour
{
    public bool canTripleShoot = false;

    [SerializeField] private float _speed = 5f;
    [SerializeField] private GameObject _laserPrefab;
    [SerializeField] private GameObject _tripeLaserPrefab;
    [SerializeField] private float _fireRate = 0.25F;
    [SerializeField] private int _playerLives = 3;
    [SerializeField] private GameObject _playerExplosion;
    [SerializeField] private GameObject _shieldSprite;
    private float _nextFire = 0.0F;
    private bool _playerShield = false;
    private UIManager _uiManager;

    // Use this for initialization
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        if (_uiManager)
        {
            _uiManager.UpdateLives(_playerLives);
        }
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

            if (canTripleShoot)
            {
                Instantiate(_tripeLaserPrefab, transform.position + new Vector3(0, 0f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(_laserPrefab, transform.position + new Vector3(0, 0.95f, 0), Quaternion.identity);
            }
        }

    }

    public void EnableShield()
    {
        _playerShield = true;
        _shieldSprite.SetActive(true);
        StartCoroutine(ShieldTimer());
    }

    public void DisableShield()
    {
        _playerShield = false;
        _shieldSprite.SetActive(false);
    }

    private IEnumerator ShieldTimer()
    {
        yield return new WaitForSeconds(10.0f);
        DisableShield();
    }

    public void EnableTripeShoot()
    {
        canTripleShoot = true;
        StartCoroutine(TripeShootPowerUpTimer());
    }

    private IEnumerator TripeShootPowerUpTimer()
    {
        yield return new WaitForSeconds(10.0f);
        canTripleShoot = false;
    }

    public void EnableSpeedBost()
    {
        _speed = 10f;
        StartCoroutine(SppedBoostTimer());
    }

    private IEnumerator SppedBoostTimer()
    {
        yield return new WaitForSeconds(5.0f);
        _speed = 5f;
    }

    public void TakeDamage()
    {

        // Verify active shield
        if (_playerShield)
        {
            DisableShield();
            return;
        }

        _playerLives--;

        // update the sprite on the UIManger canvas
        _uiManager.UpdateLives(_playerLives);

        if (_playerLives < 1)
        {
            Instantiate(_playerExplosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
            if (gameManager != null)
            {
                gameManager.gameOverGalaxyGame();
            }
        }

    }
}
