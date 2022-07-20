using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private ParticleSystem crashEffect;
    [SerializeField] private AudioClip crashSFX;

    private bool playerHasCrashed = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground" && playerHasCrashed == false)
        {
            playerHasCrashed = true;
            FindObjectOfType<PlayerController>().DisableControlls();
            GetComponent<AudioSource>().PlayOneShot(crashSFX);
            crashEffect.Play();
            Invoke("ReloadScene", 1f);
        }
    }

    private void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
