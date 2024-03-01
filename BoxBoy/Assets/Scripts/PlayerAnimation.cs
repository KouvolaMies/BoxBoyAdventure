using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    //unity components
    private Rigidbody2D rb;
    private Animator anim;
    private SpriteRenderer sprite;

    //animation state enum
    private enum AnimState{idle, running, jumping, falling};

    //double jump particle stuff
    [SerializeField] private Rigidbody2D DJPrefab;
    [SerializeField] private Transform DJPSpawn;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update(){
        UpdateAnim();
    }

    private void UpdateAnim(){
        AnimState state;
        if(rb.velocity.x > 0.1f){
            state = AnimState.running;
            sprite.flipX = false;
        }
        else if(rb.velocity.x < -0.1f){
            state = AnimState.running;
            sprite.flipX = true;
        }
        else{
            state = AnimState.idle;
        }

        if(rb.velocity.y > 0.1f){
            state = AnimState.jumping;
        }
        else if(rb.velocity.y < -0.1f){
            state = AnimState.falling;
        }

        anim.SetInteger("state", (int)state);
    }

    //spawns the double jump particles
    public void DJParticle(){
        Rigidbody2D DoubleJumpParticle = Instantiate(DJPrefab, DJPSpawn.position, Quaternion.identity);
    }
}