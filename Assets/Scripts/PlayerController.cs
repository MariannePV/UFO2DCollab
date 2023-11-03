using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    //Declaració de variables
    [SerializeField]
    float speed;

    [SerializeField]
    TextMeshProUGUI text_points;

    [SerializeField]
    TextMeshProUGUI text_final;

    [SerializeField]
    TextMeshProUGUI nom_final;

    [SerializeField]
    Button btn_restart;

    [SerializeField]
    GameObject panel_final;

    int points = 0;

    bool final = false;
    
    private Rigidbody2D rb2d;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float moveHorizontal;
        float moveVertical;

        if(Application.platform == RuntimePlatform.Android)
        {
            moveHorizontal = Input.acceleration.x;
            moveVertical = Input.acceleration.y;
        } else
        {
            moveHorizontal = Input.GetAxis("Horizontal");
            moveVertical = Input.GetAxis("Vertical");
        }

        Vector2 movement = new Vector2(moveHorizontal, moveVertical);
        rb2d.AddForce(movement * speed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag.Equals("Pickup"))
        {
            points++;   //Suma un punt
            Destroy(collision.gameObject);
            text_points.text = points.ToString();

            if (points == 9)    //Comprova si la puntuació ha arribat a 9 per finalitzar el joc
            {
                final = true;
            }
        }        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))   //Detecta si es presiona la tecla Esc per sortir del joc
        {
            Application.Quit();
        }

        if (final)      //Si la variable final és true, mostra la pantalla final i para el joc
        {
            text_final.gameObject.SetActive(true);
            btn_restart.gameObject.SetActive(true);
            nom_final.gameObject.SetActive(true);
            panel_final.SetActive(true);

            rb2d.velocity = Vector2.zero;
            rb2d.angularVelocity = 0;
            speed = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.R))    //Comproba si s'ha pulsat la tecla R i reseteja el joc
        {
            SceneManager.LoadScene(0);
        }
    }
}
