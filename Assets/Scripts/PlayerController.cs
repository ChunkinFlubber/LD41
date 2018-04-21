using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable {

    float hp;

    [SerializeField]
    GameObject Bullet;

    [SerializeField]
    GameObject Camera;

	// Use this for initialization
	void Start () {
        hp = 100.0f;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
	}

    void Shoot()
    {
        // Create instance of bullet.
        GameObject p;
        p = Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
        p.GetComponent<IProjectile>().Shoot(Camera.transform.forward);
    }

    public void Damage(float damageTaken)
    {
        // Todo: Update health & UI bar.
    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
