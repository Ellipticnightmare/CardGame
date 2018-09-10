using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour //THIS IS THE NEW ONE
{
    #region Values and Info
    public static List<Item> DeckA = new List<Item>();
    public static List<Item> DeckB = new List<Item>();
    public static List<Item> DeckC = new List<Item>();
    public static bool deckASelected;
    public static bool deckBSelected;

    public static List<Item> Hand01 = new List<Item>();
    public static List<Item> Hand02 = new List<Item>();
    public static List<Item> Graveyard = new List<Item>();

    public static List<Item> backrowA = new List<Item>();
    public static List<Item> fieldA = new List<Item>();
    public static List<Item> fieldB = new List<Item>();
    public static List<Item> backrowB = new List<Item>();

    public static int cardsToDraw;
    public static int cardsDrawn;
    public static int player1Health;
    public static int player2Health;
    public static int turnCount;
    public static bool firstTurn;
    public static int monsterPlay;

    public static int backrowACount;
    public static int fieldACount;
    public static int fieldBCount;
    public static int backrowBCount;
    public static int player1HandSize;
    public static int player2HandSize;

    public static bool deckA;
    public static bool deckB;
    public static bool deckC;
    public static Item selectedItem;
    public static Item attackingCard;
    public static Item defendingCard;
    public static int damageValue;

    public static bool attackerSelected;
    public static bool defenderSelected;

    public static bool player1Turn;
    public static bool showGY;
    public static bool showDeckC;
    public static bool showField;
    public static bool showHand;
    public static bool selectedFromBackrowA;
    public static bool selectedFromFieldA;
    public static bool selectedFromFieldB;
    public static bool selectedFromBackrowB;
    public static bool selectedFromDeck;

    public static int token;

    public static int turnPhase;
    public static bool drawPhase;
    public static bool mainPhase;
    public static bool combatPhase;
    public static bool secondPhase;
    public static bool endPhase;

    float scrW = Screen.width / 16;
    float scrH = Screen.height / 9;

    #region prefab selection bools
    public bool RainbowRoyaltyCheck;
    public static List<Item> RainbowRoyalty = new List<Item>();
    public bool AscendingWyrmCheck;
    public static List<Item> AscendingWyrm = new List<Item>();
    public bool ForestFuryCheck;
    public static List<Item> ForestFury = new List<Item>();
    public bool UnitedCheck;
    public static List<Item> United = new List<Item>();
    #endregion
    #endregion
    // Use this for initialization
    public void Start()
    {
        cardsToDraw = 0;

        showField = true;

        showHand = true;

        showDeckC = false;

        player1Turn = true;

        turnPhase = 0;

        firstTurn = true;

        turnCount = 1;

        #region Prefab Decks
        #region Rainbow Royalty
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
        ForestFury.Add(ItemData.CreateItem(126));
        ForestFury.Add(ItemData.CreateItem(127));
        #endregion
        #endregion

        selectedFromFieldA = false;
        selectedItem = null;

        player1Health = 6000;
        player2Health = 6000;

        deckA = true;
        deckB = false;
        deckC = false;


        deckASelected = false;
        deckBSelected = false;
    }

    // Update is called once per frame
    public void Update()
    {
        if (player1Health <= 0)
        {
            SceneManager.LoadScene("Player02Win");
        }
        if (player2Health <= 0)
        {
            SceneManager.LoadScene("Player01Win");
        }

        if (turnPhase == 0)
        {
            drawPhase = true;
            mainPhase = false;
            combatPhase = false;
            secondPhase = false;
            endPhase = false;
        }
        else if (turnPhase == 1)
        {
            drawPhase = false;
            mainPhase = true;
            combatPhase = false;
            secondPhase = false;
            endPhase = false;
        }
        else if (turnPhase == 2)
        {
            drawPhase = false;
            mainPhase = false;
            combatPhase = true;
            secondPhase = false;
            endPhase = false;
        }
        else if (turnPhase == 3)
        {
            drawPhase = false;
            mainPhase = false;
            combatPhase = false;
            secondPhase = true;
            endPhase = false;
        }
        else if (turnPhase == 4)
        {
            drawPhase = false;
            mainPhase = false;
            combatPhase = false;
            secondPhase = false;
            endPhase = true;
        }
        InvokeRepeating("DrawPhase", 0, 1);
    }

    public void NextDeckSelect()
    {
        Debug.Log("Switching Decks");
        if (deckA)
        {
            if (deckASelected)
            {
                deckA = false;
                deckB = true;
                selectedItem = null;
            }
            else
            {
                Debug.Log("Pick a Deck");
            }
        }
        else if (deckB)
        {
            if (deckBSelected)
            {
                deckB = false;
                deckC = true;
                selectedItem = null;
                DeckC.AddRange(DeckA);
                DeckC.AddRange(DeckB);
            }
        }
    }

    public void DiscardCards()
    {
        if (!selectedFromDeck)
        {
            if (player1Turn)
            {
                Hand01.Remove(selectedItem);
                Graveyard.Add(selectedItem);
                selectedItem = null;
                player1HandSize--;
            }
            else
            {
                Hand02.Remove(selectedItem);
                Graveyard.Add(selectedItem);
                selectedItem = null;
                player2HandSize--;
            }
        }
        else
        {
            DeckC.Remove(selectedItem);
            Graveyard.Add(selectedItem);
            selectedItem = null;
        }
    }

    public void BanishCards()
    {
        if (!selectedFromDeck && !selectedFromBackrowA && !selectedFromBackrowB && !selectedFromFieldA && !selectedFromFieldB)
        {
            if (player1Turn)
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
        else if (selectedFromDeck)
        {
            DeckC.Remove(selectedItem);
        }
        else if (selectedFromBackrowA)
        {
            backrowA.Remove(selectedItem);
            selectedItem = null;
        }
        else if (selectedFromFieldA)
        {
            fieldA.Remove(selectedItem);
            selectedItem = null;
        }
        else if (selectedFromFieldB)
        {
            fieldB.Remove(selectedItem);
            selectedItem = null;
        }
        else if (selectedFromBackrowB)
        {
            backrowB.Remove(selectedItem);
            selectedItem = null;
        }
        token++;
    }

    public void DrawPhase()
    {
        if (!firstTurn)
        {
            cardsToDraw = 1;
        }
        else
        {
            if (player1Turn)
            {
                cardsToDraw = 4;
            }
            else
            {
                cardsToDraw = 5;
            }
        }

        if (cardsDrawn < cardsToDraw)
        {
            DrawCards();
        }
    }

    public void DrawCards()
    {
        if (deckC)
        {
            int i = Random.Range(0, DeckC.Count);
            selectedItem = DeckC[i];
            DeckC.Remove(selectedItem);
            if (player1Turn)
            {
                Hand01.Add(selectedItem);
                player1HandSize++;
            }
            else
            {
                Hand02.Add(selectedItem);
                player2HandSize++;
            }
            selectedItem = null;
            cardsDrawn++;
            return;
        }
    }

    public void PlayCards()
    {
        PlayTheCards.PlayTheCard();
        if (!PlayTheCards.specialPlay)
        {
            if (showGY)
            {
                Graveyard.Remove(selectedItem);
                if (player1Turn)
                {
                    if (selectedItem.cardType == ItemType.Monster)
                    {
                        fieldA.Add(selectedItem);
                        selectedItem = null;
                    }
                    else if (selectedItem.cardType == ItemType.Spell || selectedItem.cardType == ItemType.Trap)
                    {
                        backrowA.Add(selectedItem);
                        selectedItem = null;
                    }
                }
                else if (!player1Turn)
                {
                    if (selectedItem.cardType == ItemType.Monster)
                    {
                        fieldB.Add(selectedItem);
                        selectedItem = null;
                    }
                    else if (selectedItem.cardType == ItemType.Spell || selectedItem.cardType == ItemType.Trap)
                    {
                        backrowB.Add(selectedItem);
                        selectedItem = null;
                    }
                }
            }
            else if (!showGY)
            {
                if (Inventory.selectedItem.cardType == ItemType.Monster)
                {
                    if (monsterPlay < 1)
                    {
                        if (Inventory.selectedItem.Rank < 4)
                        {
                            if (Inventory.player1Turn && fieldACount < 5)
                            {
                                Inventory.fieldA.Add(Inventory.selectedItem);
                                Inventory.Hand01.Remove(Inventory.selectedItem);
                                monsterPlay++;
                                fieldACount++;
                            }
                            else if (!player1Turn && fieldBCount < 5)
                            {
                                Inventory.fieldB.Add(Inventory.selectedItem);
                                Inventory.Hand02.Remove(Inventory.selectedItem);
                                monsterPlay++;
                                fieldBCount++;
                            }
                        }
                        else if (Inventory.selectedItem.Rank > 3 && Inventory.selectedItem.Rank < 6)
                        {
                            if (Inventory.token > 0 && (Inventory.fieldACount < 4))
                            {
                                Inventory.token--;
                                if (Inventory.player1Turn && fieldACount < 5)
                                {
                                    Inventory.fieldA.Add(Inventory.selectedItem);
                                    Inventory.Hand01.Remove(Inventory.selectedItem);
                                    monsterPlay++;
                                    fieldACount++;
                                }
                                else if (!player1Turn && fieldBCount < 5)
                                {
                                    Inventory.fieldB.Add(Inventory.selectedItem);
                                    Inventory.Hand02.Remove(Inventory.selectedItem);
                                    monsterPlay++;
                                    fieldBCount++;
                                }
                            }

                        }
                        else if (Inventory.selectedItem.Rank > 6)
                        {
                            if (Inventory.token > 1 && (Inventory.fieldACount < 4))
                            {
                                Inventory.token -= 2;
                                if (Inventory.player1Turn && fieldACount < 5)
                                {
                                    Inventory.fieldA.Add(Inventory.selectedItem);
                                    Inventory.Hand01.Remove(Inventory.selectedItem);
                                    monsterPlay++;
                                    fieldACount++;
                                }
                                else if (!player1Turn && fieldBCount < 5)
                                {
                                    Inventory.fieldB.Add(Inventory.selectedItem);
                                    Inventory.Hand02.Remove(Inventory.selectedItem);
                                    monsterPlay++;
                                    fieldBCount++;
                                }
                            }
                        }
                    }
                }

                else
                {
                    if (player1Turn)
                    {
                        Hand01.Remove(selectedItem);
                        backrowA.Add(selectedItem);
                        backrowACount++;
                    }
                    else
                    {
                        Hand02.Remove(selectedItem);
                        backrowB.Add(selectedItem);
                        backrowBCount++;
                    }
                }
                selectedItem = null;
            }
        }
        PlayTheCards.specialPlay = false;
    }

    public void UseEffect()
    {
        return;
    }

    public void CombatRun()
    {
        if (attackingCard.Attack > defendingCard.Attack)
        {
            damageValue = (attackingCard.Attack -= defendingCard.Attack);
            if (player1Turn)
            {
                player2Health -= damageValue;
                fieldB.Remove(defendingCard);
                Graveyard.Add(defendingCard);
            }
            else if (!player1Turn)
            {
                player1Health -= damageValue;
                fieldA.Remove(defendingCard);
                Graveyard.Add(defendingCard);
            }
        }
        else if (defendingCard.Attack > attackingCard.Attack)
        {
            damageValue = (defendingCard.Attack -= attackingCard.Attack);
            if (player1Turn)
            {
                player1Health -= damageValue;
                fieldA.Remove(attackingCard);
                Graveyard.Add(attackingCard);
            }
            else if (!player1Turn)
            {
                player2Health -= damageValue;
                fieldA.Remove(attackingCard);
                Graveyard.Add(attackingCard);
            }
        }
        attackingCard = null;
        defendingCard = null;
    }

    public void EndPhase()
    {
        if (player1Turn)
        {
            if (player1HandSize >= 7)
            {
                Debug.Log("Discard Cards");
            }
            else
            {
                player1Turn = false;
                turnPhase = 0;
                cardsDrawn = 0;
                DrawPhase();
                monsterPlay = 0;
            }
        }
        else if (!player1Turn)
        {
            if (player2HandSize >= 7)
            {
                Debug.Log("Discard Cards");
            }
            else
            {
                firstTurn = false;
                player1Turn = true;
                turnPhase = 0;
                cardsDrawn = 0;
                DrawPhase();
                monsterPlay = 0;
            }
        }
    }

    public void PhaseChange()
    {
        if (turnPhase < 4)
        {
            turnPhase++;
        }
    }

    public void ForfeitDuel()
    {
        if (player1Turn)
        {
            SceneManager.LoadScene("Player02Win");
        }
        else
        {
            SceneManager.LoadScene("Player01Win");
        }
    }

    public void OnGUI()
    {
        scrW = Screen.width / 16;
        scrH = Screen.height / 9;

        if (deckA == true)
        {
            if (GUI.Button(new Rect(14 * scrW, .25f * scrH, 2 * scrW, .75f * scrH), "Rainbow Royalty"))
            {
                DeckA = new List<Item>();
                DeckA.AddRange(RainbowRoyalty);
                deckASelected = true;
            }
            if (GUI.Button(new Rect(14 * scrW, 1 * scrH, 2 * scrH, .75f * scrH), "Ascending Wyrm"))
            {
                DeckA = new List<Item>();
                DeckA.AddRange(AscendingWyrm);
                deckASelected = true;
            }
            if (GUI.Button(new Rect(14 * scrW, 1.75f * scrH, 2 * scrH, .75f * scrH), "Forest Fury"))
            {
                DeckA = new List<Item>();
                DeckA.AddRange(ForestFury);
                deckASelected = true;
            }

            if (GUI.Button(new Rect(14 * scrW, 7.5f * scrH, 2 * scrH, .75f * scrH), "Erase"))
            {
                DeckA = new List<Item>();
                deckASelected = false;
            }
            if (GUI.Button(new Rect(14 * scrW, 8.25f * scrH, 2 * scrH, .75f * scrH), "Continue"))
            {
                NextDeckSelect();
            }

            #region deckList
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
            #endregion
        }
        else if (deckB == true)
        {
            if (GUI.Button(new Rect(14 * scrW, .25f * scrH, 2 * scrW, .75f * scrH), "Rainbow Royalty"))
            {
                DeckB = new List<Item>();
                DeckB.AddRange(RainbowRoyalty);
                deckBSelected = true;
            }
            if (GUI.Button(new Rect(14 * scrW, 1 * scrH, 2 * scrH, .75f * scrH), "Ascending Wyrm"))
            {
                DeckB = new List<Item>();
                DeckB.AddRange(AscendingWyrm);
                deckBSelected = true;
            }
            if (GUI.Button(new Rect(14 * scrW, 1.75f * scrH, 2 * scrH, .75f * scrH), "Forest Fury"))
            {
                DeckB = new List<Item>();
                DeckB.AddRange(ForestFury);
                deckBSelected = true;
            }

            if (GUI.Button(new Rect(14 * scrW, 7.5f * scrH, 2 * scrH, .75f * scrH), "Erase"))
            {
                DeckB = new List<Item>();
                deckBSelected = false;
            }
            if (GUI.Button(new Rect(14 * scrW, 8.25f * scrH, 2 * scrH, .75f * scrH), "Continue"))
            {
                NextDeckSelect();
            }

            #region deckList
            GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "Deck B");
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
                    selectedItem = DeckB[i];
                    Debug.Log(selectedItem.Name);
                }

            }
            #endregion
        }
        else if (deckC == true)
        {
            GUI.Box(new Rect(13 * scrW, 8 * scrH, 2 * scrW, .5f * scrH), "Tokens: " + token);
            if (selectedItem != null)
            {
                showHand = false;
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
                showHand = true;
            }
            #region fieldZones
            if (showField)
            {
                //backrowB
                GUI.Box(new Rect(0, 0, 8 * scrW, 2 * scrH), "");
                for (int i = 0; i < backrowB.Count; i++)
                {
                    GUI.TextArea(new Rect(0 * scrW + i * (2 * scrH), 0 * scrH, 2 * scrW, .25f * scrH), backrowB[i].Name);
                    if (GUI.Button(new Rect(0 * scrW + i * (2 * scrH), 0 * scrH, 2 * scrW, 2 * scrH), backrowB[i].Icon))
                    {
                        selectedItem = backrowB[i];
                        selectedFromBackrowA = false;
                        selectedFromFieldA = false;
                        selectedFromFieldB = false;
                        selectedFromBackrowB = true;
                        selectedFromDeck = false;
                    }
                }
                //fieldB
                GUI.Box(new Rect(0, 2 * scrH, 8 * scrW, 2 * scrH), "");
                for (int i = 0; i < fieldB.Count; i++)
                {
                    GUI.TextArea(new Rect(0 * scrW + i * (2 * scrH), 2 * scrH, 2 * scrW, .25f * scrH), fieldB[i].Name);
                    if (GUI.Button(new Rect(0 * scrW + i * (2 * scrH), 2 * scrH, 2 * scrW, 2 * scrH), fieldB[i].Icon))
                    {
                        selectedItem = fieldB[i];
                        selectedFromBackrowA = false;
                        selectedFromFieldA = false;
                        selectedFromFieldB = true;
                        selectedFromBackrowB = false;
                        selectedFromDeck = false;
                    }
                }
                //Health Stuff
                GUI.Box(new Rect(0.25f * scrW, 4.25f * scrH, 2f * scrW, .5f * scrH), "" + player1Health);
                GUI.Box(new Rect(5.75f * scrW, 4.25f * scrH, 2f * scrW, .5f * scrH), "" + player2Health);
                if (player1Turn)
                {
                    GUI.Box(new Rect(3f * scrW, 4.1f * scrH, 2f * scrW, .8f * scrH), "Player 01");
                }
                else if (!player1Turn)
                {
                    GUI.Box(new Rect(3f * scrW, 4.1f * scrH, 2f * scrW, .8f * scrH), "Player 02");
                }
                //fieldA
                GUI.Box(new Rect(0, 5 * scrH, 8 * scrW, 2 * scrH), "");
                for (int i = 0; i < fieldA.Count; i++)
                {
                    GUI.TextArea(new Rect(0 * scrW + i * (2 * scrH), 5 * scrH, 2 * scrW, .25f * scrH), fieldA[i].Name);
                    if (GUI.Button(new Rect(0 * scrW + i * (2 * scrH), 5 * scrH, 2 * scrW, 2 * scrH), fieldA[i].Icon))
                    {
                        selectedItem = fieldA[i];
                        selectedFromBackrowA = false;
                        selectedFromFieldA = true;
                        selectedFromFieldB = false;
                        selectedFromBackrowB = false;
                        selectedFromDeck = false;
                    }
                }
                //backrowA
                GUI.Box(new Rect(0, 7 * scrH, 8 * scrW, 2 * scrH), "");
                for (int i = 0; i < backrowA.Count; i++)
                {
                    GUI.TextArea(new Rect(0 * scrW + i * (2 * scrH), 7 * scrH, 2 * scrW, .25f * scrH), backrowA[i].Name);
                    if (GUI.Button(new Rect(0 * scrW + i * (2 * scrH), 7 * scrH, 2 * scrW, 2 * scrH), backrowA[i].Icon))
                    {
                        selectedItem = backrowA[i];
                        selectedFromBackrowA = true;
                        selectedFromFieldA = false;
                        selectedFromFieldB = false;
                        selectedFromBackrowB = false;
                        selectedFromDeck = false;
                    }
                }
            }
            #endregion

            if (showDeckC)
            {
                GUI.Box(new Rect(0, 0, 3 * scrW, Screen.height), "Deck C");
                for (int i = 0; i < DeckC.Count; i++)
                {
                    if (GUI.Button(new Rect(0, 0 * scrH + i * (.8f * scrH), 3 * scrW, .8f * scrH), DeckC[i].Name))
                    {
                        Debug.Log("Viewing :" + selectedItem.Name);
                        selectedFromBackrowA = false;
                        selectedFromFieldA = false;
                        selectedFromFieldB = false;
                        selectedFromBackrowB = false;
                        selectedFromDeck = true;
                    }
                }
            }

            #region hand stuff
            if (player1Turn)
            {
                if (showHand == true)
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
            else if (!player1Turn)
            {
                if (showHand == true)
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
            #endregion
            #region GY stuff
            if (showGY)
            {
                if (selectedItem != null)
                {
                    GUI.Box(new Rect(8 * scrW, 0, 3 * scrW, 4 * scrH), "Graveyard");
                    for (int i = 0; i < Graveyard.Count; i++)
                    {
                        if (GUI.Button(new Rect(8 * scrW, .25f * scrH + i * (0.5f * scrH), 3 * scrW, .5f * scrH), Graveyard[i].Name))
                        {
                            selectedItem = Graveyard[i];
                            Debug.Log(selectedItem.Name);
                        }
                    }
                }
                else if (selectedItem == null)
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
            }
            #endregion
            #region Control Panel
            if (selectedItem == null)
            {
                if (GUI.Button(new Rect(13f * scrW, 4f * scrH, 1f * scrW, .6f * scrH), "Draw"))
                {
                    DrawPhase();
                }

                if (GUI.Button(new Rect(14f * scrW, 4f * scrH, 1f * scrW, .6f * scrH), "GY"))
                {
                    showGY = !showGY;
                }
                if (GUI.Button(new Rect(15f * scrW, 4f * scrH, 1f * scrW, .6f * scrH), "End"))
                {
                    EndPhase();
                }
                if (GUI.Button(new Rect(13f * scrW, 4.6f * scrH, 1f * scrW, .6f * scrH), "Deck"))
                {
                    if (showField)
                    {
                        showField = false;
                    }
                    showDeckC = !showDeckC;
                }
                if (GUI.Button(new Rect(14f * scrW, 4.6f * scrH, 1f * scrW, .6f * scrH), "Field"))
                {
                    if (showDeckC)
                    {
                        showDeckC = false;
                        showField = true;
                    }
                }
                if (GUI.Button(new Rect(15f * scrW, 8f * scrH, 1f * scrW, .6f * scrH), "Forfeit"))
                {
                    ForfeitDuel();
                }
                if (GUI.Button(new Rect(15f * scrW, 4.6f * scrH, 1 * scrW, .6f * scrH), "Next"))
                {
                    PhaseChange();
                }
                if (defenderSelected && attackerSelected)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        CombatRun();
                    }
                }
            }
            else if (selectedItem != null)
            {
                if (GUI.Button(new Rect(13f * scrW, 6.4f * scrH, 1 * scrW, .6f * scrH), "Deselct"))
                {
                    selectedItem = null;
                }
                if (GUI.Button(new Rect(14f * scrW, 6.4f * scrH, 1 * scrW, .6f * scrH), "Play"))
                {
                    PlayCards();
                }
                if (GUI.Button(new Rect(15 * scrW, 6.4f * scrH, 1 * scrW, .6f * scrH), "Discard"))
                {
                    DiscardCards();
                }
                if (!selectedFromDeck)
                {
                    if (GUI.Button(new Rect(13f * scrW, 7f * scrH, 1f * scrW, .6f * scrH), "Return"))
                    {
                        if (player1Turn)
                        {
                            Hand01.Remove(selectedItem);
                        }
                        else
                        {
                            Hand02.Remove(selectedItem);
                        }
                        DeckC.Add(selectedItem);
                        selectedItem = null;
                    }
                }
                else if (selectedFromDeck)
                {
                    if (GUI.Button(new Rect(13f * scrW, 7f * scrH, 1f * scrW, .6f * scrH), "Add"))
                    {
                        DeckC.Remove(selectedItem);
                        if (player1Turn)
                        {
                            Hand01.Add(selectedItem);
                        }
                        else
                        {
                            Hand02.Add(selectedItem);
                        }
                        selectedItem = null;
                    }
                }
                if (selectedFromBackrowA || selectedFromFieldA || selectedFromFieldB || selectedFromBackrowB)
                {
                    if (GUI.Button(new Rect(15 * scrW, 7f * scrH, 1f * scrW, .6f * scrH), "Use"))
                    {
                        UseEffect();
                    }
                }

                if (GUI.Button(new Rect(14 * scrW, 7f * scrH, 1f * scrW, .6f * scrH), "Banish"))
                {
                    BanishCards();
                }
            }
            #endregion
            #region Combat stuff
            if (combatPhase)
            {
                if (player1Turn)
                {
                    if (selectedFromFieldA)
                    {
                        if (GUI.Button(new Rect(13 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Attacker"))
                        {
                            attackingCard = selectedItem;
                            Debug.Log("Attacker Selected");
                            attackerSelected = true;
                        }
                    }
                    if (selectedFromFieldB)
                    {
                        if (GUI.Button(new Rect(13 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Target"))
                        {
                            defendingCard = selectedItem;
                            Debug.Log("Defender Selected");
                            defenderSelected = true;
                        }
                    }
                }
                else
                {
                    if (selectedFromFieldB)
                    {
                        if (GUI.Button(new Rect(13 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Attacker"))
                        {
                            attackingCard = selectedItem;
                            Debug.Log("Attacker Selected");
                            attackerSelected = true;
                        }
                    }
                    if (selectedFromFieldA)
                    {
                        if (GUI.Button(new Rect(13 * scrW, 7.6f * scrH, 1 * scrW, .6f * scrH), "Target"))
                        {
                            defendingCard = selectedItem;
                            Debug.Log("Defender Selected");
                            defenderSelected = true;
                        }
                    }
                }
            }
            #endregion
        }

    }
}