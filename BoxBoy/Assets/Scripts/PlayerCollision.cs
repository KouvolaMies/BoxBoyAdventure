using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerCollision : MonoBehaviour
{
    private Rigidbody2D rb;

    public gamemanager gm;

    //coin variables
    [SerializeField] private GameObject Coins;
    private Tilemap coinmap;
    private Vector2 hitPosition;

    private void Start(){
        rb = GetComponent<Rigidbody2D>();
        coinmap = Coins.GetComponent<Tilemap>();
    }

    //collision checks
    private void OnCollisionEnter2D(Collision2D collision){
        //trap collision
        if(collision.collider.tag == "trap"){
            gm.GameOver();
        }

        //maggot collision
        if(collision.collider.tag == "maggot"){
            if(rb.velocity.y < -0.01f){
                Destroy(collision.gameObject);
                rb.velocity = new Vector2(rb.velocity.x, 5);
            }
            else{
                gm.GameOver();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        //when hitting coins
        if(collision.CompareTag("coin")){
            hitPosition = new Vector2(transform.position.x, (transform.position.y + 0.5f));
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            hitPosition = new Vector2(transform.position.x, (transform.position.y + -0.5f));
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            hitPosition = new Vector2((transform.position.x + 0.5f), transform.position.y);
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            hitPosition = new Vector2((transform.position.x + -0.5f), transform.position.y);
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            hitPosition = new Vector2((transform.position.x + -0.5f), (transform.position.y + -0.5f));
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            hitPosition = new Vector2((transform.position.x + 0.5f), (transform.position.y + -0.5f));
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            hitPosition = new Vector2((transform.position.x + 0.5f), (transform.position.y + 0.5f));
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            hitPosition = new Vector2((transform.position.x + -0.5f), (transform.position.y + 0.5f));
            coinmap.SetTile(coinmap.WorldToCell(hitPosition), null);
            gm.CoinGet();
        }

        //when hitting the goal
        if(collision.CompareTag("goal")){
            gm.Goal();
        }
    }
}