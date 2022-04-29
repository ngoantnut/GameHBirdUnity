using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particleSystem;
     bool _hasDied;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (ShoulDieFromCollison(collision))
        {
           StartCoroutine(Die());
        }
        

    }

    bool ShoulDieFromCollison(Collision2D collision)
    {
        if (_hasDied)
            return false;
        Player player = collision.gameObject.GetComponent<Player>();
        if (player != null)
            return true;
        //Neu quai nga se bien mat
        if (collision.contacts[0].normal.y < -0.5)
            return true;
        return false;

    }

     IEnumerator Die()
    {   //Cho quai chet nham mat
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        
        _particleSystem.Play();

        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        
    }
}
