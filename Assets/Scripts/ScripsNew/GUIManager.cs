using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GUIManager : MonoBehaviour
{

    public static GUIManager instance { get; private set; }
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private float scoreTotal = 0;
    [SerializeField] private PlayerMovement player;
    [SerializeField] private ScorePlayer SOScores;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }

        instance = this;
    }

    private void Update()
    {
        scoreTotal += Time.deltaTime;
        Debug.Log(scoreTotal);
        DeathPlayer();
    }

    public void UpdateText(int pointsGained)    
    {
        scoreTotal += pointsGained;
        scoreText.text = string.Format("Score: {0} (+ {1})", scoreTotal, pointsGained);
    }
    public void DeathPlayer()
    {
         int lives = player.player_lives;
        if (lives <= 0)
        {

            Debug.Log(scoreTotal);
            SOScores.RegistryNewScore(scoreTotal);
            SceneManager.LoadScene("GameOver");
        }
    }

}
