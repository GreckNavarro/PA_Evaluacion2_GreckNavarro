using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed;
    Vector2 movimiento;
    [SerializeField] AudioSource controlador;
    [SerializeField] AudioClip[] audios1;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
    }



    private void FixedUpdate()
    {
        Movimiento();

    }
    void Movimiento()
    {
        myRB.velocity = movimiento * speed;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Candy")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
            controlador.clip = audios1[0];
            controlador.Play();
            Destroy(other.gameObject);

        }
        else if(other.tag == "Enemie")
        {
            transform.position = new Vector2(-5, 0);
            controlador.clip = audios1[1];
            controlador.Play();
        }
        else if(other.tag == "Coffee")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
            controlador.clip = audios1[2];
            controlador.Play();
            Destroy(other.gameObject);
        }
        else if (other.tag == "Mushroom")
        {
            CandyGenerator.instance.ManageCandy(other.gameObject.GetComponent<CandyController>(), this);
           controlador.clip = audios1[2];
           controlador.Play();
            Destroy(other.gameObject);
        }
    }
    public void OnMovement(InputAction.CallbackContext value)
    {
        Vector2 inputMovement = value.ReadValue<Vector2>();
        movimiento = new Vector2(0, inputMovement.y);
    }

    




  
}
