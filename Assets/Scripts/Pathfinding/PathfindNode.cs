using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindNode : MonoBehaviour {

    
    public PathInfo PosInfo
    {
        get
        {
            if (posPaths.Length < 1)
                return null;
            return posPaths[Random.Range(0, posPaths.Length)];
        }
    }

    [Header("Positive Velocity >>")]
    [SerializeField]
    private PathInfo[] posPaths;

    
    public PathInfo NegInfo
    {
        get
        {
            if (negPaths.Length < 1)
                return null;
            return negPaths[Random.Range(0, negPaths.Length)];
        }
    }

    [Header("Negative Velocity <<")]
    [SerializeField]
    private PathInfo[] negPaths;
}

[System.Serializable]
public class PathInfo
{
    public float XSpeed;
    public float YForce;
}
