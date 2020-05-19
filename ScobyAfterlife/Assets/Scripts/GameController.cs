using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    // Variables
    public GameObject Scoby1;
    public GameObject Scoby2;
    public GameObject Scoby3;
    bool scobyDead = false;
    int scobiesDead = 0;

    // Start & Updates
    void Update()
    {
        CheckScoby();

        if (scobiesDead >= 3)
        {
            GameOver();
        }
    }

    void CheckScoby()
    {
        scobyDead = Scoby1.GetComponent<Scoby>().scobyAlive;
        if (scobyDead == true)
        {
            scobiesDead = scobiesDead + 1;
            scobyDead = false;
        }

        scobyDead = Scoby2.GetComponent<Scoby>().scobyAlive;
        if (scobyDead == true)
        {
            scobiesDead = scobiesDead + 1;
            scobyDead = false;
        }

        scobyDead = Scoby3.GetComponent<Scoby>().scobyAlive;
        if (scobyDead == true)
        {
            scobiesDead = scobiesDead + 1;
            scobyDead = false;
        }
    }

    void GameOver()
    {
        Application.Quit();
    }
}
