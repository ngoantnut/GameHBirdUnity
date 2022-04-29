using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Vector2 _startPoision;
    //Serial de tuan tu hoa tep lenh
    //De unity tai su dung sau nay, khac GameOject
    [SerializeField] float _launchForce = 500;
    [SerializeField] float _maxDragDistance = 5;
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
        //Han chee pham vi hoat di chuyen Bird khi bat dau
        Vector2 desiredPoisition = mousePoisiton;
        

        float distance = Vector2.Distance(desiredPoisition, _startPoision);
        if (distance > _maxDragDistance)
        {
            Vector2 direction = desiredPoisition - _startPoision;
            direction.Normalize();
            desiredPoisition = _startPoision + (direction * _maxDragDistance);
        }

        if (desiredPoisition.x > _startPoision.x)
            desiredPoisition.x = _startPoision.x;
        _rigidbody2D.position = desiredPoisition;
        //transform.position = new Vector3(mousePoisiton.x, mousePoisiton.y, transform.position.z);
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
