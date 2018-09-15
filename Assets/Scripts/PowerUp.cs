using UnityEngine;

public class PowerUp : MonoBehaviour {

    [SerializeField] private float _speed = 3.0f; 

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
	}

    private void OnTriggerEnter2D(Collider2D otherGameObject)
    {
        if(otherGameObject.tag == "Player")
        {
            Player player = otherGameObject.GetComponent<Player>();
            player.EnableTripeShoot();
            Destroy(this.gameObject);
        }
    }
}
