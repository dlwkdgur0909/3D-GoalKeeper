using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 target;

    private float Speed = 0.5f;

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(target * Speed * Time.deltaTime);
    }

    public void SetTarget(Vector3 targetPos) => this.target = targetPos;

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("GoalPos"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
