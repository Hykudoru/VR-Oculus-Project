using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITriggerable
{
    void Trigger();
}

public class PlayerTrigger : MonoBehaviour, ITriggerable
{
    [SerializeField] Command[] playerCommands;

    public void Trigger()
    {
        if (playerCommands != null && playerCommands.Length > 0)
        {
            foreach (var command in playerCommands)
            {
                command.Execute(gameObject);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
