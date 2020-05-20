using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScobyNames : MonoBehaviour
{
    // Variables
    public InputField InputBox;
    public Text ScobyName;

    // Start & Updates
    public void Start()
    {
        InputBox.onValueChanged.AddListener(delegate { NameChanged(); });
    }

    // Functions
    public void NameChanged() 
    {
        Debug.Log("hello");
        ScobyName.text = InputBox.GetComponent<Text>().text;
    }
}
