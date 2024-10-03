using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TestDrag : MonoBehaviour, IDragHandler, IDropHandler, IBeginDragHandler, IEndDragHandler
{
    private DisplayRandomCharacterData displayRandomCharacterData;
    private Dictionary<GameObject, GameObject> deck = new Dictionary<GameObject, GameObject>();
    private GameObject currentSet;
    private DeckCostDisplay deckCostDisplay;

    void Start()
    {
        displayRandomCharacterData = GetComponent<DisplayRandomCharacterData>();
        deckCostDisplay = FindObjectOfType<DeckCostDisplay>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        currentSet = null;
        foreach (var pair in deck)
        {
            if (pair.Value == gameObject)
            {
                currentSet = pair.Key;
                break;
            }
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (currentSet != null && !RectTransformUtility.RectangleContainsScreenPoint(currentSet.GetComponent<RectTransform>(), eventData.position))
        {
            deck.Remove(currentSet);
            deckCostDisplay.RemoveFromDeck(currentSet); 
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        var results = new List<RaycastResult>();
        EventSystem.current.RaycastAll(eventData, results);
        foreach (var hit in results)
        {
            if (hit.gameObject.tag == "Set")
            {
                if (deck.ContainsKey(hit.gameObject) && deck[hit.gameObject] != gameObject)
                {
                    Debug.Log("このセットには既に別のキャラクターが配置されています");
                    return;
                }

                transform.position = hit.gameObject.transform.position;

                var character = displayRandomCharacterData.GetCurrentCharacter();
                if (character != null)
                {
                    if (currentSet != null)
                    {
                        deck.Remove(currentSet);
                        deckCostDisplay.RemoveFromDeck(currentSet);
                    }

                    deck[hit.gameObject] = gameObject;
                    currentSet = hit.gameObject;
                    deckCostDisplay.AddToDeck(hit.gameObject, character); 
                }
                break;
            }
        }
    }
}
