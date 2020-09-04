using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Give")]
public class Give : Action
{
    public override void RespondOnInput(GameController controller, string noun)
    {
        if(controller.player.HasItemByName(noun))
        {
            if (GiveItem(controller, controller.player.currentLocation.items, noun))
                return;

            controller.currentText.text = "No one to give to here!";
            return;
        }

        controller.currentText.text = "You don't have that";
    }

    private bool GiveItem(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemEnabled)
            {
                if (controller.player.CanGiveTo(item))
                {
                    if (item.Interacted(controller, "give", noun))
                    {
                        return true;
                    }
                }

                controller.currentText.text = "Can't give it to " + noun;
                return true;
            }
        }
        return false;
    }
}
