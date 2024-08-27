using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class AudioClipRefsSO : ScriptableObject
{
    public List<AudioClip> chop;
    public List<AudioClip> delivery_fail;
    public List<AudioClip> delivery_success;
    public List<AudioClip> foot_step;
    public List<AudioClip> object_drop;
    public List<AudioClip> object_pickup;
    public List<AudioClip> trash; 
    public List<AudioClip> warning;
}
