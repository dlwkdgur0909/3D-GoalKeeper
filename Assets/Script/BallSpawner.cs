using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // 생성할 공의 프리팹
    public Transform goalPost; // 골대의 위치

    public float spawnInterval = 3f; 
    public float minX = -5f; 
    public float maxX = 5f; 
    public float minZ = -5f;
    public float maxZ = 5f;

    private void Start()
    {
        StartCoroutine(SpawnBall());
    }

    IEnumerator SpawnBall()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);

            Vector3 randomPos = new Vector3(Random.Range(minX, maxX), goalPost.position.y, Random.Range(minZ, maxZ));
            var ball = Instantiate(ballPrefab, transform.position, Quaternion.identity).GetComponent<Ball>();
            var pos = ball.transform.position;
            ball.SetTarget((randomPos - pos).normalized);
        }
    }
}
