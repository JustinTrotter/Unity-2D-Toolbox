using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    public LayerMask groundLayer;

    public float gravity;
    public float jumpPower;
    public float moveSpeed;
    public Vector2 velocity;

    private float jumpHeight;
    private float jumpTime;
    private bool grounded;
    public float distance;
    public float distanceOffset;
    public float gravityOffset;

    private Vector3 hitPoint;

    private void Awake() {
        rb = gameObject.GetComponent<Rigidbody2D>() as Rigidbody2D;
        rb.bodyType = RigidbodyType2D.Kinematic;
    }

    // Start is called before the first frame update
    private void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate() {
        //Ground Check
        grounded = isGrounded(distance);

        //Gravity
        if (!grounded) velocity = new Vector2(velocity.x, velocity.y - gravity * Time.deltaTime);
        
        //Push up out of ground
        if (grounded){
            velocity = new Vector2(velocity.x, 0f);
            //breakOut();
        }
        
        rb.velocity = velocity;
    }

    private bool isGrounded(float dist) {
        Vector2 position = transform.position;
        Vector2 direction = Vector2.down;
        RaycastHit2D hit = Physics2D.Raycast(position, direction, dist, groundLayer);
        if (hit.collider != null) {
            hitPoint = hit.point;
            return true;
        }
        return false;
    }

    private void breakOut() {
        //if (isGrounded(distance + distanceOffset)) {
            transform.position += new Vector3(0f, (1f + gravityOffset) * Time.deltaTime);
        //}
    }
}
