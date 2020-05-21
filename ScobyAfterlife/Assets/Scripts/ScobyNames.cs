using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScobyNames : MonoBehaviour
{
    // Variables
    public InputField InputBox;
    public Text InputText;
    public Text ScobyName;

    // Start & Updates
    public void Update()
    {
        InputBox.onValueChanged.AddListener(delegate { NameChanged(); });
    }

    // Functions
    public void NameChanged() 
    {
        ScobyName.text = InputText.GetComponent<Text>().text;
    }
}
