using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemie : MonoBehaviour
{
    public int frame1;
    public int lifeChanges1;
    public int scorechanges;


    void Update()
    {
        if (transform.position.x <= -Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0)).x)
        {
            EnemiesGenerator.instance.ManageEnemie(this);
        }
    }
}
