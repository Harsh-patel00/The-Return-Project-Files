using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Read")]
public class Read : Action
{
	public override void RespondOnInput(GameController controller, string noun)
	{
		if (ReadItems(controller, controller.player.currentLocation.items, noun))
			return;
	}

    bool ReadItems(GameController controller, List<Item> items, string noun)
    {
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                if (controller.player.CanReadItem(item))
                {
                    if (item.Interacted(controller, "read"))
                    {
                        return true;
                    }
                }

                controller.currentText.text = "Can't read it properly!";
                return true;
            }
        }
        return false;
    }
}
