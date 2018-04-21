using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public bool Activated = false;
    [SerializeField]
    Transform SightTrans = null;
    [SerializeField]
    Transform[] gunTransforms = null;
    [SerializeField]
    GameObject BulletObject = null;
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
        if(BulletObject == null)
        {
            Debug.LogError("No Bullet Set!", gameObject);
            return;
        }
        Bullet = BulletObject.GetComponent<IProjectile>();
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
                Transform gun = gunTransforms[currGunSlot];
                if(BulletObject == null)
                {
                    Debug.LogError("No bullet prefab to spawn!", gameObject);
                }
                //Spawn and shoot projectile
                GameObject bullet = Instantiate(BulletObject, gun.position, gun.rotation);
                bullet.transform.LookAt(Player.transform);
                Debug.DrawRay(gun.position, bullet.transform.forward * 500, Color.red);
                bullet.GetComponent<IProjectile>().Shoot(bullet.transform.forward);
                //Cycle through guns
                ++currGunSlot;
                if (currGunSlot == gunTransforms.Length)
                    currGunSlot = 0;
                currFireTime = 0;
            }
        }
    }

    bool CheckSight()
    {
        if(SightTrans == null)
        {
            Debug.LogError("No sight transform set!", gameObject);
            return false;
        }
        Ray ray = new Ray(SightTrans.position, SightTrans.forward * 500);
        RaycastHit hit;
        Debug.DrawRay(SightTrans.position, SightTrans.forward * 500, Color.red);
         if(Physics.Raycast(ray, out hit))
        {
            if (hit.collider.tag == "Player")
            {
                return true;
            }
        }
        return false;
    }

    public void Damage(float damageTaken)
    {
        //TO-DO:Take damage and update any health bars
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}