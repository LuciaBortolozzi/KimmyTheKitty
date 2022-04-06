using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableScript : MonoBehaviour {

    private void OnEnable()
    {
        Invoke("DestroyCollectable", 15f);
    }

    void DestroyCollectable()
    {
        gameObject.SetActive(false);
    }
}
