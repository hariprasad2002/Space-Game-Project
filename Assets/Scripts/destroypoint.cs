//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class destroypoint : MonoBehaviour
{
    //private Vector2 screenbounds;
    
    void Start()
    {
        //screenbounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "asteroid" || collision.tag == "bullet")
        {
            Destroy(collision.gameObject);
        }
        if(collision.tag == "enemy")
        {
            Destroy(collision.gameObject,2f);
        }
        if(collision.tag == "particles")
        {
            Destroy(collision.gameObject,3f);
        }
        if(collision.tag == "planets")
        {
            //Debug.Log(collision.name);
            Destroy(collision.gameObject,10f);
        }
        if (collision.tag=="fuelstation")
        {
            Destroy(collision.gameObject, 5f);
        }
    }
}
