using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGUI : MonoBehaviour
{
    public int life = 3;
    [SerializeField] float score = 0;
    float modify;
    public ScorePlayer so;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemie")
        {
            life -= 1;
            if(life <= 0)
            {
                modify = 0;
                so.RegistryNewScore(score);
                Destroy(gameObject);
            }
        }
        else if(collision.gameObject.tag == "Candy")
        {
            score += collision.GetComponent<CandyController>().scorechanges;
        }
        else if (collision.gameObject.tag == "Musroom")
        {
            score += collision.GetComponent<CandyController>().scorechanges;
        }
        else if (collision.gameObject.tag == "Coffee")
        {
            score += collision.GetComponent<CandyController>().scorechanges;
        }
    }
    public float ReturnScore()
    {
        return score;
    }
    public float ReturnLife()
    {
        return life;
    }

}
