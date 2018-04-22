using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour, IDamageable {

    float hp = 100.0f;
    bool isAlive = true;
    bool isHurt = false;
    float hurtAlphaMax = 0.5f;
    float hurtAlphaInc;
    float hurtAlphaFadeTime = 30.0f;

    [SerializeField]
    GameObject Bullet;
    [SerializeField]
    GameObject Camera;
    [SerializeField]
    Text TextHP;
    [SerializeField]
    GameObject PanelHurt;

	void Start ()
    {
        hurtAlphaInc = 1.0f / hurtAlphaFadeTime;
        UpdateUI();
	}
	
	void Update ()
    {
        // Player combat mechanics.
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
        // Update UI.
        UpdateUI();
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
        // Update hurt panel alpha.
        if (isHurt)
        {
            Color c = PanelHurt.GetComponent<Image>().color;
            c.a = Mathf.Max(c.a - hurtAlphaInc, 0);
            PanelHurt.GetComponent<Image>().color = c;
            if (PanelHurt.GetComponent<Image>().color.a == 0)
                isHurt = false;
        }
    }

    public void Damage(float damageTaken)
    {
        if (!isHurt)
        {
            isHurt = true;
            // Update HP & isAlive state.
            hp = Mathf.Max(hp - damageTaken, 0);
            if (hp == 0)
                isAlive = false;
            // Set hurt panel alpha to max.
            Color c = PanelHurt.GetComponent<Image>().color;
            c.a = hurtAlphaMax;
            PanelHurt.GetComponent<Image>().color = c;
        }
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
