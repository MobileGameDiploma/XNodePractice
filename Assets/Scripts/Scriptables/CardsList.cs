using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(menuName = "Scriptable/Stats/CardList", fileName = "New Card List")]
public class CardsList : ScriptableObject
{
    [FormerlySerializedAs("cards")] public List<CardStats> Cards;
}
