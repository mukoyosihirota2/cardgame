using UnityEngine;
using UnityEngine.UI;

public class DisplayRandomCharacterData : MonoBehaviour
{
    public CharacterDatabase characterDatabase;
    public Text hpText;
    public Text costText;
    public Text cardNumberText; 

    private CharacterData currentCharacter;
    

    void Start()
    {
        DisplayRandomCharacter();
    }

    public void DisplayRandomCharacter()
    {
      
        currentCharacter = characterDatabase.characterList[Random.Range(0, characterDatabase.characterList.Count)];

        if (currentCharacter != null)
        {
         
            hpText.text = "HP: " + currentCharacter.hp.ToString();
            costText.text = "Cost: " + currentCharacter.cost.ToString();

       
           
        }
    }

    public CharacterData GetCurrentCharacter()
    {
        return currentCharacter;
    }

   
    
}
