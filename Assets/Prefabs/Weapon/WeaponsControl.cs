using UnityEngine;
using System.Collections;

public class WeaponsControl : MonoBehaviour
{
    string Enemy = "aim";
    float distance;
    public float range = 0.5f;
    Transform target = null;

    public GameObject bulletPrefab;
    public int intialSpeed = 500;

    public Transform muzzle;
    public float muzzleVelocity = 35;
    public float msBetweenShots = 100;

    float current_time;
    float lastSpawnTime;
    public float spawnRate = 1.0f;
    public int countEnemie;
    public bool canShoot;


    private LivingEntity livingEntity;

    float nextShotTime;

    void Start()
    {
        InvokeRepeating("getTarget", 0, 1f); // search for enemy every 1 second
        countEnemie = 0;
        //canShoot = false;

    }


    void Update()
    {
        if (target != null && countEnemie>0)
        {
            transform.LookAt(target);

                shoot();
                lastSpawnTime = current_time; //reset


        }
    }

    void getTarget()
    {
        //add all tagged enemies into array
            GameObject[] allTaggedEnemies;


        allTaggedEnemies = GameObject.FindGameObjectsWithTag("Enemy") ;
            

            float distanceDectect = Mathf.Infinity; // initialize the var, which means we start the search from the farthest distance
            Transform closestTargetPosition = null;

            

            //keep detect if the target enemie is in range
            //if the target is in the range, we retrieve its target position
            foreach (GameObject taggedTarget in allTaggedEnemies)
            {
            if (taggedTarget.GetComponent<MeshRenderer>().isVisible)
            {
                distance = (taggedTarget.transform.position - transform.position).magnitude;
                if (distance > range)// check if enemy is inside the range
                    if (distance < distanceDectect) //check is the enemy is the clossest one
                    {
                        distanceDectect = distance;
                        closestTargetPosition = taggedTarget.transform;
                    }
            }
                
            }


            target = closestTargetPosition;
            //gameObject.GetComponent<MeshRenderer>().enabled = false;



            //then, the weapon can look at this target based on the position we get
       

    }

    void shoot()
    {
        if (Time.time > nextShotTime)
        {
            nextShotTime = Time.time + msBetweenShots / 1000;
            //spawn a bullet
            Projectile newProjectile = Instantiate(bulletPrefab, muzzle.position, muzzle.rotation) as Projectile;
            //shoot the bullet with force
            GetComponent<Rigidbody>().AddForce(transform.forward * intialSpeed);
        }

    }

        void OnTriggerEnter (Collider enemy)
        {
            if (enemy.tag == "Enemy")
            {
                //shoot();
                countEnemie++;
                Debug.Log("++");
            }
        }

        void OnTriggerExit (Collider enemy)
        {
            if (enemy.tag == "Enemy" )
            {
                countEnemie--;
            }
        }

    void OnTriggerStay(Collider enemy)
        {
            if (enemy.tag == "Enemy" )
            {
                canShoot = true;
                Debug.Log("shoot");
            }
            else
            {
                canShoot = false;
                Debug.Log("cant shoot");
            }
        }   
}
