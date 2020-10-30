using D2D.Database;
using UnityEngine;

namespace D2D
{
    /// <summary>
    /// Load data from db and defaults from PlayerData where defaults stored
    /// </summary>
    public static class PlayerModel
    {
        public static IntegerContainer MoneyContainer
        {
            get
            {
                if (PlayerDatabase.MoneyContainer.IsEmpty)
                {
                    // Returns some default from player data SO
                    PlayerDatabase.MoneyContainer.Value = 0;
                    Debug.Log("...w");
                }

                return PlayerDatabase.MoneyContainer;
            }
        }
    }
}