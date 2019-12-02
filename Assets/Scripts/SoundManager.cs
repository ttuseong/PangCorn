using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public float volum;
    public AudioClip clip;
    private AudioSource source;

    public void SetSource(AudioSource _source)
    {
        source = _source;
        source.clip = clip;
        source.volume = volum;
    }

    public void Play()
    {
        source.Play();
    }
}

public class SoundManager : MonoBehaviour {
    [SerializeField]
    public Sound[] sounds;
	// Use this for initialization
	void Start () {
		for(int i = 0; i<sounds.Length;i++)
        {
            GameObject soundObject = new GameObject("사운드 파일 이름 : " + i + " = " + sounds[i].name);
            sounds[i].SetSource(soundObject.AddComponent<AudioSource>());
            soundObject.transform.SetParent(this.transform);
        }
	}

    public void Play(string _name)
    {
        for (int i = 0; i < sounds.Length; i++)
        {
            if (_name == sounds[i].name)
            {
                sounds[i].Play();
                return;
            }
        }
    }
}
