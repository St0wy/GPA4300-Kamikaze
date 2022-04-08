using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Kamikaze.Audio.Music.CombatMusic
{
    public class CombatMusicManager : MonoBehaviour
    {
        private AudioSource audio;

        void Awake()
        {
            audio = GetComponent<AudioSource>();
            DontDestroyOnLoad(gameObject);
        }

        void Update()
        {
            if (audio == null) return;

            GameObject laneGo = GameObject.FindGameObjectWithTag("Selectable");
            if (laneGo != null)
            {
                if (!audio.isPlaying) audio.Play();
                return;
            }

            audio.Stop(); return;



        }
    }
}
