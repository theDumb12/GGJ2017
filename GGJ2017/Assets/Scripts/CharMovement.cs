using UnityEngine;
using System.Collections;

public class CharMovement : MonoBehaviour {

   public float speed = 1.0f;
   public bool moveEnabled = true;

   private Rigidbody2D rb;
   private PlayerVars vars;
   private Animator animator;
   private bool isHit;
    private float prevAngle;


   public float fullHealth = 10.0f;
   public float currHealth = 10.0f;
   public bool damaged = false;
   public SpriteRenderer damageImage;
   public Color flashColor = new Color(1f, 0f, 0f, 0.1f);
   public float flashSpeed = 5f;

    private bool isDead;



    // Use this for initialization
    void Start ()
   {
        vars = gameObject.GetComponent<PlayerVars>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();

        isHit = false;
   }

   // Update is called once per frame
   void FixedUpdate ()
   {
      if(moveEnabled)
      {
         float horz = Input.GetAxis("Horizontal");
         float vert = Input.GetAxis("Vertical");
         Vector3 location = transform.position;
         Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
         Vector3 rightStick = new Vector3(vars.rStickX,vars.rStickY).normalized;

            //Vector3 targetDir = rightStick.position
            float angle = prevAngle;
            //float angle = (Mathf.Atan2(rightStick.y, -rightStick.x) * Mathf.Rad2Deg) - 90;
            if (rightStick.y != 0 || rightStick.x != 0)
            {
                angle = (Mathf.Atan2(rightStick.y, -rightStick.x) * Mathf.Rad2Deg) - 90;
                //angle = 0;
            }
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            prevAngle = angle;
            //transform.rotation = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward);
         //transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
         GetComponent<Rigidbody2D>().angularVelocity = 0;

         if (horz != 0 && vert != 0)
         {
            location.x += horz * speed;
            location.y += vert * speed;
         }
         else if (horz != 0)
         {
            location.x += horz * speed;
         }
         else if (vert != 0)
         {
            location.y += vert * speed;
         }
         transform.position = location;


         if (damaged)
         {
            damageImage.color = flashColor;
         }
         else
         {
            damageImage.color = Color.Lerp(damageImage.color, Color.white, flashSpeed * Time.deltaTime);
         }
         damaged = false;

      }
   }

    public void hit(Vector2 dir, float force, float damage)
    {
        if (!isHit)
        {
            isHit = true;
            rb.velocity = new Vector2(0, 0);

            // Apply knockback
            //rb.velocity += dir * force * Mathf.Sqrt(vars.damageRatio * 4.0f);

            // Damage
            //vars.damageRatio += damage;
        }
    }

    public void TakeDamage(float amount)
   {
      damaged = true;
      currHealth -= amount;

      if (currHealth <= 0 && !isDead)
      {

            moveEnabled = false;
      }
   }
}
