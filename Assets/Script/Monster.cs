using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
     void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShoulDieFromCollison(collision))
        {
            Die();
        }
        

    }

    bool ShoulDieFromCollison(Collision2D collision)
    {
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            return true;
        return false;

    }

     void Die()
    {
        gameObject.SetActive(false);
    }
}
