using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] GameObject gun;
    AttackerSpawner myLaneSpawner;
    Animator animator;
     GameObject projectileParent;
    const string PROJECTİLE_PARENT_NAME = "Projectiles";
     private void Start()
    {
        SetLaneSpawner();
        animator = GetComponent<Animator>();
        CreateProjectileParent();
    }

     private void Update()
    {
        if(IsAttackerInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

     private void CreateProjectileParent()
    {
        projectileParent = GameObject.Find(PROJECTİLE_PARENT_NAME);
        if (!projectileParent)
        {
            projectileParent = new GameObject(PROJECTİLE_PARENT_NAME);
        }
    }

    private bool IsAttackerInLane()
    {
        if (myLaneSpawner.transform.childCount <= 0) //if childcount = 0 then there is no attacker in my lane
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void SetLaneSpawner()
    {
        AttackerSpawner[] spawners = FindObjectsOfType<AttackerSpawner>();

        foreach (AttackerSpawner spawner in spawners)
        {
            bool IsCloseEnough = (Mathf.Abs(spawner.transform.position.y - transform.position.y) <= Mathf.Epsilon); //Mathf.Epsilon almost equals 0
            
            if (IsCloseEnough)
            {
                myLaneSpawner = spawner;
            }
        }
    }

    public void Fire()
    {
        GameObject newProjectile =  Instantiate(projectile, gun.transform.position, gun.transform.rotation) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
    }
}
