using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour, IProjectile
{
    float AliveTime = 10.0f;
    Vector3 Direction = Vector3.zero;
    [SerializeField]
    float Speed = 12.0f;
    float time = 0.0f;
	
	// Update is called once per frame
	void Update ()
    {
        time += Time.deltaTime;
        transform.Translate(Direction * Speed * Time.deltaTime,Space.World);
        if (time >= AliveTime)
            Destroy(gameObject);
	}

    public GameObject GetObject()
    {
        return gameObject;
    }

    public void Shoot(Vector3 direction)
    {
        Direction = direction;
    }

    public void Shoot(Ray direction)
    {
        Direction = direction.direction;
    }

    public void Shoot(Ray direction, float speed)
    {
        
    }

    public void Shoot(Vector3 direction, float speed)
    {
        
    }
}
