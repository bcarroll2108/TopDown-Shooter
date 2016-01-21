using UnityEngine;
using System.Collections;

public class baseKill1 : MonoBehaviour
{

    public Spawner spawner;
    public baseHealth baseHealth1;

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy" )
        {
           // if (collider.GetComponent<MeshRenderer>().isVisible)
           // {
                Debug.Log("die");
                spawner.OnEnemyDeath();
            //baseHealth1.countHealth();
            
           // }

            //gameObject.GetComponent<MeshRenderer>().enabled = false;
        }
    }
}
