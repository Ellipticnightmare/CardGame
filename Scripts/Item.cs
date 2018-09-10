using UnityEngine;

public class Item
{
    #region Private Variables
    private int _idNum;
    private string _name;
    private string _description;
    private string _type;
    private int _attack;
    private int _defense;
    private int _rank;
    private Texture2D _icon;
    private GameObject _mesh;
    private ItemType _cardType;
    private EffType _effectType;
    private EffUseType _useType;
    private int _effectValue;
    #endregion
    #region Constructor
    public void ItemConstructor(int itemID, string itemName, Texture2D itemIcon, ItemType cardType, EffType effectType, EffUseType effuseType)
    {
        _idNum = itemID;
        _name = itemName;
        _icon = itemIcon;
        _cardType = cardType;
        _effectType = effectType;
        _useType = useType;
    }
    #endregion
    #region Public Variables
    public int ID
    {
        get { return _idNum; }
        set { _idNum = value; }
    }
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }
    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }
    public string Type
    {
        get { return _type; }
        set { _type = value; }
    }
    public int Attack
    {
        get { return _attack; }
        set { _attack = value; }
    }
    public int Defense
    {
        get { return _defense; }
        set { _defense = value; }
    }
    public int Rank
    {
        get { return _rank; }
        set { _rank = value; }
    }
    public Texture2D Icon
    {
        get { return _icon; }
        set { _icon = value; }
    }
    public GameObject MeshName
    {
        get { return _mesh; }
        set { _mesh = value; }
    }
    public ItemType cardType
    {
        get { return _cardType; }
        set { _cardType = value; }
    }
    public EffType effectType
    {
        get { return _effectType; }
        set { _effectType = value; }
    }
    public EffUseType useType
    {
        get { return _useType; }
        set { _useType = value; }
    }
    public int EffectValue
    {
        get { return _effectValue; }
        set { _effectValue = value; }
    }
    #endregion
}
#region Enums
public enum ItemType
{
    Spell,
    Monster,
    Trap
}
public enum EffType
{
    HealSelf,
    HealOpponent,
    DamageSelf,
    DamageOpponent,
    Draw
}
public enum EffUseType
{
    Repeat,
    Once
}
#endregion