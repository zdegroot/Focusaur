 using System.Collections.Generic;
 using UnityEngine.UI;
 using UnityEngine;

 public class CosmeticItem
 {
     private string name;
     private int price;
     public string ImageTxt;
     public Sprite CosmeticImage;
     public bool bought;

     public CosmeticItem(string name,string ImageTxt, int price, bool bought)
     {
         this.name = name;
         this.price = price;
         this.bought = bought;
         this.imageTxt = ImageTxt;
         CosmeticImage = Resources.Load<Sprite>(ImageTxt);

     }

     public void buyCosmetic()
     {
         this.bought = true;
         PlayerStuff.Leaves -= this.price;
     }

     public void sellCosmetic()
     {
         this.bought = false;
         PlayerStuff.Leaves += this.price;
     }

     public bool isBought()
     {
         return this.bought;
     }
 }
public class CosmeticScript : MonoBehaviour
{
    private int firstCosRand;
    private int secondCosRand;
    private int thirdCosRand;
    private int fourthCosRand;
    private int fifthCosRand;
    private int sixthCosRand;
    private int finalUnboughtInd;
    public Canvas canvas;       // drag your Canvas in
    public List<Image> CosmeticImages; // the actual images in the scene
    //contains objects of the cosmetic item class where the image components in the art folder exist
    public List<CosmeticItem> CosmeticItems = new List<CosmeticItem>
    {
        new CosmeticItem("Jungle Hat","Art/ambulance.png", 20, false);
        new CosmeticItem("Winter Hat","Art/angry.png", 20, false);
        new CosmeticItem("Summer Hat","Art/bee.png", 20, false);
        new CosmeticItem("Sunglasses","Art/cat.png", 10, false);
        new CosmeticItem("Rainbow Hat","Art/circle.png", 20, false);
        new CosmeticItem("Rainbow Sunglasses","Art/cow.png", 15, false);
        new CosmeticItem("Top Hat","Art/cringe.png", 25, false);
        new CosmeticItem("Star Sunglasses","Art/cry.png", 15, false);
        new CosmeticItem("Heart Glasses","Art/dog.png", 15, false);
        new CosmeticItem("Astronaut Helmet","Art/hate.png", 25, false);
        new CosmeticItem("Cat In the Hat Hat","Art/hexagon.png", 30, false);
        new CosmeticItem("Sombrero","Art/horse.png", 30, false);
        new CosmeticItem("Zach Hat","Art/hospital.png", 5, false);
        new CosmeticItem("Naveed Hat","Art/octogon.png", 1, false);
        new CosmeticItem("Jerry Hat","Art/park.png", 5, false);
        new CosmeticItem("Ethan Hat","Art/pentagon.png", 5, false);
        new CosmeticItem("Jake Hat","Art/pizza.png", 5, false);
        new CosmeticItem("Aiden Hat","Art/smile.png", 5, false);
        new CosmeticItem("Andy Hat","Art/snake.png", 5, false);
        new CosmeticItem("Oscar Hat","Art/square.png", 5, false);
        new CosmeticItem("Party Hat","Art/suprised.png", 25, false);
        new CosmeticItem("Wizard Hat","Art/taco.png", 25, false);
        new CosmeticItem("Baseball Hat","Art/tree.png", 15, false);
        new CosmeticItem("Beanie","Art/Untitled design (1).png", 10, false);
        new CosmeticItem("Cowboy Hat","Art/Untitled design (2).png", 20, false);
        new CosmeticItem("Fruit Hat","Art/Untitled design (3).png", 18, false);
        new CosmeticItem("Golden Crown","Art/Untitled design.png", 2000, false);
    };

    public void SortList(int currentIndex)
    {
        CosmeticItem temp = CosmeticItems[currentIndex];
        CosmeticItems[currentIndex] = CosmeticItems[finalUnboughtInd];
        CosmeticItems[finalUnboughtInd] = temp;
        finalUnboughtInd--;
    }
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        var indexes = GetUniqueRandomIndexes(CosmeticItems.Count);
        firstCosRand = indexes[0];
        secondCosRand = indexes[1];
        thirdCosRand = indexes[2];
        fourthCosRand = indexes[3];
        fifthCosRand = indexes[4];
        sixthCosRand = indexes[5];
        finalUnboughtInd = CosmeticItems.Count;
    }

    void Update()
    {
        for (int i = 0; i < CosmeticItems.Count; i++)
        {
            if (CosmeticItems[i].isBought() == true)
            {
                SortList(i);
            }
        }
    }

    List<int> GetUniqueRandomIndexes(int count)
    {
        int amount = 6;
        var indexes = new List<int>();
        for (int i = 0; i < count; i++) indexes.Add(i);

        for (int i = finalUnboughtInd - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (indexes[i], indexes[j]) = (indexes[j], indexes[i]);
        }

        return indexes.GetRange(0, amount);
    }

}
