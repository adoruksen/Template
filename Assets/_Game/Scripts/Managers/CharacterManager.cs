using System;
using System.Collections;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using CharacterController = Character.CharacterController;

namespace Managers
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager instance;

        public static event Action OnCharacterSpawned;

        [SerializeField] private CharacterController _playerCharacter;
        [SerializeField] private CharacterController _aiCharacter;

        private List<CharacterController> _characters = new List<CharacterController>();

        [ReadOnly] public CharacterController Player;

        private void Awake()
        {
            instance = this;
        }

        private void OnEnable()
        {
            AncientGameManager.OnLevelStart += StartCharacters;
        }

        private void OnDisable()
        {
            AncientGameManager.OnLevelStart -= StartCharacters;
        }

        public IReadOnlyList<CharacterController> GetCharacters() => _characters;

        public void SpawnCharacters(Vector3 playerPosition, Vector3 aiPosition)
        {
            SpawnPlayer(playerPosition);
            //SpawnAi(aiPosition);
            OnCharacterSpawned?.Invoke();
        }

        private void SpawnPlayer(Vector3 position)
        {
            Player = Instantiate(_playerCharacter, position, Quaternion.identity);
            _characters.Add(Player);
        }

        private void SpawnAi(Vector3 position)
        {
            var ai = Instantiate(_aiCharacter, position, Quaternion.identity);
            _characters.Add(ai);
        }

        private void StartCharacters()
        {
            foreach (var characterController in _characters)
            {
                if (characterController.GameState == null) continue;
                characterController.SetState(characterController.StackState);
            }
        }

        public void DestroyCharacter()
        {
            while(_characters.Count > 0)
            {
                var character = _characters[0];
                _characters.RemoveAt(0);
                Destroy(character.gameObject);
            }
        }
    }
}

