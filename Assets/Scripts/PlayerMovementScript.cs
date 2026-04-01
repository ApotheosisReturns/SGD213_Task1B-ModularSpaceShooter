using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField] private float horizontalAcceleration = 5000f; // determines the target speed 

    private Rigidbody2D rb;
    private float input;

    private void Awake() // Get/Use attached rigidbody
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Always read input in Update
        input = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (Mathf.Abs(input) > 0.01f)
        {
            Vector2 force = Vector2.right * input * horizontalAcceleration * Time.fixedDeltaTime;
            rb.AddForce(force);
        }
    }
}