using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamageable
{
    public bool Activated = false;
    [SerializeField]
    float hp = 100.0f;
    [SerializeField]
    Transform SightTrans = null;
    [SerializeField]
    Transform[] gunTransforms = null;
    [SerializeField]
    GameObject BulletObject = null;
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
                Vector3 dir = Player.transform.position - bullet.transform.position;
                dir = GetRandomDirInRange(dir, 0.5f);
                Debug.DrawRay(gun.position, dir * 500, Color.red);
                bullet.GetComponent<IProjectile>().Shoot(dir.normalized);
                //Cycle through guns
                ++currGunSlot;
                if (currGunSlot == gunTransforms.Length)
                    currGunSlot = 0;
                currFireTime = 0;
            }
        }
    }

    Vector3 GetRandomDirInRange(Vector3 dir, float range)
    {
        dir.x = dir.x + Random.Range(-range, range);
        dir.y = dir.y + Random.Range(-range, range);
        dir.z = dir.z + Random.Range(-range, range);
        return dir;
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
        hp -= damageTaken;
        if (hp <= 0)
            Destroy(gameObject);
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}