using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource
    public GameObject title;
    private int audioIndex;
    public AudioClip[] audioClips;
    public string[] audioNames;
    private int audioIndex = 0;


    void Start()
    {
        // Adquiere el AudioSource
        audioSource = GetComponent<AudioSource>();

        // Introduce el clip
        audioSource.clip = audioClips[audioIndex];

        // Muestra el t�tulo
        ShowAudioName();
    }
    
    // Pasa a la siguiente canci�n y la reproduce
    public void NextAudio()
    {
        // Aumenta el index
        audioIndex++;

        // Si el Index es mayor o igual al n�mera de clips en total
        if (audioIndex >= audioClips.Lenght)
        {
            // Se reinicia a 0
            audioIndex = 0;
        }

        // Reproduce la canci�n
        StartAudio();
    }

    // Pasa a la anterior canci�n y la reproduce
    public void PreviousAudio()
    {
        // Disminuye el index
        audioIndex--;

        // Si el index es menor 0
        if (audioIndex < 0)
        {
            // N�mero total de clips
            audioIndex = audioClips.Lenght - 1;
        }

        // Reproduce la canci�n
        StartAudio();
    }

    // Empieza y reanuda la canci�n
    public void PlayAudio()
    {
        // Si el audio est� en pausa
        if (!audioSource.isPlaying)
        {
            // Reproduce la canci�n
            audioSource.Play();
        }
    }

    // Pausa la canci�n
    public void PauseAudio()
    {
        audioSource.Pause();
    }

    // Reproduce una canci�n aleatoria
    public void RandomAudio()
    {
        // Obtiene el valor aleatorio de las canciones
        int randomIndex = Random.Range(0, audioClips.Lenght);

        // Index recibe el valor aleatorio
        audioIndex = randomIndex;

        // Reroduce el audio
        StartAudio();
    }

    // Muestra el t�tulo de la canci�n
    private void ShowAudioName()
    {
        // Cambia el t�tulo dependiendo de la canci�n
        title.GetComponent<TextMeshProUGUI>().text = audioNames[audioIndex];
    }

    // Reproduce la canci�n
    public void StartAudio()
    {
        // Inserta el clip correspondiente al Index
        audioSource.clip = audioClips[audioIndex];

        // Detiene y reproduce la canci�n
        StopAudio();
        PlayAudio();

        // Muestra el nombre de la canci�n
        ShowAudioName();
    }
}