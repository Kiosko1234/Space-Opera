using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
{
    [SerializeField] private List<TKey> keys = new List<TKey>();
    [SerializeField] private List<TValue> values = new List<TValue>();


    //save the dictionary to lists
    public void OnBeforeSerialize()
    {
        keys.Clear();
        values.Clear();
        foreach(KeyValuePair<TKey, TValue> pair in this)
        {
            keys.Add(pair.Key);
            values.Add(pair.Value);
        }
    }

    //Load the Dictionary from lists
    public void OnAfterDeserialize()
    {
        if(keys.Count != values.Count)
        {
            Debug.LogError("Tried to deserialize a serializeableDictionary, but the amount of keys (" + keys.Count + ") does not match the number of values (" + values.Count + ") which indicates that something has gone horribly wrong oh no oh god what is ahppening shy wjus t");
        }
        this.Clear();
        for(int k = 0; k < keys.Count; k++)
        {
            this.Add(keys[k], values[k]);
        }
    }
}
