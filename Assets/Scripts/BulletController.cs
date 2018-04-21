using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IProjectile {

    Vector3 dir = Vector3.zero;
    
    [SerializeField]
    float speed;
    [SerializeField]
    float lifeTimer;

	// Use this for initialization
	void Start ()
    {
        //dir = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        // Update bullet's life timer.
        lifeTimer = Mathf.Max(lifeTimer - Time.deltaTime, 0.0f);
        if (lifeTimer == 0.0f)
        {
            Destroy(gameObject);
        }

        // Update bullet position.
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
	}

    public void Shoot(Vector3 direction)
    {
        dir = direction;
    }
    public void Shoot(Ray direction)
    {

    }
    public void Shoot(Ray direction, float speed)
    {

    }
    public void Shoot(Vector3 direction, float speed)
    {

    }

    public GameObject GetObject()
    {
        return gameObject;
    }
}
