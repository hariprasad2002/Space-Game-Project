using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class coinmanager : MonoBehaviour
{
    public float coins=0f;
    [SerializeField]private Text coinstext;
    private float incCoins=10f;
    
    void Start()
    {
        //player=GameObject.FindWithTag("Player");
        coinstext.text="0 Coins";
    }

    void Update()
    {
        if((int)transform.position.y==incCoins)
        {
            addcoins(1);
            incCoins=incCoins+10f;
        }
    }
    public void addcoins(float c)
    {
        coins+=c;
        coinstext.text=coins.ToString()+" Coins";
    }
}
