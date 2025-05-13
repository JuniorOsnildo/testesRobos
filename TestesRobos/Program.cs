using ControladorDeRobos.Services;
using ControladorDeRobos.Services.Buscas;

var mapa = new MapaService();
mapa.GerarMapa();
var robos = new RoboSevice();
robos.PosicionarRobos();

var algoritimo = BuscaFactory.GetAlgoritmo("largura");
var (melhorRobo, melhorCaminho) = 
    BuscaService.EncontrarRoboMaisProximo(algoritimo, 10, 0);

var rota = RotaService.GerarRotaCompleta(melhorCaminho, 10, 0);

foreach (var aa in rota)
{
    Console.WriteLine(aa.x + " " + aa.y);
}

Console.WriteLine();
Console.WriteLine(melhorRobo);
