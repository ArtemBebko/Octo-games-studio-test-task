using UnityEngine;
using System.Collections.Generic;


public class EntitiesTracking : MonoBehaviour
{
    private readonly List<Entity> _entities = new List<Entity>(0);
    private readonly List<Entity> _activeInGameplayEntities = new List<Entity>(0);

    private static EntitiesTracking _instance = null;
    public static EntitiesTracking Instance => _instance;


    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddEntity(Entity entity)
    {
        _entities.Add(entity);
    }

    public void RemoveEntity(Entity entity)
    {
        _entities.Remove(entity);
    }

    public IReadOnlyList<Entity> GetGameplayActiveEntities()
    {
        _activeInGameplayEntities.Clear();

        foreach (var entity in _entities)
        {
            if (entity.IsActiveInGameplay)
                _activeInGameplayEntities.Add(entity);
        }

        return _activeInGameplayEntities;
    }
}