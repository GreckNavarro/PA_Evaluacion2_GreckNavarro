using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public int life = 3;
    public float score = 0;
    public float modify;
    [SerializeField] ScorePlayer so;

    private void Start()
    {
        modify = 1;
    }
    public ScorePlayer GetSO()
    {
        return so;
    }
    private void Update()
    {
        if(life > 0)
        {
            score += Time.deltaTime * modify;
        }
    }
    public float ReturnScore()
    {
        return score;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemie")
        {
            life -= 1;
            if(life == 0)
            {
                modify = 0;
                so.RegistryNewScore(score);
                Destroy(gameObject);
            }
        }
    }
    

}
