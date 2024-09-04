class Program
{
    //Metodo Main em java
    //public static void Main(string[] args)

    //Metodo Main em CSharp
    static void Main()
    {
        //Chamando o objeto aluno e cadastrando varios aluno
        aluno o1 = new aluno();

        o1.matricula = "A";
        o1.nome = "Nome1";
        o1.nota1 = 7;
        o1.nota2 = 9;

        aluno o2 = new aluno();
        o2.matricula = "B";
        o2.nome = "Nome2";
        o2.nota1 = 8;
        o2.nota2 = 5;

        aluno o3 = new aluno();
        aluno o4 = new aluno();
        aluno o5 = new aluno();

        aluno[] alunos = new aluno[5];
        alunos[0] = o1;
        alunos[1] = o2;

        Console.WriteLine(o2);

        //Executando a função
        executar();

    }

    //Criando a Função
    static void executar()
    {
        Console.WriteLine("Digite o nome do aluno: ");
        string nome = Console.ReadLine();

        Console.WriteLine("Digite a nota do aluno: ");
        double nota1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Digite a nota do aluno: ");
        double nota2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Nome: " + nome);
        Console.WriteLine("Nota: " + nota1);
        Console.WriteLine("Nota: " + nota2);
        Console.WriteLine("Soma das notas: " + Calculadora.Somar(nota1, nota2));
        Console.WriteLine("Subtração: " + Calculadora.Subtrair(nota1, nota2));
        Console.WriteLine("Multiplicação: " + Calculadora.Multiplicar(nota1, nota2));
        Console.WriteLine("Divisão: " + Calculadora.Dividir(nota1, nota2));
    }
}