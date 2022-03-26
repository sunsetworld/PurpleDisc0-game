using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class healthDisplay : MonoBehaviour
{
    [SerializeField]TextMeshProUGUI scoreHealth;
    GameManager gm;
    [SerializeField] Player p;

    // Start is called before the first frame update
    void Start()
    {
        scoreHealth = GetComponent<TextMeshProUGUI>();
        gm = FindObjectOfType<GameManager>();
        p.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreHealth.text = p.GetHealth().ToString();
    }
}
