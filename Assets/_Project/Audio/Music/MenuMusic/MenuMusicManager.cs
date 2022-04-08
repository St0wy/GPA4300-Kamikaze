using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Audio.Music.MenuMusic
{
    public class MenuMusicManager : MonoBehaviour
    {
        private AudioSource audioSource;

        void Awake()
        {
            audioSource = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            if (audioSource == null) return;

            GameObject laneGo = GameObject.FindGameObjectWithTag("Selectable");
            if (laneGo != null)
            {
                audioSource.Stop();
                return;
            }

            if (audioSource.isPlaying) return;

            if (!audioSource.isPlaying) audioSource.Play();
            

            
        }

    }
}
