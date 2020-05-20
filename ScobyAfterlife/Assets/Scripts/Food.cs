using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Varaibles
    public GameObject player;
    public GameObject FoodGlow;
    public GameObject Instructions;

    public Sprite FoodInHand;

    public bool holdingFood = false;
    bool glowOn = false;

    int InstructionsVisible = 0;

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

    // Functions
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

            if (InstructionsVisible < 2)
            {
                Instructions.SetActive(true);
            }
            else 
            {
                Instructions.SetActive(false);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            glowOn = false;
        }

        if (Instructions.activeInHierarchy == true)
        {
            Instructions.SetActive(false);
        }
    }
}
