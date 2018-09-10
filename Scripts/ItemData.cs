using UnityEngine;

public static class ItemData
{
    public static Item CreateItem(int itemId)
    {
        Item temp = new Item();
        string name = "";
        string description = "";
        string type = "";
        int attack = 0;
        int defense = 0;
        int rank = 0;
        string icon = "";
        string mesh = "";
        ItemType cardType = ItemType.Spell;

        EffType effectType = EffType.HealSelf;
        EffUseType effuseType = EffUseType.Repeat;
        int effectValue = 0;

        switch (itemId)
        {
            #region Archetypes
            #region Spells
            #region RainbowRoyalty
            case 001:
                name = "Chromagic: Delta Hurricane";
                description = "Discard as many cards as desired, with at least one Water.  Destroy an equal or lesser number of cards upon the field.";
                type = "Water";
                icon = "chromagicDeltaHurricane";
                cardType = ItemType.Spell;
                break;
            case 002:
                name = "Chromagic: Cursed Prophet";
                description = "Once per turn, players may spend 250 Health to look at 1 card in their opponents hand.";
                type = "Dark";
                cardType = ItemType.Spell;
                break;
            case 003:
                name = "Chromagic: Divine Light";
                description = "Discard as many cards as desired.  You gain 500 Health for each card discarded.";
                type = "Light";
                cardType = ItemType.Spell;
                effectType = EffType.HealSelf;
                effuseType = EffUseType.Repeat;
                effectValue = 500;
                break;
            case 004:
                name = "Chromagic: Blessed Armor";
                description = "When a monster equipped with this card is sent to the grave, flip a coin.  On heads, the monster is returned to the deck.  On tails, this card is returned to the deck.";
                type = "Light";
                cardType = ItemType.Spell;
                break;
            case 005:
                name = "Chromagic: Divine Blade";
                description = "When a monster equipped with this card is sent to the grave, deal half ATK of the monster to the controller of the attack monster";
                type = "Fire";
                cardType = ItemType.Spell;
                break;
            case 006:
                name = "Chromagic: Mystic Book";
                description = "A monster equipped with this card has its Battle Damage treated as effect damage";
                type = "Air";
                cardType = ItemType.Spell;
                break;
            case 007:
                name = "Chromagic: Spiral Lance";
                description = "Flip 1 North Star Knight, 1 Tapestry Queen, and 1 Ancient King upside down and shuffle them around.  At random, 1 card is returned to your deck, 1 card is placed Face-Down on the opponent's field, or in their hand if not applicable, and the final card deals half ATK damage to the opponent as effect damage";
                type = "Fire";
                cardType = ItemType.Spell;
                break;
            case 008:
                name = "Chromagic: Final Celestial Strike";
                description = "Select 1 Rainbow archetype Monster.  Token all other Rainbow Monsters on the field, and add their ATK values to the selected monster until the end of this turn.  During the end phase, the selected monster is placed into DEF position, and cannot change it's position, nor use any of it's effects for the remainder of the game";
                type = "Wood";
                cardType = ItemType.Spell;
                break;
            #endregion
            #region AscendingWyrm
            case 009:
                name = "Miracle Scale";
                description = "Spend x * 100 Health.  For each 100 Health spent, increase the rank of 1 monster on the field by one.";
                type = "Dark";
                cardType = ItemType.Spell;
                effectType = EffType.DamageSelf;
                effuseType = EffUseType.Repeat;
                effectValue = 100;
                break;
            case 010:
                name = "Void Caller";
                description = "Either player can spend 500 Health, return 2 cards from their hand to their deck, then draw and reveal a card.  If the revealed card is a monster, it is summoned regardless of previous summoning conditions.  If the card is a spell, it is added to the hand.  If the card is a trap, it is returned to the deck, and the player gains 250 Health";
                type = "Dark";
                break;
            case 011:
                name = "Ancient Ritual of Life Sharing";
                description = "Target two monsters on the field with different ranks.  Both ranks become equal to the sum of the two ranks, divided by two.";
                type = "Light";
                break;
            case 012:
                name = "Equivalent Exchange";
                description = "This card remains face up on the field.  While this card is faceup, whenever a player would lose life by a spell card, except by paying it as a cost or passive effect, that player gains the life lost instead, and the opposing player takes one half the damage instead.";
                type = "Light";
                break;
            case 013:
                name = "Spiteful Salvation";
                description = "This card remains face up on the field.  While this card is faceup, whenever a monster is summoned to your side of the field, you may choose one of the following effets: That monster gains 100 ATK and 100 DEF, and you lose 100 Health.  That monster loses 100 ATK and 100 DEF, and you gain 100 Health.  This damage is not paid as a cost.";
                type = "Energy";
                break;
            case 014:
                name = "Cracked Egg";
                description = "During each player's end phase, place a counter on this card.  When a monster is summoned to your opponents side of the field, you may remove as many counters as desired from this card and place them on the summoned monster.  That monster loses 50 ATK for each counter added.";
                type = "Dark";
                break;
            #endregion
            #region Forest Fury

#endregion
            #region United

            #endregion
            #region World Tortoise

            #endregion
            #endregion

            #region Monsters
            #region RainbowRoyalty
            case 101:
                name = "Street Urchin";
                description = "This card is treated as a Light type until it declares an attack.  This card may attack your opponent directly";
                type = "Dark";
                icon = "streetUrchin";
                attack = 700;
                defense = 100;
                rank = 1;
                cardType = ItemType.Monster;
                break;
            case 102:
                name = "North Star Knight";
                description = "When battling a Water or Light Monster, the enemy monster is destroyed at the end of the Battle Phase";
                type = "Fire";
                icon = "northStarKnight";
                attack = 1400;
                defense = 1200;
                rank = 3;
                cardType = ItemType.Monster;
                break;
            case 103:
                name = "Tapestry Queen";
                description = "When this card is destroyed, it may be returned as a token, as well as any other Rainbow Alignment cards in the Graveyard.";
                type = "Wood";
                icon = "tapestryQueen";
                attack = 1200;
                defense = 1000;
                rank = 2;
                cardType = ItemType.Monster;
                break;
            case 104:
                name = "Noble Squire";
                description = "When this card is destroyed, summon 1 North Star Knight from the deck in Face Down DEF position.  If this card is not in ATK position, destroy it";
                type = "Wood";
                attack = 1000;
                defense = 0;
                rank = 1;
                cardType = ItemType.Monster;
                break;
            case 105:
                name = "Ancient King";
                description = "When this card is flipped face-up, mill the deck until a Chromagic card is revealed.  Put the revealed card into your hand, then shuffle the Graveyard and deck together into a new deck.  Once per turn, during the end phase, you may spend 500 Health to flip this monster face down.";
                type = "Energy";
                attack = 1000;
                defense = 100;
                rank = 3;
                cardType = ItemType.Monster;
                break;
            case 106:
                name = "Warrior Princess";
                description = "When this card attacks a Fire or Earth Type, this card gains 300 ATK.  At the end of each turn, this card switches positions";
                type = "Water";
                attack = 1200;
                defense = 1400;
                rank = 3;
                cardType = ItemType.Monster;
                break;
            case 107:
                name = "Mystic Elder";
                description = "When this card is sent to the grave, add 1 Mysic Book to your hand from the deck, and place 1 Chromagic card back into the deck from your field or the Graveyard.";
                type = "Light";
                attack = 600;
                defense = 400;
                rank = 2;
                cardType = ItemType.Monster;
                break;
            case 108:
                name = "Hoheitlich";
                description = "This card can only be summoned by tokening 1 Noble Squire or 1 Street Urchin, 1 Mystic Elder, and 1 Divine Blade or 1 Blessed Armor.  If tokened with Street Urchin, this card deals piercing damage against DEF monsters.  If tokened with Noble Squire, the controlling player gains 1000 Health per turn.  If tokened with Divine Blade, this card gains 400 ATK.  If tokened with Blessed Armor, this card gains 400 DEF.  While Ancient King, Tapestry Queen, and Warrior Princess are on the field face-up, this card loses 1500 ATK/DEF, but cannot be destroyed by battle, and all battle damage is dealt to the opponent instead";
                type = "Fire";
                attack = 3500;
                defense = 3500;
                rank = 8;
                cardType = ItemType.Monster;
                break;
            #endregion
            #region AscendingWyrm
            case 109:
                name = "Umbrella Swordsman";
                break;
            case 110:
                name = "Nimrod the hidden Deceiver";
                break;
            case 111:
                name = "Kamikaze Dragon";
                break;
            case 112:
                name = "Ascension Dragon, Apex Form";
                break;
            case 113:
                name = "Ascension Dragon, Shadow Form";
                break;
            case 114:
                name = "Ascension Dragon, Vengeance Form";
                break;
            case 115:
                name = "Ascension Dragon, Arsenal Form";
                break;
            case 116:
                name = "Ascension Dragon, Bomber Form";
                break;
            case 117:
                name = "Ascension Dragon, TimeSlip Form";
                break;
            case 118:
                name = "Ascension Dragon, Heart Form";
                break;
            case 119:
                name = "Ascension Dragon, Lich Form";
                break;
            case 120:
                name = "Ascension Dragon, Miracle Form";
                break;
            case 121:
                name = "Ascension Dragon, Breeding Form";
                break;
            #endregion
            #region Forest Fury
            case 122:
                name = "Sapling";
                description = "The turn after this card is flipped faceup, you may token it, and summon 1 Dryad or 1 Treeant from the deck.  If this card is in the Graveyard, you may banish it to summon 1 Poison Oak Knight or 1 Poison Ivy Witch from the deck.";
                type = "Wood";
                attack = 300;
                defense = 300;
                rank = 2;
                cardType = ItemType.Monster;
                break;
            case 123:
                name = "Dryad";
                description = "The turn after this card is summoned, you may toekn it, and summon one Hamadryad from the deck.  If this effect is used, return 1 Sapling from the graveyard to the deck.  If this card was summoned using the effect of Sapling, it gains 300 DEF.";
                type = "Wood";
                attack = 1600;
                defense = 1800;
                rank = 4;
                cardType = ItemType.Monster;
                break;
            case 124:
                name = "Hamadryad";
                description = "This card cannot be normal summoned.  If this card was special summoned through the effect of Dryad, negate and destroy all trap cards on the field while this card remains face-up.";
                type = "Wood";
                attack = 2000;
                defense = 2400;
                rank = 8;
                cardType = ItemType.Monster;
                break;
            case 125:
                name = "Treeant";
                description = "The turn after this card was summoned, you may token it, and summon one Ent from the deck.  If this effect is used, return 1 Sapling from the Graveyard to the deck.  If this card was summoned using the effect of Sapling, it gains 300 ATK";
                type = "Wood";
                attack = 1500;
                defense = 1600;
                rank = 4;
                cardType = ItemType.Monster;
                break;
            case 126:
                name = "Ent";
                description = "This card cannot be normal summoned.  If this card was special summoned through the effect of Treeant, negate and destroy all spell cards on the field while this card remains face-up.";
                type = "Wood";
                attack = 2200;
                defense = 2200;
                rank = 8;
                cardType = ItemType.Monster;
                break;
            case 127:
                name = "Seedling";
                description = "When this card is destroyed by battle, you may add 1 Sapling from the deck to your hand.";
                type = "Wood";
                attack = 100;
                defense = 100;
                rank = 1;
                cardType = ItemType.Monster;
                break;
                #endregion
            #region United

            #endregion
            #region World Tortoise
            #endregion
            #endregion

            #region Traps
            #region RainbowRoyalty
            case 201:
                name = "Spirit Bond";
                description = "Discard 1 card to negate the effect of a card of the same type";
                type = "Fire";
                cardType = ItemType.Trap;
                break;
            case 202:
                name = "Phalanx Bond";
                description = "This card stays face-up on the field.  While this card is active, all North Star Knights gain 100 ATK and DEF per card on the field.";
                type = "Wood";
                cardType = ItemType.Trap;
                break;
            case 203:
                name = "False Retirement";
                description = "For every Ancient King, Tapestry Queen, and Warrior Princess face-up on the field, 1 card may be un-tokened.";
                type = "Wood";
                cardType = ItemType.Trap;
                break;
            case 204:
                name = "Military Bluff";
                description = "This card remains face-up on the field.  Once per turn, flip 3 coins per facedown card.  On 2 or more heads, that card is destroyed without flipping or activating effects";
                type = "Dark";
                cardType = ItemType.Trap;
                break;
            #endregion
            #region AscendingWyrm
            case 205:
                name = "Wyrm Ascension";
                description = "Reduce your Health to 1.  After this cost resolves, special summon as many Ascension Dragon type monsters as possible from the Graveyard, and recover x100 Health, x being the total rank of all monsters special summoned by this cards effect.";
                type = "Light";
                cardType = ItemType.Trap;
                effectType = EffType.DamageSelf;
                effuseType = EffUseType.Once;
                if (Inventory.player1Turn)
                {
                    effectValue = Inventory.player1Health - 1;
                }
                else if(Inventory.player1Turn == false)
                {
                    effectValue = Inventory.player2Health - 1;
                }
                break;
            #endregion
            #region United

            #endregion
            #region World Tortoise

            #endregion
            #endregion
            #endregion

            #region General
            #region spells
            case 400:
                name = "Vicious Frenzy";
                description = "Target a face-up monster.  You may force that monster to attack one of your opponents monsters.  Damage calculation is done normally.";
                type = "Dark";
                cardType = ItemType.Spell;
                break;
            case 401:
                name = "Sunbeam";
                description = "Gain 1000 health";
                type = "Light";
                cardType = ItemType.Spell;
                effectType = EffType.HealSelf;
                effuseType = EffUseType.Once;
                effectValue = 1000;
                break;
            case 402:
                name = "Bandit Specialist";
                description = "Spend 500 Health.  Your opponent discards any and all traps currently in their hand";
                type = "Fire";
                cardType = ItemType.Spell;
                effectType = EffType.DamageSelf;
                effuseType = EffUseType.Once;
                effectValue = 500;
                break;
            #endregion
            #region Monsters
            #endregion
            #region Traps
            case 600:
                name = "False Expectations";
                description = "Players each select a card from the other persons hand at random.  If the card selected was a spell or trap, the original owner draws a card.  Otherwise, the drawing player must guess the type of monster.  If they guess successfully, they summon it in face down position.  If they guess incorrectly, the original owner summons it to their field in face down position";
                type = "Energy";
                cardType = ItemType.Trap;
                break;
            case 601:
                name = "Surface Tension";
                description = "Negate the current attack, also, the user takes no battle damage until the end of their opponents next turn";
                type = "Water";
                cardType = ItemType.Trap;
                break;
            #endregion
            #endregion
            default:
                itemId = 0;
                name = "Apple";
                description = "Munchies and Crunchies";
                type = "blank";
                break;
        }

        temp.Name = name;
        temp.ID = itemId;
        temp.Description = description;
        temp.Type = type;
        temp.Attack = attack;
        temp.Defense = defense;
        temp.Rank = rank;
        temp.Icon = Resources.Load("Icons/" + icon) as Texture2D;
        temp.MeshName = Resources.Load("Prefabs/" + mesh) as GameObject;
        temp.cardType = cardType;
        temp.effectType = effectType;
        temp.useType = effuseType;
        temp.EffectValue = effectValue;

        return temp;
    }

}