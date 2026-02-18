using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;


[RequireComponent(typeof(Text))]
public class CharactersView : MonoBehaviour
{
    [SerializeField] private List<Character> _characters;
    [SerializeField] private float _updateInterval; //Створив поле яке буде відповідати за інтрвал оновлення тексту
    private Text _text;
    private float _timer; //Поле яке використовується для відстеження часу, що минув з останнього оновлення тексту
    private int _currentCharactersCount; //Поточна кількість персонажів, які не null


    private void UpdateText(float charactersAverageValue) // Виніс логіку оновлення тексту в окремий метод,
                                                          // який приймає середнє значення персонажів як параметр
    {
        _text.text = $"Characters: {_currentCharactersCount} Avg value: {charactersAverageValue}";
    }

    private void Initialize() // Метод який відповідає за початкову ініціалізацію компонентів та полів класу
    {
        //Текст
        _text = GetComponent<Text>();
        UpdateText(CalculateCharactersAverageValue());

        //Таймер
        _timer = 0f;
    }

    private void Awake()
    {
        Initialize();
    }

    private float CalculateCharactersAverageValue()//Логіку обрахунку середнього значення персонажів виніс в окремий метод
                                                   //, який повертає це значення.
    {
        float totalValue = 0f;
        _currentCharactersCount = 0;

        for (int i = 0; i < _characters.Count; i++)
        {
            if(_characters[i] != null)
            {
                totalValue += _characters[i].Value;
                _currentCharactersCount++;//Тут збільшую лічильник поточної кількості персонажів
            }
        }

        return totalValue > 0 ? totalValue/ _currentCharactersCount : 0f; //Правильна формула для обрахунку середнього значення
    }

    private void Update()
    {
        _timer += Time.deltaTime;//Відлік
        if(_timer >= _updateInterval)
        {
            _timer = 0f;
            UpdateText(CalculateCharactersAverageValue());
        }
    }
}