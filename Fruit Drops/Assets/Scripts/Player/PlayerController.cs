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
    [SerializeField] float spawnLeftBound;
    [SerializeField] float spawnRightBound;

    // spawn fields
    [SerializeField] List<GameObject> spawnList;

    [SerializeField] float spawnCooldown = 1.0f;
    private bool canDrop = true;
    [SerializeField] Sprite spawnSprite;

    private GameObject currentFruit;    // stores a reference to the fruit type that will drop
    [SerializeField] List<float> spawnRates;    // elements in this list should add to 100 (represent percentages)

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // set the current fruit to the default (should be cherry, or first element of spawnList)
        currentFruit = spawnList[0];
        GetComponent<SpriteRenderer>().sprite = currentFruit.GetComponent<SpriteRenderer>().sprite;
        transform.localScale = currentFruit.transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        // move spawner each frame
        Move();

        // ensure spawner doesn't move past bounds
        if (transform.position.x < spawnLeftBound)
        {
            transform.position = new Vector3(spawnLeftBound, transform.position.y, transform.position.z);
        }
        if (transform.position.x > spawnRightBound)
        {
            transform.position = new Vector3(spawnRightBound, transform.position.y, transform.position.z);
        }
    }

    /// <summary>
    /// Sets the current fruit that represents the next active fruit that will be dropped
    /// The current fruit will be selected based on proability of spawnable types
    /// </summary>
    private void SetCurrentFruit()
    {
        // generate a random float for comparison
        float randVal = Random.Range(0f, 1f);

        // determine current fruit based on random percentage
        // by referring to a variable for the spawn rate, this means other game components can alter spawn rates dynamically
        // initial spawn rates will be heavily skewed in favor of smaller (low level) fruits
        if (randVal < spawnRates[0])
        {
            // set the intended fruit as the current
            currentFruit = spawnList[0];
        }
        else if (randVal < spawnRates[1])
        {
            currentFruit = spawnList[1];
        }
        else if (randVal < spawnRates[2])
        {
            currentFruit = spawnList[2];
        }
        else if (randVal < spawnRates[3])
        {
            currentFruit = spawnList[3];
        }
        else if (randVal < spawnRates[4])
        {
            currentFruit = spawnList[4];
        }
        else if (randVal < spawnRates[5])
        {
            currentFruit = spawnList[5];
        }
        else if (randVal < spawnRates[6])
        {
            currentFruit = spawnList[6];
        }
        else if (randVal < spawnRates[7])
        {
            currentFruit = spawnList[7];
        }
        else if (randVal < spawnRates[8])
        {
            currentFruit = spawnList[8];
        }
        else
        {
            currentFruit = spawnList[9];
        }

        // ensure that sprite & color & size of spawner reflects the current fruit
        GetComponent<SpriteRenderer>().sprite = currentFruit.GetComponent<SpriteRenderer>().sprite;
        transform.localScale = currentFruit.transform.localScale;
    }

    /// <summary>
    /// Updates the position of the spawner depending on current direction
    /// </summary>
    private void Move()
    {
        // calculate intended speed using direction and maxSpeed
        Vector2 targetSpeed = direction * maxSpeed;

        // apply lerping for smoother movement between current velocity and intended speed
        targetSpeed.x = Mathf.Lerp(rb.velocity.x, targetSpeed.x, lerpAmount);

        // Calculate difference between current velocity and desired velocity
        Vector2 speedDif = targetSpeed - rb.velocity;

        // calculate acceleration and force of movement
        Vector2 movement = speedDif * 1;

        // Convert this to a vector and apply to rigidbody
        rb.AddForce(movement, ForceMode2D.Force);
    }

    /// <summary>
    /// Update player direction when input for move is triggered
    /// </summary>
    /// <param name="context"></param>
    public void OnMove(InputAction.CallbackContext context)
    {
        // Get the direction vector based on player input
        direction = context.ReadValue<Vector2>();
    }

    /// <summary>
    /// Begin the process of dropping a fruit when onDrop is triggered
    /// </summary>
    /// <param name="context"></param>
    public void OnDrop(InputAction.CallbackContext context)
    {
        // once cooldown time has elapsed, drop a fruit
        if (canDrop)
        {
            StartCoroutine(Drop());
        }
    }

    /// <summary>
    /// Coroutine that drops a fruit into the cup and queues the next fruit
    /// </summary>
    /// <returns></returns>
    IEnumerator Drop()
    {
        canDrop = false;

        // drop fruit here by instantiating the right prefab at the spawner's location
        Instantiate(currentFruit, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);

        // while on cooldown, change spawn sprite back to its default
        GetComponent<SpriteRenderer>().sprite = spawnSprite;
        transform.localScale = new Vector3(0.03267056f, 0.03267056f, 0.03267056f);

        // run coroutine for cooldown
        yield return new WaitForSeconds(spawnCooldown);

        // allow player to drop again
        canDrop = true;

        // update current fruit after drop
        SetCurrentFruit();
    }

    /// <summary>
    /// Listens for changes in score as broadcasted by other game objects
    /// Alters spawn rates according to score
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="scoreData"></param>
    public void OnScoreChanged(Component sender, object scoreData)
    {
        switch ((float)scoreData)
        {
            case > 1500:
                // check to see if spawn rates have already been altered
                if (spawnRates[9] >= 1.1f)  // 1.1f is the default value for spawnRates[9]  
                {
                    spawnRates[9] = 1f;
                }
                break;

            case > 1000:
                // check to see if spawn rates have already been altered
                if (spawnRates[8] >= 1.1f)  // 1.1f is the default value for spawnRates[8]  
                {
                    // alter spawn rates (if not previously altered for this score)
                    spawnRates[0] = 0.2f;
                    spawnRates[1] = 0.5f;
                    spawnRates[2] = 0.7f;
                    spawnRates[3] = 0.87f;
                    spawnRates[4] = 0.9f;
                    spawnRates[5] = 0.93f;
                    spawnRates[6] = 0.95f;
                    spawnRates[7] = 0.97f;
                    spawnRates[8] = 0.99f;
                }
                break;

            case > 650:
                // check to see if spawn rates have already been altered
                if (spawnRates[7] >= 1.1f)  // 1.1f is the default value for spawnRates[7]  
                {
                    // alter spawn rates (if not previously altered for this score)
                    spawnRates[6] = 0.97f;
                    spawnRates[7] = 0.99f;
                }
                break;

            case > 400:
                // check to see if spawn rates have already been altered
                if (spawnRates[6] >= 1.1f)  // 1.1f is the default value for spawnRates[6]  
                {
                    // alter spawn rates (if not previously altered for this score)
                    spawnRates[0] = 0.3f;
                    spawnRates[1] = 0.6f;
                    spawnRates[2] = 0.75f;
                    spawnRates[3] = 0.85f;
                    spawnRates[4] = 0.93f;
                    spawnRates[5] = 0.97f;
                    spawnRates[6] = 0.99f;
                }
                break;

            case > 250:
                // check to see if spawn rates have already been altered
                if (spawnRates[5] >= 1.1f)  // 1.1f is the default value for spawnRates[5]  
                {
                    // alter spawn rates (if not previously altered for this score)
                    // no change this increment for other spawn rates
                    spawnRates[4] = 0.97f;
                    spawnRates[5] = 0.99f;
                }
                break;

            case > 100:
                // check to see if spawn rates have already been altered
                if (spawnRates[4] >= 1.1f)  // 1.1f is the default value for spawnRates[4]  
                {
                    // alter spawn rates (if not previously altered for this score)
                    spawnRates[0] = 0.4f;
                    spawnRates[1] = 0.7f;
                    spawnRates[2] = 0.85f;
                    spawnRates[3] = 0.9f;
                    spawnRates[4] = 0.99f;
                }
                break;

            default:
                break;
        }

    }
}
