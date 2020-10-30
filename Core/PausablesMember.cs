using D2D.Utils;
using UnityEngine;

namespace D2D.Core
{
    public class PausablesMember : MonoBehaviour
    {
        private void Awake()
        {
            var hub = gameObject.FindOrCreate<PausablesHub>();
            hub.AddPausable(this);
        }
    }
}
