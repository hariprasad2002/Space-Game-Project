//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityStandardAssets.CrossPlatformInput;
//using UnityEngine.SceneManagement;

public class playercontrol : MonoBehaviour
{
    //player movement
    private float Xdir;
    private float Ydir;
    [SerializeField]private Slider movement;
    [SerializeField]private float speed=3f;
    private Rigidbody2D rb;
    [SerializeField]private Text distancetext;
    [SerializeField]private Text scoretext;
    [SerializeField]private Text highscoretext;
    [SerializeField]private Text speedtext;
    private int highscore=0;
    //animation
    [SerializeField]private Animator anim;

    //player health
    private float maxhealth=100f;
    private float currenthealth;
    [SerializeField]private Slider healthslider;
    private float healthvalue=5f;
    [SerializeField]private Gradient healthgradient;
    [SerializeField]private Image fill;

    //shooting
    [SerializeField]private float bulletspeed=20f;
    [SerializeField] private GameObject bulletprefab;
    [SerializeField] private GameObject bulletflash;
    [SerializeField] private Transform firepoint;
    //private float firedelay = 0.1f;
    public GameObject hiteffect;
    public GameObject gameoverUI;

    Fuelsystem fuelsystem;   //fuel system
    [SerializeField]private AudioClip clip;
    [SerializeField]private AudioClip clip1;
    [SerializeField]private AudioClip clip2;
    [SerializeField]private AudioSource source;
    void Start()
    {
        anim=GetComponent<Animator>();
        fuelsystem=GetComponent<Fuelsystem>();
        rb = GetComponent<Rigidbody2D>();
        currenthealth = maxhealth;
        healthslider.maxValue=maxhealth;
        updatehealth();
        highscoretext.text="High Score: "+highscore;
        //audio play
        source.PlayOneShot(clip);
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            firebullet();
            source.PlayOneShot(clip1);
        }
        //Debug.Log(currenthealth);
    }
    void FixedUpdate()
    {
        if(fuelsystem.currentFuel <=0 || currenthealth<=0)
        {
            GameObject effect = Instantiate(hiteffect, transform.position, Quaternion.identity);
            Destroy(effect, 5f);
            Destroy(this.gameObject);
            scoretext.text="Your Score: "+distancetext.text;
            highscoretext.text="High Score: "+highscore+"m";
           //Time.timeScale=0;
           gameoverUI.SetActive(true);
        }
        //Xdir = CrossPlatformInputManager.GetAxis("Horizontal")*speed;
        //Xdir = (movement.value-1);
        Xdir = Input.GetAxis("Horizontal");
        movement.value=Xdir+1;
        Ydir = Input.GetAxis("Vertical");
        anim.SetFloat("DirX",Xdir);
        //anim.SetFloat("Ydir",Ydir);
        rb.velocity = new Vector2(Xdir*speed, Ydir+speed);
        int dist=(int)transform.position.y;
        if(highscore<dist)
        {
            highscore=dist;
        }
        distancetext.text=(dist).ToString()+" m";
        speedtext.text=(rb.velocity.y*2).ToString()+" MPH";
        fuelsystem.fuelconsumptionrate = speed * speed;
        fuelsystem.fuelconsume();
    }
    //fire bullet method
    private void firebullet()
    {
        GameObject bullet = Instantiate(bulletprefab, firepoint.position, firepoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        GameObject flash = Instantiate(bulletflash, firepoint.position, Quaternion.identity);
        Destroy(flash,1f);
        rb.AddForce(firepoint.up * bulletspeed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        source.PlayOneShot(clip2);
        consumehealth(healthvalue);
        GameObject effect = Instantiate(hiteffect, collision.transform.position, Quaternion.identity);
        Destroy(effect, 5f);
    }
    //health related code
    void updatehealth()
    {
        healthslider.value=currenthealth;
        fill.color=healthgradient.Evaluate(healthslider.normalizedValue);
        if(currenthealth<=0)
        {
            currenthealth=0;
        }
    }
    public void consumehealth(float value)
    {
        currenthealth -= value;
        updatehealth();
    }
    
}
