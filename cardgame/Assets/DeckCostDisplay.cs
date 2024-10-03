using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeckCostDisplay : MonoBehaviour
{
    public Text costText; 
    private Dictionary<GameObject, CharacterData> deck = new Dictionary<GameObject, CharacterData>();
    private int maxCost = 10; // コスト上限

    
    public void AddToDeck(GameObject setObject, CharacterData characterData)
    {
        deck[setObject] = characterData;
        UpdateCostDisplay();
    }

  
    public void RemoveFromDeck(GameObject setObject)
    {
        if (deck.ContainsKey(setObject))
        {
            deck.Remove(setObject);
            UpdateCostDisplay();
        }
    }

  
    private void UpdateCostDisplay()
    {
        int totalCost = 0;

        foreach (var characterData in deck.Values)
        {
            totalCost += characterData.cost;
        }

       
        if (totalCost > maxCost)
        {
            costText.text = "コスト上限です: " + totalCost.ToString();
            costText.color = Color.red; // テキストの色を赤くする
        }
        else
        {
            costText.text = "Total Cost: " + totalCost.ToString();
            costText.color = Color.black; 
        }
    }
}
