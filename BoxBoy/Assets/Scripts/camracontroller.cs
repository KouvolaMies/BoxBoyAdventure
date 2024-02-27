using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camracontroller : MonoBehaviour
{
    [SerializeField] private Transform playerpos;
    void Update()
    {
        transform.position = new Vector3(playerpos.position.x, playerpos.position.y, -10);
    }
}