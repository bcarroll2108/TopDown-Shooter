using UnityEngine;
using System.Collections;
using UnityEngine.UI;

[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : LivingEntity
{

    public enum State { Idle, Chasing, Attacking };
    State currentState;

    NavMeshAgent pathfinder;
    Transform target;
    LivingEntity targetEntity;
    Material skinMaterial;

    Color originalColour;

    float attackDistanceThreshold = .5f;
    float timeBetweenAttacks = 1;
    float damage = 1;

    float nextAttackTime;
    float myCollisionRadius;
    float targetCollisionRadius;


    bool hasTarget;

    bool attacked;
    public int attackCount;

    public ParticleSystem deathFX;
    public int bloodCount;
    public GameObject character;
    public Animator animator;







    protected override void Start()
    {
        bloodCount = 0;
        base.Start();
        pathfinder = GetComponent<NavMeshAgent>();
        skinMaterial = GetComponent<Renderer>().material;
        originalColour = skinMaterial.color;
        attacked = false;
        attackCount = 0;
       


        if (GameObject.FindGameObjectWithTag("base") != null)
        {
            currentState = State.Chasing;
            //animation.Play("run");
            //GetComponentInChildren<Animation>();

            hasTarget = true;

            target = GameObject.FindGameObjectWithTag("base").transform;
            targetEntity = target.GetComponent<LivingEntity>();
            //targetEntity.OnDeath += OnTargetDeath;

            myCollisionRadius = GetComponent<CapsuleCollider>().radius;
            //targetCollisionRadius = target.GetComponent<CapsuleCollider>().radius;

            StartCoroutine(UpdatePath());

        }
    }

    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }


public override void TakeHit(float damage, Vector3 hitPoint, Vector3 hitDirection)
    {
        if (damage >= currentHealth && bloodCount <1)
        {
            bloodCount++;
            Destroy(Instantiate(deathFX.gameObject, hitPoint, Quaternion.FromToRotation(Vector3.forward, hitDirection)) as GameObject, deathFX.startLifetime);
            GameObject.Destroy(character.gameObject);
        }
        base.TakeHit(damage, hitPoint, hitDirection);
    }




    void OnTargetDeath()
    {
        hasTarget = false;
        currentState = State.Idle;
    }


    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            animator.SetBool("attack", true);
            Debug.Log("attack");
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("attack", false);
        }
    }



    void Update()
    {

        if (hasTarget)
        {
            if (Time.time > nextAttackTime)
            {
                float sqrDstToTarget = (target.position - transform.position).sqrMagnitude;
                if (sqrDstToTarget < Mathf.Pow(attackDistanceThreshold + myCollisionRadius + targetCollisionRadius, 2))
                {
                    nextAttackTime = Time.time + timeBetweenAttacks;
                    StartCoroutine(Attack());
                    attacked = true;
                    //Destroy(gameObject);


                    if (attacked == true)
                    {
                        IDamageable damageableObject = GetComponent<IDamageable>();
                        damageableObject.TakeDamage(damage);
                       
                        attackCount++;
                        Debug.Log("attacked");

                        Destroy(gameObject);

                    }

                }

            }
        }



    }


            IEnumerator Attack()
    {

        currentState = State.Attacking;
        pathfinder.enabled = false;

        Vector3 originalPosition = transform.position;
        Vector3 dirToTarget = (target.position - transform.position).normalized;
        Vector3 attackPosition = target.position - dirToTarget * (myCollisionRadius);

        float attackSpeed = 3;
        float percent = 0;

        skinMaterial.color = Color.red;
        bool hasAppliedDamage = false;


        while (percent <= 1)
        {

            if (percent >= .5f && !hasAppliedDamage)
            {
                hasAppliedDamage = true;
                targetEntity.TakeDamage(damage);
            }

            percent += Time.deltaTime * attackSpeed;
            float interpolation = (-Mathf.Pow(percent, 2) + percent) * 4;
            transform.position = Vector3.Lerp(originalPosition, attackPosition, interpolation);

            yield return null;
        }

        skinMaterial.color = originalColour;
        currentState = State.Chasing;
        pathfinder.enabled = true;
    }

    IEnumerator UpdatePath()
    {
        float refreshRate = .25f;

        while (hasTarget)
        {
            if (currentState == State.Chasing)
            {
                Vector3 dirToTarget = (target.position - transform.position).normalized;
                Vector3 targetPosition = target.position - dirToTarget * (myCollisionRadius + targetCollisionRadius + attackDistanceThreshold / 2);
                if (!dead)
                {
                    pathfinder.SetDestination(targetPosition);
                }
            }
            yield return new WaitForSeconds(refreshRate);
        }
    }



}