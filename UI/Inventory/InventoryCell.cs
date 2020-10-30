using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace D2D
{
    public class InventoryCell : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI itemAmountLabel;
        [SerializeField] private Image itemIcon;

        public void Render(Item item)
        {
            if (itemAmountLabel != null)
                itemAmountLabel.text = item.ItemAmount + "";

            if (item.ItemIcon == null)
            {
                itemIcon.gameObject.SetActive(false);
                return;
            }
                
            itemIcon.gameObject.SetActive(true);
            itemIcon.sprite = item.ItemIcon;
        }
    }
}