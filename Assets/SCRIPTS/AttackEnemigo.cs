using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AttackEnemigo : MonoBehaviour
{
    private Animator animator;

    public LayerMask enemigoLayer;
    public float radioDeteccion = 2f;

    private bool isAttacking = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, radioDeteccion, enemigoLayer);

        if (hitColliders.Length > 0)
        {
            Vector3 enemyPosition = hitColliders[0].transform.position;

            Vector3 directionToEnemy = (enemyPosition - transform.position).normalized;

            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(directionToEnemy.x, 0f, directionToEnemy.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);

            if (!isAttacking)
            {
                animator.SetTrigger("Attack");
                isAttacking = true;
            }
        }
        else
        {
            animator.ResetTrigger("Attack");
            isAttacking = false;
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radioDeteccion);
    }
}
