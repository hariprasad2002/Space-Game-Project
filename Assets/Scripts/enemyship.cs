using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyship : MonoBehaviour
{
    private Rigidbody2D rb;
    //shooting
    [SerializeField] private float bulletspeed = 20f;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private GameObject bulletflash;
    [SerializeField] private Transform firepoint;
    [SerializeField]private float firedelay = 0.2f;

    //health
    private float maxhealth=100f;
    private float currenthealth;
    [SerializeField]private Slider healthbar;
    [SerializeField]private Image fill;
    [SerializeField]private Gradient healthgradient;
    [SerializeField]private GameObject hiteffect;

    private void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        StartCoroutine(wait());
        currenthealth = maxhealth;
        healthbar.maxValue=maxhealth;
        updatehealth();
    }
    void Update()
    {
        if(currenthealth<=0)
        {
           Destroy(gameObject);
        }
        //Debug.Log(currenthealth);
        rb.velocity = new Vector2(0, -3f);
    }
    private void firebullet()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        GameObject flash = Instantiate(bulletflash, firepoint.position, Quaternion.identity);
        Destroy(flash, 1f);
        rb.AddForce(firepoint.up * bulletspeed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        currenthealth -= 10f;
        updatehealth();
        GameObject effect = Instantiate(hiteffect, collision.transform.position, Quaternion.identity);
        Destroy(effect, 5f);
    }
    IEnumerator wait()
    {
        while (true)
        {
            yield return new WaitForSeconds(firedelay);
            firebullet();
        }
    }
    void updatehealth()
    {
        healthbar.value=currenthealth;
        fill.color=healthgradient.Evaluate(healthbar.normalizedValue);
        if(currenthealth<=0)
        {
            currenthealth=0;
        }
    }
}
