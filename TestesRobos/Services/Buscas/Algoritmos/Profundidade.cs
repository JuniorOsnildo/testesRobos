﻿using ControladorDeRobos.Enum;
using ControladorDeRobos.Models;
using ControladorDeRobos.Repositorys;

namespace ControladorDeRobos.Services.Buscas.Algoritmos;

public class Profundidade : IBuscaCaminho
{
    public List<Nodo> Busca(int xInicio, int yInicio, int xFinal, int yFinal)
    {
        var visitado = new bool[MapaRepository.Mapa.GetLength(0), MapaRepository.Mapa.GetLength(1)];
        var pilha = new Stack<Nodo>();

        pilha.Push(new Nodo(xInicio, yInicio));
        MapaRepository.Mapa[xFinal, yFinal].Objeto = EnumObjetos.Livre; //libera posição da estante para o robozinho entrar

        while (pilha.Count > 0)
        {
            var atual = pilha.Pop();
            
            if(atual.X < visitado.GetLength(0) && atual.Y < visitado.GetLength(1))
                if (visitado[atual.X, atual.Y]) continue;
            
            if(atual.X < visitado.GetLength(0) && atual.Y < visitado.GetLength(1))
                visitado[atual.X, atual.Y] = true;//evita loop infinito visitando a mesma celula várias vezes
            

            if (atual.X == xFinal && atual.Y == yFinal) return UtilBusca.ReconstruirCaminho(atual);

            foreach (var (dx, dy) in UtilBusca.Direcoes)
            {
                var xNovo = atual.X + dx;
                var yNovo = atual.Y + dy;

                if (!UtilBusca.EstaDentroDoMapa(xNovo, yNovo) || visitado[xNovo, yNovo] ||
                    MapaRepository.Mapa[xNovo, yNovo].Objeto != EnumObjetos.Livre) continue;

                pilha.Push(new Nodo(xNovo, yNovo, atual));
            }
        }
        return [];
    }
}