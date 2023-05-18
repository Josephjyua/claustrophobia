using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEditor.Animations;



public class AnimatorController : MonoBehaviour
{

    public string[] wa1 = new string[8];
    public string[] wa2 = new string[8];
    public string[] wa3 = new string[8];
    public List<string[]> nombresClips = new List<string[]>();

    
    Animator animator;
    JoystickInput joystickInput;
    Angle angle;
    Mov mov;
    bool isrun = false;
    float t = 0;
    public float cdDash = 0.65f;
    public bool isDasheable = false;
    private Rigidbody2D rb2D;
    
    float force = 1f;

   
    //Attack
    public int combo =0;
    public int timeForAttack = 0;
    public bool atacando = false;
    public bool finishCombo = false; 
    public AudioSource audioSource;
    public AudioClip[] sonido;
    void Awake() {
       
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        joystickInput = GetComponent<JoystickInput>();
        audioSource = GetComponent<AudioSource>();
        angle = GetComponent<Angle>();
        mov = GetComponent<Mov>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isDasheable = false;
        //nombresClips.Add(wa1);
        //nombresClips.Add(wa2);
        //nombresClips.Add(wa3);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        IsRun();
       
        animator.SetBool("IsWalk", IsWalk());
        animator.SetBool("IsRun", isrun);
        animator.SetFloat("Look",angle.lookMouse);
        Dash();
        Attack();
          
    }
   
    bool IsWalk() {
        string PlayerNumName = transform.name;

        if (Input.GetAxisRaw(PlayerNumName + "_X") != 0 || Input.GetAxisRaw(PlayerNumName + "_Y") != 0) {

            return true;
        }
        else {
            isrun = false;
            return false;
        }
        
     }

    void IsRun() {
        if (joystickInput.x) {
            mov.velocidad = 3f;
            isrun = true;

        }
        else {
            isrun = false;
            mov.velocidad = 2;
        }


    }
    void Dash() {
        
        if (joystickInput.a && !isDasheable ) {
            
            animator.SetBool("IsDash", true);
            
        }
    }
    public void StartDash() {
        
            // Establecer intargeteable como true

            isDasheable = true;
         
    }
    public void finishDash() {
        isDasheable = false;
        animator.SetBool("IsDash", false);
    }
    public void StartAnim() {
        atacando = true;
      
    }
    public void StartCombo() {
        animator.SetBool("FinishCombo", false);
        finishCombo = false; 
        atacando = true;
        if (combo<3) {
           combo++;
        }
    }

    public void FinishAnim() {

        finishCombo = true;
        atacando = false;
        animator.SetBool("Atacando", false);
        animator.SetBool("FinishCombo", true);
        combo = 0;
    }

    float GetPercent(float ti, float l) {
        float p = 0;
        p = (100 * ti) /l;
        return p;
    }
    void Attack() {

        if (joystickInput.rb) {


            animator.SetBool("Atacando", true);
            animator.SetInteger("Combo", combo);
            rb2D.AddForce(angle.p.transform.position * 0.1f,ForceMode2D.Impulse);
            //MoveSoft();
           
           
        }

    }

    void MoveSoft() {
    
        Vector2 m = new Vector2(Input.GetAxisRaw(mov.PlayerNumName + "_X"), Input.GetAxisRaw(mov.PlayerNumName + "_Y") * -1f);
        float step = 1 * Time.deltaTime;

        // move sprite towards the target location
        transform.position = Vector2.Lerp(transform.position, angle.p.transform.position * 0.2f, 0.5f); /*Vector2.MoveTowards(transform.position, m * 1.2f, step);*/


    }

    int GetAttackAnim() {

        string nombreAnim = animator.GetCurrentAnimatorClipInfo(0)[0].clip.name;
        if (wa1.Contains(nombreAnim)) {
            return 0;
        }

        if (wa2.Contains(nombreAnim)) {
            return 1;
        }
        if (wa3.Contains(nombreAnim)) {
            return 2;
        }
        return 3;
    }
}
