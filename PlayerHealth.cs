using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;            //Value of player health
    public GameObject deathEffect;      //Effect after death of the character
    public GameObject GameoverImage;    //Game over Image
    public GameObject UI;               //Player HUD
    public Slider healthSlider;         //That slider is a graphic presentation of player health
    public EndLevel endLevel;           //Script
    public GameManager gameManager;     //Script
    public GameObject Hidden1;
    public GameObject Hidden2;
    public GameObject Hidden3;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.SetActiveScene(SceneManager.GetActiveScene());
            //SavePlayer();
        }

        if (Input.GetKeyDown(KeyCode.F9))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            //LoadPlayer();
        }
    }

    public void SavePlayer()
    {
            DataSystem.SavePlayer(this);
            Debug.Log("I'm saving your progress");
    }

    public void LoadPlayer()
    {
            PlayerData data = DataSystem.LoadPlayer();

            health = data.health;

            Vector2 position;
            position.x = data.position[0];
            position.y = data.position[1];
            transform.position = position;
            Debug.Log("I'm loading your progress");
    }

    public void TakeDamage(int damage)          //Function of Taking damage
    {
        health -= damage;                       //Value of HP is changing
        healthSlider.value = health;            //Value of slider is changing after taking damage
        if (health <= 0)
        {
            Die();                              //Calling a function Die
        }
    }

    public void Die()                                                               //Function after HP is 0
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);          //Effect of death is Instantiating
        GameoverImage.gameObject.SetActive(true);                                   //Set active Game over image
        UI.gameObject.SetActive(false);                                             //Player HUD setting to false
        Destroy(gameObject);                                                        //Destroying our Player
        Cursor.visible = true;                                                      //Visible of cursor is again active
    }

    public void OnTriggerEnter2D(Collider2D collision)                              //That function checking collisions with Player
    {
        endLevel = collision.GetComponent<EndLevel>();                              //setting variable collision
        if(endLevel != null)                                                        //Checking collision witch object who has script endLevel
        {
            endLevel.Completed();                                                   //Calling function Completed from endLevel script
        }

        gameManager = collision.GetComponent<GameManager>();
        if(gameManager != null)
        {
            Hidden1.gameObject.SetActive(false);
            Hidden2.gameObject.SetActive(false);
            Hidden3.gameObject.SetActive(true);
        }
        else
        {
            Hidden1.gameObject.SetActive(true);
        }

    }

}
