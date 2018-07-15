using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class scr_chr : MonoBehaviour
{
    public float chr_speed = 3;

    //  bullet
    public GameObject bullet;
    public float fireRate = 1f;
    float nextFire = 0;

    //  damage 
    public float damageDelay = 1f;
    float nextDamage = 0;

    // HP
    public int chr_hp = 20;
    Image hp_bar;

    // Spawn Enemy
    public GameObject spawn_enemy;
    public float spawnDelay = 2f;
    float nextSpawn = 2f;
    

    //  Score
    public int score = 0;
    Text score_text;


    private void Awake()
    {
        hp_bar = GameObject.Find("Image").GetComponent<Image>();
        score_text = GameObject.Find("Text").GetComponent<Text>();
    }

    private void FixedUpdate()
    {
        //  Movement
        float w = Input.GetAxis("Horizontal");
        float h = Input.GetAxis("Vertical");

        transform.position += new Vector3(w * Time.deltaTime * chr_speed, h * Time.deltaTime * chr_speed);

        //  Angle
        Vector2 mouse_pos = Camera.main.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));

        float dx = mouse_pos.x - transform.position.x;
        float dy = mouse_pos.y - transform.position.y;
        float rotDeg = Mathf.Atan2(dy, dx) * Mathf.Rad2Deg;

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0f, 0f, rotDeg), 10 * Time.deltaTime);
    }

    private void Update()
    {
        //  Create Bullet
        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            GameObject Bullet = Instantiate(bullet);
            Bullet.transform.position = transform.position;
            Bullet.transform.rotation = transform.rotation;
            Bullet.name = "chr_bullet";
        }

        //  Create Enemy
        if (Time.time > nextSpawn)
        {
            GameObject spawned_enemy = Instantiate(spawn_enemy);
            spawned_enemy.transform.position = new Vector3(Random.Range(-4, -5), Random.Range(-4, -5), 0);

            nextSpawn = Time.time + spawnDelay;
        }

        //  UI
        hp_bar.fillAmount = (float)chr_hp / 20;
        score_text.text = "Score: " + score;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "tag_enemy" && Time.time > nextDamage)
        {
            nextDamage = Time.time + damageDelay;
            chr_hp -= 1;  
        }
    }
}
