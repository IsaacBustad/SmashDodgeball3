// Isaac Bustad
// 2/28/2022

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ball", menuName = "ScriptableObjects/PathObj")]
public class PathObj : ScriptableObject
{
    public List<Transform> tfPts;   
}
