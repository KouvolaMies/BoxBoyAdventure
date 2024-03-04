using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObject : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private int lastnode;
    [SerializeField] private Transform node1;
    [SerializeField] private Transform node2;

    private void Start(){
        transform.position = new Vector2(node1.position.x, node1.position.y);
        lastnode = 1;
    }

    private void Update(){
        if(Vector2.Distance(node1.position, transform.position) < 0.05f){
            lastnode = 1;
        }
        else if(Vector2.Distance(node2.position, transform.position) < 0.05f){
            lastnode = 2;
        }

        if(lastnode == 1){
            transform.position = Vector2.MoveTowards(transform.position, node2.position, speed * Time.deltaTime);
        }
        else if(lastnode == 2){
            transform.position = Vector2.MoveTowards(transform.position, node1.position, speed * Time.deltaTime);
        }
    }
}