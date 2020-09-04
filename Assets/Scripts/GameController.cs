using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text logText;
    public Text currentText;

    public Action[] actions;

    [TextArea]
    public string introText;


    // Start is called before the first frame update
    void Start()
    {
        logText.text = "";
        logText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void DisplayLocation(bool additive = false)
    {
        string description = player.currentLocation.description + "\n\n";
        description += player.currentLocation.GetConnectionsList();
        description += player.currentLocation.GetItemText();

        if (additive)
            currentText.text = currentText.text + "\n" + description;
        else
            currentText.text = description;
    }

    public void TextEntered()
    {
        LogTextEntered();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void LogTextEntered()
    {
        logText.text += "\n\n";
        logText.text += currentText.text;

        logText.text += "\n";
        logText.text += "<color=#ffaaaaff>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();

        char[] delimiter = { ' ' };
        string[] seperatedInput = input.Split(delimiter);

        foreach (Action action in actions)
        {
            if(action.keyword.ToLower() == seperatedInput[0])
            {
                if(seperatedInput.Length > 1)
                {
                    action.RespondOnInput(this, seperatedInput[1]);
                }
                else
                {
                    action.RespondOnInput(this, "");
                }
                return;
            }
        }

        currentText.text = "Nothing happens! (Touble?) Type Help.";


    }
}
