using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField] private float _speed = 10f;

	// Update is called once per frame
	void Update () {
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        if(transform.position.y > 7.50)
        {
            Destroy(this.gameObject);
        }
	}
}
