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
  // Using this to play sounds that need a certain position
  public void MakeTurnSound(float x, float y, float z){
    MakeSound(TurnSound,x,y,z);
  }

  public void MakeSound(AudioClip originalClip,float x, float y, float z){
    AudioSource.PlayClipAtPoint(originalClip, new Vector3(x,y,z));
  }
  // Using this to play sounds that don't need a certain position
  public void MakeButtonPressSound(){
    MakeSound(ButtonPressSound);
  }
  private void MakeSound(AudioClip originalClip){
    AudioSource.PlayClipAtPoint(originalClip, new Vector3(0,0,0));
  }
}
