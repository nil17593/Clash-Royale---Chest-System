using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestGroup : MonoBehaviour
{
    public static ChestGroup sharedInstance;
    public Transform GetChestGroupTransform() => gameObject.transform;
}
