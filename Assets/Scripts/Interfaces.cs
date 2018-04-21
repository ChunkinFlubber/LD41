using UnityEngine;
using System.Collections;

public interface IProjectile
{
    void Shoot(Vector3 direction);
    void Shoot(Ray direction);
    void Shoot(Ray direction, float speed);
    void Shoot(Vector3 direction, float speed);
}

public interface IDamageable
{
    void Damage(float damageTaken);
}
