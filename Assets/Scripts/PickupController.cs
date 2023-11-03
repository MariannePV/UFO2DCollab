using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 100 * Time.deltaTime, Space.Self);   //Afegim rotació als PickUps
    }
}
