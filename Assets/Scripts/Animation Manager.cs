using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class AnimationManager : MonoBehaviour
{
    private PlayableDirector playableDirector;
    [SerializeField] PlayableAsset[] assets;
    [SerializeField] AudioSource EnviromentalSound;

    private void Awake()
    {
        playableDirector= GetComponent<PlayableDirector>();
    }

    public void setAnim(int num) 
    { 
        playableDirector.playableAsset = assets[num];
    }

    public void Play()
    {
        EnviromentalSound.Stop();
        playableDirector.Play();
    }

}
