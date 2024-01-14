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
        SideCheck();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount == 1)
        {
            rigid.AddForce(new Vector2(0f, jumpForce),ForceMode.Impulse);
            jumpCount--;
        }
    }

    void Move()
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

    void Dive()
    {
        // 왼쪽으로 다이빙하기
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (jumpCount == 0)
            {
                transform.Translate(Vector3.left * diveForce * Time.deltaTime);              //GetKey로 diveForce에 값을 저장받고 저장받은 -diveForce만큼 이동하기
                //rotation 90
            }
        }

        // 오른쪽으로 다이빙하기
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (jumpCount == 0)
            {       
                //GetKey로 diveForce에 값을 저장받고 저장받은 diveForce만큼 이동하기
                //rotation -90
            }
        }
    }

    void SideCheck()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, -80f, 0f);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 80f, 0f);
        }   
        if (Input.GetKeyUp(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);
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
