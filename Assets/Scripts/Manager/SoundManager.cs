
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance {  get; private set; }
    [SerializeField] private AudioClipRefsSO audioClipRefsSO;
    private int volume = 5;
    private void Awake()
    {
        Instance = this;
    }
    private void Start()
    {
        PlayerSound.PlayerStepSound += PlayerSound_PlayerStepSound;
        OrderManager.Instance.OnRecipeFailed += OrderManager_OnRecipeFailed;
        OrderManager.Instance.OnRecipeSuccessed += OrderManager_OnRecipeSuccessed;
        CuttingCounter.OnCut += CuttingCounter_OnCut;
        KitchenObjectHolder.Drop += KitchenObjectHolder_Drop;
        KitchenObjectHolder.PickUP += KitchenObjectHolder_PickUP;
        TrashCounter.Trash += TrashCounter_Trash;
    }

    private void PlayerSound_PlayerStepSound(object sender, System.EventArgs e)
    {
        //PlaySound(audioClipRefsSO.foot_step, Player.Instance);
    }

    private void TrashCounter_Trash(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.trash);
    }

    private void KitchenObjectHolder_PickUP(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.object_pickup);
    }

    private void KitchenObjectHolder_Drop(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.object_drop);
    }

    private void CuttingCounter_OnCut(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.chop);
    }

    private void OrderManager_OnRecipeSuccessed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.delivery_success);
    }

    private void OrderManager_OnRecipeFailed(object sender, System.EventArgs e)
    {
        PlaySound(audioClipRefsSO.delivery_fail);
    }
    public void PlaySound(AudioClip audioClip, float volume = 0.6f)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
        
    }
    public void PlaySound(List<AudioClip> audioClipList, float volumeMutipler = 0.5f)
    {
        int index = Random.Range(0, audioClipList.Count);
        AudioSource.PlayClipAtPoint(audioClipList[index],Camera.main.transform.position, volumeMutipler*(volume/10.0f));

    }
    public void ChangeVolume()
    {
        
        if(volume > 10)
        {
            volume = 0;
        }
        volume++;
    }
    public int GetVolume()
    {
        return volume;
    }

    /*public void PlaySound(List<AudioClip> audioClipList,Vector3 position,float volume = 1.0f)
    {
        int index = Random.Range(0, audioClipList.Count);
        AudioSource.PlayClipAtPoint(audioClipList[index], position,volume);
    }
    public void PlaySound(List<AudioClip> audioClipList,Player player, float volume = 0.6f)
    {
        int index = Random.value > 0.5f ? 2 : 0;
        AudioSource.PlayClipAtPoint(audioClipList[index], Camera.main.transform.position, volume);
        PlayNextFootstep(audioClipList, index, volume);
    }
    IEnumerator<WaitForSeconds> PlayNextFootstep(List<AudioClip> audioClipList, int index,float volume)
    {
        yield return new WaitForSeconds(audioClipList[index].length);
        if(index == 0)
        {
            PlaySound(audioClipList[1], volume);
        }
        else
        {
            PlaySound(audioClipList[3], volume);
        }
    }*/
}
