using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/TalkTo")]
public class TalkTo : Action
{
	public override void RespondOnInput(GameController controller, string noun)
	{
		if(TalkToItem(controller, controller.player.currentLocation.items, noun))
			return;

		controller.currentText.text = "No one to talk to here!";
	}

	private bool TalkToItem(GameController controller, List<Item> items ,string noun)
	{
        foreach (Item item in items)
        {
            if (item.itemName.ToLower() == noun.ToLower() && item.itemEnabled)
            {
                if (controller.player.CanTalkTo(item))
                {
                    if (item.Interacted(controller, "talkto"))
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
