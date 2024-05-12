using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SpawnController : MonoBehaviour
{
    public GameObject[] area_1 = new GameObject[6];
    public GameObject[] area_2 = new GameObject[5];
    public GameObject[] area_3 = new GameObject[6];
    public GameObject[] area_4 = new GameObject[5];

    public GameObject[] checkPoints = new GameObject[2];

    bool objectToInstantiate;
    public GameObject isSwapned = null;
    public enum ArrayType
    {
        Array_1,
        Array_2,
        Array_3,
        Array_4,
    }

    private Dictionary<ArrayType, GameObject[]> keyValuePairs;
    void Start()
    {
        keyValuePairs = new Dictionary<ArrayType, GameObject[]>()
        {
            { ArrayType.Array_1, area_1 },
            { ArrayType.Array_2, area_2 },
            { ArrayType.Array_3, area_3 },
            { ArrayType.Array_4, area_4 },
        };
    }

    // Update is called once per frame
    void Update()
    {
        if(isSwapned == null)
        {
            SpawnObjects();
        }
    }

    void SpawnObjects()
    {
        Debug.Log("Hi");
        // getting a random enum value
        ArrayType arrayType = (ArrayType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ArrayType)).Length);

        // getting the area associate to that enum
        GameObject[] _randomArea = keyValuePairs[arrayType];

        // getting a random value
        int randomIndex = UnityEngine.Random.Range(0, _randomArea.Length);

        // getting the gameobject at the randomIndex
        GameObject _spawnObject = _randomArea[randomIndex];
        isSwapned = _spawnObject;

        // checkpoint to instantiate
        GameObject checkpointToInstantiate = checkPoints[InstantiateNumber(objectToInstantiate)];
        //Instantiating the game Object
        Instantiate(checkpointToInstantiate, _spawnObject.transform.position, Quaternion.identity);
    }

    public int InstantiateNumber(bool hasPizzaToBeInstantiated)
    {
        objectToInstantiate = hasPizzaToBeInstantiated;

        if (hasPizzaToBeInstantiated)
        {
            return 0;
        }
        else
        {
            return 1;
        }

    }

    // Pick a random enum value
    // ArrayType randomArrayType = (ArrayType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(ArrayType)).Length);

    // Get the array associated with the randomly selected enum value
    //int[] randomArray = arrayDictionary[randomArrayType];

    // Getting a random index within the array
    //int randomIndex = UnityEngine.Random.Range(0, _randomArea.Length);

    // Getting the GameObject at the random index
   // GameObject _spawnObject = _randomArea[randomIndex];

    // Spawn the selected GameObject
    //Instantiate(_spawnObject, transform.position, Quaternion.identity);

}
