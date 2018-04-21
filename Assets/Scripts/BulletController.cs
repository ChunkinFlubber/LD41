using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour, IProjectile {

    Vector3 dir;
    
    [SerializeField]
    float speed;

	// Use this for initialization
	void Start ()
    {
        //dir = new Vector3(0.0f, 0.0f, 0.0f);
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(dir.normalized * speed * Time.deltaTime);
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
