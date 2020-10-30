using System;
using D2D.Core;
using D2D.Utils;
using UnityEngine;

namespace D2D
{
    public class WorryHub : MonoBehaviour, ILazyCreating
    {
        [Header("General")]
        [SerializeField] private float _worryCapacity;
        [SerializeField] private float _worryCoolDown;
        
        [Header("Enemy distance")]
        [SerializeField] private float _worryDistanceToEnemyFactor;
        [SerializeField] private float _minIgnoreDistanceToEnemy;

        [Header("Other worries")] 
        [SerializeField] private float _worryAddOnPlayerUnderLight;
        [SerializeField] private float _worryAddOnLockboxOpen;
        [SerializeField] private float _worryAddOnDoorOpen;
        
        public event Action WorryOverhead; 
        
        /// <summary>
        /// From 0 to 1
        /// </summary>
        public float WorryFactor => Worry / _worryCapacity;

        private float Worry
        {
            get => _worry;
            set
            {
                _worry = value;
                
                if (_worry > _worryCapacity)
                {
                    _worry = _worryCapacity;
                    WorryOverhead?.Invoke();
                    enabled = false;
                }

                if (_worry <= 0)
                    _worry = 0;
            }
        }
        
        private Player _player;
        private EnemyLightRaycaster[] _enemies;
        private LockBox[] _lockBoxes;
        private Door[] _doors;
        
        private float _worry;

        private void OnEnable()
        {
            _player = FindObjectOfType<Player>();
            _enemies = FindObjectsOfType<EnemyLightRaycaster>();
            
            _lockBoxes = FindObjectsOfType<LockBox>();
            foreach (LockBox lockBox in _lockBoxes)
            {
                lockBox.Opened += AddOpenLockboxWorry;
            }

            _doors = FindObjectsOfType<Door>();
            foreach (Door door in _doors)
            {
                door.Opened += AddOpenDoorWorry;
            }
        }

        private void OnDisable()
        {
            foreach (LockBox lockBox in _lockBoxes)
            {
                lockBox.Opened -= AddOpenLockboxWorry;
            }
            
            foreach (Door door in _doors)
            {
                door.Opened -= AddOpenDoorWorry;
            }
        }
        
        private void AddOpenDoorWorry()
        {
            Worry += _worryAddOnDoorOpen;
        }

        private void AddOpenLockboxWorry()
        {
            Worry += _worryAddOnLockboxOpen;
        }

        private void Update()
        {
            CheckEnemiesWorry();
            CoolDownWorry();
        }

        private void CheckEnemiesWorry()
        {
            // Find closest dist to enemy
            float closestDistToEnemy = float.MaxValue;
            foreach (EnemyLightRaycaster enemy in _enemies)
            {
                if (enemy.PlayerIsOtherLight)
                    Worry += _worryAddOnPlayerUnderLight;
                
                var delta = _player.transform.position - enemy.transform.position;
                var dist = delta.magnitude;
                if (dist < closestDistToEnemy)
                    closestDistToEnemy = dist;
            }

            if (closestDistToEnemy <= _minIgnoreDistanceToEnemy)
                Worry += closestDistToEnemy * _worryDistanceToEnemyFactor;
        }

        private void CoolDownWorry()
        {
            Worry -= _worryCoolDown;
        }
    }
}