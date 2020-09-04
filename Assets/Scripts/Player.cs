using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Security.Cryptography;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Location currentLocation;

    public List<Item> inventory = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool ChangeLocation(string connectionNoun)
    {
        Connection connection = currentLocation.GetConnection(connectionNoun);

        if(connection != null)
        {
            if(connection.connectionEnabled)
            {
                currentLocation = connection.location;
                return true;
            }
        }
        return false;
    }

    public bool CanReadItem(Item item)
    {
        return item.canReadItem;
    }

    internal bool CanGiveTo(Item item)
    {
        return item.canGiveTo;
    }

    public bool CanTalkTo(Item item)
	{
        return item.canTalkTo;
    }

	public bool CanUseItem(Item itemToUse)
    {

        if (itemToUse.targetItem == null)
            return true;

        if (HasItem(itemToUse.targetItem))
            return true;

        if (currentLocation.HasItem(itemToUse.targetItem))
            return true;
    
        return false;   
    }

    bool HasItem(Item item)
    {
        foreach (Item itemInInv in inventory)
        {
            if (itemInInv == item && itemInInv.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }

    public bool HasItemByName(string noun)
    {
        foreach (Item item in inventory)
        {
            if (item.itemName.ToLower() == noun.ToLower())
            {
                return true;
            }
        }
        return false;
    }

    public void TeleportToEnd(GameController controller, Location dest)
    {
        currentLocation = dest;
    }
}
