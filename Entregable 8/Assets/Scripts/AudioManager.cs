using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;
    public GameObject Title;
    private int audioIndex;
    public AudioClip[] audioClips;
    public string[] audioNames;


    void Start()
    {
        // Adquiere el AudioSource
        audioSource = GetComponent<AudioSource>();

        // Introduce el clip
        audioSource.clip = audioClips[audioIndex];

        // Muestra el título
        ShowAudioName();
    }
    
    // Pasa a la siguiente canción y la reproduce
    public void NextAudio()
    {
        // Aumenta el index
        audioIndex++;

        // Si el Index es mayor o igual al número de clips en total
        if (audioIndex >= audioClips.Length)
        {
            // Se reinicia a 0
            audioIndex = 0;
        }

        // Reproduce la canción
        StartAudio();
    }

    // Pasa a la anterior canción y la reproduce
    public void PreviousAudio()
    {
        // Disminuye el index
        audioIndex--;

        // Si el index es menor 0
        if (audioIndex < 0)
        {
            // Número total de clips
            audioIndex = audioClips.Length - 1;
        }

        // Reproduce la canción
        StartAudio();
    }

    // Empieza y reanuda la canción
    public void PlayAudio()
    {
        // Si el audio está en pausa
        if (!audioSource.isPlaying)
        {
            // Reproduce la canción
            audioSource.Play();

            // Muestra el título
            ShowAudioName();
        }
    }

    // Pausa la canción
    public void PauseAudio()
    {
        audioSource.Pause();
    }

    // Reproduce una canción aleatoria
    public void RandomAudio()
    {
        // Obtiene el valor aleatorio de las canciones
        int randomIndex = Random.Range(0, audioClips.Length);

        // Index recibe el valor aleatorio
        audioIndex = randomIndex;

        // Reroduce el audio
        StartAudio();
    }

    // Muestra el título de la canción
    private void ShowAudioName()
    {
        // Cambia el título dependiendo de la canción
        Title.GetComponent<TextMeshProUGUI>().text = audioNames[audioIndex];
    }

    // Reproduce la canción
    public void StartAudio()
    {
        // Inserta el clip correspondiente al Index
        audioSource.clip = audioClips[audioIndex];

        // reproduce la canción
        PlayAudio();

        // Muestra el nombre de la canción
        ShowAudioName();
    }
}
