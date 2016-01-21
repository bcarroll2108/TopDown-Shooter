using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
[RequireComponent(typeof(GunController))]
public class Player : LivingEntity
{

    public float moveSpeed = 5;

    Camera viewCamera;
    PlayerController controller;
    GunController gunController;

    private Vector3 touchOrigin = -Vector3.one;

    public baseHealth baseHealth;

    public GameObject rightJoystick;


    protected override void Start()
    {
        base.Start();
        controller = GetComponent<PlayerController>();
        gunController = GetComponent<GunController>();
        viewCamera = Camera.main;
    }

    void Update()
    {

        // Movement input
        Vector3 moveInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 moveVelocity = moveInput.normalized * moveSpeed;
        controller.Move(moveVelocity);


        // Weapon input
        //if (Input.GetMouseButton(0))
        //if (rightJoystick.transform.position.y != 64)
       // {
       //    gunController.Shoot();
       // }

    }

    void playerDeath()
    {
        if (dead==true)
        {
            Debug.Log("He gone");
        }
    }


 //   void OnTriggerEnter(Collider Collision)
 //   {
 //     if (Collision.gameObject.tag == "Enemy")
 //       {
 //           baseHealth.healthOfBase--;
 //       }
 //  }


}

