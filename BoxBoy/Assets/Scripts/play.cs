using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class play : MonoBehaviour
{
    private SpriteRenderer sprite;

    private void Start(){
        sprite = GetComponent<SpriteRenderer>();
    }

    public void PlayHover(){
        sprite.color = new Color(255, 255, 255, 255);
    }

    public void PlayRevert(){
        sprite.color = new Color(0, 255, 0, 255);
    }
}