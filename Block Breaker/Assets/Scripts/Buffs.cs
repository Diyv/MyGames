using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buffs : MonoBehaviour
{

    [SerializeField]GameObject paddle;


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Paddle")
        {
            Destroy(gameObject);
        }
    }

}
