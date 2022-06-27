using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static bool playerCreated;
    public bool canMove = true;

    public float speed = 5f;
    private float currentspeed;
    //public float currentSpeed = 5f;

    public Vector2 lastMovement = Vector2.zero;
    private int walkToHash;
    private bool walking = false;
    private bool attack = false;
    private bool roll = false;
    private bool swapW = false;
    private const string AXIS_H = "Horizontal", AXIS_V = "Vertical";
    public string nextUUID;
    public float timetoAttack;
    private float timetoAttackCounter;

    public Button pistolMode, attackPistol, swordMode, attackSword;

    public int energyAttack;
    public int energyRoll;

    private EnergyManager energy;

    private Rigidbody2D _rigidBody;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        _rigidBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        energy = GetComponent<EnergyManager>();
        walkToHash = Animator.StringToHash("Walking");
        timetoAttackCounter = timetoAttack;
        playerCreated = true;
        currentspeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        walking = false;

        if (!canMove)
        {
            return;
        }

        Attacking();

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_H)) > 0.2f)
        {
            //Vector3 translation = new Vector3(Input.GetAxisRaw(AXIS_H) * speed * Time.deltaTime, 0, 0);
            //this.transform.Translate(translation);
            _rigidBody.velocity = new Vector2(Input.GetAxisRaw(AXIS_H), _rigidBody.velocity.y).normalized * currentspeed;
            walking = true;
            lastMovement = new Vector2(Input.GetAxisRaw(AXIS_H), 0);
        }

        if (Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        {
            //Vector3 translation = new Vector3(0, Input.GetAxisRaw(AXIS_V) * speed * Time.deltaTime, 0);
            //this.transform.Translate(translation);
            _rigidBody.velocity = new Vector2(_rigidBody.velocity.x, Input.GetAxisRaw(AXIS_V)).normalized * currentspeed;
            walking = true;
            lastMovement = new Vector2(0, Input.GetAxisRaw(AXIS_V));
        }

        //if (Mathf.Abs(Input.GetAxisRaw(AXIS_H))> 0.2f && Mathf.Abs(Input.GetAxisRaw(AXIS_V)) > 0.2f)
        //{
        //    currentSpeed = speed / Mathf.Sqrt(2);
        //}
        //else
        //{
        //    currentSpeed = speed;
        //}
    }

    public void Attacking()
    {
        if (attack)
        {
            timetoAttackCounter -= Time.deltaTime;
            if (timetoAttackCounter < 0)
            {
                attack = false;
                _anim.SetBool("Attack", attack);
            }
        }
        else
        {
            if (Input.GetButtonDown("Attack"))
            {
                attack = true;
                timetoAttackCounter = timetoAttack;
                _rigidBody.velocity = Vector2.zero;
                _anim.SetBool("Attack", attack);
            }
        }
    }

    private void LateUpdate()
    {
        if (!walking && !roll)
        {
            _rigidBody.velocity = Vector2.zero;
        }
        _anim.SetFloat(AXIS_H, Input.GetAxisRaw(AXIS_H));
        _anim.SetFloat(AXIS_V, Input.GetAxisRaw(AXIS_V));
        _anim.SetBool(walkToHash, walking);
        _anim.SetFloat("LastH", lastMovement.x);
        _anim.SetFloat("LastV", lastMovement.y);
        roll = Input.GetButtonDown("Roll");
        if (roll && !_anim.GetBool("LowEnergy") && timetoAttackCounter <= 0)
        {
            currentspeed *= 2;
            _anim.SetBool("Roll", true);
            walking = false;
            energy.LowEnergy(energyRoll);
        }
        else
        {
            currentspeed = speed;
            _anim.SetBool("Roll", false);
        }

        ChangeWeapon();

        if (Input.GetButtonDown("Attack") && !_anim.GetBool("LowEnergy") && timetoAttackCounter <= 0)
        {
            energy.LowEnergy(energyAttack);
        }
    }

    public void ChangeWeapon()
    {
        if (!swapW && Input.GetButtonDown("SwapW"))
        {
            swapW = true;
            _anim.SetBool("PistolMode", swapW);
            pistolMode.interactable = true;
            attackPistol.interactable = true;
            swordMode.interactable = false;
            attackSword.interactable = false;
        }
        else if (swapW && Input.GetButtonDown("SwapW"))
        {
            swapW = false;
            _anim.SetBool("PistolMode", swapW);
            pistolMode.interactable = false;
            attackPistol.interactable = false;
            swordMode.interactable = true;
            attackSword.interactable = true;
        }
    }
}
