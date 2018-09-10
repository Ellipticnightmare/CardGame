using System.Collections;
using UnityEngine;

public class ItemHandler : MonoBehaviour
{
    #region public Variables
    public int idNum;
    public string itemName;
    public string description;
    public string type;
    public int attack;
    public int defense;
    public int rank;
    public string icon;
    public string mesh;
    public ItemType cardType;
    public EffType effectType;
    public EffUseType useType;
    public int effectValue;
    #endregion
    public void OnCollection()
    {
        Item temp = new Item();
        temp.ID = idNum;
        temp.Name = itemName;
        temp.Description = description;
        temp.Type = type;
        temp.Attack = attack;
        temp.Defense = defense;
        temp.Rank = rank;
        temp.Icon = Resources.Load("Icons/" + icon) as Texture2D;
        temp.MeshName = Resources.Load("Prefabs/" + mesh) as GameObject;
        temp.cardType = cardType;
        temp.effectType = effectType;
        temp.useType = useType;
        temp.EffectValue = effectValue;

        Inventory inventory = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Inventory>();

        
    }
}