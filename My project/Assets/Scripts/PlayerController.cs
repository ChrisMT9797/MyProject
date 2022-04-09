using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D playerRb;
    public float jumpForce = 25f;
    public float gravityModifier;
    public bool isOnGround = true;
    public float speed;
    public GameObject Cam1;
    public GameObject Cam2;
    public GameObject Cam3;
    public GameObject Cam4;
    public GameObject Cam5;
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        Physics.gravity *= gravityModifier;
        Cam1.SetActive(true);
    }

    void Update()
    {
        if (transform.position.x == 120)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(true);
                Cam3.SetActive(false);
                Cam4.SetActive(false);
                Cam5.SetActive(false);
            }
            if (transform.position.x == 276)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(false);
                Cam3.SetActive(true);
                Cam4.SetActive(false);
                Cam5.SetActive(false);
            }
            if (transform.position.x == 434)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(false);
                Cam3.SetActive(false);
                Cam4.SetActive(true);
                Cam5.SetActive(false);
            }
            if (transform.position.x== 592)
            {
                Cam1.SetActive(false);
                Cam2.SetActive(false);
                Cam3.SetActive(false);
                Cam4.SetActive(false);
                Cam5.SetActive(true);
            }
            if (transform.position.x == -63)
            {
                Cam1.SetActive(true);
                Cam2.SetActive(false);
                Cam3.SetActive(false);
                Cam4.SetActive(false);
                Cam5.SetActive(false);
            }
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
		transform.position = new Vector2(120, -10);
		}
        else if (collision.gameObject.CompareTag("Door2"))
        {
            transform.position = new Vector2(276, -10);
        }
        else if (collision.gameObject.CompareTag("Door3"))
        {
            transform.position = new Vector2(434, -10);
        }
        else if (collision.gameObject.CompareTag("Door4"))
        {
            transform.position = new Vector2(592, -10);
        }
	}    
}