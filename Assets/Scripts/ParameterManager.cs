using System;
using TMPro;
using UnityEngine;

public class ParameterManager : MonoBehaviour
{
    public float BasicParameterValue;

    public TMP_Text FaithText;
    public TMP_Text HumansText;
    public TMP_Text WarText;
    public TMP_Text MoneyText;
    
    private float _faithPrameter = 100;
    private float _humansPrameter = 100;
    private float _warParameter = 100;
    private float _moneyParameter = 100;
    
    
    private void Awake()
    {
        _faithPrameter = BasicParameterValue;
        _humansPrameter = BasicParameterValue;
        _warParameter = BasicParameterValue;
        _moneyParameter = BasicParameterValue;
    }


    public void UseCard(CardStats card)
    {
        _faithPrameter += card.FaithInfluence;
        _humansPrameter += card.HumanInfluence;
        _warParameter += card.WarInfluence;
        _moneyParameter += card.MoneyInfluence;
        
        CheckGameState();
    }

    public void DiscardCard(CardStats card)
    {
        _faithPrameter -= card.FaithInfluence;
        _humansPrameter -= card.HumanInfluence;
        _warParameter -= card.WarInfluence;
        _moneyParameter -= card.MoneyInfluence;
        
        CheckGameState();
    }

    private void CheckGameState()
    {
        if (_moneyParameter > 100)
        {
            _moneyParameter = 100;
        }
        if (_faithPrameter > 100)
        {
            _faithPrameter = 100;
        }
        if (_humansPrameter > 100)
        {
            _humansPrameter = 100;
        }
        if (_warParameter > 100)
        {
            _warParameter = 100;
        }


        UpdateUI();
        
        if (_faithPrameter <= 0)
        {
            Debug.Log("Game Over");
        }
        else if (_humansPrameter <= 0)
        {
            Debug.Log("Game Over");
        }
        else if (_warParameter <= 0)
        {
            Debug.Log("Game Over");
        }
        else if (_moneyParameter <= 0)
        {
            Debug.Log("Game Over");
        }
    }

    private void UpdateUI()
    {
        FaithText.text = _faithPrameter.ToString();
        HumansText.text = _humansPrameter.ToString();
        WarText.text = _warParameter.ToString();
        MoneyText.text = _moneyParameter.ToString();
    }
}
