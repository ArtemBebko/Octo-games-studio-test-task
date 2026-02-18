using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;


//Тестовий клас для показу як працює попап
public class PopupSystem : MonoBehaviour
{
    [SerializeField] private Popup _popup;


    //Методи для передачі в попап
    private void SendMessage1()
    {
        Debug.Log("Button1 clicked");
    }

    private void SendMessage2()
    {
        Debug.Log("Button2 clicked");
    }

    private void SendMessage3()
    {
        Debug.Log("Button3 clicked");
    }

    //Метод для налаштування попапу в залежності від натиснутої клавіші
    private void SetPopup()
    {
        if (Keyboard.current.aKey.wasPressedThisFrame)//А
        {
            _popup.Setup(
                "PopUp1", 
                "Sending message popup1",
                new List<string>(2){ "send message 1","send message 2"},
                new List<UnityAction>(2) { SendMessage1,SendMessage2});
        }
        else if (Keyboard.current.bKey.wasPressedThisFrame)// B
        {
            _popup.Setup(
                "PopUp2",
                "",
                new List<string>(1) {"send message 3" },
                new List<UnityAction>(1) {SendMessage3});
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)//C
        {
            _popup.Setup(
                "Popup 3",
                "Popup 3",
                new List<string>(3) { "send message 1", "send message 2", "send message 3" },
                new List<UnityAction>(3) { SendMessage1, SendMessage2, SendMessage3});
        }
    }

    private void Update()
    {
        SetPopup();
    }
}