using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct DeckSaveData
{

    public List<string> deckSave;

}

[CreateAssetMenu(menuName = "SO/Binding")]
public class DeckBindingSO : ScriptableObject
{

    [System.Serializable]
    public class BindData
    {

        public string key;
        public Sprite iconSprite;
        public GameObject unitPrefab;
        public int cost;

    }

    public List<BindData> bindList = new();

}
