using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class proximitySpawn : MonoBehaviour
{

    private spawnDataManager _sp;
    public GameObject spawnObject;
    private bool _isInstanciated = false;
    private GameObject spawn;

    private void Start()
    {
        //Look for data manager in the scene
        _sp = FindObjectOfType<spawnDataManager>();

        if (!_sp)
        {
            Debug.Log("I dont have a data manager!");
        }

        //audioSource = GetComponent<AudioSource>();

    }

    private void FixedUpdate()
    {

        //variables for raycasting
        RaycastHit hit;
        LayerMask spawnLayer = LayerMask.GetMask("Spawn");

        //check if ray is touching something in the spawn layer
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, spawnLayer))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            //turn the location of the hit into a x, y and z location in integers (make sure your spawn objects are located in round numbers)
            Vector3Int hitLocation = new Vector3Int(
                Mathf.RoundToInt(hit.collider.transform.position.x),
                Mathf.RoundToInt(hit.collider.transform.position.y),
                Mathf.RoundToInt(hit.collider.transform.position.z));

            Debug.Log(hit.collider.gameObject.name + " is in " + hitLocation);

            //Check if what we hit is in the Dictionary
            if ( _sp.positionsAndSounds.ContainsKey(hitLocation) && !_isInstanciated)
            {
                Debug.Log("this is one the list");

                spawn = Instantiate(spawnObject, hit.point, transform.rotation);

                //spawn.GetComponent<AudioSource>().PlayOneShot(_sp.positionsAndSounds[hitLocation]);

                //_isInstanciated = true;
            }
            
        }
        //else
        //{
        //    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
        //    Debug.Log("Did not Hit");
        //}

    }

}
