using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClockPlatform : MonoBehaviour
{
    private int contactMaxCount = 3;
    private float contactMaxTime = 10;
    private float contactStartTime;

    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (contactStartTime != 0) {
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1 - (Time.time - contactStartTime) / contactMaxTime);
        }
        if (contactStartTime != 0 && Time.time - contactStartTime > contactMaxTime)
        {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && contactStartTime == 0)
        {
            contactStartTime = Time.time;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            contactMaxCount--;
        }

        if (contactMaxCount == 0)
        {
            gameObject.SetActive(false);
        }
    }
}
