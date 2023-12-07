using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public Transform rightEdge;
    private bool lastState = false;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        List<GameObject> nextTerrainsPrefab = GameManager.instance.nextTerrainsPrefab;

        int randomTerrain = Random.Range(0, nextTerrainsPrefab.Count);
        GameObject nextTerrain = nextTerrainsPrefab[randomTerrain];

        Vector3 lowerLefScreenPos = new Vector3(0, 0, 0);
        Vector3 lowerLeftWorldPos = Camera.main.ScreenToWorldPoint(lowerLefScreenPos);
        Vector3 lowerRightScreenPos = new Vector3(Screen.width, 0, 0);
        Vector3 lowerRightWorldPos = Camera.main.ScreenToWorldPoint(lowerRightScreenPos);
        lowerRightWorldPos.z = 0;

        if (rightEdge.position.x < lowerRightWorldPos.x && !lastState)
        {
            Instantiate(nextTerrain, rightEdge.transform.position, Quaternion.identity);
        }

        // lastState will stay True after a new terrain is generated
        lastState = rightEdge.position.x < lowerRightWorldPos.x || lastState;

        if (rightEdge.position.x < lowerLeftWorldPos.x)
        {
            Destroy(gameObject);
        }
    }

    private void OnDrawGizmos()
    {
        Transform selectedTransform = Selection.activeTransform;
        if (selectedTransform != null && (selectedTransform.IsChildOf(transform) || selectedTransform == transform))
        {
            Gizmos.DrawWireSphere(rightEdge.transform.position, 3);
            Gizmos.DrawWireSphere(transform.position, 3);
        }
    }
}
