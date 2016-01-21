using UnityEngine;
using System.Collections;

public class EnemyDie : MonoBehaviour
{
    private Animator animator;

    void Awake ()
    {
        animator = GetComponent<Animator>();
    }

    void playDead()
    {
        
    }

}
