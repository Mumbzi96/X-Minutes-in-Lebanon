using UnityEngine;
using System.Collections;

public class SoundEffectsHelper : MonoBehaviour{

  public static SoundEffectsHelper Instance;
  public AudioClip TurnSound;
  public AudioClip ButtonPressSound;

  void Awake()
  {
    if (Instance != null){
      Debug.LogError("Multiple instances of SoundEffectsHelper!");
    }
    Instance = this;
  }

  public void MakeTurnSound(){
    MakeSound(TurnSound);
  }

  public void MakeButtonPressSound(){
    MakeSound(ButtonPressSound);
  }


  private void MakeSound(AudioClip originalClip){
    AudioSource.PlayClipAtPoint(originalClip, transform.position);
  }
}
