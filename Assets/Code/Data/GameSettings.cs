using UnityEngine;

namespace TestAssingment.Data
{
    [CreateAssetMenu(menuName = "Data/GameSettings", fileName = "GameSettings")]
    public class GameSettings: ScriptableObject
    {
        [Tooltip("Set distance of mixing elements between 0.3...0.5 units")]
        [SerializeField] private float _distanceThreshold;
        [Tooltip("Set win score")]
        [SerializeField] private int _winScore;

        public float DistanceThreshold => _distanceThreshold;
        public int WinScore => _winScore;
    }
}