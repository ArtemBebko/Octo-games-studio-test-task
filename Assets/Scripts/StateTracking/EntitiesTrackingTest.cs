using UnityEngine;
using UnityEngine.InputSystem;


public class EntitiesTrackingTest : MonoBehaviour
{
    [Header("Special entities")]
    [SerializeField] private Entity _entityThatWillBeDestroyed;
    [SerializeField] private Entity _entityThatWillBeDisabled;
    //Також на сцені є Entity який є gameplayActive = false;


    private void ShowGameActiveEntities() // Метод для виведення активних в грі entities
    {
        var gameplayActiveEntities = EntitiesTracking.Instance.GetGameplayActiveEntities();
        Debug.Log($"Gameplay active entities count: {gameplayActiveEntities.Count}");

        foreach (Entity entity in gameplayActiveEntities)
        {
            Debug.Log($"Gameplay active entity: {entity.name}");
        }
    }
    private void TestTracking() //Цей метод створений для тестування відстежування активних в грі entities
    {
        if(Keyboard.current.dKey.wasPressedThisFrame)//D
        {
            Destroy(_entityThatWillBeDestroyed.gameObject);
            ShowGameActiveEntities();
        }
        else if (Keyboard.current.eKey.wasPressedThisFrame)//E
        {
            _entityThatWillBeDisabled.gameObject.SetActive(false);
            ShowGameActiveEntities();
        }
    }

    private void Start()//Початковий показ
    {
        ShowGameActiveEntities();
    }

    private void Update()
    {
        TestTracking();
    }
}