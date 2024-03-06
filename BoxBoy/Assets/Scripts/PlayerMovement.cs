using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //unity components
    private Rigidbody2D rb;

    //movement variables
    private float xvel;
    private float speed = 10f;
    private float jumpforce = 15f;
    private bool DoubleJump;
    private bool Walljump;
    private float WalljumpTime = 0;
    private bool moving;

    //boxcast variables
    [SerializeField] public Vector2 boxSizeD;
    [SerializeField] public float castDistanceD;
    [SerializeField] public Vector2 boxSizeL;
    [SerializeField] public float castDistanceL;
    [SerializeField] public Vector2 boxSizeR;
    [SerializeField] public float castDistanceR;
    [SerializeField] public LayerMask jumpableGround;

    //script references
    public PlayerAnimation panim;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        
        //sets the boxcasts to the right positions, just in case it gets reset for some reason
        boxSizeD = new Vector2(0.9f, 0.1f);
        castDistanceD = 0.47f;
        boxSizeL = new Vector2(0.1f, 0.8f);
        castDistanceL = 0.47f;
        boxSizeR = new Vector2(0.1f, 0.8f);
        castDistanceR = -0.47f;
    }

    private void Update(){
        //reset double jump
        if(IsGrounded() || LeftWall() || RightWall()){
            DoubleJump = true;
        }
        //run movement if not walljumping
        if(Walljump == false){
            movement();
        }
        //timer for the walljump
        else if(WalljumpTime < (50 * Time.deltaTime)){
            WalljumpTime++;
        }
        else{
            Walljump = false;
            WalljumpTime = 0;
        }
        //slow down momentum
        if(moving == false){
            if(xvel > 0f){
                xvel -= (25f * Time.deltaTime);
            }
            if(xvel < 0f){
                xvel += (25f * Time.deltaTime);
            }
            if(xvel < 0.1f && xvel > -0.1f){
                xvel = 0f;
            }
            if(rb.velocity.x < 1f && rb.velocity.x > -1f){
                xvel = 0f;
            }
        }
        //apply speed
        rb.velocity = new Vector2(xvel, rb.velocity.y);
    }

    private void movement(){
        //check for sprint
        if(Input.GetKey(KeyCode.LeftShift)){
            speed = 15f;
        }
        else{
            speed = 10f;
        }
        //check for right
        if(Input.GetAxisRaw("Horizontal") > 0.1f){
            if(xvel < speed){
                xvel += (30f * Time.deltaTime);
            }
            moving = true;
        }

        //check for left
        if(Input.GetAxisRaw("Horizontal") < -0.1f){
            if(xvel > -speed){
                xvel -= (30f * Time.deltaTime);
            }
            moving = true;
        }

        //check for movement
        if(!Input.GetKey("a") && !Input.GetKey("d")){
            moving = false;
        }

        //wall cling and wall jump check
        if(LeftWall()){
            if(rb.velocity.y < 0f){
                rb.velocity = new Vector2(rb.velocity.x, -1f);
            }
            if(Input.GetButtonDown("Jump")){
                rb.velocity = new Vector2(7, jumpforce);
                xvel = 7;
                Walljump = true;
            }
        }
        else if(RightWall()){
            if(rb.velocity.y < 0f){
                rb.velocity = new Vector2(rb.velocity.x, -1f);
            }
            if(Input.GetButtonDown("Jump")){
                rb.velocity = new Vector2(-7, jumpforce);
                xvel = -7;
                Walljump = true;
            }
        }
        //check for jump, else if is there to give walljumps priority over double jumps
        else if(Input.GetButtonDown("Jump") && (IsGrounded() || DoubleJump == true)){
            //checks for which jump power to use, grounded is stronger than double jump
            if(IsGrounded()){
                rb.velocity = new Vector2(xvel, jumpforce);
            }
            else{
                rb.velocity = new Vector2(xvel, jumpforce * 0.8f);
                panim.DJParticle();
            }
            if(DoubleJump == true && !IsGrounded()){
                DoubleJump = false;
            }
        }
    }

    //ground check
    public bool IsGrounded(){
        if(Physics2D.BoxCast(transform.position, boxSizeD, 0, -transform.up, castDistanceD, jumpableGround)){
            return true;
        }
        else{
            return false;
        }
    }

    //Wall checks, both left and right
    public bool LeftWall(){
        if(Physics2D.BoxCast(transform.position, boxSizeL, 0, -transform.right, castDistanceL, jumpableGround) && Input.GetAxisRaw("Horizontal") < -0.1f && !IsGrounded()){
            return true;
        }
        else{
            return false;
        }
    }

    public bool RightWall(){
        if(Physics2D.BoxCast(transform.position, boxSizeR, 0, -transform.right, castDistanceR, jumpableGround) && Input.GetAxisRaw("Horizontal") > 0.1f && !IsGrounded()){
            return true;
        }
        else{
            return false;
        }
    }

    //makes the box casts visible in unity
    private void OnDrawGizmos(){
        Gizmos.DrawWireCube(transform.position-transform.up * castDistanceD, boxSizeD);
        Gizmos.DrawWireCube(transform.position-transform.right * castDistanceL, boxSizeL);
        Gizmos.DrawWireCube(transform.position-transform.right * castDistanceR, boxSizeR);
    }
}