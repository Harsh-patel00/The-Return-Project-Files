using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Use")]
public class Use : Action
{
	public override void RespondOnInput(GameController controller, string noun)
    {
        // In room
        if (UseItems(controller, controller.player.currentLocation.items, noun))
            return;

        // In Inventory
        if (UseItems(controller, controller.player.inventory, noun))
            return;

        controller.currentText.text = "Can't use this item!";
    }

    bool UseItems(GameController controller, List<Item> items , string noun)
    {
        foreach(Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if(controller.player.CanUseItem(item))
                {
                    if(item.Interacted(controller, "use"))
                    {
                        return true;
                    }
                }

                controller.currentText.text = "No Use!";
                return true;
            }
        }
        return false;
    }
}
