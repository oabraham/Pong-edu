using TMPro;
using UnityEditorInternal;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    public float speed = 5.0f;
    
    private Rigidbody rb;
    private Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        direction = new Vector3(1.0f, 1.0f, 0.0f);
        // Apply an initial force to the ball
        rb.linearVelocity = new Vector3(5, 5, 0);
        rb.AddForce(direction * speed, ForceMode.VelocityChange);
    }

    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        


        if (collision.gameObject.CompareTag("Paddle"))
        {
            rb.linearVelocity = Vector3.Reflect(rb.linearVelocity.normalized ,new Vector3(-1f, 1f, 1f));
            
            //rb.AddForce(rb.linearVelocity.normalized * speed, ForceMode.VelocityChange);
            //direction = Vector3.Reflect(direction, collision.contacts[0].normal);
            
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            //direction = Vector3.Reflect(direction, collision.contacts[0].normal);
            //rb.AddForce(direction * speed, ForceMode.VelocityChange);
        }
        else if (collision.gameObject.CompareTag("Goal"))
        {
            // Score a point
            // Call UpdateScore with the player number (1 or 2)
            Scoring scoringScript = GameObject.Find("PongBall").GetComponent<Scoring>();
            //scoringScript.UpdateScore(direction.x > 0 ? 2 : 1);
            //GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>().text = "Player " + (direction.x > 0 ? "2" : "1") + " scores!";
            //ResetBall();
        }
    }

    void FixedUpdate()
    {
        float CurrentSpeed = rb.linearVelocity.magnitude;
        if (CurrentSpeed < speed)
        {
            rb.AddForce(rb.linearVelocity.normalized * speed, ForceMode.VelocityChange);
        }

    }
    void ResetBall()
    {
        transform.position = new Vector3(0.0f, 0.0f, 0.0f);
        direction = new Vector3(1.0f, 1.0f, 0.0f);
    }
}
