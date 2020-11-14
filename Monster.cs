using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private Transform TF;

    [Header("Target")]
    public GameObject TargetObject;/* if this object is Active on the Scene the monster teleports,
                                    * be sure to deactivate the target (make it invisible) on the inspector*/
    public Transform TTF;//target
    public int Steps = 1;
    private int x = 0;
    public float TeleportNerf = 2f;//high values means the monster teleports less closer to the targt


    void Start()
    {
        if(TeleportNerf < 0) { TeleportNerf = 1; }
        TF = GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 _curentPosition = new Vector3(TF.position.x,TF.position.y,TF.position.z);
        Vector3 _targetposition = new Vector3(TTF.position.x, TTF.position.y, TTF.position.z);
        Vector3 _nextposition = new Vector3(    _targetposition.x - _curentPosition.x / TeleportNerf,
                                                _targetposition.y - _curentPosition.y / TeleportNerf,
                                                _targetposition.z - _curentPosition.z / TeleportNerf
                                                                                            );
        if (TargetObject.activeSelf == true)
        {
            
            if(x == 0)
            {
            for(; x <= Steps; x++)//will move the monster until x is equal to the number of spets he can make
            {
                TF.position = _nextposition;
                
            }

            }
        }
        else
        {
            x = 0;
        }
    }
}
