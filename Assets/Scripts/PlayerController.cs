using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageable {

    float hp;
    bool isAlive;

    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    GameObject Camera;
    [SerializeField]
    Text TextHP;

	void Start ()
    {
        hp = 100.0f;
        UpdateUI();
        isAlive = true;
	}
	
	void Update ()
    {
        if (isAlive)
        {
            // Fire Weapon.
            if (Input.GetButtonDown("Fire1"))
            {
                Shoot();
            }
        }
        // Update isAlive state.
        if (hp <= 0)
            isAlive = false;
	}

    void Shoot()
    {
        // Create instance of bullet.
        GameObject p;
        p = Instantiate(Bullet, gameObject.transform.position, gameObject.transform.rotation);
        p.GetComponent<IProjectile>().Shoot(Camera.transform.forward);
    }

    void UpdateUI()
    {
        // Update HP text.
        if (TextHP != null)
        {
            TextHP.text = hp.ToString();
        }
    }

    public void Damage(float damageTaken)
    {
        // Todo: Update health & UI bar.
        hp = Mathf.Max(hp - damageTaken, 0);
        UpdateUI();
        if(hp == 0)
            isAlive = false;
    }

    public GameObject GetObject()
    {
        return gameObject;
    }

    public bool GetIsAlive()
    {
        return isAlive;
    }
}
