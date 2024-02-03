using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    #region FIELDS
    // physics fields
    private Rigidbody2D rb;
    private Vector3 direction = new Vector3(0, 0, 0);
    [SerializeField] float lerpAmount = 0;
    [SerializeField] float maxSpeed = 1.0f;

    // spawn fields
    [SerializeField] List<GameObject> spawnList;

    [SerializeField] float spawnCooldown = 1.0f;
    private bool canDrop = true;

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // move spawner each frame
        Move();
    }

    private void Move()
    {
        // calculate intended speed using direction and maxSpeed
        Vector2 targetSpeed = direction * maxSpeed;

        // apply lerping for smoother movement between current velocity and intended speed
        targetSpeed.x = Mathf.Lerp(rb.velocity.x, targetSpeed.x, lerpAmount);

        // Calculate difference between current velocity and desired velocity
        Vector2 speedDif = targetSpeed - rb.velocity;

        // calculate acceleration and force of movement
        Vector2 movement = speedDif * 1;// accel rate

        // Convert this to a vector and apply to rigidbody
        rb.AddForce(movement, ForceMode2D.Force);
    }

    // update player direction when input for move is triggered
    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the direction vector based on player input
        direction = context.ReadValue<Vector2>();
    }

    public void OnDrop(InputAction.CallbackContext context)
    {
        // once cooldown time has elapsed, drop a fruit
        if (canDrop)
        {
            StartCoroutine(Drop());
        }
    }

    // drops a fruit into the cup
    IEnumerator Drop()
    {
        canDrop = false;

        // drop fruit here by instantiating the right prefab at the spawner's location
        Instantiate(spawnList[0], new Vector3(transform.position.x, transform.position.y - 0.5f, transform.position.z), Quaternion.identity);

        // run coroutine for cooldown
        yield return new WaitForSeconds(spawnCooldown);

        // allow player to drop again
        canDrop = true;
    }
}
