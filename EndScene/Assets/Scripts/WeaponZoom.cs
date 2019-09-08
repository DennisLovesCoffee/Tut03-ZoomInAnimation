using System;
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
            //zoom in
            StopAllCoroutines();
            StartCoroutine(ZoomAnim(true));
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
        float animationTime = ak47Animator.ZoomAnimTime;
        float elapsed = 0f;
        float startFieldOfView = mainCam.fieldOfView;
        float endFieldOfView = (zoomIn) ? zoomedInFieldOfView : baseFieldOfView;

        while (elapsed < animationTime)
        {
            float newFieldOfView = Mathf.Lerp(startFieldOfView, endFieldOfView, elapsed / animationTime);
            mainCam.fieldOfView = newFieldOfView;
            elapsed += Time.deltaTime;
            yield return null;
        }
    }
}
