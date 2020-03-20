using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    public bool isGround;

    private Rigidbody2D PLRgb;
    private SpriteRenderer PLSpr;

    // Start is called before the first frame update
    void Start()
    {
        PLRgb = GetComponent<Rigidbody2D>();
        PLSpr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") > 0)
        {
            PLRgb.velocity = new Vector2(speed, PLRgb.velocity.y);
            PLSpr.flipX = false;

        }
        else if (Input.GetAxisRaw("Horizontal") < 0)
        {
            PLRgb.velocity = new Vector2(-speed, PLRgb.velocity.y);
            PLSpr.flipX = true;
        }
        else
        {
            PLRgb.velocity = new Vector2(PLRgb.velocity.x, PLRgb.velocity.y);
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
            PLRgb.velocity = new Vector2(PLRgb.velocity.x, jumpForce);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;    
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }
}
