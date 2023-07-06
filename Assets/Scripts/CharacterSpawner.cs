using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesignSim
{
    public class CharacterSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject[] characterPrefabs;
        private bool _haveCharactersSpawned = false;

        public void SpawnCharacters()
        {
            if (!_haveCharactersSpawned)
            {
                foreach (var character in characterPrefabs)
                {
                    Instantiate(character);
                }
                _haveCharactersSpawned = true;
            }
        }
    }
}
