using UnityEngine;

public class Card : MonoBehaviour
{
    private CharacterData characterData;

    public void SetCharacterData(CharacterData data)
    {
        characterData = data;
        // �J�[�h�ɕ\��������e��ݒ肷��
    }

    public CharacterData GetCharacterData()
    {
        return characterData;
    }
}
