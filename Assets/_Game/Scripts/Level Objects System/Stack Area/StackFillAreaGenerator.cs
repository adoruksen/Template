using System;
using System.Collections.Generic;
using Managers;
using Vehicle;
using Character;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;


namespace LevelObjectsSystem
{
    [Serializable]
    public class StackFillAreaGenerator
    {
        [SerializeField] private Transform _rail;
        [SerializeField] private Transform _wall;
        [SerializeField] private StackFillArea _fillArea;
        [SerializeField] private FillObject[] _fillObjects;
        [SerializeField] private float _fillObjectScale;
        [SerializeField] private float _fillAreaWidth;

        [SerializeField] private int _rowStackAmount;

        public List<StackFillArea> Generate(Transform parent, VehicleData[] vehicles)
        {
            var areas = new List<StackFillArea>();
            for (int i = 0; i < vehicles.Length; i++)
            {
                var xOffset = (-((vehicles.Length - 1) / 2f) + i) * _fillAreaWidth;
                var offset = Vector3.left * xOffset;
                var fillArea = Generate(parent, offset, vehicles[i]);
                areas.Add(fillArea);
            }
            GenerateWalls(parent, vehicles.Length);
            return areas;
        }

        public StackFillArea Generate(Transform parent, Vector3 position, VehicleData vehicleData)
        {
            var fillArea = Object.Instantiate(_fillArea, parent);
            fillArea.transform.localPosition = position;
            var vehiclePosition = fillArea.transform.position + Vector3.forward * 14;
            var vehicle = Object.Instantiate(vehicleData.Vehicle, vehiclePosition, Quaternion.identity, GameManager.instance.defaultParent);
            var fillVisual = fillArea.GetComponent<StackFillAreaVisualController>();
            var fillTrigger = fillArea.GetComponent<CharacterDriveStateTrigger>();

            var rows = vehicleData.Cost / _rowStackAmount;
            var offset = Vector3.left * (.5f * (rows - 1));

            fillArea.transform.Find("StackSign").localScale = new Vector3(rows / 2f, 1f, 1f);
            GenerateFillArea(fillArea, offset, rows, vehicleData.Cost);
            GenerateFillObjects(fillVisual, offset, rows);
            GenerateFillTrigger(fillTrigger, vehicle);
            return fillArea;
        }

        private void GenerateFillArea(StackFillArea fillArea, Vector3 position, int rows, int size)
        {
            fillArea.SetSize(size);

            var parent = fillArea.transform.Find("Rails");
            for (var i = 0; i < rows; i++)
            {
                var rail = Object.Instantiate(_rail, parent);
                rail.localPosition = position + Vector3.right * i;
            }

            var wallScale = (8 - rows) / 2f;
            var wallPosition = Vector3.right * (wallScale / 2f + rows / 2f);
            SpawnWall(fillArea.transform, wallPosition, wallScale);
            wallPosition = Vector3.left * (wallScale / 2f + rows / 2f);
            SpawnWall(fillArea.transform, wallPosition, wallScale);
        }

        private void GenerateFillObjects(StackFillAreaVisualController fillVisual, Vector3 position, int rows)
        {
            var fillObjects = new List<FillObject>();
            var parent = fillVisual.transform.Find("FillObjects");
            for (var z = 0; z < _rowStackAmount; z++)
            {
                for (var x = 0; x < rows; x++)
                {
                    var fillObject = Object.Instantiate(_fillObjects[Random.Range(0,_fillObjects.Length)], parent);
                    fillObject.transform.localPosition = position + new Vector3(x, 0, (z + .5f) * _fillObjectScale);
                    fillObject.transform.localScale = Vector3.zero;
                    fillObjects.Add(fillObject);
                }
            }

            fillVisual.SetFillObjects(fillObjects.ToArray());
        }

        private void GenerateFillTrigger(CharacterDriveStateTrigger fillTrigger, VehicleController vehicle)
        {
            fillTrigger.SetVehicle(vehicle);
        }

        private void GenerateWalls(Transform parent, int areaCount)
        {
            if (areaCount >= 3) return;

            var size = (24 - (areaCount * _fillAreaWidth)) / 2;
            var position = 12 - size / 2;
            SpawnWall(parent, Vector3.left * position, size);
            SpawnWall(parent, Vector3.right * position, size);
        }

        private void SpawnWall(Transform parent, Vector3 wallPosition, float wallScale)
        {
            var wall = Object.Instantiate(_wall, parent);
            wall.localPosition = wallPosition;
            wall.localScale = new Vector3(wallScale, 1f, 1f);
        }
    }
}


