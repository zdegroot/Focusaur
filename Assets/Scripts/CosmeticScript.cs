using System;
using TMPro;
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
	[SerializeField] public TMP_Text CosmeticText;
    
    // Only stores strings and numbers, so it's safe to call from a field initializer
    public CosmeticItem(string name, Sprite cosmeticImage, int price, bool bought)
    {
        this.name = name;
        this.cosmeticImage = cosmeticImage;
        this.price = price;
        this.bought = bought;
		CosmeticText.text = name;
    }
	public string getName(){
		return name;
	}
	public int getPrice(){
		return price;
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
	public List<TMP_Text> CosmeticText;
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
	public string concatTxt(string name, int price){
		return name + price.ToString();
	}

	public List<string> CosmeticTexts = new List<string>{
		concat(CosmeticItems[0].getName(),CosmeticItems[0].getPrice()),
		concat(CosmeticItems[1].getName(),CosmeticItems[1].getPrice()),
		concat(CosmeticItems[2].getName(),CosmeticItems[2].getPrice()),
		concat(CosmeticItems[3].getName(),CosmeticItems[3].getPrice()),
		concat(CosmeticItems[4].getName(),CosmeticItems[4].getPrice()),
		concat(CosmeticItems[5].getName(),CosmeticItems[5].getPrice()),
		concat(CosmeticItems[6].getName(),CosmeticItems[6].getPrice()),
		concat(CosmeticItems[7].getName(),CosmeticItems[7].getPrice()),
		concat(CosmeticItems[8].getName(),CosmeticItems[8].getPrice()),
		concat(CosmeticItems[9].getName(),CosmeticItems[9].getPrice()),
		concat(CosmeticItems[10].getName(),CosmeticItems[10].getPrice()),
		concat(CosmeticItems[11].getName(),CosmeticItems[11].getPrice()),
		concat(CosmeticItems[12].getName(),CosmeticItems[12].getPrice()),
		concat(CosmeticItems[13].getName(),CosmeticItems[13].getPrice()),
		concat(CosmeticItems[14].getName(),CosmeticItems[14].getPrice()),
		concat(CosmeticItems[15].getName(),CosmeticItems[15].getPrice()),
		concat(CosmeticItems[16].getName(),CosmeticItems[16].getPrice()),
		concat(CosmeticItems[17].getName(),CosmeticItems[17].getPrice()),
		concat(CosmeticItems[18].getName(),CosmeticItems[18].getPrice()),
		concat(CosmeticItems[19].getName(),CosmeticItems[19].getPrice()),
		concat(CosmeticItems[20].getName(),CosmeticItems[20].getPrice()),
		concat(CosmeticItems[21].getName(),CosmeticItems[21].getPrice()),
		concat(CosmeticItems[22].getName(),CosmeticItems[22].getPrice()),
		concat(CosmeticItems[23].getName(),CosmeticItems[23].getPrice()),
		concat(CosmeticItems[24].getName(),CosmeticItems[24].getPrice()),
		concat(CosmeticItems[25].getName(),CosmeticItems[25].getPrice()),
		concat(CosmeticItems[26].getName(),CosmeticItems[26].getPrice())
    };
	
	
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
                CosmeticText[i].text = CosmeticTexts[shownIndexes[i]];
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
