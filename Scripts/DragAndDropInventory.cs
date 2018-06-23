//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class DragAndDropInventory : MonoBehaviour
//{
//    #region Variables
//    [Header("Inventory")]
//    public List<Item> dragInv = new List<Item>();
//    public bool showDragInv;
//    public int slotX, slotY;
//    private Rect invRect;
//    [Header("Dragging")]
//    public bool dragging;
//    public Item draggedItem;
//    public int draggedFrom;//Slot we took the item from
//    public GameObject droppedItem;
//    [Header("Tool Tip")]
//    public int toolTipItem;
//    public bool showToolTip;
//    private Rect toolTipRect;
//    [Header("References + Other")]
//    public float scrW;
//    public float scrH;
//    //Reference Player/Camera for Move and MouseLook
//    #endregion
//    #region Clamp to Screen
//    Rect ClampToScreen(Rect r)
//    {
//        r.x = Mathf.Clamp(r.x, 0, Screen.width - r.width);
//        r.y = Mathf.Clamp(r.y, 0, Screen.height - r.height);
//        return r;
//    }
//    #endregion
//    #region Toggle Inv and Control of player
//    public bool ToggleInv()
//    {
//        if(showDragInv)
//        {
//            showDragInv = false;
//            Cursor.lockState = CursorLockMode.Locked;
//            Cursor.visible = false;
//            //time = 1
//            //toggle on player/camera move and mouse look
//            return false;
//        }
//        else
//        {
//            showDragInv = true;
//            Cursor.lockState = CursorLockMode.None;
//            Cursor.visible = true;
//            //time = 0
//            //toggle off player/camera move and mouse look
//            return true;
//        }
//    }
//    #endregion
//    #region AddItem
//    void AddItem(int iD)
//    {
//        for (int i = 0; i < dragInv.Count; i++)
//        {
//            if (dragInv[i].Name == null)
//            {
//                dragInv[i] = ItemData.CreateItem(iD);
//                return;
//            }
//        }
//    }
//    #endregion
//    #region Start
//    void Start()
//    {
//        scrW = Screen.width / 16;
//        scrH = Screen.height / 9;
//        invRect = new Rect(scrW, scrH, 5.5f * scrW, 4.5f * scrH);
//        for (int i = 0; i < (slotX * slotY); i++)
//        {
//            dragInv.Add(new Item());
//        }
//        AddItem(0);
//        AddItem(100);
//        AddItem(101);
//        AddItem(102);
//        AddItem(201);
//        AddItem(202);
//        AddItem(302);
//    }
//    #endregion
//    #region Update
//    void Update()
//    {
//        if(Input.GetKeyDown(KeyCode.I))
//        {
//            ToggleInv();
//        }
//    }
//    #endregion
//    #region Drag Inventory
//    void DragInventory(int windowID)
//    {
//        GUI.Box(new Rect(0, 0.25f * scrH, 5.5f * scrW, 0.5f * scrH), "Banner");
//        GUI.Box(new Rect(0, 4.25f * scrH, 5.5f * scrW, 0.5f * scrH), "Gold n EXP");
//        showToolTip = false;
//        #region Nested For Loop
//        Event e = Event.current;
//        int i = 0;
//        for (int y = 0; y < slotY; y++)
//        {
//            for (int x = 0; x < slotX; x++)
//            {
//                Rect slotLocation = new Rect(scrW*0.125f+x*(scrW*0.75f),scrH*0.75f + y*(scrH * 0.65f),0.75f*scrW,0.65f*scrH);
//                GUI.Box(slotLocation, "");
//                //ADD TO HERE FOR MORE INV SHIZ
//				#region Pick Up
//				if(e.button == 0 && e.type == EventType.MouseDown && 
//					slotLocation.Contains(e.mousePosition)&& !dragging &&
//					dragInv[i].Name != null && !Input.GetKey(KeyCode.LeftShift))
//				{
//					draggedItem = dragInv[i];//we pick up item
//					dragInv[i] = new Item();//set the slot to empty
//					dragging = true;//we are now dragging
//					draggedFrom = i;//original item location
//					Debug.Log("Dragging: "+draggedItem.Name);
//				}
//				#endregion
//				#region Swap Items
//				if(e.button == 0 && 
//					e.type == EventType.MouseUp && 
//					slotLocation.Contains(e.mousePosition)&&
//					dragging && dragInv[i].Name != null)
//				{
//					Debug.Log("Swapping: " + draggedItem.Name + " :With: " + dragInv[i].Name);
//					dragInv[draggedFrom] = dragInv[i];//old location now has other item
//					dragInv[i] = draggedItem;//fill new location with dragged item
//					draggedItem = new Item();//empty dragged item
//					dragging = false;//no longer dragging items
//				}
//				#endregion
//				#region Place in Slot
//				if(e.button == 0 && e.type == EventType.MouseUp &&
//					slotLocation.Contains(e.mousePosition)&&
//					dragging && dragInv[i].Name == null)
//				{
//					Debug.Log("Place: "+draggedItem.Name+" :Into: "+i);
//					dragInv[i] = draggedItem;//place dragged item into slot
//					draggedItem = new Item();//item we are dragging is now empty
//					dragging = false;//we are not holding an item
//				}
//				#endregion
//				#region Return To Original Location

