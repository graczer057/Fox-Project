using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject OptionsImage;
    public PlayerHealth playerHealth;

    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    public void FixedUpdate()
    {
        
    }
    public void Continue()
    {

    }
    public void NewGame()
    {
        SceneManager.LoadScene("Cinematic 1");
    }
    public void LoadSave()
    {
        playerHealth.LoadPlayer();
    }
    public void Options()
    {
        //OptionsImage.gameObject.SetActive(true);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
