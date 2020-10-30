using UnityEngine;

namespace D2D
{
    public class Money : Item
    {
        protected override void OnPick()
        {
            PlayerModel.MoneyContainer.Value += ItemAmount;
            Destroy(gameObject);
        }
    }
}