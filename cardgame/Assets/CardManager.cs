using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardManager : MonoBehaviour
{
    public GameObject cardPrefab; // カードのプレハブ
    public Transform gridParent; // Grid Layout Groupを設定した親オブジェクト
    public Button sortByHPButton; // HPで並び替えるためのボタン
    public Button sortByCostButton; // コストで並び替えるためのボタン
    public Button resetButton; // 元の配置に戻すためのボタン
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

        // 初期配置を保存
        initialCardOrder.AddRange(cards);

        // ボタンのクリックイベントにメソッドを登録
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
