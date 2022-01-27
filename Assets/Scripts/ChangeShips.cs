using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeShips : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    public Sprite[] sprites;
    int k=0;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    public void changeship()
    {
        if(k>=sprites.Length)
        {
            k=0;
        }
        spriteRenderer.sprite=sprites[k];
        if(k<sprites.Length)
        {
            k++;
        }
    }
}
