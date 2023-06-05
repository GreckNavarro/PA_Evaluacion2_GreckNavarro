using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemiesGenerator : MonoBehaviour
{

    public static EnemiesGenerator instance;
    public List<GameObject> Enemies = new List<GameObject>();
    private float time_to_create = 1.0f;
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
            enemie.GetComponent<Enemie>().SetAudio(myaudio);
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



}

