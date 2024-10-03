using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // �J�[�h�̃v���n�u
    public Transform gridParent; // Grid Layout Group��ݒ肵���e�I�u�W�F�N�g
    public Button sortByHPButton; // HP�ŕ��ёւ��邽�߂̃{�^��
    public Button sortByCostButton; // �R�X�g�ŕ��ёւ��邽�߂̃{�^��
    public Button resetButton; // ���̔z�u�ɖ߂����߂̃{�^��
    public DisplayRandomCharacterData displayRandomCharacterData;

    private List<GameObject> cards = new List<GameObject>();
    private List<GameObject> initialCardOrder = new List<GameObject>();

    void Start()
    {
        int totalCards = 16;
        int columns = 8;
        int rows = 2;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                int index = i * columns + j;
                if (index < totalCards)
                {
                    GameObject card = Instantiate(cardPrefab, gridParent);
                    cards.Add(card);
                }
            }
        }

        // �����z�u��ۑ�
        initialCardOrder.AddRange(cards);

        // �{�^���̃N���b�N�C�x���g�Ƀ��\�b�h��o�^
        if (sortByHPButton != null)
        {
            sortByHPButton.onClick.AddListener(SortCardsByHP);
        }

        if (sortByCostButton != null)
        {
            sortByCostButton.onClick.AddListener(SortCardsByCost);
        }

        if (resetButton != null)
        {
            resetButton.onClick.AddListener(ResetCardOrder);
        }
    }

    void SortCardsByHP()
    {
        List<(GameObject card, int hp)> cardWithHP = new List<(GameObject card, int hp)>();

        foreach (var card in cards)
        {
            var characterData = card.GetComponent<DisplayRandomCharacterData>().GetCurrentCharacter();
            if (characterData != null)
            {
                cardWithHP.Add((card, characterData.hp));
            }
        }

        cardWithHP.Sort((x, y) => y.hp.CompareTo(x.hp));

        for (int i = 0; i < cardWithHP.Count; i++)
        {
            cardWithHP[i].card.transform.SetSiblingIndex(i);
        }
    }

    void SortCardsByCost()
    {
        List<(GameObject card, int cost)> cardWithCost = new List<(GameObject card, int cost)>();

        foreach (var card in cards)
        {
            var characterData = card.GetComponent<DisplayRandomCharacterData>().GetCurrentCharacter();
            if (characterData != null)
            {
                cardWithCost.Add((card, characterData.cost));
            }
        }

        cardWithCost.Sort((x, y) => y.cost.CompareTo(x.cost));

        for (int i = 0; i < cardWithCost.Count; i++)
        {
            cardWithCost[i].card.transform.SetSiblingIndex(i);
        }
    }

    void ResetCardOrder()
    {
        for (int i = 0; i < initialCardOrder.Count; i++)
        {
            initialCardOrder[i].transform.SetSiblingIndex(i);
        }
    }
}
