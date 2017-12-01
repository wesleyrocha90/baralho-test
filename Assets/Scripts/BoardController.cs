using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoardController : MonoBehaviour
{

    public Baralho baralho { get; set; }
    private Player player1, player2;

    private Player primeiroJogador, segundoJogador;
    private Carta primeiraCarta, segundaCarta;
    private bool alguemGanhou = false;

    private UIController uIController;

    private void Start()
    {
        baralho = new Baralho();
        player1 = new Player("Fulano  ", baralho);
        player2 = new Player("Ciclano ", baralho);
        primeiroJogador = player1;
        segundoJogador = player2;

        for (int i = 0; i < 3; i++)
        {
            player1.PegaCarta();
            player2.PegaCarta();
        }

        uIController = GetComponent<UIController>();
        // uIController.InstanciaBaralho();
        uIController.InstanciaCarta(player1.cartasPlayer[0]);
        // Debug.Log (player1.nome + imprime (player1.cartasPlayer));
        // Debug.Log (player2.nome + imprime (player2.cartasPlayer));
    }

    private void FixedUpdate()
    {
        if (!alguemGanhou)
        {
            turno(primeiroJogador, segundoJogador);
            if (segundaCarta.Nome > primeiraCarta.Nome)
            {
                primeiroJogador = player2;
                segundoJogador = player1;
            }
            if (primeiroJogador.cartasPlayer.Count == 0 || segundoJogador.cartasPlayer.Count == 0)
            {
                alguemGanhou = true;
            }
        }
    }

    private void turno(Player primeiroJogador, Player segundoJogador)
    {
        primeiraCarta = primeiroJogador.Joga(null);
        // Debug.Log ("Carta Jogada: " + primeiroJogador.nome + ": " + primeiraCarta.ToString ());
        segundaCarta = segundoJogador.Joga(primeiraCarta);
        // Debug.Log ("Carta Jogada: " + segundoJogador.nome + ": " + segundaCarta.ToString ());

        // Debug.Log (player1.nome + imprime (player1.cartasPlayer));
        // Debug.Log (player2.nome + imprime (player2.cartasPlayer));
    }

    private string imprime(List<Carta> cartas)
    {
        string retorno = "[ ";
        foreach (Carta carta in cartas)
        {
            retorno += carta.ToString() + ", ";
        }
        return retorno + " ]";
    }

    public string ola()
    {
        return "ola";
    }
}