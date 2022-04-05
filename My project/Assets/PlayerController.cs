using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float jumpForce = 25f;
    public float gravityModifier;
    public bool isOnGround = true;
    public float speed;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
    }

    void Update()
    {
       if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
       {
           playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
           isOnGround = false;
       }
           playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * speed * Time.deltaTime, playerRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }
		else if (collision.gameObject.CompareTag("Door1"))
		{
		transform.position = new Vector2(35, -3);
		}
	}    
}