<<<<<<< HEAD
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeVolume : MonoBehaviour
{

    // Use this for initialization
    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public void VolumeController()
    {
        volumeAudio.volume = volumeSlider.value;
    }
=======
﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeVolume : MonoBehaviour
{

    // Use this for initialization
    public Slider volumeSlider;
    public AudioSource volumeAudio;
    public void VolumeController()
    {
        volumeAudio.volume = volumeSlider.value;
    }
>>>>>>> d66cc9901a2a92e656f0f708cdbe4f274c71a3e5
}