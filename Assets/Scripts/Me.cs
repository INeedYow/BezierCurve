using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Me : MonoBehaviour
{
    public GameObject target;
    public Bullet prfBullet;

    public int count = 10;
    public float interval = 0.1f;
    public float cooldown = 1.5f;




    private void Start() {
        Attack();
    }



    void Attack()
    {
        StartCoroutine(Shoot());
    }



    IEnumerator Shoot()
    {
        for (int i = 0; i < count; i++)
        {
            Bullet bullet = GameObject.Instantiate(prfBullet, transform.position, Quaternion.identity) as Bullet;

            bullet.Launch(gameObject, target);

            yield return new WaitForSeconds(interval);
        }

        yield return new WaitForSeconds(cooldown);
        Attack();
    }
}
