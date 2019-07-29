using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myBody;

    public float speed ;
    public float jumpf ;
    public float jumpAbilityF;
    private float moveVelo;
    protected bool facingRight = true;

    private bool shouldMove = true;
    public bool isAlice;

    protected bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    protected int extraJumps;
    public int extraJumpsValue;

    void Start()
    {
        extraJumps = extraJumpsValue;
        myBody = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
#if UNITY_STANDALONE || UNITY_WEBGL
        DetectInput();
#endif
    }

    void Update()
    {
        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }

        //myBody.velocity = new Vector2(moveVelo*Time.deltaTime, myBody.velocity.y);
        
    }

    public void Move(float ab)
    {
        Debug.Log("den move  girdi");
        if (ab>0 && facingRight==false)
        {
            Flip();
        }
        else if(ab<0 && facingRight==true)
        {
            Flip();
        }
        //moveVelo = ab * speed;
        myBody.velocity = new Vector2(ab * speed, myBody.velocity.y);
    }

    
    public void Jumper()
    {
        Debug.Log("deneme Jum girdi");
        myBody.velocity = Vector2.up * jumpf;

        if (facingRight == true && isGrounded == false && extraJumps > 0 && shouldMove == true&&isAlice)
        {
            myBody.position = new Vector2((myBody.position.x + jumpAbilityF), myBody.position.y);
            extraJumps--;
        }
        else if (facingRight == false && isGrounded == false && extraJumps > 0 && shouldMove == true &&isAlice)
        {
            myBody.position = new Vector2((myBody.position.x - jumpAbilityF), myBody.position.y);
            extraJumps--;
        }
        else if(!isAlice && isGrounded == false && extraJumps > 0 && shouldMove == true)
        {
            myBody.position = new Vector2(myBody.position.x, myBody.position.y - jumpAbilityF);
            extraJumps--;
        }
    }
#if UNITY_STANDALONE || UNITY_WEBGL
    public void MoveLeft(float ab)
    {
        //myBody.velocity = new Vector2(-speed, myBody.velocity.y);
        if(facingRight==true)
        {
            Flip();
        }
        myBody.velocity = new Vector2(ab * speed, myBody.velocity.y);

    }

    public void MoveRight(float ab)
    {
        //myBody.velocity = new Vector2(speed, myBody.velocity.y);
        if (facingRight == false)
        {
            Flip();
        }
        myBody.velocity = new Vector2(ab * speed, myBody.velocity.y);

    }

    public void AJumpAbility()
    {
        if(facingRight==true)
        {
            myBody.position = new Vector2((myBody.position.x + jumpAbilityF), myBody.position.y);
            extraJumps--;
        }
        else if(facingRight==false)
        {
            myBody.position = new Vector2((myBody.position.x - jumpAbilityF), myBody.position.y);
            extraJumps--;
        }
    }

    public void BJumpAbility()
    {
        myBody.position = new Vector2(myBody.position.x, myBody.position.y - jumpAbilityF);
        extraJumps--;
    }


    void DetectInput()
    {
        float x = InputManager.MainHorizontal();
        bool y = InputManager.JButton();

        if (x > 0)
        {
            if(facingRight == false)
            {
                Flip();
            }
            MoveRight(x);
        }
        else if (x < 0)
        {
            if (facingRight == true)
            {
                Flip();
            }
            MoveLeft(x);
        }

        if(y && isGrounded==true)
        {
            Jumper();
        }
        else if(y && isGrounded==false&&extraJumps>0&&shouldMove==true)
        {
            if(isAlice==true)
            {
                AJumpAbility();
            }
            else if(isAlice==false)
            {
                BJumpAbility();
            }
        }

        
    }
#endif
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        //transform.Rotate(0f, 180f, 0f);
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            shouldMove = false;
        }
    }
}
