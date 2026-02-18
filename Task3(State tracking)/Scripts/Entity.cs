using UnityEngine;


public class Entity : MonoBehaviour
{
    [SerializeField] private bool _isActiveInGameplay; //Створив прапорець для відстеження активного entity в грі
    public bool IsActiveInGameplay => _isActiveInGameplay;


    private void OnDisable()
    {
        EntitiesTracking.Instance.RemoveEntity(this);
    }

    private void OnEnable()
    {
        EntitiesTracking.Instance.AddEntity(this);
    }
}