using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour, IProjectile
{
    float AliveTime = 10.0f;
    Vector3 Direction = Vector3.zero;
    [SerializeField]
    float damage = 5.0f;
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

    void OnTriggerEnter(Collider e)
    {
        if(e.gameObject.tag == "Player")
        {
<<<<<<< HEAD
            e.GetComponentInParent<IDamageable>().Damage(damage);
            //e.GetComponent<IDamageable>().Damage(damage);
=======
            IDamageable damageable = e.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.Damage(damage);
            }
>>>>>>> 4efec53be9f5e7ebdb0c57eed93b2a4447de54a6
            Destroy(gameObject);
        }
        else if(e.gameObject.tag != "Enemy")
        {
            Destroy(gameObject);
        }
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
