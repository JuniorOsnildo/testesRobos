using ControladorDeRobos.Repositorys;
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


for (int i = 0; i < 13; i++)
{
    Console.WriteLine();
    for (int j = 0; j < 15; j++)
    {
        Console.Write(MapaRepository.Mapa[i,j].valor);
        Console.Write(" | ");
    }
    
}