//				#endregion
//                #region Draw Inventory Icon
//                if(dragInv[i].Name != null)
//                {
//                    GUI.DrawTexture(slotLocation, dragInv[i].Icon);
//					#region Set ToolTip on Mouse Hover
//					if(slotLocation.Contains(e.mousePosition)&&!dragging && showDragInv)
//					{
//						toolTipItem = i;
//						showToolTip = true;
//					}
//					#endregion
//                }
//                #endregion
//                i++;
//            }
//        }
//        #endregion
//		#region Drag Window
//		GUI.DragWindow(new Rect(0*scrW,0*scrH,5.5f*scrW,0.5f*scrH));//top		GUI.DragWindow(new Rect(scrW,scrH,scrW,scrH));
//		GUI.DragWindow(new Rect(0*scrW,0.5f*scrH,0.25f*scrW,3.5f*scrH));//left
//		GUI.DragWindow(new Rect(5.25f*scrW,0.5f*scrH,0.25f*scrW,3.5f*scrH));//right
//		GUI.DragWindow(new Rect(0*scrW,4*scrH,5.5f*scrW,0.5f*scrH));//bottom
//		#endregion
//    }
//    #endregion
//    #region OnGUI
//    void OnGUI()
//    {
//		scrW = Screen.width / 16;
//		scrH = Screen.height / 9;
//        Event e = Event.current;
//        #region Draw Inventory is show = true
//        if(showDragInv)
//        {
//            invRect = ClampToScreen(GUI.Window(1, invRect, DragInventory,"Drag Inventory"));
//        }
//        #endregion
//		#region Draw ToolTip
//		if(showToolTip && showDragInv)
//		{
//			toolTipRect = new Rect(e.mousePosition.x+0.01f,e.mousePosition.y +0.01f,scrW*2,scrH*3);
//			GUI.Window(15,toolTipRect,DrawToolTip,"");
//		}
//		#endregion
//		#region Draw Item on Mouse
//		if(dragging)
//		{
//			Rect mouseLocation = new Rect(e.mousePosition.x - scrW*0.5f,
//				e.mousePosition.y+0.125f,
//				scrW*0.5f,scrH*0.5f);
//			GUI.Window(2,mouseLocation,DrawItem,"");
//		}
//		#endregion
//		#region Drop Item on Drag/Drop Item on Close
//		if((e.button == 0 && e.type == EventType.MouseUp && dragging)
//			||(dragging && !showDragInv))
//		{
//			DropItem();
//			Debug.Log("Dropped: "+draggedItem.Name);
//			draggedItem = new Item();
//			dragging = false;
//			droppedItem.GetComponent<ItemHandler>().enabled = true;
//			droppedItem.AddComponent<Rigidbody>();
//			droppedItem.GetComponent<Rigidbody>().useGravity = true;
//			droppedItem = null;
//		}
//		#endregion
//    }
//    #endregion
//    #region DrawItem
//    void DrawItem(int windowID)
//    {
//		if(draggedItem.Icon!=null)
//		{
//			GUI.DrawTexture (new Rect(0,0,scrW*0.5f,scrH*0.5f),draggedItem.Icon);
//		}
//    }
//    #endregion
//	#region ToolTip
//		#region ToolTipContent
//	//string ToolTipText(int iD)
//	//{
//	//	string toolTipText = "Name: "+dragInv[iD].Name+
//		//	"\nDescription: "+dragInv[iD].Description+
//			//"\nType: "+dragInv[iD].Type+
//			//"\nValue: "+dragInv[iD].Value;
//	//	return toolTipText;
//	//}
//		#endregion
//		#region ToolTipWindow
//	void DrawToolTip(int windowID)
//	{
//		GUI.Box (new Rect (0, 0, scrW * 2, scrH * 3), ToolTipText (toolTipItem));
//	}
//		#endregion
//	#endregion
//	#region Drop Item
//	public void DropItem()
//	{
//		//						  Resources.Load("Prefabs/"+draggedItem.MeshName)as GameObject
//		droppedItem = Instantiate(draggedItem.MeshName,transform.position+transform.forward *3+transform.up*2,Quaternion.identity);
//		return;
//	}
//	#endregion
//}
