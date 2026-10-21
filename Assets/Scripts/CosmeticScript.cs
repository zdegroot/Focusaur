using System;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class CosmeticItem
{
    private string name;
    private int price;
	private Sprite cosmeticImage;
    public bool bought;

    public string Name => name;
    public int Price => price;
    public Sprite CosmeticImage => cosmeticImage;
    
    // Only stores strings and numbers, so it's safe to call from a field initializer
    public CosmeticItem(string name, Sprite cosmeticImage, int price, bool bought)
    {
        this.name = name;
        this.cosmeticImage = cosmeticImage;
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
    public List<Sprite> CosmeticSprites;
    private int unboughtCount;           // items [0, unboughtCount) are unbought
    private List<int> shownIndexes = new List<int>();
    private int day;
    private int prevDay;
// didn't push
    [System.NonSerialized]
    public List<CosmeticItem> CosmeticItems;
	void Awake(){
		
		Debug.Log("Sprites in list: " + CosmeticSprites.Count, this);
		
		CosmeticItems = new List<CosmeticItem>
    	{
        	new CosmeticItem("Jungle Hat", CosmeticSprites[0], 20, false),
        	new CosmeticItem("Winter Hat", CosmeticSprites[1], 20, false),
        	new CosmeticItem("Summer Hat", CosmeticSprites[2], 20, false),
        	new CosmeticItem("Sunglasses", CosmeticSprites[3], 10, false),
        	new CosmeticItem("Rainbow Hat", CosmeticSprites[4], 20, false),
        	new CosmeticItem("Rainbow Sunglasses", CosmeticSprites[5], 15, false),
        	new CosmeticItem("Top Hat", CosmeticSprites[6], 25, false),
        	new CosmeticItem("Star Sunglasses", CosmeticSprites[7], 15, false),
        	new CosmeticItem("Heart Glasses", CosmeticSprites[8], 15, false),
        	new CosmeticItem("Astronaut Helmet", CosmeticSprites[9], 25, false),
        	new CosmeticItem("Cat In the Hat Hat", CosmeticSprites[10], 30, false),
        	new CosmeticItem("Sombrero", CosmeticSprites[11], 30, false),
        	new CosmeticItem("Zach Hat", CosmeticSprites[12], 5, false),
        	new CosmeticItem("Naveed Hat", CosmeticSprites[13], 1, false),
        	new CosmeticItem("Jerry Hat", CosmeticSprites[14], 5, false),
        	new CosmeticItem("Ethan Hat", CosmeticSprites[15], 5, false),
        	new CosmeticItem("Jake Hat", CosmeticSprites[16], 5, false),
        	new CosmeticItem("Aiden Hat", CosmeticSprites[17], 5, false),
        	new CosmeticItem("Andy Hat", CosmeticSprites[18], 5, false),
        	new CosmeticItem("Oscar Hat", CosmeticSprites[19], 5, false),
        	new CosmeticItem("Party Hat", CosmeticSprites[20], 25, false),
        	new CosmeticItem("Wizard Hat", CosmeticSprites[21], 25, false),
       		new CosmeticItem("Baseball Hat", CosmeticSprites[22], 15, false),
        	new CosmeticItem("Beanie", CosmeticSprites[23], 10, false),
        	new CosmeticItem("Cowboy Hat", CosmeticSprites[24], 20, false),
        	new CosmeticItem("Fruit Hat", CosmeticSprites[25], 18, false),
        	new CosmeticItem("Golden Crown", CosmeticSprites[26], 2000, false)
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
        for (int i = 0; i < CosmeticItems.Count; i++) 
        {
	        // unbought items only
	        if (!CosmeticItems[i].isBought())
	        {
		        indexes.Add(i);
	        }
        } 
			
        for (int i = indexes.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (indexes[i], indexes[j]) = (indexes[j], indexes[i]);
        }

        return indexes.GetRange(0, Mathf.Min(amount, indexes.Count));
    }
}
