using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Go")]
public class Go : Action
{
    public override void RespondOnInput(GameController controller, string verb)
    {
        if(controller.player.ChangeLocation(verb))
        {
            controller.DisplayLocation();
        }
        else
        {
            controller.currentText.text = "You can't go to that location";
        }
    }
}
