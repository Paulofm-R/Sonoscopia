using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colectavel : MonoBehaviour
{

    [SerializeField] float duracao = 6f;

    void Start()
    {
        Destroy(gameObject, duracao);
        // matar o colectavel à nascença
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 30, 15) * Time.deltaTime);
    }

    private void OnDestroy()
    {
        //informar o jogo que tem de instanciar novo colectavel
        GameObject.Find("Quartos3D").GetComponent<Jogo>().instanciar = true;
    }
}
