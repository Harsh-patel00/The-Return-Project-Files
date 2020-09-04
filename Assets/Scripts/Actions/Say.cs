using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Say")]
public class Say : Action
{
    public override void RespondOnInput(GameController controller, string noun)
    {
        if (SayToItem(controller, controller.player.currentLocation.items, noun))
            return;

        controller.currentText.text = "No one to say to here!";
    }

    private bool SayToItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanTalkTo(item))
                {
                    if (item.Interacted(controller, "say", noun))
                    {
                        return true;
                    }
                }

                controller.currentText.text = "Can't talk to " + noun;
                return true;
            }
        }
        return false;
    }
}
