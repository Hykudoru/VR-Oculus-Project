using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ScriptableAction : ScriptableObject
{
    public abstract void Execute(GameObject gameObject);
}


public abstract class Command<T> : ScriptableObject
{
    public virtual void Execute(T o) { }
}

public abstract class CommandAsync<T> : ScriptableObject
{
    public IEnumerator ExecuteAsync(T o)
    {
        yield return null;
    }
}

public abstract class RaycastHitCommand : Command<RaycastHit>
{
    public override void Execute(RaycastHit info)
    {
        Procedure(info);
    }

    protected abstract void Procedure(RaycastHit info);
}


public abstract class Command : Command<GameObject>
{

}


public class Sound : Command<object>
{
    object audio = new string[] { "sound_1", "sound_2" };
    int lastPlayed;
    public void Init(object audio)
    {
        //sounds = Audio.Sounds;
        //this.audio = audio;
    }

    public void Execute()
    {
        if (true)
        {
            string[] sounds = (string[]) audio;
            Debug.Log("Playing Audio" + sounds[new System.Random().Next(0, sounds.Length-1)].ToLower());
        }
    }


}



[CreateAssetMenu]
public class ToggleGravity : Command
{
    public void Execute(GameObject gameObject)
    {
        Rigidbody rigidbody = gameObject.GetComponent<Rigidbody>() as Rigidbody;
        if (rigidbody)
        {
            rigidbody.useGravity = !rigidbody.useGravity;
        }
    }
}

[CreateAssetMenu]
public class Spawn : Command
{
    [SerializeField] GameObject spawn;
    public void Execute(GameObject gameObject)
    {
        if (spawn)
        {
            Instantiate(spawn);
        }
    }
}