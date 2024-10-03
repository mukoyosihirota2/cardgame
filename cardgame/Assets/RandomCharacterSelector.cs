using UnityEngine;

public class RandomCharacterSelector : MonoBehaviour
{
    public CharacterDatabase characterDatabase;

    void Start()
    {
       
        CharacterData randomCharacter = characterDatabase.characterList[Random.Range(0, characterDatabase.characterList.Count)];

        if (randomCharacter != null)
        {
            Debug.Log($"Random Character: {randomCharacter.characterName}, HP: {randomCharacter.hp}, Cost: {randomCharacter.cost}");
        }
    }
}
