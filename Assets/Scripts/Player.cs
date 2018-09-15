using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdatePlayerPosition();
    }

    private void UpdatePlayerPosition()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(new Vector3(horizontalInput, verticalInput, 0) * speed * Time.deltaTime);
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
}
