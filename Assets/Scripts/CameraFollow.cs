using System.Collections;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField]private Vector3 offset;
    private float smoothness = 0.07f;

    //backgrounds
    [SerializeField] private GameObject[] backgrounds;
    private int backgroundindex;
    private int temp;
    private float timetochange=70f;

    private void Start()
    {
        offset = new Vector3(0,3.8f,-10);
        changeBackgrounds();
        StartCoroutine(waittochangeBG());
    }
    void FixedUpdate()
    {
        Vector3 desiredpos = target.position + offset;
        Vector3 smoothedpos = Vector3.Lerp(transform.position, desiredpos, smoothness);
        transform.position = smoothedpos;

        //transform.LookAt(target);
    }
    public void changeBackgrounds()
    {
        backgroundindex = Random.Range(0, (backgrounds.Length - 1));
        backgrounds[backgroundindex].SetActive(true);
        backgrounds[temp].SetActive(false);
        temp=backgroundindex;
    }
    IEnumerator waittochangeBG()
    {
        while (true)
        {
            yield return new WaitForSeconds(timetochange);
            changeBackgrounds();
        }
    }
}
