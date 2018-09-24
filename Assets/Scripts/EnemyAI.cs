using UnityEngine;

public class EnemyAI : MonoBehaviour
{

    [SerializeField] float _speed = 2.0f;
    [SerializeField] GameObject enemyExplosion;
    private UIManager _uiManager;

    // Use this for initialization
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
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

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "Player")
        {
            Player player = otherGameObject.GetComponent<Player>();
            player.TakeDamage();
            Instantiate(enemyExplosion, this.gameObject.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

        }
        else if (otherGameObject.tag == "Laser")
        {
            Destroy(otherGameObject.gameObject);
            Instantiate(enemyExplosion, this.gameObject.transform.position, Quaternion.identity);
            updateScore();
            Destroy(this.gameObject);

        }
    }

    private void updateScore()
    {
        if (_uiManager != null)
        {
            _uiManager.UpdateScore();
        }
    }
}
