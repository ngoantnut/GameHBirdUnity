using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _startPoision;
    [SerializeField] float _launchForce = 500;
    Rigidbody2D _rigidbody2D;
    SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        _startPoision = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
    }
    void OnMouseDown()
    {
        _spriteRenderer.color = Color.red;
    }
     void OnMouseUp()
    {
        Vector2 currentPosition = _rigidbody2D.position;
        Vector2 direction = _startPoision - currentPosition;
        direction.Normalize();
        _rigidbody2D.isKinematic = false;
        _rigidbody2D.AddForce(direction * _launchForce);
        _spriteRenderer.color = Color.white;
    }
     void OnMouseDrag()
    {
        Vector3 mousePoisiton = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousePoisiton.x, mousePoisiton.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ResetAfterDelay());
        
    }

  
    IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(3);
        _rigidbody2D.position = _startPoision;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;

    }
}
