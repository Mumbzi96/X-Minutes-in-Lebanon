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
  

  public void MakeSound(AudioClip originalClip,float x, float y, float z){
    AudioSource.PlayClipAtPoint(originalClip, new Vector3(x,y,z));
  }
  public void MakeTurnSound(float x, float y, float z){
    AudioSource.PlayClipAtPoint(TurnSound, new Vector3(x,y,z));
  }
  public void MakeButtonPressSound(){
    AudioSource.PlayClipAtPoint(ButtonPressSound, new Vector3(0,0,0));
  }
}
