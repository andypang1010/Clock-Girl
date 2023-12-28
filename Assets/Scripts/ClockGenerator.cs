using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockGenerator : MonoBehaviour
{
    public static ClockGenerator instance;

    public float maxSpacing;
    public GameObject clockPrefab;

    // Start is called before the first frame update
    void Start()
    {
        float spacing = 20;
        Vector2 nextPos = new Vector2(0, 0);
        for (int i = 0; i < 10; i++)
        {
            if (i % 2 == 0)
            {
                nextPos.x = 0;
            }
            else
            {
                nextPos.x = spacing / 2;
            }

            for (int j = 0; j < 10; j++)
            {
                Instantiate(clockPrefab, NewRandPosition(nextPos), Quaternion.identity);
                nextPos.x += spacing;
            }
            nextPos.y -= Mathf.Sin(Mathf.PI/3) * spacing;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    Vector2 NewRandPosition(Vector2 currPosition) {
        return currPosition + new Vector2(Random.Range(-maxSpacing, maxSpacing), Random.Range(-maxSpacing, maxSpacing));
    }
}
