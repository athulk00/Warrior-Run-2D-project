using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float enemyWalkSpeed = 3f;
    [SerializeField] private float visionRadious = 3f;
    [SerializeField] private GameObject target1;
    [SerializeField] private GameObject target2;
    private GameObject currentTargetPos;
    private bool previouslyAttacked;
    [SerializeField] private GameObject player;
    [SerializeField] LayerMask playerMask;
    private int currentPosition = 0;
    private float playerInAttackZone;
    private SpriteRenderer sprite;
    public SpriteRenderer playerSprite;
    private Animator anim;
    public Transform rayPoint1;
    public Transform rayPoint2;
    private Transform currentRayPoint;
    private float damage = 5f;
    private float timeBetweenAttack = 2f;
    public EnemyTarget enemyTarget;

    public enum MovementState {walk, attack1 };
    public MovementState state;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        
    }

    void Update()
    {
       

        AnimationUpdate();
        if(player != null)
        {
            playerInAttackZone = Vector2.Distance(player.transform.position, transform.position);
        }
        

        if (playerInAttackZone > visionRadious) EnemyWalk();
        if (playerInAttackZone <= visionRadious) Attack();


    }

    private void EnemyWalk()
    {
        state = MovementState.walk;
        if(Vector2.Distance(waypoints[currentPosition].transform.position, transform.position) < 0.1f)
        {
            currentPosition++;
            if(currentPosition >= waypoints.Length)
            {
                currentPosition = 0;
            }
        }
        if(waypoints[currentPosition].transform.position.x < transform.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentPosition].transform.position, Time.deltaTime * enemyWalkSpeed);
        
    }
    private void Attack()
    {
        if (playerSprite != null && playerSprite.flipX == false )
        {
            currentTargetPos = target1;
        }
        else if(playerSprite != null && playerSprite.flipX == true)
        {
            currentTargetPos = target2;
        }
        
        Vector2 targetPos = new Vector2(currentTargetPos.transform.position.x, transform.position.y);
        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * enemyWalkSpeed);
        transform.LookAt(transform.position);
        if(playerInAttackZone <= visionRadious)
        {
            state = MovementState.attack1;
        }
        else
        {
            state = MovementState.walk;
        }
       
        if(enemyTarget.playerCurrentHealth == 0)
        {
            EnemyWalk();
        }
        /*if (target.transform.position.x <= transform.position.x)
        {
            sprite.flipX = true;

        }
        else if(target.transform.position.x >= transform.position.x)
        {
            sprite.flipX = false;
            
            
            
        }*/
        if(sprite.flipX == true && player != null)
        {
            currentRayPoint = rayPoint1;
        }
        else if (sprite.flipX == false && player != null)
        {
            currentRayPoint = rayPoint2;
        }
        if (!previouslyAttacked)
        {
            RaycastHit2D hit = Physics2D.Raycast(currentRayPoint.position, currentRayPoint.forward, 2f, playerMask);
            if (hit.collider != null)
            {
                hit.collider.gameObject.GetComponent<EnemyTarget>().TakeDamage(damage);
                
            }
            previouslyAttacked = true;
            Invoke(nameof(ActiveAttacking), timeBetweenAttack);
        }
       
       

    }
    void ActiveAttacking()
    {
        previouslyAttacked = false;
    }


    private void AnimationUpdate()
    {
        anim.SetInteger("State", (int)state);
    }
}
