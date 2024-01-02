using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockMove : MonoBehaviour
{
    public bool isMove, isX, isY;
    private Vector2 startPos;
    public float moveSpeed, moveRange;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove && (isX || isY)) {
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime * Convert.ToInt32(isX), transform.position.y + moveSpeed * Time.deltaTime * Convert.ToInt32(isY));
        }
        if (transform.position.x > startPos.x + moveRange || 
        transform.position.x < startPos.x - moveRange || 
        transform.position.y > startPos.y + moveRange || 
        transform.position.y < startPos.y - moveRange) {
            moveSpeed *= -1;
        }
    }
}
