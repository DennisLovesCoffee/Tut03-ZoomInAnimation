using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponZoom : MonoBehaviour
{
    [SerializeField] private WeaponAnimator ak47Animator;
    [SerializeField] private float zoomedInFieldOfView;

    private float baseFieldOfView;
    private Camera mainCam;


    private void Start()
    {
        mainCam = Camera.main;
        baseFieldOfView = mainCam.fieldOfView;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            StopAllCoroutines();
            StartCoroutine(ZoomAnim(true));
            //zoom in
        }
        else if (Input.GetMouseButtonUp(1))
        {
            //zoom out
            StopAllCoroutines();
            StartCoroutine(ZoomAnim(false));
        }
    }

    private IEnumerator ZoomAnim(bool zoomIn)
    {
        ak47Animator.ZoomIn(zoomIn);
        float animTime = ak47Animator.ZoomAnimTime;
        Debug.Log("Here1:" + animTime);
        float elapsed = 0f;

        float startFieldOfView = mainCam.fieldOfView;

        float endFieldOfView = (zoomIn) ? zoomedInFieldOfView : baseFieldOfView;
        /*
        if(zoomIn == true)
        {
            endFieldOfView = zoomedInFieldOfView;
        }
        else
        {
            endFieldOfView = baseFieldOfView;
        }*/

        while (elapsed < animTime)
        {
            float currentFieldOfView = Mathf.Lerp(startFieldOfView, endFieldOfView, elapsed / animTime);
            mainCam.fieldOfView = currentFieldOfView;
            elapsed += Time.deltaTime;
            yield return null;
        }

    }

}
