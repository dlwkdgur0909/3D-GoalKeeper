using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] private Vector3 target;

    float Speed = 0.5f;

    void Start()
    {

    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(target * Speed);
    }

    public void SetTarget(Vector3 targetPos) => this.target = targetPos;



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoalPos"))
        {
            Destroy(gameObject);
        }
    }
}
