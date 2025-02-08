using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashDestroy : MonoBehaviour
{

    public float Timer; 

    void Start()
{
    StartCoroutine(SelfDestruct());
}

IEnumerator SelfDestruct()
{
    yield return new WaitForSeconds(Timer);
    Destroy(gameObject);
}
}
