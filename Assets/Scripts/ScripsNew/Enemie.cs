using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public int frame1;
    public int lifeChanges1;
    [SerializeField] AudioSource audiohit;

    public void SetAudio(AudioSource hit)
    {
        audiohit = hit;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            audiohit.Play();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
           Destroy(gameObject);
        }
    }
}
