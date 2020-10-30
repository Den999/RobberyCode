using D2D.Utils;
using UnityEngine;

namespace Robbery
{
    [CreateAssetMenu(fileName = "GameData", menuName = "SO/GameData", order = 0)]
    public class GameData : SingletonData<GameData>
    {
        [Header("UI")]
        public GameObject robberyListLinePrefab;
        public GameObject inventoryCellPrefab;
    }
}