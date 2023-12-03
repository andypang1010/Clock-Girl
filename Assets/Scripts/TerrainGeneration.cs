using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerrainGeneration : MonoBehaviour
{
    public List<GameObject> terrainsPrefab;
    public Transform playerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        int randomTerrain = Random.Range(0, terrainsPrefab.Count);

        GameObject nextTerrain = terrainsPrefab[randomTerrain];
        
        Transform generationPoint = nextTerrain.Transform.Find();
    
        
    }
}
