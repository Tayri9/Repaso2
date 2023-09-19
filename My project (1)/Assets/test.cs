using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour 
{    
    private Rigidbody2D rb;
    [SerializeField] float speed = 10;
    float move_x;
    float move_y;
    public bool canJump = true;

    public SpriteRenderer spriteRenderer;
    public Sprite standing;
    public Sprite crouching;

    public BoxCollider2D col;
    public Vector2 standingSize;
    public Vector2 crouchingSize;
     
// Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>(); rb.mass = 8; rb.gravityScale = 8;
        col = GetComponent<BoxCollider2D>();
        spriteRenderer.sprite = standing;
        standingSize = col.size;
    }

    // Update is called once per frame
    void Update()
    {
        move_x = Input.GetAxis("Horizontal");        
        move_y = Input.GetAxis("Vertical");

        //movimiento
        //if (Mathf.Abs(move_x) > 0) rb.velocity = new Vector2(speed * move_x, speed * Mathf.Abs(move_x));
        //if (Mathf.Abs(move_y) > 0) rb.velocity = new Vector2(0, speed * move_y);

        //salto
        if (canJump)
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow)) rb.velocity = new Vector2(0, 30);
        }

        //agacharse
        if (Input.GetKeyDown(KeyCode.DownArrow)){
            spriteRenderer.sprite = crouching;
            col.size = crouchingSize;
            rb.position = new Vector2(rb.position.x, -6.385001f);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            spriteRenderer.sprite = standing;
            col.size = standingSize;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            canJump = false;
        }
    }
}
