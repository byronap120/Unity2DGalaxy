using UnityEngine;

public class PowerUp : MonoBehaviour
{

    [SerializeField] private float _speed = 3.0f;
    [SerializeField] private int _powerUpId = 0;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        if(transform.position.y < -5.75)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if (otherGameObject.tag == "Player")
        {
            Player player = otherGameObject.GetComponent<Player>();

            if (_powerUpId == 0)
            {
                player.EnableTripeShoot();
            }
            else if (_powerUpId == 1)
            {
                player.EnableSpeedBost();
            }
            else if (_powerUpId == 2)
            {
                player.EnableShield();
            }

            
            Destroy(this.gameObject);
        }
    }
}
