using System.Collections;
using UnityEngine;

public class BallSpawner : MonoBehaviour
{
    public GameObject ballPrefab; // ������ ���� ������
    public Transform goalPost; // ����� ��ġ

    public float ballSpeed = 5f; // ���� �̵� �ӵ�
    public float spawnInterval = 3f; // �� ���� ����
    public float minX = -5f; // ���� ��ġ�� �ּ� x��
    public float maxX = 5f; // ���� ��ġ�� �ִ� x��
    public float minZ = -5f; // ���� ��ġ�� �ּ� z��
    public float maxZ = 5f; // ���� ��ġ�� �ִ� z��

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
