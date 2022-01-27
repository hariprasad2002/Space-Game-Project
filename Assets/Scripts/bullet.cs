using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public GameObject hiteffect;
    public float deathtime = 5f;
    private void Start()
    {
        StartCoroutine(death());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
        Destroy(effect, 3f);
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "bulletdestroy" || collision.tag == "destroypoint")
        {
            Destroy(gameObject);
        }
        if(collision.tag == "asteroid")
        {
            Destroy(collision.gameObject);
        }
    }
    IEnumerator death()
    {
        while (true)
        {
            yield return new WaitForSeconds(deathtime);
            Destroy(gameObject);
        }
    }
}
