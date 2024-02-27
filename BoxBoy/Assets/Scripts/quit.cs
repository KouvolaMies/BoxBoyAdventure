using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class quit : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start(){
        sprite = GetComponent<SpriteRenderer>();
    }

    public void QuitHover(){
        sprite.color = new Color(255, 255, 255, 255);
    }

    public void QuitRevert(){
        sprite.color = new Color(255, 0, 0, 255);
    }
}
