﻿using ControladorDeRobos.Enum;

namespace ControladorDeRobos.Models;

public class Celula(int y,int x, EnumObjetos enumObjetos, string valor = "0")
{
    public int X { get; } = x;
    public int Y { get; } = y;
    public EnumObjetos Objeto { get; set; } = enumObjetos;
    public string valor { get; set; } = valor;
}