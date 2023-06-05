using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
public class GameOverController : MonoBehaviour
{
    public Button btnPlay;
    [SerializeField] public int ganador;
    [SerializeField] private TMP_Text TextWinner;

    // Start is called before the first frame update
    void Start()
    {
        ganador = PlayerPrefs.GetInt("Ganador");
        btnPlay.onClick.AddListener(() => ReturnMenu());

        if(ganador == 1)
        {
            TextWinner.text = "El Ganador es: P1";
        }
        else if(ganador == 2)
        {
            TextWinner.text = "El Ganador es: P2";
        }
    }



    void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
