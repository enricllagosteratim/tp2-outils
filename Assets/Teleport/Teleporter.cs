using System.Collections;
using System.Collections.Generic;
using StarterAssets;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    [SerializeReference] GameObject exitSpot;
    [SerializeField] float exitFreezeInterval = 0.1f;
    [SerializeField] Vector3 exitPositionOffset = new Vector3(0, 0.01f, 0);

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var controller = other.gameObject.GetComponent<FirstPersonController>();
            controller.enabled = false;
            other.transform.position = exitSpot.transform.position + exitPositionOffset;
            other.transform.rotation = exitSpot.transform.rotation;
            StartCoroutine("ReactivateControl", controller);
        }
    }

    IEnumerator ReactivateControl(FirstPersonController controller)
    {
        yield return new WaitForSeconds(exitFreezeInterval);
        controller.enabled = true;
    }
}