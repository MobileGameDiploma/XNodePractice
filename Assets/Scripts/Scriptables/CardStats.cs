using UnityEngine;

[CreateAssetMenu(menuName = "Scriptable/Stats/Card Stats", fileName = "New Card Stats")]
public class CardStats : ScriptableObject
{
    public GameObject cardPrefab;

    public float FaithInfluence;
    public float HumanInfluence;
    public float WarInfluence;
    public float MoneyInfluence;
}
