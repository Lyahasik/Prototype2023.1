using UnityEngine;
using Random = UnityEngine.Random;

namespace Prototype.Gameplay.Obstacles
{
    [RequireComponent(typeof(Animator))]
    public class ObstacleMovement : MonoBehaviour
    {
        private const float clipDuration = 1f;
        
        private readonly int clipNameHash;

        private void Awake()
        {
            Animator.StringToHash("SquareMove");
        }

        private void Start()
        {
            float shiftStart = Random.Range(0f, clipDuration);
            GetComponent<Animator>().Play("SquareMove", 0, shiftStart);
        }
    }
}
