using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.InteropServices;

public class PlayerController : MonoBehaviour
{
    [DllImport("SimplePlugin")]
    private static extern int Changeprefab();

    public static event Action ShotEvent;

    public float speed = 3.0f;
    public UnityEngine.CharacterController controller;
    public Transform cam;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    Vector3 direction;
    Vector3 playerVelocity;

    public GameObject bullet;
    public GameObject dllBullet;
    public GameObject BulletEmitter;
    public float BulletSpeed;

    public float gravity = -9.81f;
    public bool groundedPlayer;

    void Start()
    {
        if (Changeprefab() == 1)
        {
            bullet = dllBullet;
        }
    }
    void Update()
    {
        PlayerMovement();
        Shooting();
    }

    void PlayerMovement()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * speed;

        direction = new Vector3(x, 0.0f, z).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f, angle, 0f);

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
    void Shooting()
    {
        if (Input.GetKeyDown("space"))
        {
            ShotEvent?.Invoke();

            GameObject Temporary_Bullet_Handler;
            Temporary_Bullet_Handler = Instantiate(bullet, BulletEmitter.transform.position, BulletEmitter.transform.rotation) as GameObject; //Get prefab and spawn it
            //Temporary_Bullet_Handler = Instantiate(bullet, new Vector3(transform.position.x, 1.57f, transform.position.z), transform.rotation);
            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = Temporary_Bullet_Handler.GetComponent<Rigidbody>();
            Temporary_RigidBody.AddForce(transform.forward * BulletSpeed);

            Destroy(Temporary_Bullet_Handler, 10.0f); //destroy bullet
        }

    }
}
