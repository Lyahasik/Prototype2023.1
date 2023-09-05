using System.Collections.Generic;
using UnityEngine;

using Prototype.Gameplay.ActiveArea;

namespace Prototype.Gameplay
{
    public class GameplayPool : MonoBehaviour
    {
        [SerializeField] private MovementInArea prefabObstacle;
        
        private readonly Stack<MovementInArea> obstacles = new ();

        public static GameplayPool Single;

        private void Awake()
        {
            Single = this;
        }

        public MovementInArea GetObstacle()
        {
            if (obstacles.Count == 0)
                return Instantiate(prefabObstacle);
            
            return obstacles.Pop();
        }

        public void ReturnObstacle(MovementInArea obstacle)
        {
            obstacle.transform.parent = transform;
            obstacle.Reset();
            
            obstacles.Push(obstacle);
        }
    }
}
