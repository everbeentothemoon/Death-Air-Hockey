using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnOffPortals : MonoBehaviour
{
    public GameObject targetObject;
    public float reloadTime = 2f;
    public float duration = 1f;
    private bool isReloaded = true;

    private void Start()
    {
        StartCoroutine(ReloadObject());
    }

    private IEnumerator ReloadObject()
    {
        while (true)
        {
            if (isReloaded)
            {
                targetObject.SetActive(false);
                yield return new WaitForSeconds(reloadTime);
                isReloaded = false;
            }
            else
            {
                targetObject.SetActive(true);
                yield return new WaitForSeconds(duration);
                isReloaded = true;
            }
        }
    }
}
