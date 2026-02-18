using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections.Generic;


public class Popup : MonoBehaviour
{
    //Компоненти попапу
    [SerializeField] private List<Button> _buttons;
    [SerializeField] private Text _title;
    [SerializeField] private Text _bodyText;
    private Text[] _buttonTexts; //Створив масив для зручності доступу до текстів кнопок,
    // оскільки викликати кожен раз GetComponentInChildren<Text>() є дорого 


    private void Hide() //Метод для приховування попапу
    {
        gameObject.SetActive(false);
    }

    private void Initialize()//Метод для ініціалізації комопнентів класу
    {
        _buttonTexts = _buttons.ConvertAll(button => button.GetComponentInChildren<Text>()).ToArray();
    }

    private void Awake()
    {
        Initialize();
        Hide();
    }

    //Метод для налаштування кнопки
    private void SetupButton(Button button, Text buttonText, string text, UnityAction callbackFunction)
    {
        button.gameObject.SetActive(true);
        button.onClick.RemoveAllListeners();
        buttonText.text = text;
        button.onClick.AddListener(()=> {
            callbackFunction.Invoke();
            Hide(); // Вирішив додати призовування попапу при натиску на кнопку,
            //Бо не можу знати яка кнопка буде CloseButton , проте це можна легко змінити
        });
    }

    //Метод для вимкнення всіх кнопок
    private void OffButtons()
    {
        _buttons.ForEach(button => button.gameObject.SetActive(false));
    }

    //Метод показу попапу
    private void Show()
    {
        gameObject.SetActive(true);
    }

    //Метод для налаштування попапу
    public void Setup(string title, string bodyText, List<string> buttonTexts, List<UnityAction> callbackFunctions)
    {
        Show();

        //Тексти
        _title.text = title;
        _bodyText.text = bodyText;

        //Кнопки
        OffButtons();
        for(int i = 0; i < buttonTexts.Count; i++)
        {
            SetupButton(_buttons[i], _buttonTexts[i], buttonTexts[i], callbackFunctions[i]);
        }
    }

    //Відписування кнопок
    private void UnsubscribeButtons()
    {
        _buttons.ForEach(button => button.onClick.RemoveAllListeners());
    }

    private void OnDestroy()
    {
        UnsubscribeButtons();
    }
}