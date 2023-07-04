using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LevelDesignSim
{
    [CreateAssetMenu]
    public class PlaceablesDatabaseSO : ScriptableObject
    {
        public List<PlaceablesData> placeablesData;
    }

    [Serializable]
    public class PlaceablesData
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int ID { get; private set; }
        [field: SerializeField] public Vector2Int Size { get; private set; } = Vector2Int.one;
        [field: SerializeField] public GameObject Prefab { get; private set; }

    }
}
