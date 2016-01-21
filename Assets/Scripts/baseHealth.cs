using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class baseHealth : MonoBehaviour
{
    public int healthOfBase;
    public Text baseHealthText;

    public Spawner spawner;




    void start()
    {
        healthOfBase = 50;
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Enemy")
        {
                Debug.Log("die");
            Destroy(collider.gameObject);
                spawner.OnEnemyDeath();
            
            if (collider.GetComponent<MeshRenderer>().isVisible)
            {
                healthOfBase -= 1;
            }
        }
    }


    void Update()
    {
        
        baseHealthText.text = "Health: " + healthOfBase;
        gameOver();
    }

   void gameOver()
    {
        if (healthOfBase <=0)
        {
            Time.timeScale = 0;
        }
    }
    


}
