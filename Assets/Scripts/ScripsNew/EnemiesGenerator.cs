using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesGenerator : MonoBehaviour
{

    public static EnemiesGenerator instance;
    public List<GameObject> Enemies = new List<GameObject>();
    private float time_to_create = 0.5f;
    private float actual_time = 0f;
    private float limitSuperior;
    private float limitInferior;
    public List<GameObject> Enemies_actual = new List<GameObject>();
    [SerializeField] AudioSource myaudio;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        instance = this;
    }

    void Start()
    {
        SetMinMax();
    }

    public AudioSource ObtenerAudio()
    {
        return myaudio;
    }

    void Update()
    {
        actual_time += Time.deltaTime;
        if (time_to_create <= actual_time)
        {
            GameObject enemie = Instantiate(Enemies[Random.Range(0, Enemies.Count)],
            new Vector3(transform.position.x, Random.Range(limitInferior, limitSuperior), 0f), Quaternion.identity);
            enemie.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 0);
            actual_time = 0f;
            Enemies_actual.Add(enemie);
        }
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -(bounds.y * 0.9f);
        limitSuperior = (bounds.y * 0.9f);
    }

    public void ManageEnemie(Enemie enemigo_scrip, PlayerMovement player_script = null)
    {
        myaudio.Play();
        if (player_script == null)
        {
            Destroy(enemigo_scrip.gameObject);
            return;
        }

        if (enemigo_scrip.frame1 == 3)
        {
            SceneManager.LoadScene("GameOver");
            return;
        }
        /*int lives = player_script.player_lives;
        int live_changer = enemigo_scrip.lifeChanges1;
        lives += live_changer;
        print(lives);
        player_script.player_lives = lives;
        Destroy(enemigo_scrip.gameObject);
        */
    }


}

