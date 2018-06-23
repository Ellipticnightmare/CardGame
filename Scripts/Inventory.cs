using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static List<Item> DeckA = new List<Item>();
    public static List<Item> DeckB = new List<Item>();
    public static List<Item> DeckC = new List<Item>();

    public static List<Item> Hand01 = new List<Item>();
    public static List<Item> Hand02 = new List<Item>();
    public static List<Item> Graveyard = new List<Item>();
    public static List<Item> Field = new List<Item>();

    public int cardsDrawn;

    public static List<Item> RainbowRoyalty = new List<Item>();
    public static List<Item> AscendingWyrm = new List<Item>();

    public static List<Item> ForestFury = new List<Item>();
    public static List<Item> United = new List<Item>();

    public bool deckA;
    public bool deckB;
    public bool deckC;
    public static Item selectedItem;

    #region deckPrefabs
    public bool RainbowRoyaltyCheck;
    public bool AscendingWyrmCheck;
    public bool ForestFuryCheck;
    public bool UnitedCheck;
    #endregion

    public bool playerTurn;
    public bool showGY;
    public bool showDeckC;
    public bool showField;
    public static bool showHand;

    float scrW = Screen.width / 16;
    float scrH = Screen.height / 9;

    public static int playMoney;
    public float playerMoney;
    // Use this for initialization
    void Start()
    {
        cardsDrawn = 0;

        Inventory.showHand = true;

        showDeckC = false;

        playerTurn = false;
        #region Archetypes
        #region RainbowRoyalty
        RainbowRoyalty = new List<Item>();
        RainbowRoyalty.Add(ItemData.CreateItem(001));
        RainbowRoyalty.Add(ItemData.CreateItem(002));
        RainbowRoyalty.Add(ItemData.CreateItem(003));
        RainbowRoyalty.Add(ItemData.CreateItem(004));
        RainbowRoyalty.Add(ItemData.CreateItem(005));
        RainbowRoyalty.Add(ItemData.CreateItem(006));
        RainbowRoyalty.Add(ItemData.CreateItem(007));
        RainbowRoyalty.Add(ItemData.CreateItem(008));
        RainbowRoyalty.Add(ItemData.CreateItem(101));
        RainbowRoyalty.Add(ItemData.CreateItem(102));
        RainbowRoyalty.Add(ItemData.CreateItem(103));
        RainbowRoyalty.Add(ItemData.CreateItem(104));
        RainbowRoyalty.Add(ItemData.CreateItem(105));
        RainbowRoyalty.Add(ItemData.CreateItem(106));
        RainbowRoyalty.Add(ItemData.CreateItem(107));
        RainbowRoyalty.Add(ItemData.CreateItem(108));
        RainbowRoyalty.Add(ItemData.CreateItem(201));
        RainbowRoyalty.Add(ItemData.CreateItem(202));
        RainbowRoyalty.Add(ItemData.CreateItem(203));
        RainbowRoyalty.Add(ItemData.CreateItem(204));
        #endregion
        #region AscendingWyrm
        AscendingWyrm = new List<Item>();
        AscendingWyrm.Add(ItemData.CreateItem(009));
        AscendingWyrm.Add(ItemData.CreateItem(010));
        AscendingWyrm.Add(ItemData.CreateItem(011));
        AscendingWyrm.Add(ItemData.CreateItem(012));
        AscendingWyrm.Add(ItemData.CreateItem(013));
        AscendingWyrm.Add(ItemData.CreateItem(014));
        AscendingWyrm.Add(ItemData.CreateItem(109));
        AscendingWyrm.Add(ItemData.CreateItem(110));
        AscendingWyrm.Add(ItemData.CreateItem(111));
        AscendingWyrm.Add(ItemData.CreateItem(112));
        AscendingWyrm.Add(ItemData.CreateItem(113));
        AscendingWyrm.Add(ItemData.CreateItem(114));
        AscendingWyrm.Add(ItemData.CreateItem(115));
        AscendingWyrm.Add(ItemData.CreateItem(116));
        AscendingWyrm.Add(ItemData.CreateItem(117));
        AscendingWyrm.Add(ItemData.CreateItem(118));
        AscendingWyrm.Add(ItemData.CreateItem(119));
        AscendingWyrm.Add(ItemData.CreateItem(120));
        AscendingWyrm.Add(ItemData.CreateItem(121));
        AscendingWyrm.Add(ItemData.CreateItem(205));
        #endregion
        #region ForestFury
        ForestFury = new List<Item>();
        ForestFury.Add(ItemData.CreateItem(122));
        ForestFury.Add(ItemData.CreateItem(123));
        ForestFury.Add(ItemData.CreateItem(124));
        ForestFury.Add(ItemData.CreateItem(125));
        #endregion

        #endregion

        deckA = true;
        deckB = false;
        deckC = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Switch Decks");
            if (deckA == true)
            {
                deckA = false;
                deckB = true;
                selectedItem = null;
            }
            else if (deckB == true)
            {
                deckB = false;
                deckC = true;
                selectedItem = null;
                DeckC.AddRange(DeckA);
                DeckC.AddRange(DeckB);
            }
        }
    }
    void OnGUI()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;

        if (deckA == true)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;

            if (GUI.Button(new Rect(13f * scrW, .25f * scrH, 2f * scrW, .75f * scrH), "Rainbow Royalty"))
            {
                DeckA = new List<Item>();
                DeckA.AddRange(RainbowRoyalty);
            }
            if (GUI.Button(new Rect(13f * scrW, 1 * scrH, 2f * scrW, .75f * scrH), "Ascending Wyrm"))
            {
                DeckA = new List<Item>();
                DeckA.AddRange(AscendingWyrm);
            }
            if (GUI.Button(new Rect(13f * scrW, 1.75f * scrH, 2f * scrW, .75f * scrH), "Forest Fury"))
            {
                DeckA = new List<Item>();
                DeckA.AddRange(ForestFury);
            }

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Deck A");
            for (int i = 0; i < DeckA.Count; i++)
            {
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(5.9f * scrW, .8f * scrH, 4.2f * scrW, 6.4f * scrH), "");
                    GUI.TextArea(new Rect(6.25f * scrW, 1f * scrH, 3.5f * scrW, .4f * scrH), selectedItem.Name);
                    GUI.TextArea(new Rect(6.25f * scrW, 1.4f * scrH, 1.75f * scrW, .4f * scrH), selectedItem.Type);
                    GUI.DrawTexture(new Rect(6.5f * scrW, 1.85f * scrH, 3f * scrW, 2.5f * scrH), selectedItem.Icon);
                    GUI.TextArea(new Rect(6.5f * scrW, 4.4f * scrH, 3f * scrW, 2f * scrH), selectedItem.Description);
                    if (selectedItem.cardType == ItemType.Monster)
                    {
                        GUI.TextArea(new Rect(8f * scrW, 1.4f * scrH, 1.75f * scrW, .4f * scrH), " Rank:  " + selectedItem.Rank);
                        GUI.TextArea(new Rect(6.25f * scrW, 6.5f * scrH, 1.75f * scrW, .4f * scrH), selectedItem.Attack + "   ATK");
                        GUI.TextArea(new Rect(8f * scrW, 6.5f * scrH, 1.75f * scrW, .4f * scrH), selectedItem.Defense + "     Def");
                    }

                }
                if (GUI.Button(new Rect(0.5f * scrW, 0.25f * scrH + i * (0.5f * scrH), 3 * scrW, 0.5f * scrH), DeckA[i].Name))
                {
                    selectedItem = DeckA[i];
                    Debug.Log(selectedItem.Name);
                }
            }
        }
        else if (deckB == true)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;

            if (GUI.Button(new Rect(13f * scrW, .25f * scrH, 2f * scrW, .75f * scrH), "Rainbow Royalty"))
            {
                DeckB = new List<Item>();
                DeckB.AddRange(RainbowRoyalty);
            }
            if (GUI.Button(new Rect(13f * scrW, 1 * scrH, 2f * scrW, .75f * scrH), "Ascending Wyrm"))
            {
                DeckB = new List<Item>();
                DeckB.AddRange(AscendingWyrm);
            }
            if (GUI.Button(new Rect(13f * scrW, 1.75f * scrH, 2f * scrW, .75f * scrH), "Forest Fury"))
            {
                DeckB = new List<Item>();
                DeckB.AddRange(ForestFury);
            }

            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Deck B");
            for (int i = 0; i < DeckB.Count; i++)
            {
                if (GUI.Button(new Rect(0.5f * scrW, 0.25f * scrH + i * (0.5f * scrH), 3 * scrW, 0.5f * scrH), DeckB[i].Name))
                {
                    selectedItem = DeckB[i];
                    Debug.Log(selectedItem.Name);
                }
            }
        }
        else if (deckC == true)
        {
            scrW = Screen.width / 16;
            scrH = Screen.height / 9;

            if (selectedItem != null)
            {
                Inventory.showHand = false;
                GUI.Box(new Rect(12.1f * scrW, 0f * scrH, 4f * scrW, 6.4f * scrH), "");
                GUI.TextArea(new Rect(12.325f * scrW, .2f * scrH, 3.5f * scrW, .4f * scrH), selectedItem.Name);
                GUI.TextArea(new Rect(12.3f * scrW, .6f * scrH, 1.75f * scrW, .4f * scrH), selectedItem.Type);
                GUI.DrawTexture(new Rect(12.6f * scrW, 1.05f * scrH, 3f * scrW, 2.5f * scrH), selectedItem.Icon);
                GUI.TextArea(new Rect(12.6f * scrW, 3.6f * scrH, 3f * scrW, 2f * scrH), selectedItem.Description);
                if (selectedItem.cardType == ItemType.Monster)
                {
                    GUI.TextArea(new Rect(14.1f * scrW, .6f * scrH, 1.75f * scrW, .4f * scrH), " Rank:  " + selectedItem.Rank);
                    GUI.TextArea(new Rect(12.3f * scrW, 5.7f * scrH, 1.75f * scrW, .4f * scrH), selectedItem.Attack + "   ATK");
                    GUI.TextArea(new Rect(14.05f * scrW, 5.7f * scrH, 1.75f * scrW, .4f * scrH), selectedItem.Defense + "     Def");
                }
            }
            else if (selectedItem == null)
            {
                Inventory.showHand = true;
            }

            if (showDeckC)
            {
                GUI.Box(new Rect(0, 0, 3 * scrW, Screen.height), "Deck C");
                for (int i = 0; i < DeckC.Count; i++)
                {
                    if (GUI.Button(new Rect(0, 0 * scrH + i * (.8f * scrH), 3 * scrW, .8f * scrH), DeckC[i].Name))
                    {
                        Debug.Log("Viewing :" + selectedItem.Name);
                    }
                }
            }
            if (!playerTurn)
            {
                if (Inventory.showHand == true)
                {
                    GUI.Box(new Rect(13 * scrW, 0, 3 * scrW, 4 * scrH), "Hand01");
                    for (int i = 0; i < Hand01.Count; i++)
                    {
                        if (GUI.Button(new Rect(13f * scrW, 0.25f * scrH + i * (0.5f * scrH), 3 * scrW, 0.5f * scrH), Hand01[i].Name))
                        {
                            selectedItem = Hand01[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                }
            }
            else if (playerTurn)
            {
                if (Inventory.showHand == true)
                {
                    GUI.Box(new Rect(13 * scrW, 0, 3 * scrW, 4 * scrH), "Hand02");
                    for (int i = 0; i < Hand02.Count; i++)
                    {
                        if (GUI.Button(new Rect(13f * scrW, 0.25f * scrH + i * (0.5f * scrH), 3 * scrW, 0.5f * scrH), Hand02[i].Name))
                        {
                            selectedItem = Hand02[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                }
            }
            if (FieldScript.showField)
            {
                GUI.Box(new Rect(0, 0, 12 * scrW, Screen.height), "Field");
                for (int i = 0; i < Field.Count; i++)
                {
                    if (GUI.Button(new Rect(scrW, .5f * scrH + i * (.8f * scrH), 8 * scrW, .8f * scrH), Field[i].Name))
                    {
                        selectedItem = Field[i];
                        Debug.Log("Playing :" + selectedItem.Name);
                    }
                }
            }
            if (showGY)
            {
                GUI.Box(new Rect(10 * scrW, 0, 3 * scrW, 4 * scrH), "Graveyard");
                for (int i = 0; i < Graveyard.Count; i++)
                {
                    if (GUI.Button(new Rect(10 * scrW, .25f * scrH + i * (0.5f * scrH), 3 * scrW, .5f * scrH), Graveyard[i].Name))
                    {
                        selectedItem = Graveyard[i];
                        Debug.Log(selectedItem.Name);
                    }
                }
            }

            #region main Controls
            if (selectedItem == null)
            {
                if (GUI.Button(new Rect(13f * scrW, 4f * scrH, 1f * scrW, .6f * scrH), "Draw"))
                {
                    if (!playerTurn && cardsDrawn < 1)
                    {
                        int i = Random.Range(0, DeckC.Count);
                        selectedItem = DeckC[i];
                        DeckC.Remove(selectedItem);
                        Hand01.Add(selectedItem);
                        selectedItem = null;
                        cardsDrawn++;
                        return;
                    }
                    else if (playerTurn && cardsDrawn < 1)
                    {
                        int i = Random.Range(0, DeckC.Count);
                        selectedItem = DeckC[i];
                        DeckC.Remove(selectedItem);
                        Hand02.Add(selectedItem);
                        selectedItem = null;
                        cardsDrawn++;
                        return;
                    }
                }
                if (GUI.Button(new Rect(14f * scrW, 4f * scrH, 1f * scrW, .6f * scrH), "GY"))
                {
                    if (selectedItem == null)
                    {
                        showGY = !showGY;
                    }
                }
                if (GUI.Button(new Rect(15f * scrW, 4f * scrH, 1 * scrW, .6f * scrH), "End"))
                {
                    playerTurn = !playerTurn;
                    cardsDrawn = 0;
                }
                if (GUI.Button(new Rect(13f * scrW, 4.6f * scrH, 1 * scrW, .6f * scrH), "Deck"))
                {
                    if (FieldScript.showField == true)
                    {
                        FieldScript.showField = false;
                    }
                    if (Inventory.showHand == true)
                    {
                        Inventory.showHand = false;
                    }
                    showDeckC = !showDeckC;
                }
                if (GUI.Button(new Rect(14 * scrW, 4.6f * scrH, 1 * scrW, .6f * scrH), "Field"))
                {
                    if (showDeckC)
                    {
                        showDeckC = false;
                        FieldScript.showField = true;
                    }
                }
            }
            else if (selectedItem != null)
            {
                if (GUI.Button(new Rect(13f * scrW, 6.4f * scrH, 1f * scrW, .6f * scrH), "Draw"))
                {
                    if (!playerTurn && cardsDrawn < 1)
                    {
                        int i = Random.Range(0, DeckC.Count);
                        selectedItem = DeckC[i];
                        DeckC.Remove(selectedItem);
                        Hand01.Add(selectedItem);
                        selectedItem = null;
                        cardsDrawn++;
                        return;
                    }
                    else if (playerTurn && cardsDrawn < 1)
                    {
                        int i = Random.Range(0, DeckC.Count);
                        selectedItem = DeckC[i];
                        DeckC.Remove(selectedItem);
                        Hand02.Add(selectedItem);
                        selectedItem = null;
                        cardsDrawn++;
                        return;
                    }
                }
                if (GUI.Button(new Rect(14f * scrW, 6.4f * scrH, 1f * scrW, .6f * scrH), "GY"))
                {
                    if (selectedItem == null)
                    {
                        showGY = !showGY;
                    }
                }
                if (GUI.Button(new Rect(15f * scrW, 6.4f * scrH, 1 * scrW, .6f * scrH), "End"))
                {
                    playerTurn = !playerTurn;
                    cardsDrawn = 0;
                }
                if (GUI.Button(new Rect(13f * scrW, 7f * scrH, 1 * scrW, .6f * scrH), "Deck"))
                {
                    if (FieldScript.showField == true)
                    {
                        FieldScript.showField = false;
                    }
                    if (Inventory.showHand == true)
                    {
                        Inventory.showHand = false;
                    }
                    showDeckC = !showDeckC;
                }
                if (GUI.Button(new Rect(14 * scrW, 7f * scrH, 1 * scrW, .6f * scrH), "Deselect"))
                {
                    selectedItem = null;
                }
                if (!showGY)
                {
                    if (GUI.Button(new Rect(13 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Play"))
                    {
                        if (!playerTurn)
                        {
                            Hand01.Remove(selectedItem);
                            Field.Add(selectedItem);
                            selectedItem = null;
                        }
                        else
                        {
                            Hand02.Remove(selectedItem);
                            Field.Add(selectedItem);
                            selectedItem = null;
                        }
                    }
                    if (GUI.Button(new Rect(14 * scrW, 7.6f * scrH, 1 * scrW, .6F * scrH), "Discard"))
                    {
                        if (!playerTurn)
                        {
                            Hand01.Remove(selectedItem);
                            Graveyard.Add(selectedItem);
                            selectedItem = null;
                        }
                        else
                        {
                            Hand02.Remove(selectedItem);
                            Graveyard.Add(selectedItem);
                            selectedItem = null;
                        }
                    }
                    if (GUI.Button(new Rect(15 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Return"))
                    {
                        if (!playerTurn)
                        {
                            Hand01.Remove(selectedItem);
                            DeckC.Add(selectedItem);
                            selectedItem = null;
                        }
                        else
                        {
                            Hand02.Remove(selectedItem);
                            DeckC.Add(selectedItem);
                            selectedItem = null;
                        }
                    }
                    if (GUI.Button(new Rect(13 * scrW, 8.2f * scrH, 1 * scrW, .6f * scrH), "Banish"))
                    {
                        if (!playerTurn)
                        {
                            Hand01.Remove(selectedItem);
                            selectedItem = null;
                        }
                        else
                        {
                            Hand02.Remove(selectedItem);
                            selectedItem = null;
                        }
                    }
                }
                else
                {
                    if (GUI.Button(new Rect(13 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Play"))
                    {
                        Graveyard.Remove(selectedItem);
                        Field.Add(selectedItem);
                        selectedItem = null;
                    }
                    if (GUI.Button(new Rect(14 * scrW, 7.6f * scrH, 1 * scrW, .6F * scrH), "Hand"))
                    {
                        if (!playerTurn)
                        {
                            Hand01.Add(selectedItem);
                            Graveyard.Remove(selectedItem);
                            selectedItem = null;
                            showGY = false;
                        }
                        else
                        {
                            Hand02.Add(selectedItem);
                            Graveyard.Remove(selectedItem);
                            selectedItem = null;
                            showGY = false;
                        }
                    }
                    if (GUI.Button(new Rect(15 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Deck"))
                    {
                        Graveyard.Remove(selectedItem);
                        DeckC.Add(selectedItem);
                        selectedItem = null;
                    }
                    if (GUI.Button(new Rect(13 * scrW, 8.2f * scrH, 1 * scrW, .6f * scrH), "Banish"))
                    {
                        Graveyard.Remove(selectedItem);
                        selectedItem = null;
                    }
                }
            }
            #endregion
        }
    }
}
