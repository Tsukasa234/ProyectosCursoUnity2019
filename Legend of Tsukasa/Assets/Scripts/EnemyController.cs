using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Tooltip("Velocidad de movimiento del enemigo")]
    public float speed = 1;
    private Rigidbody2D _enemyRB;
    private bool move;
    private Animator _enemyAnim;
    private SpriteRenderer _enemySprite;
    public bool needWalk;
    public int experiencia;

    //Tiempo entre un paso y el sig sucesivamente
    public float timeBeetweenSteps;
    //Cuanto tiempo a pasado desde que dio los pasos sucesivamente
    private float timeBeetweenStepsCounter;
    //Tiempo a hacer un paso
    public float timeToMakeStep;
    //Tiempo que ha pasado desde que dio un paso
    private float timeToMakeStepCounter;

    public Vector2 directionToMove;

    // Start is called before the first frame update
    void Start()
    {
        _enemyRB = GetComponent<Rigidbody2D>();
        _enemyAnim = GetComponent<Animator>();
        _enemySprite = GetComponent<SpriteRenderer>();
        timeBeetweenStepsCounter = timeBeetweenSteps*Random.Range(0.5f, 1.5f);
        timeToMakeStepCounter = timeToMakeStep*Random.Range(0.5f, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (move)
        {
            timeToMakeStepCounter -= Time.deltaTime;
            _enemyRB.velocity = directionToMove * speed;
            //Cuando me quedo sin tie3mpo de movimiento paramos al enemigo
            if (timeToMakeStepCounter < 0)
            {
                move = false;
                timeBeetweenStepsCounter = timeBeetweenSteps;
                _enemyRB.velocity = Vector2.zero;
                EnemyMovement();
            }
        }
        else
        {
            timeBeetweenStepsCounter -= Time.deltaTime;
            
            if (timeBeetweenStepsCounter < 0)
            {
                move = true;
                timeToMakeStepCounter = timeToMakeStep;
                directionToMove = new Vector2(Random.Range(-1, 2), Random.Range(-1, 2));
                EnemyMovement();
            }
        }
    }

    private void EnemyMovement()
    {
        if (needWalk)
        {
            _enemyAnim.SetBool("Move", move);
            if (directionToMove.x < 0)
            {
                _enemySprite.flipX = true;
            }
            else
            {
                _enemySprite.flipX = false;
            }
        }
    }
}
