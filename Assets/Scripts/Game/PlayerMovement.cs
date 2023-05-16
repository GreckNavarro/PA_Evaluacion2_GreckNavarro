using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed;
    private float limitSuperior;
    private float limitInferior;
    public int player_lives = 4;
    Vector2 movimiento;
    public int puntaje;
    [SerializeField] AudioSource golpe;
    [SerializeField] AudioSource comer;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        SetMinMax();
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    private void FixedUpdate()
    {
        Movimiento();

    }
    void Movimiento()
    {
        myRB.velocity = movimiento * speed;
    }

    void SetMinMax()
    {
        Vector3 bounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        limitInferior = -bounds.y;
        limitSuperior = bounds.y;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
            comer.Play();
            Destroy(other.gameObject);

        }
        else if(other.tag == "Enemie")
        {
            EnemiesGenerator.instance.ManageEnemie(other.gameObject.GetComponent<Enemie>(), this);
            transform.position = new Vector2(-5, 0);
            golpe.Play();
            
        }
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        movimiento = new Vector2(0, inputMovement.y);
    }

    




  
}
