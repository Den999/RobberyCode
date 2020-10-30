using D2D.UI;
using UnityEngine;

namespace D2D
{
    public class CloseWindowOnClick : ButtonListener
    {
        [SerializeField] private Window _parentWindow;
        
        protected override void OnClick()
        {
            _parentWindow.Close();
        }
    }
}