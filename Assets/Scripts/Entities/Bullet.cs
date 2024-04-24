using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour 
{
    public float bulletSpeed;
    private string targetTag;
    private int damage;

    private void Update()
    {
        transform.Translate(Vector2.right * bulletSpeed * Time.deltaTime);
    }

    private void Start()
    {
        Destroy(gameObject, 5f);
    }

    public void SetUpBullet(string tag, int damageParam)
    {
        damage = damageParam;
        targetTag = tag;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag(targetTag))
        {
            //Debug.Log("Shot" + targetTag);
            collision.GetComponent<IDamageable>().ReceiveDamage();
            
            //collision.GetComponent<Enemy>().ReceiveDamage();
            Destroy(gameObject);   
        }
    }
}
