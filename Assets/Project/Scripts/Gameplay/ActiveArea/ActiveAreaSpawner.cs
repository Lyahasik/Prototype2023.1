using UnityEngine;
using Random = UnityEngine.Random;

using Prototype.Core;

namespace Prototype.Gameplay.ActiveArea
{
    public class ActiveAreaSpawner : MonoBehaviour
    {
        [SerializeField] private float minDelaySpawn;
        [SerializeField] private float maxDelaySpawn;

        [Space]
        [SerializeField] private Transform coinsParent;
        [SerializeField] private int weightCoinProbability;
        [SerializeField] private Transform obstaclesParent;
        [SerializeField] private int weightObstacleProbability;
        [SerializeField] private float minShiftY;
        [SerializeField] private float maxShiftY;

        private int _totalWeightProbability;
        private float _nextTimeSpawn;

        private void Awake()
        {
            _totalWeightProbability = weightCoinProbability + weightObstacleProbability;
        }

        private void Update()
        {
            Spawn();
        }

        private void Spawn()
        {
            if (!ProcessingGame.Single.IsStarted
                || _nextTimeSpawn > Time.time)
                return;

            int probability = Random.Range(0, _totalWeightProbability + 1);
            if (probability <= weightObstacleProbability)
                AddObstacle();
            else
                AddCoin();

            _nextTimeSpawn = Time.time + Random.Range(minDelaySpawn, maxDelaySpawn);
        }

        private void AddObstacle()
        {
            MovementInArea obstacle = GameplayPool.Single.GetObject(PooledObjectType.Obstacle);
            obstacle.transform.parent = obstaclesParent;

            Vector3 newPosition = transform.position;
            newPosition.y += Random.Range(minShiftY, maxShiftY);
            
            obstacle.Activate(newPosition);
        }

        private void AddCoin()
        {
            MovementInArea coin = GameplayPool.Single.GetObject(PooledObjectType.Coin);
            coin.transform.parent = coinsParent;

            Vector3 newPosition = transform.position;
            newPosition.y += Random.Range(minShiftY, maxShiftY);
            
            coin.Activate(newPosition);
        }
    }
}
