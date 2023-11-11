using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StrDeckManager : MonoBehaviour
{

    [SerializeField] private DeckStrSlot slotPrefab;
    [SerializeField] private Transform deckRoot, cardRoot;
    [SerializeField] private string nextScene;

    private DeckBindingSO deckBind;

    private void Awake()
    {

        deckBind = Resources.Load<DeckBindingSO>("Bind");

        foreach(var deck in deckBind.bindList) 
        {

            var slot = Instantiate(slotPrefab, cardRoot);
            slot.Setting(deck.key, deck.cost, deck.iconSprite, deckRoot, cardRoot);

        }

    }

    public void Save()
    {

        var ls = deckRoot.GetComponentsInChildren<DeckStrSlot>();

        var save = new DeckSaveData();

        var str = ls.ToList().Select(x => x.key).ToList();

        save.deckSave = str;

        JSON.WriteObject(Application.dataPath + @"\Deck.json", save);

        SceneManager.LoadScene(nextScene);

    }

}
