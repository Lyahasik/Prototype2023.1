using System;

using Prototype.Gameplay.ActiveArea;

namespace Prototype.Gameplay
{
    [Serializable]
    public class PooledObjectData
    {
        public PooledObjectType Type;
        public MovementInArea Prefab;
    }
}
