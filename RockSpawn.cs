using UnityEngine;

public class RockSpawn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject[] rockPrefabs;
    [SerializeField] private float secondsBetweenRock = 1.5f;
    [SerializeField] private Vector2 forceRange;
    private Camera mainCamera;
    private float timer;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0){
            SpawnRock();
            timer += secondsBetweenRock;
        }
    }

    private void SpawnRock()
    {
        int side = Random.Range(0, 4);  
        Vector3 spawnPoint = Vector3.zero;
        Vector2 direction = Vector2.zero;

        // หาขอบของหน้าจอในโลกจริง (World Space)
        // float camHeight = 2f * mainCamera.orthographicSize;
        // float camWidth = camHeight * mainCamera.aspect;
        // float halfWidth = camWidth / 2f;
        // float halfHeight = camHeight / 2f;

        // Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        // Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1,  mainCamera.nearClipPlane));

        // float leftEdge = bottomLeft.x;
        // float rightEdge = topRight.x;
        // float bottomEdge = bottomLeft.y;
        // float topEdge = topRight.y;

        switch (side)
        {
            case 0: 
                // Left
                spawnPoint = mainCamera.ViewportToWorldPoint(
                    new Vector3(0,Random.value,mainCamera.nearClipPlane+10f));
                spawnPoint.z = 0;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;

            case 1: // Right
                spawnPoint = mainCamera.ViewportToWorldPoint(
                    new Vector3(1, Random.value, mainCamera.nearClipPlane+10f));
                spawnPoint.z = 0;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;

            case 2: // Bottom
                spawnPoint = mainCamera.ViewportToWorldPoint(
                    new Vector3(Random.value, 0, mainCamera.nearClipPlane + 10f));
                spawnPoint.z = 0;
                direction = new Vector2(Random.Range(-1f, 1f),1f);
                break;

            case 3: // Top
                spawnPoint = mainCamera.ViewportToWorldPoint(
                    new Vector3(Random.value, 1, mainCamera.nearClipPlane + 10f));
                spawnPoint.z = 0;
                direction = new Vector2(Random.Range(-1f, 1f),-1f);
                // Debug.Log(spawnPoint);
                break;
        }

        // สุ่มก้อนหินที่ต้องการสร้าง
        GameObject selectedRock = rockPrefabs[Random.Range(0, rockPrefabs.Length)];
        GameObject rockInstance = Instantiate(
            selectedRock,
            spawnPoint,
            Quaternion.Euler(0f, 0f, Random.Range(0f, 360f))
        );

        // ใช้ Rigidbody เพื่อให้ก้อนหินเคลื่อนที่
        Rigidbody rb = rockInstance.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);
        }
    }

}
