using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterDatabase", menuName = "ScriptableObjects/CharacterDatabase", order = 2)]
public class CharacterDatabase : ScriptableObject
{
    public List<CharacterData> characterList;
}
