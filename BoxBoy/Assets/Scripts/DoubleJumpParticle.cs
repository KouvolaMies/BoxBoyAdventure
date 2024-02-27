using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJumpParticle : MonoBehaviour
{
    private void Awake(){
        Invoke("Destroy", 1);
    }

    private void Destroy(){
        Destroy(gameObject);
    }
}
