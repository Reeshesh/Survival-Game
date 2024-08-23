using System.Collections.Generic;
using UnityEngine;

public class PlacementGenerator : MonoBehaviour
{
    public GameObject treePrefab;
    public int numberOfTrees = 10;
    public float spawnRadius = 10f;

    private List<GameObject> spawnedTrees;

    private void Start()
    {
        GenerateTrees();
    }

    private void OnApplicationQuit()
    {
        ClearTrees();
    }

    public void GenerateTrees()
    {
        ClearTrees();

        spawnedTrees = new List<GameObject>();

        Terrain terrain = Terrain.activeTerrain;
        Vector3 terrainSize = terrain.terrainData.size;

        for (int i = 0; i < numberOfTrees; i++)
        {
            Vector3 randomPosition = GetRandomPosition(terrain, terrainSize);
            spawnedTrees.Add(SpawnTree(randomPosition));
        }
    }

    Vector3 GetRandomPosition(Terrain terrain, Vector3 terrainSize)
    {
        float randomX = Random.Range(0, terrainSize.x);
        float randomZ = Random.Range(0, terrainSize.z);
        float terrainY = terrain.SampleHeight(new Vector3(randomX, 0, randomZ));
        Vector3 randomPosition = new Vector3(randomX, terrainY, randomZ);
        return randomPosition;
    }

    GameObject SpawnTree(Vector3 spawnPosition)
    {
        return Instantiate(treePrefab, spawnPosition, Quaternion.identity);
    }

    public void ClearTrees()
    {
        if (spawnedTrees != null)
        {
            foreach (var tree in spawnedTrees)
            {
                Destroy(tree);
            }

            spawnedTrees.Clear();
        }
    }
}
