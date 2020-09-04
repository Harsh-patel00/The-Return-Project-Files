using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.AI;

public class Location : MonoBehaviour
{
    public string locationName;

    [TextArea]
    public string description;

    public Connection[] connections;

    public List<Item> items = new List<Item>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetItemText()
    {
        if(items.Count == 0)
        {
            return "";
        }

        string result = "You see ";

        bool firstItem = true;

        foreach(Item item in items)
        {
            if(item.itemEnabled)
            {
                if(!firstItem)
                {
                    result += " , ";
                }

                result += item.description;
                firstItem = false;
            }
        }

        result += "\n";
        
        return result;
    }

    public bool HasItem(Item item)
    {
        foreach (Item itemOnLoc in items)
        {
            if (itemOnLoc == item && itemOnLoc.itemEnabled)
            {
                return true;
            }
        }
        return false;
    }

    public string GetConnectionsList()
    {
        string result = "";
        foreach(Connection connection in connections)
        {
            if(connection.connectionEnabled)
            {
               result += connection.description + "\n ";
            }
        }

        return result;
    }

    public Connection GetConnection(string connectionNoun)
    {
        foreach(Connection connection in connections)
        {
            if(connection.connectionName.ToLower() == connectionNoun.ToLower())
            {
                return connection;
            }
        }
        return null;
    }
}
