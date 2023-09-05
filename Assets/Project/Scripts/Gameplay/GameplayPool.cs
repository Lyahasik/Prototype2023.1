using System.Collections.Generic;
using UnityEngine;

using Prototype.Gameplay.Obstacles;

namespace Prototype.Gameplay
{
    public class GameplayPool : MonoBehaviour
    {
        [SerializeField] private ObstacleSquare prefabObstacle;
        
        private readonly Stack<ObstacleSquare> obstacles = new ();

        public static GameplayPool Single;

        private void Awake()
        {
            Single = this;
        }

        public ObstacleSquare GetObstacle()
        {
            if (obstacles.Count == 0)
                return Instantiate(prefabObstacle);

            return obstacles.Pop();
        }

        public void ReturnObstacle(ObstacleSquare obstacle)
        {
            obstacle.transform.parent = transform;
            obstacle.Reset();
            
            obstacles.Push(obstacle);
        }
    }
}
