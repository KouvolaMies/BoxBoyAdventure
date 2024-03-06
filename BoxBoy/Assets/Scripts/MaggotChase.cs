using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaggotChase : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool right = true;
    public Transform playerpos;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        if((transform.position.y > (playerpos.position.y - 2) && transform.position.y < (playerpos.position.y + 5)) && transform.position.x > (playerpos.position.x - 7) && transform.position.x < (playerpos.position.x + 7)){
            Chase();
        }
        else{
            if(rb.velocity.x > -0.1f && rb.velocity.x < 0.1f){
                if(right == true){
                    right = false;
                    Move();
                }
                else{
                    right = true;
                    Move();
                }
            }
        }
    }

    private void Move(){
        if(right == true){
            rb.velocity = new Vector2(-100f * Time.deltaTime, 0);
            sprite.flipX = true;
        }
        else if(right == false){
            rb.velocity = new Vector2(100f * Time.deltaTime, 0);
            sprite.flipX = false;
        }
    }

    private void Chase(){
        if(transform.position.x < playerpos.position.x){
            rb.velocity = new Vector2(150f * Time.deltaTime, 0);
            sprite.flipX = false;
        }
        else if(transform.position.x > playerpos.position.x){
            rb.velocity = new Vector2(-150f * Time.deltaTime, 0);
            sprite.flipX = true;
        }
    }
}