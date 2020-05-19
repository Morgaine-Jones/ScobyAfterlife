using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoby : MonoBehaviour
{
    // Variables
    public GameObject player;
    public GameObject ScobyGlow;
    public GameObject Heart1;
    public GameObject Heart2;
    public GameObject Heart3;

    public Sprite s_ScobyDead;
    public Sprite heartFull;
    public Sprite heartEmpty;

    public bool scobyAlive = true;
    bool glowOn = false;
    int currentHearts = 3;

    // Start & Updates
    void FixedUpdate()
    {
        Glow();
        HeartsChange();
    }

    // Change sprites
    void Glow() 
    {
        if (glowOn == true)
        {
            ScobyGlow.SetActive(true);
            ScobyGlow.GetComponent<Animator>().enabled = true;
        }
        else 
        {
            ScobyGlow.GetComponent<Animator>().enabled = false;
            ScobyGlow.SetActive(false);
        }
    }
    void HeartsChange() 
    {
        if (currentHearts == 3)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartFull;
        }
        else if (currentHearts == 2)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartFull;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
        }
        else if (currentHearts == 1)
        {
            Heart1.GetComponent<SpriteRenderer>().sprite = heartFull;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartEmpty;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
        }
        else if (currentHearts == 0)
        {
            scobyAlive = false;
            GetComponent<SpriteRenderer>().sprite = s_ScobyDead;

            Heart1.GetComponent<SpriteRenderer>().sprite = heartEmpty;
            Heart2.GetComponent<SpriteRenderer>().sprite = heartEmpty;
            Heart3.GetComponent<SpriteRenderer>().sprite = heartEmpty;
        }
    }

    // Start/stop timer
    void OnMouseDown()
    {
        if (scobyAlive == true)
        {
            StopCoroutine(LifeTimer());
            currentHearts = 3;
        }
    }
    void OnMouseUp()
    {
        StartCoroutine(LifeTimer());
    }

    // Checks if the player is within the vicinity
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            glowOn = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            glowOn = false;
        }
    }

    // Slowly decreases lives over time
    IEnumerator LifeTimer()
    {
        yield return new WaitForSeconds(8);
        if (scobyAlive == true) 
        {
            currentHearts = currentHearts - 1;
        }
        yield return new WaitForSeconds(8);
        if (scobyAlive == true)
        {
            currentHearts = currentHearts - 1;
        }
        yield return new WaitForSeconds(8);
        if (scobyAlive == true)
        {
            currentHearts = currentHearts - 1;
        }
    }
}
