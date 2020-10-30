using TMPro;
using UnityEngine;

namespace D2D
{
    public class RobberyListLine : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI goalNameLabel;
        
        public void Render(RobberyGoal goal)
        {
            goalNameLabel.text = goal.GoalName;
            if (goal.IsCompleted)
                goalNameLabel.fontStyle = FontStyles.Strikethrough;
        }
    }
}