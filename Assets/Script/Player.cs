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
    private bool isJump = false;
    private bool isDiving = false;
    private bool isDiveDirectionSet = false;
    private Vector3 diveDirection; // ���̺� ���� ����
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

    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) && jumpCount == 1 && !isJump && !isDiving)
        {
            rigid.AddForce(new Vector2(0f, jumpForce), ForceMode.Impulse);
            jumpCount--;
            isJump = true;
        }

        if (isJump && (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow)) && !isDiving)
        {
            isDiveDirectionSet = true;
            if (Input.GetKeyDown(KeyCode.LeftArrow))
                diveDirection = Vector3.left;
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                diveDirection = Vector3.right;
        }

        if (isJump && isDiveDirectionSet && Input.GetKeyDown(KeyCode.Space) && !isDiving)
        {
            rigid.AddForce(diveDirection * diveForce, ForceMode.Impulse);
            isDiving = true;
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.position += new Vector3(-1 * moveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += new Vector3(1 * moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void Dive()
    {
        // �߰��� ���̺� ���� ������ �ʿ��ϸ� ���⿡ �ۼ�
    }

    void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.tag == "Ground")
        {
            rigid.AddForce(Vector3.zero * diveForce * Time.deltaTime, ForceMode.Impulse);
            jumpCount++;
            isJump = false;
            isDiving = false;
            isDiveDirectionSet = false;
        }
    }
}
