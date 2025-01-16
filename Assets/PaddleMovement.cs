using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 5.0f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(0.0f, moveVertical, 0.0f);

        rb.AddForce(movement * speed);
    }
}