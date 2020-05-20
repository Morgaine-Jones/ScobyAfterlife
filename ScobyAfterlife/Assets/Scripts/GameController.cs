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
    public GameObject GameOver_Menu;

    bool scoby1Alive = true;
    bool scoby2Alive = true;
    bool scoby3Alive = true;
    int scobiesDead = 0;

    // Start & Updates
    void Awake()
    {
        Pause();

        Start_Menu.SetActive(true);
        GameOver_Menu.SetActive(false);
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
        Pause();

        GameOver_Menu.SetActive(true);
    }

    // Button Clicks
    public void PlayGame() 
    {
        Start_Menu.SetActive(false);

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
