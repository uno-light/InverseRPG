using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CopyActiveStatus : MonoBehaviour
{
    public GameObject master;
    public GameObject follower;

    void Update()
    {
        follower.SetActive(master.activeSelf);
    }
}
