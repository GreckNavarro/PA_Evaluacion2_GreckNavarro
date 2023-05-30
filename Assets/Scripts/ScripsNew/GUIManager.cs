using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour
{

    public static GUIManager instance { get; private set; }
    [SerializeField] private TMP_Text ps1;
    [SerializeField] private PlayerGUI pl1;
    [SerializeField] float score1;
    [SerializeField] ScorePlayer so1;

    [SerializeField] private TMP_Text ps2;
    [SerializeField] private PlayerGUI pl2;
    [SerializeField] float score2;
    [SerializeField] ScorePlayer so2;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            
        }

        instance = this;
    }
    private void Start()
    {
        so1 = pl1.GetSO();
        so2 = pl2.GetSO();
    }

    private void Update()
    {
        if(pl1.life > 0)
        {
            score1 = pl1.ReturnScore();
            Debug.Log(score1);
            ps1.text = "Score: " + score1;
        }
        else
        {
            ps1.text = "Score: " + score1;
        }

        if(pl2.life > 0)
        {
            score2 = pl2.ReturnScore();
            Debug.Log(score2);
            ps2.text = "Score: " + score2;
        }
        else
        {
            ps2.text = "Score: " + score2;
        }
        GoToMenu();
    }
    public void GoToMenu()
    {

        if(pl1 == null && pl2 == null )
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
