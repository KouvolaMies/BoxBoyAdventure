using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maggot : MonoBehaviour
{
    private Rigidbody2D rb;
    private SpriteRenderer sprite;
    private bool right = true;
    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update(){
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
}