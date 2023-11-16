using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnDataManager : MonoBehaviour
{

    public Vector3Int spawnOne;
    public AudioClip spawnSound;

    //public List<Vector3> SpawnPositions;
    public Dictionary<Vector3Int, AudioClip> positionsAndSounds;
    public Dictionary<Vector3Int, bool> positionsAndBools;

    private void Start()
    {
        //We are manually feeding the data here, but will eventualy get it from a file
        //spawnOne = new Vector3Int(9, 1, -1);
        //spawnSound = GetComponent<AudioClip>();

        //Create Dictionary for positions and sounds
        positionsAndSounds = new Dictionary<Vector3Int, AudioClip>();
        positionsAndSounds.Add(spawnOne, spawnSound);

        //Create Dictionary for positions and bools
        positionsAndBools = new Dictionary<Vector3Int, bool>();
        positionsAndBools.Add(spawnOne, false);

       Debug.Log(positionsAndSounds.Keys);
    }


}
