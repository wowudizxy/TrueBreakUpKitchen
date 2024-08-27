using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;

    private void Start()
    {
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.delivery_success);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.delivery_fail);
    }
    private void PlaySound(List<AudioClip> audioClipList, float volume = 1.0f)
    {
        int index = Random.Range(0, audioClipList.Count);
        AudioSource.PlayClipAtPoint(audioClipList[index],Camera.main.transform.position);
    }
    private void PlaySound(List<AudioClip> audioClipList,Vector3 position,float volume = 1.0f)
    {
        int index = Random.Range(0, audioClipList.Count);
        AudioSource.PlayClipAtPoint(audioClipList[index], position,volume);
    }
}
