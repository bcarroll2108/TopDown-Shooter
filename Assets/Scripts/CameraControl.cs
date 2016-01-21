using UnityEngine;
using System.Collections;

public class CameraControl: MonoBehaviour
{

    public GameObject player;

    private Vector3 offset;

    


    void Start()
    {
        offset = transform.position - GameObject.FindGameObjectWithTag("Player").transform.position;

    }

    void LateUpdate()
    {
        transform.position = GameObject.FindGameObjectWithTag("Player").transform.position + offset;
        //transform.rotation = GameObject.FindGameObjectWithTag("Player").transform.rotation;

    }
}