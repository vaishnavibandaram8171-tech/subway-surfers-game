using UnityEngine;

public class WorldGenerator : MonoBehaviour
{
    [SerializeField] private GameObject groundTilePrefab;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private float tileLength = 10f;
    [SerializeField] private float spawnDistance = 100f;
    [SerializeField] private float despawnDistance = -20f;
    [SerializeField] private float obstacleDensity = 0.3f;
    [SerializeField] private float coinDensity = 0.4f;
    
    private Transform playerTransform;
    private float nextTileZ = 0f;
    private Transform tilesParent;

    void Start()
    {
        playerTransform = FindObjectOfType<PlayerController>().transform;
        
        // Create parent for organization
        tilesParent = new GameObject("TilesParent").transform;

        // Spawn initial tiles
        for (int i = 0; i < 10; i++)
        {
            SpawnTile();
        }
    }

    void Update()
    {
        // Spawn new tiles as player progresses
        if (playerTransform.position.z + spawnDistance > nextTileZ)
        {
            SpawnTile();
        }

        // Despawn old tiles
        foreach (Transform tile in tilesParent)
        {
            if (tile.position.z < playerTransform.position.z + despawnDistance)
            {
                Destroy(tile.gameObject);
            }
        }
    }

    void SpawnTile()
    {
        // Create ground tile
        GameObject tile = Instantiate(groundTilePrefab, new Vector3(0, 0, nextTileZ), Quaternion.identity);
        tile.transform.parent = tilesParent;

        // Randomly spawn obstacles
        for (int lane = 0; lane < 3; lane++)
        {
            if (Random.value < obstacleDensity)
            {
                SpawnObstacle(lane, nextTileZ);
            }
        }

        // Randomly spawn coins
        for (int lane = 0; lane < 3; lane++)
        {
            if (Random.value < coinDensity)
            {
                SpawnCoin(lane, nextTileZ);
            }
        }

        nextTileZ += tileLength;
    }

    void SpawnObstacle(int lane, float zPosition)
    {
        float xPosition = (lane - 1) * 3f;
        GameObject obstacle = Instantiate(obstaclePrefab, new Vector3(xPosition, 0.5f, zPosition + 5f), Quaternion.identity);
        obstacle.transform.parent = tilesParent;
    }

    void SpawnCoin(int lane, float zPosition)
    {
        float xPosition = (lane - 1) * 3f;
        GameObject coin = Instantiate(coinPrefab, new Vector3(xPosition, 1f, zPosition + 5f), Quaternion.identity);
        coin.transform.parent = tilesParent;
    }
}
