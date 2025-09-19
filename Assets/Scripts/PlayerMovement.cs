using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : PlayerBulletController
{
    [SerializeField] int speed = 6;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] string groundTag = "Ground"; // �^�O�Œn�ʔ���
    [SerializeField] float airControlDuration = 0.3f; // �󒆈ړ��\���ԁi�b�j
    [SerializeField] float airControlMultiplier = 0.3f; // �󒆂ł̈ړ��́i�n��̊����j

    Rigidbody rb;
    Vector3 movement;
    bool isGrounded = false;
    float airControlEndTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = true;
    }

    void Update()
    {
        movement = Vector3.zero;

        //if (Input.GetKey("w"))
        //{
        //    movement += Vector3.forward;
        //    //transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (Input.GetKey("s"))
        //{
        //    movement += Vector3.back;
        //    //transform.rotation = Quaternion.Euler(0, 180, 0);
        //}
        if (Input.GetKey("a"))
        {
            movement += Vector3.left;
            //transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if (Input.GetKey("d"))
        {
            movement += Vector3.right;
            //transform.rotation = Quaternion.Euler(0, 90, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            airControlEndTime = Time.time + airControlDuration;
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
        }
    }

    void FixedUpdate()
    {
        // �����t���ړ�
        Vector3 moveDir = movement.normalized;
        float currentSpeed = speed;

        if (!isGrounded && Time.time >= airControlEndTime)
        {
            // �󒆂��������ԊO �� ���������ړ���
            currentSpeed *= airControlMultiplier;
        }

        // �����x�I�Ɉړ��ivelocity �𒼐ڏ㏑�������j
        Vector3 targetVelocity = moveDir * currentSpeed;
        Vector3 velocity = rb.velocity;
        Vector3 velocityChange = new Vector3(
            targetVelocity.x - velocity.x,
            0,
            targetVelocity.z - velocity.z
        );

        rb.AddForce(velocityChange, ForceMode.VelocityChange);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = true;
            airControlEndTime = 0f;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject); // ���g��j��
            FindObjectOfType<PlayerDeathSceneLoader>().OnPlayerDeath();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
            isGrounded = true;
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag(groundTag))
        {
            isGrounded = false;
        }
    }
}
