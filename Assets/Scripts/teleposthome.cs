using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleposthome : MonoBehaviour
{
    [SerializeField] private Transform detination;
    public Transform GetDestination()
    {
        return detination;
    }
}
