﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    // Varaibles
    bool glowOn = false;
    public GameObject FoodGlow;
    public GameObject player;

    bool holdingFood = false;
    public Sprite FoodInHand;

    // Start & Updates
    private void FixedUpdate()
    {
        Glow();
    }

    // Change sprites
    private void Glow()
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
    private void CollectedFood() 
    {
        player.GetComponent<SpriteRenderer>().sprite = FoodInHand;
    }

    // Collects Food
    private void OnMouseDown()
    {
        if (glowOn == true && holdingFood == false) 
        {
            holdingFood = true;
            CollectedFood();
        }
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
}