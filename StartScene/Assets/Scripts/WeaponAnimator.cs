using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAnimator : MonoBehaviour
{
    private Animator anim;
    private float zoomAnimTime;
    public float ZoomAnimTime => zoomAnimTime;


    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        SetZoomAnimTime();
    }

    private void SetZoomAnimTime()
    {
        AnimationClip[] clips = anim.runtimeAnimatorController.animationClips;
        foreach(AnimationClip clip in clips)
        {
            if(clip.name == "ZoomInAnim")
            {
                zoomAnimTime = clip.length;
                return;
            }
        }
    }

    public void ZoomIn(bool zoomIn)
    {
        anim.SetBool("ZoomIn", zoomIn);
    }


}
