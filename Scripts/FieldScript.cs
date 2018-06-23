using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldScript : MonoBehaviour
{
    [Header("FieldAreas")]
    public List<Item> fieldA = new List<Item>();
    public static int fieldAX, fieldAY;
    private Rect fieldARect;
    public List<Item> fieldB = new List<Item>();
    public int fieldBX, fieldBY;
    private Rect fieldBRect;
    public List<Item> backrowA = new List<Item>();
    public static int backrowAX, backrowAY;
    private Rect backrowARect;
    public List<Item> backrowB = new List<Item>();
    public static int backrowBX, backrowBY;
    private Rect backrowBRect;

    public static bool showField;
    public float scrW;
    public float scrH;

    #region Clamp to Screen
    Rect ClampToScreen(Rect r)
    {
        r.x = Mathf.Clamp(r.x, 0, Screen.width - r.width);
        r.y = Mathf.Clamp(r.y, 0, Screen.height - r.height);
        return r;
    }
    #endregion
    #region Toggle Field
    // public bool ToggleField()
    //{
    //  if (showField)
    //{
    //  showField = false;
    //
    //}
    //    }
    // Use this for initialization
#endregion
    void Start()
    {
        FieldScript.showField = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
