using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponType
{
    None,
    Projectile,
    Beam,
    Explosive,
    Meele,
    Gun
}

public class Weapon : MonoBehaviour
{
    [Range(0, 50)] public int ammo = 30;
    public int damage;

    public WeaponType type;

    public GameObject projectile;

    public Transform spawnPoint;
    

    public void Fire(Vector3 direction)
    {
        if (type == WeaponType.Projectile)
        {
            GameObject go = Instantiate(projectile, spawnPoint);
            go.GetComponent<Rigidbody>().AddForce(direction);
        }
    }
}
