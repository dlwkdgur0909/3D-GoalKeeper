using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rigid;
    public float diveForce;
    public float moveSpeed;
    public bool isDive = false;

    public Transform ball;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();
        ClickScreen();
        LookAtTheBall();
    }

    private void ClickScreen()
    {
        if (Input.GetMouseButtonDown(0) && !isDive)
        {
            isDive = true;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.name == "GoalBox")
                {
                    Vector3 dir = hit.point - rigid.transform.position;
                    rigid.AddForce(dir.normalized * diveForce, ForceMode.Impulse);
                }
            }
        }
    }

    private void Move()
    {
        if (isDive) return; //Dive중이라면 return하기

        float h = Input.GetAxisRaw("Horizontal");
        Vector3 move = new Vector3(h, 0, 0);
        rigid.MovePosition(transform.position + move * moveSpeed * Time.deltaTime);
    }

    private void LookAtTheBall() //추후에 Ball보는 걸로 바꿀 예정
    {
        if (isDive) return;
        transform.LookAt(ball.transform.position);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Tag Ground");
            isDive = false;
        }
    }
}
