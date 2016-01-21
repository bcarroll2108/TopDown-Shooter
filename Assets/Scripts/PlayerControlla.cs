using UnityEngine;
using System.Collections;
using UnityStandardAssets.CrossPlatformInput;


[RequireComponent(typeof(GunController))]
public class PlayerControlla : MonoBehaviour
{
    public float myForce = 5, boostMultiplier = 2;
    Rigidbody myBody;


    GunController gunController;
    public Joystick rightjoystick;




    void Start ()
    {
        myBody = this.GetComponent<Rigidbody>();
        gunController = GetComponent<GunController>();
    }




    void FixedUpdate ()
    {

        //player rotation (Left Joystick)
        float sngHorizontalAxis = CrossPlatformInputManager.GetAxis("leftHorizontal");
        float sngVerticalAxis = CrossPlatformInputManager.GetAxis("leftVertical");

        float rightHorizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");  //new
        float rightVerticalAxis = CrossPlatformInputManager.GetAxis("Vertical");      //new

        sngHorizontalAxis = sngHorizontalAxis * Time.deltaTime;
        sngVerticalAxis = sngVerticalAxis * Time.deltaTime;

        rightHorizontalAxis = rightHorizontalAxis * Time.deltaTime;                         //new
        rightVerticalAxis = rightVerticalAxis * Time.deltaTime;                             //new


        Vector3 objDirection = new Vector3(sngHorizontalAxis, 0, sngVerticalAxis);

        Vector3 RightobjDirection = new Vector3(rightHorizontalAxis, 0, rightVerticalAxis);          //new


        //Player Movement (Right Joystick)
        Vector3 moveVec = new Vector3(CrossPlatformInputManager.GetAxis("leftHorizontal"),0,  CrossPlatformInputManager.GetAxis("leftVertical")) * myForce; //rightstick
        //Vector3 moveVec1 = new Vector3(CrossPlatformInputManager.GetAxis("Horizontal"), 0, CrossPlatformInputManager.GetAxis("Vertical")) * myForce; //leftstick
        //transform.rotation = Quaternion.LookRotation(objDirection);

       transform.rotation = Quaternion.LookRotation(objDirection);                 //new

        transform.Rotate(0, -90, 1);

        

        if (rightjoystick.moved == true)
        {
            transform.rotation = Quaternion.LookRotation(RightobjDirection);             //delete
            transform.Rotate(0, -90, 1);
            gunController.Shoot();
        }


        


        bool isBoosting = CrossPlatformInputManager.GetButton("Shoot");
        Debug.Log(isBoosting ? boostMultiplier : 1);

        myBody.AddForce(moveVec * (isBoosting ? boostMultiplier : 1));

    }

}
