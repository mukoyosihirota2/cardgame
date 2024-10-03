using UnityEngine;

public class Card : MonoBehaviour
{
    private CharacterData characterData;

    public void SetCharacterData(CharacterData data)
    {
        characterData = data;
        // カードに表示する内容を設定する
    }

    public CharacterData GetCharacterData()
    {
        return characterData;
    }
}
