using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jogo : MonoBehaviour
{
    [SerializeField] Transform[] coordenadas = new Transform[4]; // coordenadas possíveis para instanciar o colectavel
    [SerializeField] GameObject colectavel; // este é o prefab que vamos instanciar

    public bool instanciar = true; // só instancia quando esta variável é verdadeira

    private int[] preenchidos = new int[4]; // garantir que tpdas as pocições são preenchidas
    private int contaPreenchidos = 0; // quando preenchemos o vector fazemos reset
    private int pontos = 0;
    [SerializeField] Text textoPontos;

    void Start()
    {
        ResetPreenchidos();
    }

    void Update()
    {
        if (instanciar) InstanciaColectavel();
    }

    void InstanciaColectavel()
    {
        instanciar = false;
        Instantiate(colectavel, coordenadas[Sorteio()].position, Quaternion.identity);
    }

    private int Sorteio()
    {
        // sortear apenas as posições livres
        int sorteado = 0;
        bool livre = false;

        while (!livre)
        {
            sorteado = Random.Range(0, 4); // sortear um número de 0 a 4

            // procurar uma posição no vector que esteja livre
            if (preenchidos[sorteado] == 0)
            {
                preenchidos[sorteado] = 1;
                Debug.Log(preenchidos[0] + "," + preenchidos[1] + "," + preenchidos[2] + "," + preenchidos[3]);
                livre = true;
            }
        }

        contaPreenchidos++;
        if (contaPreenchidos >= 4) ResetPreenchidos();
        return sorteado;
    }

    void ResetPreenchidos()
    {
        contaPreenchidos = 0;
        for (int i = 0; i < preenchidos.Length; i++)
        {
            preenchidos[i] = 0;
        }
    }

    public void Pontuacao()
    {
        pontos++;
        textoPontos.text = pontos.ToString();
    }
}
