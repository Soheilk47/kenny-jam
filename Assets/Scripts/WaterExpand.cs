using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterExpand : MonoBehaviour
{
    public GameObject water;
    public GameObject player;

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            int xint = Mathf.RoundToInt(transform.position.x);
            int zint = Mathf.RoundToInt(transform.position.z);

            Instantiate(water, new Vector3(xint + 1000, 0, zint + 1000), Quaternion.identity);
            Instantiate(water, new Vector3(xint - 1000, 0, zint + 1000), Quaternion.identity);
            Instantiate(water, new Vector3(xint + 1000, 0, zint - 1000), Quaternion.identity);
            Instantiate(water, new Vector3(xint - 1000, 0, zint - 1000), Quaternion.identity);
            Instantiate(water, new Vector3(xint, 0, zint + 1000), Quaternion.identity);
            Instantiate(water, new Vector3(xint + 1000, 0, zint), Quaternion.identity);
            Instantiate(water, new Vector3(xint - 1000, 0, 0), Quaternion.identity);
            Instantiate(water, new Vector3(0, 0, zint - 1000), Quaternion.identity);
        }
    }

    private void Update()
    {
        if (Vector3.Distance(player.transform.position, water.transform.position) > 1200f)
        {
            Destroy(gameObject);
        }
    }
}