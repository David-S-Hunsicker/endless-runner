using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlatformCreator : MonoBehaviour
{
    [SerializeField] GameObject[] platformPrefab;
    [SerializeField] Transform referencePoint;
    [SerializeField] GameObject lastCreatedPlatform;
    [SerializeField] float spaceBetweenPlatforms = 2;
    float lastPlatformWidth;

    // Update is called once per frame
    void Update()
    {
        if (lastCreatedPlatform.transform.position.x < referencePoint.position.x)
        {

            Vector3 targetCreationPoint = new Vector3(referencePoint.position.x + lastPlatformWidth + spaceBetweenPlatforms, lastCreatedPlatform.transform.position.y, lastCreatedPlatform.transform.position.z);
            lastCreatedPlatform = Instantiate(platformPrefab[Random.Range(0, platformPrefab.Length)], targetCreationPoint, Quaternion.identity);
            BoxCollider2D collider = lastCreatedPlatform.GetComponent<BoxCollider2D>();
            lastPlatformWidth = collider.bounds.size.x;
        }
    }
}
