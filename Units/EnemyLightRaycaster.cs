using System;
using UnityEngine;

namespace D2D
{
    public class EnemyLightRaycaster : MonoBehaviour
    {
        [SerializeField] private Light _light;
        [SerializeField] private float _rayLength = 10;

        public bool PlayerIsOtherLight { get; private set; }

        private void Update()
        {
            CheckPlayerUnderLight();
        }

        private void CheckPlayerUnderLight()
        {
            PlayerIsOtherLight = false;
            
            if (_light == null)
                return;

            var p1 = _light.transform.position;
            var p2 = _light.transform.forward;
            if (Physics.Raycast(p1, p2, out RaycastHit hit, _rayLength))
            {
                if (hit.collider.TryGetComponent(out Player player))
                {
                    PlayerIsOtherLight = true;
                }
            }
        }
    }
}