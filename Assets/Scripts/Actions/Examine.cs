using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Examine")]
public class Examine : Action
{
    public override void RespondOnInput(GameController controller, string noun)
    {
        // In room
        if (CheckItems(controller, controller.player.currentLocation.items, noun))
            return;

        // In Inventory
        if (CheckItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "Can't find the item!";
    }

    bool CheckItems(GameController controller, List<Item> items , string noun)
    {
        foreach(Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if(item.Interacted(controller, "examine"))
                {
                    return true;
                }

                controller.currentText.text = item.description;
                return true;
            }
        }
        return false;
    }
}
