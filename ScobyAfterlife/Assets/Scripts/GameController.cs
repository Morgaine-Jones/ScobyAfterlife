using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Variables
    public GameObject player;
    public GameObject Scoby1;
    public GameObject Scoby2;
    public GameObject Scoby3;

    public GameObject Start_Menu;
    public GameObject Naming_Menu;
    public GameObject GameOver_Menu;
    public GameObject Audio;

    bool scoby1Alive = true;
    bool scoby2Alive = true;
    bool scoby3Alive = true;
    int scobiesDead = 0;

    // Start & Updates
    void Awake()
    {
        Start_Menu.SetActive(true);
        Naming_Menu.SetActive(false);
        GameOver_Menu.SetActive(false);
        Audio.SetActive(false);

        Pause();
    }
    void Update()
    {
        CheckScoby();

        if (scobiesDead == 3)
        {
            GameOver();
        }
    }

    // Functions
    void CheckScoby()
    {
        if (Scoby1.GetComponent<Scoby>().scobyAlive == false && scoby1Alive == true)
        {
            scobiesDead = scobiesDead + 1;
            scoby1Alive = false;
        }
        if (Scoby2.GetComponent<Scoby>().scobyAlive == false && scoby2Alive == true)
        {
            scobiesDead = scobiesDead + 1;
            scoby2Alive = false;
        }
        if (Scoby3.GetComponent<Scoby>().scobyAlive == false && scoby3Alive == true)
        {
            scobiesDead = scobiesDead + 1;
            scoby3Alive = false;
        }
    }
    void GameOver()
    {
        GameOver_Menu.SetActive(true);
        Audio.SetActive(false);

        Pause();
    }

    // Button Clicks
    public void Naming()
    {
        Start_Menu.SetActive(false);
        Naming_Menu.SetActive(true);
    }
    public void PlayGame() 
    {
        Naming_Menu.SetActive(false);

        Audio.SetActive(true);

        Play();
    }
    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    // Play/Pause Game
    void Pause() 
    {
        Time.timeScale = 0;
    }
    void Play() 
    {
        Time.timeScale = 1;
    }
}
