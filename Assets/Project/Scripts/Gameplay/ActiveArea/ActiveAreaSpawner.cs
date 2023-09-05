using UnityEngine;

using Prototype.Core;
using Prototype.Gameplay.Obstacles;

namespace Prototype.Gameplay.ActiveArea
{
    public class ActiveAreaSpawner : MonoBehaviour
    {
        [SerializeField] private float minDelaySpawn;
        [SerializeField] private float maxDelaySpawn;

        [Space]
        [SerializeField] private Transform obstaclesParent;

        private float _nextTimeSpawn;

        private void Update()
        {
            Spawn();
        }

        private void Spawn()
        {
            if (!ProcessingGame.Single.IsStarted
                || _nextTimeSpawn > Time.time)
                return;

            ObstacleSquare obstacle = GameplayPool.Single.GetObstacle();
            obstacle.transform.parent = obstaclesParent;
            obstacle.Activate(transform.position);

            _nextTimeSpawn = Time.time + Random.Range(minDelaySpawn, maxDelaySpawn);
        }
    }
}
