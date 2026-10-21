using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class CosmeticItem
{
    private string name;
    private int price;
    public string ImageTxt;
	private Sprite cosmeticImage;
    public bool bought;

    public string Name => name;
    public int Price => price;

    // Loads the sprite the first time it's requested (safe: happens after Unity is ready)
    public Sprite CosmeticImage
    {
        get
        {
            if (cosmeticImage == null)
            {
                cosmeticImage = Resources.Load<Sprite>(ImageTxt);
                if (cosmeticImage == null)
                    Debug.LogWarning("Sprite not found: " + ImageTxt);
            }
            return cosmeticImage;
        }
    }

    // Only stores strings and numbers, so it's safe to call from a field initializer
    public CosmeticItem(string name, string ImageTxt, int price, bool bought)
    {
        this.name = name;
        this.ImageTxt = ImageTxt;
        this.price = price;
        this.bought = bought;
    }

    public void buyCosmetic()
    {
        bought = true;
        PlayerStuff.Leaves -= price;
    }

    public void sellCosmetic()
    {
        bought = false;
        PlayerStuff.Leaves += price;
    }

    public bool isBought()
    {
        return bought;
    }
}

public class CosmeticScript : MonoBehaviour
{
    public List<Image> CosmeticImages;   // drag your 6 slot Images in the Inspector

    private int unboughtCount;           // items [0, unboughtCount) are unbought
    private List<int> shownIndexes = new List<int>();
    private int day;
    private int prevDay;

    [System.NonSerialized]
    public List<CosmeticItem> CosmeticItems;
	void Awake(){
		CosmeticItems = new List<CosmeticItem>
    	{
        	new CosmeticItem("Jungle Hat", "Art/ambulance", 20, false),
        	new CosmeticItem("Winter Hat", "Art/angry", 20, false),
        	new CosmeticItem("Summer Hat", "Art/bee", 20, false),
        	new CosmeticItem("Sunglasses", "Art/cat", 10, false),
        	new CosmeticItem("Rainbow Hat", "Art/circle", 20, false),
        	new CosmeticItem("Rainbow Sunglasses", "Art/cow", 15, false),
        	new CosmeticItem("Top Hat", "Art/cringe", 25, false),
        	new CosmeticItem("Star Sunglasses", "Art/cry", 15, false),
        	new CosmeticItem("Heart Glasses", "Art/dog", 15, false),
        	new CosmeticItem("Astronaut Helmet", "Art/hate", 25, false),
        	new CosmeticItem("Cat In the Hat Hat", "Art/hexagon", 30, false),
        	new CosmeticItem("Sombrero", "Art/horse", 30, false),
        	new CosmeticItem("Zach Hat", "Art/hospital", 5, false),
        	new CosmeticItem("Naveed Hat", "Art/octogon", 1, false),
        	new CosmeticItem("Jerry Hat", "Art/park", 5, false),
        	new CosmeticItem("Ethan Hat", "Art/pentagon", 5, false),
        	new CosmeticItem("Jake Hat", "Art/pizza", 5, false),
        	new CosmeticItem("Aiden Hat", "Art/smile", 5, false),
        	new CosmeticItem("Andy Hat", "Art/snake", 5, false),
        	new CosmeticItem("Oscar Hat", "Art/square", 5, false),
        	new CosmeticItem("Party Hat", "Art/suprised", 25, false),
        	new CosmeticItem("Wizard Hat", "Art/taco", 25, false),
       		new CosmeticItem("Baseball Hat", "Art/tree", 15, false),
        	new CosmeticItem("Beanie", "Art/Untitled design (1)", 10, false),
        	new CosmeticItem("Cowboy Hat", "Art/Untitled design (2)", 20, false),
        	new CosmeticItem("Fruit Hat", "Art/Untitled design (3)", 18, false),
        	new CosmeticItem("Golden Crown", "Art/Untitled design", 2000, false)
    	};
	}
	
    void Start()
    {
	    day = prevDay = DateTime.Now.Day;
        RefreshShop();
    }

    void Update()
    {
	    day = DateTime.Now.Day;
	    if (day != prevDay)
	    {
		    RefreshShop();
		    prevDay = day;
	    }
    }

    public void RefreshShop()
    {
        shownIndexes = GetUniqueRandomIndexes(6);

        for (int i = 0; i < CosmeticImages.Count; i++)
        {
            bool hasItem = i < shownIndexes.Count;
            CosmeticImages[i].gameObject.SetActive(hasItem);

            if (hasItem)
                CosmeticImages[i].sprite = CosmeticItems[shownIndexes[i]].CosmeticImage;
        }
    }

    // Hook to each slot's button OnClick, passing the slot number 0-5
    public void BuySlot(int slot)
    {
        if (slot >= shownIndexes.Count) return;
        CosmeticItem item = CosmeticItems[shownIndexes[slot]];
        if (item.Price > PlayerStuff.Leaves) return;
        if (item.isBought()) return;
        item.buyCosmetic();
        CosmeticImages[slot].gameObject.SetActive(false);
    }

    List<int> GetUniqueRandomIndexes(int amount)
    {
        var indexes = new List<int>();
        for (int i = 0; i < CosmeticItems.Count; i++) indexes.Add(i); // unbought items only
			if (!CosmeticItems[i].isBought()) indexes.Add(i);
        for (int i = indexes.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (indexes[i], indexes[j]) = (indexes[j], indexes[i]);
        }

        return indexes.GetRange(0, Mathf.Min(amount, indexes.Count));
    }
}
