using System.Collections.Generic;
using UnityEngine;

using Prototype.Gameplay.ActiveArea;

namespace Prototype.Gameplay
{
    public class GameplayPool : MonoBehaviour
    {
        [SerializeField] private List<PooledObjectData> prefabsObject;
        
        private readonly Dictionary<PooledObjectType, Stack<MovementInArea>> pooledObjects = new ();

        public static GameplayPool Single;

        private void Awake()
        {
            Single = this;
        }

        public MovementInArea GetObject(PooledObjectType type)
        {
            if (!pooledObjects.ContainsKey(type))
                pooledObjects.Add(type, new Stack<MovementInArea>());
            
            if (pooledObjects[type].Count == 0)
                return Instantiate(prefabsObject.Find(obj => obj.Type == type).Prefab);
            
            return pooledObjects[type].Pop();
        }

        public void ReturnObstacle(PooledObjectType type, MovementInArea obstacle)
        {
            obstacle.transform.parent = transform;
            obstacle.Reset();
            
            pooledObjects[type].Push(obstacle);
        }
    }
}
