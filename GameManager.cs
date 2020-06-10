using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject Dialog0;                  //In this game object i held all of UI from dialogs
    public GameObject Cutscene;                 //Soma black bars to cutscenes
    public GameObject Player;                   //Main player
    public GameObject Option;                   //Canvas of options menu
    public static GameManager instance;         //Instance of coroutine
    public static bool Paused = false;          //
    public TextMeshProUGUI text;
    int score;
    public PlayerPos pp;

    public void Awake()
    {
        Cursor.visible = false;
        if(instance == null)
        {
            instance = this;
        }
        StartCoroutine(Cut_scene());
    }

    public IEnumerator Cut_scene()
    {
        Player.GetComponent<PlayerMovement>().enabled = false;
        Player.GetComponent<CharacterController2D>().enabled = false;
        Cutscene.gameObject.SetActive(true);
        Dialog0.gameObject.SetActive(true);
        yield return new WaitForSeconds(4);
        Cutscene.gameObject.SetActive(false);
        Dialog0.gameObject.SetActive(false);
        Player.GetComponent<PlayerMovement>().enabled = true;
        Player.GetComponent<CharacterController2D>().enabled = true;
    }

    public void Score(int gems)
    {
        score += gems;
        text.text = score.ToString() + "/3";
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            if (Paused)
            {
                Resume();
                Cursor.visible = false;
                Cursor.lockState = CursorLockMode.Locked;
            }
            else
            {
                Pause();
                Paused = true;
            }
        }
    }

    public void Resume()
    {
        Option.SetActive(false);
        Time.timeScale = 1f;
        Paused = false;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Pause()
    {
        Option.SetActive(true);
        Time.timeScale = 0f;
        Paused = true;
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("I'm quit. BYE!");
    }

    public void Continue()
    {

    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
