using System;


namespace RodaRodaGame
{
    class Program
    {
        static void Main(string[] args)
        {    //lista de palavras para serem sorteadas no game.
            string[] palavras = { "casa", "artista", "celular", "coca-cola", "oculos", "escova", "abacate", "abacaxi", "acessório", "açougue", "eclipse", "ecologico", "piolho" };

            Random ramdom = new Random();
            //random.next vai gerar um numero aleatorio do 0 ate o tamanho do vetor.
            string palavraSorteada = palavras[ramdom.Next(0, palavras.Length)];

            //quebramos a palavra em um vetor de letras. 
            char[] palavraQuebrada = palavraSorteada.ToCharArray();

            //nesse vetor vamos guardar as letras que a pessoa acertou. 
            //vetor é uma coleçao.
            string[] letrasReveladas = new string[palavraQuebrada.Length];

            //variavies de controle.
            const int limiteErros = 7;
            int qtdErros = 0;
            string letraEscolhida;
            bool acertou = false;
            bool sairJogo = false;
            int qtdLetras = 0;
            int qtdAcertos = 0;

            /*
              ### MONTANDO O JOGO NA TELA ### 
             */

            //primeiro vamos montar a lista de letras reveladas da palavra.
            for (int i = 0; i < palavraQuebrada.Length; i++)
            {
                if (palavraQuebrada[i].ToString() == "-")
                {
                    letrasReveladas[i] = " - ";
                    Console.Write(letrasReveladas[i]);
                }
                else
                {
                    letrasReveladas[i] = " _ ";
                    Console.Write(letrasReveladas[i]);
                    //auto incrementa a quantidade de letras que a palavra efetivamente tem.
                    qtdLetras++;
                }
            }

            while (sairJogo == false)
            {
                Console.Clear();
                Console.WriteLine("### VOCÊ ESTA JOGANDO O RODA RODA SENAC DEV ###");
                Console.WriteLine();
                Console.WriteLine("ERROS: {0} DE {1}", qtdErros, limiteErros);
                Console.WriteLine("A PALAVRA POSSUI: {0} LETRAS.", qtdLetras);
                Console.WriteLine();

                //vamos exibir as letras reveladas.
                for (int i = 0; i < letrasReveladas.Length; i++)
                {
                    Console.Write(letrasReveladas[i]);
                }

                //agora, vamos perguntar ao jogador qual letra que ele quer tentar.
                Console.WriteLine();
                Console.WriteLine();
                Console.Write("Digite uma letra: ");
                letraEscolhida = Console.ReadLine();

                //reinicia o valor de acertou para falso.
                acertou = false;

                for (int i = 0; i < letrasReveladas.Length; i++)
                {
                    //se a letra existe, entao vamos revelar ela.
                    if (palavraQuebrada[i].ToString() == letraEscolhida)
                    {
                        letrasReveladas[i] = letraEscolhida;
                        acertou = true;
                        qtdAcertos++;

                    }
                }
                if (acertou == false)
                    qtdErros++;

                if (qtdErros >= limiteErros)
                {
                    Console.Clear();
                    Console.WriteLine("QUE PENA VOÇE PERDEU. a palavra era {0}. ", palavraSorteada.ToUpper());
                    sairJogo = true;
                }

                if (qtdLetras == qtdAcertos)
                {
                    Console.Clear();
                    Console.WriteLine("PARABÉNS, VOCE GANHOU! pois conseguiu descobrir a palavra {0}. ", palavraSorteada.ToUpper());
                    sairJogo = true;
                }
            }
            Console.ReadKey();


        }

    }
}
