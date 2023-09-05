using UnityEngine;

using Prototype.Core;

namespace Prototype.Gameplay.ActiveArea
{
    public class ActiveAreaSpawner : MonoBehaviour
    {
        [SerializeField] private float minDelaySpawn;
        [SerializeField] private float maxDelaySpawn;

        [Space]
        [SerializeField] private Transform obstaclesParent;
        [SerializeField] private float minShiftY;
        [SerializeField] private float maxShiftY;

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

            MovementInArea obstacle = GameplayPool.Single.GetObstacle();
            obstacle.transform.parent = obstaclesParent;

            Vector3 newPosition = transform.position;
            newPosition.y += Random.Range(minShiftY, maxShiftY);
            
            obstacle.Activate(newPosition);

            _nextTimeSpawn = Time.time + Random.Range(minDelaySpawn, maxDelaySpawn);
        }
    }
}
