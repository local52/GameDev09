using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : PlayerBulletController
{
    [SerializeField] int speed = 6;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] string groundTag = "Ground"; // タグで地面判定
    [SerializeField] float airControlDuration = 0.3f; // 空中移動可能時間（秒）
    [SerializeField] float airControlMultiplier = 0.3f; // 空中での移動力（地上の割合）

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
        // 減衰付き移動
        Vector3 moveDir = movement.normalized;
        float currentSpeed = speed;

        if (!isGrounded && Time.time >= airControlEndTime)
        {
            // 空中かつ制限時間外 → 減衰した移動力
            currentSpeed *= airControlMultiplier;
        }

        // 加速度的に移動（velocity を直接上書きせず）
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
            Destroy(gameObject); // 自身を破壊
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
