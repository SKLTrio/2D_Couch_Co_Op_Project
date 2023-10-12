using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pressure_Plate_Behaviour : MonoBehaviour
{
    [SerializeField] public SpriteRenderer Plate_Sprite;
    [SerializeField] public Sprite Plate_Unpushed_Sprite;
    [SerializeField] public Sprite Plate_Pushed_Sprite;
    [SerializeField] public GameObject Wall;

    // Start is called before the first frame update
    void Start()
    {
        Wall.SetActive(true);
    }

    private void OnTriggerStay2D(Collider2D Collider)
    {
        if (Collider.CompareTag("Player_Feet"))
        {
            Wall.SetActive(false);
            Plate_Sprite.sprite = Plate_Pushed_Sprite;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Wall.SetActive(true);
        Plate_Sprite.sprite = Plate_Unpushed_Sprite;
    }
}
