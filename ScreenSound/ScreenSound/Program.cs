// See https://aka.ms/new-console-template for more information


string mensagemInicial = "Boas vindas ao ScreenSound !";
//List<string> ListaBandas = new List<string>();
Dictionary<string, List<int>> bandasRegistradas = new Dictionary<string, List<int>>();
bandasRegistradas.Add("Linking Park",new List<int>() { 3 ,7, 3 });

IniciaScreenSound();
void IniciaScreenSound()
{
    ExibirMensagemInicial();
    ExibirOpcoes();
    EscolheOpcao();
}

void ExibirMensagemInicial()
{
    Console.WriteLine(@"
    
░██████╗░█████╗░██████╗░███████╗███████╗███╗░░██╗  ░██████╗░█████╗░██╗░░░██╗███╗░░██╗██████╗░
██╔════╝██╔══██╗██╔══██╗██╔════╝██╔════╝████╗░██║  ██╔════╝██╔══██╗██║░░░██║████╗░██║██╔══██╗
╚█████╗░██║░░╚═╝██████╔╝█████╗░░█████╗░░██╔██╗██║  ╚█████╗░██║░░██║██║░░░██║██╔██╗██║██║░░██║
░╚═══██╗██║░░██╗██╔══██╗██╔══╝░░██╔══╝░░██║╚████║  ░╚═══██╗██║░░██║██║░░░██║██║╚████║██║░░██║
██████╔╝╚█████╔╝██║░░██║███████╗███████╗██║░╚███║  ██████╔╝╚█████╔╝╚██████╔╝██║░╚███║██████╔╝
╚═════╝░░╚════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░╚══╝  ╚═════╝░░╚════╝░░╚═════╝░╚═╝░░╚══╝╚═════╝░
");
    Console.WriteLine(mensagemInicial);
}
void ExibirOpcoes()
{
    Console.WriteLine("\nDigite 1 para registrar uma banda");
    Console.WriteLine("digite 2 para mostrar todas as bands");
    Console.WriteLine("digite 3 para avaliar uma banda");
    Console.WriteLine("digite 4 para exibir a media de uma banda");
    Console.WriteLine("digite -1 para sair");

    Console.Write("Digite sua opção: ");
}

void EscolheOpcao()
{
    int opcaoEscolhida = int.Parse(Console.ReadLine()!);

    switch (opcaoEscolhida)
    {
        case 1: RegistrarBanda(); break;
        case 2: MostrarBandas(); break;
        case 3: RegistraNotasBanda(); break;
        case 4: ExibirMediaBanda(); break;
        case -1: Console.WriteLine("Você escolheu a opção: " + opcaoEscolhida); break;
        default:
        break;
    }
}

void RegistrarBanda()
{
    Console.Clear();
    ExibirTituloDaOpcao("Registro de Bandas");
    Console.Write("Digite o nome da banda que deseja registra : ");
    string nomeBanda = Console.ReadLine()!;
    bandasRegistradas.Add(nomeBanda,new List<int>());
    Console.WriteLine($"A banda {nomeBanda} foi registrada com sucesso!!");
    Thread.Sleep(2000);
    Console.Clear();
    IniciaScreenSound();
}


void MostrarBandas()
{
    Console.Clear();
    ExibirTituloDaOpcao("Mostrar Bandas");
    foreach (var (item, index) in bandasRegistradas.Select((item, index) => (item, index))) Console.WriteLine($"Banda {index + 1} - {item.Key}");
    Console.WriteLine("Digite qualquer tecla para retornar");
    Console.ReadKey();
    Console.Clear();
    IniciaScreenSound();
}

void ExibirTituloDaOpcao(string tituloDaOpcao)
{
    int tamanhoDaOpcao = tituloDaOpcao.Length;
    string asteriscos = "".PadLeft(tamanhoDaOpcao, '*');
    Console.WriteLine(asteriscos);
    Console.WriteLine(tituloDaOpcao);
    Console.WriteLine(asteriscos);
}

void RegistraNotasBanda()
{
    Console.Clear();
    foreach (var (item, index) in bandasRegistradas.Select((item, index) => (item, index))) Console.WriteLine($"Banda {index + 1} - {item.Key}");
    Console.WriteLine("Escolha a banda que quer avaliar: ");
    int bandaEscolhida = int.Parse(Console.ReadLine()!);
    foreach (var (item, index) in bandasRegistradas.Select((item, index) => (item, index)))
    {
        if(bandaEscolhida == ( index+ 1 ))
        {
            Console.Write($"Banda Escolhida {item.Key} Digite o valor da nota de 0 a 10 : ");
            int nota = int.Parse(Console.ReadLine()!);
            item.Value.Add(nota);
            Console.WriteLine($"A nota {nota} foi adicionada com sucesso para a banda {item.Key}");
            Thread.Sleep(2000);
            Console.Clear() ;
            IniciaScreenSound();
        }
    }
    
}

void ExibirMediaBanda()
{
    Console.Clear();
    foreach (var (item, index) in bandasRegistradas.Select((item, index) => (item, index))) Console.WriteLine($"Banda {index + 1} - {item.Key}");
    Console.WriteLine("Escolha a banda que quer ver a média: ");
    int bandaEscolhida = int.Parse(Console.ReadLine()!);
    foreach (var (item, index) in bandasRegistradas.Select((item, index) => (item, index)))
    {
        if (bandaEscolhida == (index + 1))
        {
            double media = bandasRegistradas[item.Key].Average();
            Console.WriteLine($"A nota média da banda {item.Key} é {media.ToString("F2")}");
            Thread.Sleep(2000);
            Console.Clear();
            IniciaScreenSound();
        }
    }

}

void ExibeNotasDaBanda(string nomeBanda)
{
    Console.Clear();

    Console.WriteLine($"{string.Join(',', bandasRegistradas[nomeBanda])}");
    
    Console.ReadKey();
    Console.Clear();
    IniciaScreenSound();
}
