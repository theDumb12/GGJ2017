using UnityEngine;
using System.Collections;


public class WerewolfMovement : MonoBehaviour {

   public float speed = 1.0f;
   public float speedMultiplier = 4.0f;
   public float rotateSpeed = 5.0f;
   public bool moveEnabled = true;
   public bool seePlayer = false;
   public float randMove = 15.0f;
   public float stunTime = 100.0f;
   public float currentStun = 0.0f;

   private Vector3 randTarget = new Vector3(0,0,0);


   public float fullHealth = 10.0f;
   public float currHealth = 10.0f;
   public bool damaged = false;
   public SpriteRenderer damageImage;
   public Color flashColor = new Color(1f, 0f, 0f, 0.01f);
   public float flashSpeed = 3f;

    private bool isDead = false;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
   void FixedUpdate ()
   {
      if (currentStun > 0.0f)
      {
         moveEnabled = false;
         currentStun--;
      }
      else
      {
         moveEnabled = true;
      }

      if (moveEnabled)
      {
         if (seePlayer)
         {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            Vector3 playerLoc = player.transform.position;
            Vector3 warewoLoc = this.transform.position;

            transform.position = Vector3.MoveTowards(warewoLoc, playerLoc, speed * speedMultiplier);

            Vector3 vectorToTarget = playerLoc - warewoLoc;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle - 90, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * rotateSpeed);
         }
         else
         {
            Vector3 warewoLoc = this.transform.position;

            if (warewoLoc == randTarget)
            {
               randTarget.x += Random.Range(-randMove,randMove);
               randTarget.y += Random.Range(-randMove,randMove);
            }
            else
            {
               transform.position = Vector3.MoveTowards(warewoLoc, randTarget, speed);

               Vector3 v2t = randTarget - warewoLoc;
               float angle = Mathf.Atan2(v2t.y, v2t.x) * Mathf.Rad2Deg;
               Quaternion quat = Quaternion.AngleAxis(angle - 90, Vector3.forward);
               transform.rotation = Quaternion.Slerp(transform.rotation, quat, Time.deltaTime * rotateSpeed);
            }
         }


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
        //if (!isHit)
        //{
            //isHit = true;
            //rb.velocity = new Vector2(0, 0);

            // Apply knockback
            //rb.velocity += dir * force * Mathf.Sqrt(vars.damageRatio * 4.0f);

            // Damage
            //currentHealth -= damage;

        //}
    }

    public void TakeDamage(float amount)
   {
      damaged = true;
      currHealth -= amount;
       Debug.Log(currHealth);
      if (currHealth <= 0 && !isDead)
      {
         //moveEnabled = false;
         //SceneManager.LoadScene("EndGameScene");
         Application.LoadLevel("EndGameScene");
      }
   }

    public void OnCollision2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Walls")
        {
            randTarget.x += Random.Range(-randMove, randMove);
            randTarget.y += Random.Range(-randMove, randMove);
        }
    }
}
