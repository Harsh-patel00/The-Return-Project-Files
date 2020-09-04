using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Actions/Inventory")]
public class Inventory : Action
{
    public override void RespondOnInput(GameController controller, string noun)
    {

        string result = "";

        if(! (controller.player.inventory.Count == 0))
        {
            result = "Your inventory: \n";
            bool firstItem = true;

            foreach (Item item in controller.player.inventory)
            {
                if (!firstItem)
                {
                    result += ", ";
                }
                result += item.itemName;
                firstItem = false;
            }

            controller.currentText.text = result;

            return;
        }

        result = "Inventory empty!";
        controller.currentText.text = result;
        return;
    }
}
