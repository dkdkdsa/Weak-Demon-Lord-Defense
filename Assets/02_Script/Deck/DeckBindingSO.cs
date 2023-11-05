using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "SO/Binding")]
public class DeckBindingSO : ScriptableObject
{

    [System.Serializable]
    public class BindData
    {

        public string key;
        public Sprite iconSprite;
        public GameObject unitPrefab;

    }

    public List<BindData> bindList = new();

}
