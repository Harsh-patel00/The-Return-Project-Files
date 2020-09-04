using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Help")]
public class Help : Action
{
    public override void RespondOnInput(GameController controller, string verb)
    {
        controller.currentText.text = "Type a verb followed by a noun.";
        controller.currentText.text += "\nAllowed verbs are:" +
                                       "\nGo, Examine, Get, Use, Give, Read, TalkTo, Say, Inventory, Help";
    }
}
