using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    Rigidbody rigid;
    [Header("***Jump***")]
    public float jumpForce = 10f;
    public int jumpCount = 0;
    public float diveForce = 5f;
    [Header("***Move***")]
    public float moveSpeed = 10f;

    void Start()
    {
        rigid = GetComponent<Rigidbody>();
    }


    void Update()
    {
        Jump();
        Move();
        Dive();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {
            rigid.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jumpCount--;
        }
    }

    void Move()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        if (horizontalInput < 0)
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime);
        }

        else if (horizontalInput > 0)
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
        }
    }

    void Dive()
    {
        // 왼쪽으로 다이빙하기
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (jumpCount == 0)
            {
                Vector3 diveDirection = -transform.right * diveForce; // 왼쪽으로 다이빙하는 방향
                rigid.AddForce(diveDirection, ForceMode.Impulse);
            }
        }

        // 오른쪽으로 다이빙하기
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (jumpCount == 0)
            {
                Vector3 diveDirection = transform.right * diveForce; // 오른쪽으로 다이빙하는 방향
                rigid.AddForce(diveDirection, ForceMode.Impulse);
            }
        }
    }
            

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            jumpCount++;
        }
    }
}
