using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboSystem : MonoBehaviour
{
    // Start is called before the first frame update
    JoystickInput joystickInput;
    public GameObject parent;
    Animator animator;
    public int combo;
    public bool atacando;
    //public AudioSource audioSource;
    //public AudioClip[] sonido;
    void Start()
    {
        joystickInput = parent.GetComponent<JoystickInput>();
       // audioSource = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        Combo();
    }
    public void Combo() {
        if (joystickInput.x && !atacando) {
            animator.SetTrigger("" + combo);
           // audioSource.clip = sonido[combo];
            //audioSource.Play();
        }
    }
    public void StartCombo() {
        atacando = false;
        if (combo < 3) {
            combo++;
        }
    }

    public void FinishAnim() {
        atacando = false;
        combo = 0;
    }
}
