using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 170;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 15f;

    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float speedAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, speedAmount, 0);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // if (collision.gameObject.tag == "Obstacle")
        // {
            moveSpeed = slowSpeed;
        // }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Speed Up")
        {
            moveSpeed = boostSpeed;
            Destroy(collider.gameObject);
        }
        if (collider.tag == "Slow Down")
        {
            moveSpeed = slowSpeed;
            Destroy(collider.gameObject);
        }
    }
}
