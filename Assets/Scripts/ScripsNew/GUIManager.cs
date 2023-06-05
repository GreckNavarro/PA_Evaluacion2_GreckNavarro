using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour
{

    public static GUIManager instance { get; private set; }
    [SerializeField] private TMP_Text textscore1;
    [SerializeField] private PlayerGUI pl1;
    [SerializeField] private TMP_Text vidaPlayer1;
     float score1;
     float life1;
    [SerializeField] ScorePlayer so1;

    public int i = 0;



    [SerializeField] private TMP_Text textscore2;
    [SerializeField] private PlayerGUI pl2;
    [SerializeField] private TMP_Text vidaPlayer2;
    float score2;
    float life2;
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
        PlayerPrefs.SetInt("Ganador", 0);

    }

    private void Update()
    {
        if(pl1.life > 0)
        {
            score1 = pl1.ReturnScore();
            life1 = pl1.ReturnLife();
            textscore1.text = "Score P1: " + Mathf.RoundToInt(score1);
            vidaPlayer1.text = "Vida P1: " + life1;
            
        }
        else if(pl1.life <= 0 && pl2 != null)
        {
            PlayerPrefs.SetInt("Ganador", 2);
            
        }
        else
        {
            textscore1.text = "Score: " + Mathf.RoundToInt(score1);
            vidaPlayer1.text = "Vida P1 Eliminado";
        }

        if(pl2.life > 0)
        {
           
            score2 = pl2.ReturnScore();
            life2 = pl2.ReturnLife();
            textscore2.text = "Score P2: " + Mathf.RoundToInt(score2);
            vidaPlayer2.text = "Vida P2: " + life2;
        }
        else if(pl2.life <= 0 && pl1 != null)
        {
            PlayerPrefs.SetInt("Ganador", 1);
            
            
        }
        else
        {
            textscore2.text = "Score: " + Mathf.RoundToInt(score2);
            vidaPlayer2.text = "Vida P2 Eliminado";
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
