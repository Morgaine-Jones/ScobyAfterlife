using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Varaibles
    public GameObject player;
    public GameObject FoodGlow;

    public Sprite FoodInHand;

    bool glowOn = false;
    bool holdingFood = false;

    // Start & Updates
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.Return))
        {
            CollectFood();
        }
    }
    void FixedUpdate()
    {
        Glow();
    }

    void Glow()
    {
        if (glowOn == true)
        {
            FoodGlow.SetActive(true);
            FoodGlow.GetComponent<Animator>().enabled = true;
        }
        else
        {
            FoodGlow.SetActive(false);
            FoodGlow.GetComponent<Animator>().enabled = false;
        }
    }
    void CollectFood() 
    {
        if (glowOn == true && holdingFood == false) 
        {
            player.GetComponent<Animator>().SetBool("Holding_Food", true);

            holdingFood = true;
        }
    }

    // Checks if the player is within the vicinity
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
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
