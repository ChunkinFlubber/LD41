using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool Activated = false;
    [SerializeField]
    Transform SightTrans = null;
    [SerializeField]
    Transform[] gunTransforms = null;
    [SerializeField]
    IProjectile Bullet = null;
    [SerializeField]
    float ROF = 1.0f;
    int currGunSlot = 0;
    float fireTimeing = 0;
    float currFireTime = 0;
    GameObject Player = null;
	// Use this for initialization
	void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        fireTimeing = 1 / ROF;
        currFireTime = fireTimeing;
	}
	
	// Update is called once per frame
	void Update ()
    {
        currFireTime += Time.deltaTime;
        if (Activated && Player != null)
        {
            ShootAtPlayer();
            //May or may not hide behind cover
        }
	}

    void ShootAtPlayer()
    {
        //Look at player
        transform.LookAt(Player.transform);
        //Can we see player
        if (CheckSight())
        {
            //Shoot at player
            if(currFireTime >= fireTimeing)
            {

            }
        }
    }

    bool CheckSight()
    {
        Ray ray = new Ray(SightTrans.position, SightTrans.forward);
        RaycastHit hit;
         if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }
}
