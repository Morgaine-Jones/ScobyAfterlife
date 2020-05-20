using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoby : MonoBehaviour
{
    // Variables
    public GameObject player;
    public GameObject Food;
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

    private Coroutine HeartTimer;

    // Start & Updates
    void Awake()
    {
        HeartTimer = StartCoroutine(LifeTimer());
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            FeedScoby();
        }

        if (scobyAlive == false) 
        {
            glowOn = false;
            ScobyGlow.GetComponent<Animator>().enabled = false;
            ScobyGlow.SetActive(false);
        }
    }
    void FixedUpdate()
    {
        if (scobyAlive == true)
        {
            Glow();
            HeartsChange();
        }
    }

    // Functions
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
    void FeedScoby() 
    {
        if (glowOn == true && scobyAlive == true && currentHearts < 3 && Food.GetComponent<Food>().holdingFood == true)
        {
            StopCoroutine(HeartTimer);

            currentHearts = 3;

            player.GetComponent<Animator>().SetBool("Holding_Food", false);
            Food.GetComponent<Food>().holdingFood = false;

            HeartTimer = StartCoroutine(LifeTimer());
        }
    }

    // Slowly decreases lives over time
    IEnumerator LifeTimer()
    {
        while (scobyAlive == true)
        {
            yield return new WaitForSeconds(8);
            currentHearts = currentHearts - 1;
        }
        //yield return null;
    }

    // Checks if the player is within the vicinity
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player && scobyAlive == true)
        {
            glowOn = true;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            glowOn = false;
        }
    }
}
