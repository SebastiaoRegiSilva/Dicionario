using System;
using System.Collections.Generic;
using System.Linq;

namespace DicPalavras
{
    /// <sumary>Classe principal do Dicionário de Palavras.</sumary>    
    class Program
    {
        /// <summary>Lista de palavras que não devem ser exibidas no programa.</summary>
        static List<string> _listaNegra = new List<string> { "de", "e", "as", "em", "da,", "abaixo", "acordo", "junto", "a", "acerca", "respeito", "fora", "sem","embargo","frente", "trás", "razão", "quanto","com",
        "embaixo", "junto", "acima", "modo","não", "obstante", "sob", "uso","do","fim", "dentro", "para", "à", "frente", "diante", "baixo","antes", "embaixo", "por", "cima", "respeito", "cima", "atrás", "através", "em"};

        /// <summary>Lista pronta, depois de todos tratamentos.</summary>
        static List<PalavraGrupoPontuacao> _tabelaFinal = new List<PalavraGrupoPontuacao> { };

        /// <summary>Método principal de execução do programa.</summary>
        static void Main(string[] args)
        {
            // Lista de grupo listaGrupo, divisão de Id's e títulos.
            List<TipoLista> listaGrupo = new List<TipoLista>
            {
                new TipoLista { IdGrupo = 1, Titulo = "PRODUÇÃO DE LAVOURAS TEMPORÁRIAS"},
                new TipoLista { IdGrupo = 1, Titulo = "PRODUÇÃO DE LAVOURAS TEMPORÁRIAS"},
                new TipoLista { IdGrupo = 2, Titulo = "HORTICULTURA E FLORICULTURA"},
                new TipoLista { IdGrupo = 3, Titulo = "PRODUÇÃO DE LAVOURAS PERMANENTES"},
                new TipoLista { IdGrupo = 4, Titulo = "PRODUÇÃO DE SEMENTES E MUDAS CERTIFICADAS"},
                new TipoLista { IdGrupo = 5, Titulo = "PECUÁRIA"},
                new TipoLista { IdGrupo = 6, Titulo = "ATIVIDADES DE APOIO À AGRICULTURA E À PECUÁRIA; ATIVIDADES DE PÓS-COLHEITA"},
                new TipoLista { IdGrupo = 7, Titulo = "CAÇA E SERVIÇOS RELACIONADOS"},
                new TipoLista { IdGrupo = 8, Titulo = "PRODUÇÃO FLORESTAL - FLORESTAS PLANTADAS"},
                new TipoLista { IdGrupo = 9, Titulo = "PRODUÇÃO FLORESTAL - FLORESTAS NATIVAS"},
                new TipoLista { IdGrupo = 10, Titulo = "ATIVIDADES DE APOIO À PRODUÇÃO FLORESTAL"},
                new TipoLista { IdGrupo = 11, Titulo = "PESCA"},
                new TipoLista { IdGrupo = 12, Titulo = "AQUICULTURA"},
                new TipoLista { IdGrupo = 13, Titulo = "EXTRAÇÃO DE CARVÃO MINERAL"}
            };

            // Lista de grupo listaClasse, divisão de Id's e títulos.
            List<TipoLista> listaClasse = new List<TipoLista>
            {
                new TipoLista { IdGrupo = 1, Titulo = "PRODUÇÃO FLORESTAL - FLORESTAS NATIVAS"},
                new TipoLista { IdGrupo = 1, Titulo = "ATIVIDADES DE APOIO À PRODUÇÃO FLORESTAL"},
                new TipoLista { IdGrupo = 1, Titulo = "PESCA EM ÁGUA SALGADA"},
                new TipoLista { IdGrupo = 1, Titulo = "PESCA EM ÁGUA DOCE"},
                new TipoLista { IdGrupo = 1, Titulo = "AQUICULTURA EM ÁGUA SALGADA E SALOBRA"},
                new TipoLista { IdGrupo = 1, Titulo = "AQUICULTURA EM ÁGUA DOCE"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE CARVÃO MINERAL"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE PETRÓLEO E GÁS NATURAL"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE FERRO"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE ALUMÍNIO"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE ESTANHO"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE MANGANÊS"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE METAIS PRECIOSOS"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINERAIS RADIOATIVOS"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINERAIS METÁLICOS NÃO FERROSOS NÃO ESPECIFICADOS ANTERIORMENTE"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE PEDRA, AREIA E ARGILA"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINERAIS PARA FABRICAÇÃO DE ADUBOS, FERTILIZANTES E OUTROS PRODUTOS QUÍMICOS"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO E REFINO DE SAL MARINHO E SAL-GEMA"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE GEMAS (PEDRAS PRECIOSAS E SEMIPRECIOSAS"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINERAIS NÃO METÁLICOS NÃO ESPECIFICADOS ANTERIORMENTE"},
                new TipoLista { IdGrupo = 2, Titulo = "ATIVIDADES DE APOIO À EXTRAÇÃO DE PETRÓLEO E GÁS NATURAL"},
                new TipoLista { IdGrupo = 2, Titulo = "ATIVIDADES DE APOIO À EXTRAÇÃO DE MINERAIS, EXCETO PETRÓLEO E GÁS NATURAL"},
                new TipoLista { IdGrupo = 3, Titulo = "ABATE DE RESES, EXCETO SUÍNOS"},
                new TipoLista { IdGrupo = 3, Titulo = "ABATE DE SUÍNOS, AVES E OUTROS PEQUENOS ANIMAIS"},
                new TipoLista { IdGrupo = 3, Titulo = "FABRICAÇÃO DE PRODUTOS DE CARNE"},
                new TipoLista { IdGrupo = 3, Titulo = "PRESERVAÇÃO DO PESCADO E FABRICAÇÃO DE PRODUTOS DO PESCADO"},
                new TipoLista { IdGrupo = 3, Titulo = "FABRICAÇÃO DE CONSERVAS DE FRUTAS"},
                new TipoLista { IdGrupo = 3, Titulo = "FABRICAÇÃO DE CONSERVAS DE LEGUMES E OUTROS VEGETAIS"},
                new TipoLista { IdGrupo = 3, Titulo = "FABRICAÇÃO DE SUCOS DE FRUTAS, HORTALIÇAS E LEGUMES"},
            };

            // Lista de grupo listaSubclasse, divisão de Id's e títulos.
            List<TipoLista> listaSubclasse = new List<TipoLista>
            {
                new TipoLista { IdGrupo = 1, Titulo = "CRIAÇÃO DE OSTRAS E MEXILHÕES EM ÁGUA SALGADA E SALOBRA"},
                new TipoLista { IdGrupo = 1, Titulo = "CRIAÇÃO DE PEIXES ORNAMENTAIS EM ÁGUA SALGADA E SALOBRA"},
                new TipoLista { IdGrupo = 1, Titulo = "ATIVIDADES DE APOIO À AQUICULTURA EM ÁGUA SALGADA E SALOBRA"},
                new TipoLista { IdGrupo = 1, Titulo = "CULTIVOS E SEMICULTIVOS DA AQUICULTURA EM ÁGUA SALGADA E SALOBRA NÃO ESPECIFICADOS ANTERIORMENTE"},
                new TipoLista { IdGrupo = 1, Titulo = "CRIAÇÃO DE PEIXES EM ÁGUA DOCE"},
                new TipoLista { IdGrupo = 1, Titulo = "CRIAÇÃO DE CAMARÕES EM ÁGUA DOCE"},
                new TipoLista { IdGrupo = 1, Titulo = "CRIAÇÃO DE OSTRAS E MEXILHÕES EM ÁGUA DOCE"},
                new TipoLista { IdGrupo = 1, Titulo = "CRIAÇÃO DE PEIXES ORNAMENTAIS EM ÁGUA DOCE"},
                new TipoLista { IdGrupo = 1, Titulo = "RANICULTURA"},
                new TipoLista { IdGrupo = 1, Titulo = "CRIAÇÃO DE JACARÉ"},
                new TipoLista { IdGrupo = 1, Titulo = "ATIVIDADES DE APOIO À AQUICULTURA EM ÁGUA DOCE"},
                new TipoLista { IdGrupo = 1, Titulo = "CULTIVOS E SEMICULTIVOS DA AQUICULTURA EM ÁGUA DOCE NÃO ESPECIFICADOS ANTERIORMENTE"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE CARVÃO MINERAL"},
                new TipoLista { IdGrupo = 2, Titulo = "BENEFICIAMENTO DE CARVÃO MINERAL"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE PETRÓLEO E GÁS NATURAL"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO E BENEFICIAMENTO DE XISTO"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO E BENEFICIAMENTO DE AREIAS BETUMINOSAS"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE FERRO"},
                new TipoLista { IdGrupo = 2, Titulo = "PELOTIZAÇÃO, SINTERIZAÇÃO E OUTROS BENEFICIAMENTOS DE MINÉRIO DE FERRO"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE ALUMÍNIO"},
                new TipoLista { IdGrupo = 2, Titulo = "BENEFICIAMENTO DE MINÉRIO DE ALUMÍNIO"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE ESTANHO"},
                new TipoLista { IdGrupo = 2, Titulo = "BENEFICIAMENTO DE MINÉRIO DE ESTANHO"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE MANGANÊS"},
                new TipoLista { IdGrupo = 2, Titulo = "BENEFICIAMENTO DE MINÉRIO DE MANGANÊS"},
                new TipoLista { IdGrupo = 2, Titulo = "EXTRAÇÃO DE MINÉRIO DE METAIS PRECIOSOS"},
                new TipoLista { IdGrupo = 2, Titulo = "BENEFICIAMENTO DE MINÉRIO DE METAIS PRECIOSOS"},
            };

            // Adição de ponto a cada lista segundo o tipo.
            TratarTabelas(listaGrupo, 5);
            TratarTabelas(listaClasse, 10);
            TratarTabelas(listaSubclasse, 15);

            _tabelaFinal = RanquearPontosEmCategorias(_tabelaFinal).OrderByDescending(pt => pt.Pontos).ToList();

            System.Console.WriteLine(_tabelaFinal);

            foreach (var item in _tabelaFinal)
            {
               Console.WriteLine(String.Format("|{0,25}|{1,5}|{2,5}|", item.Palavra, item.Grupo, item.Pontos));
            }
        }
        
        ///<summary>Função utilizada para fazer tratamento nas listas.</summary>
        ///<param name="listas">É uma lista criada à partir da retirada de palavras da lista negra.</param>
        ///<param name="pontos">Quantidade de pontos atribuída a relação grupo e palavras da classe PalavraGrupoPontuacao.</param>
        ///<returns>Tabelas de listas com os devidos tratamentos realizados.</returns>
        static void TratarTabelas(List<TipoLista> listas, int pontos)
        {
            foreach (TipoLista lista in listas)
            {
                lista.Titulo = RetirarSinais(lista.Titulo);

                string[] palavras = DividirEmPalavras(lista.Titulo);

                string[] listaFiltrada = RetirarListaNegra(palavras);

                foreach (string palavra in listaFiltrada)
                {
                    PalavraGrupoPontuacao item = new PalavraGrupoPontuacao
                    {
                        Palavra = palavra.ToUpper(),
                        Grupo = lista.IdGrupo,
                        Pontos = pontos
                    };
                    _tabelaFinal.Add(item);
                }
            }
        }

        ///<summary>Função utilizada para converter Strings em arrays.</summary>
        ///<param name="palavra">Variável do tipo PalavraGrupoPontuacao utilizada para armazenar os títulos das listas.</param>
        ///<returns>Retorna um array de palavras separadas, linha-a-linha.</returns>
        static string[] DividirEmPalavras(string palavra)
        {
            return palavra.Split(' ');
        }

        ///<summary>Função utilizada para retirar sinais de pontuação predefinidos, nos títulos das listas.</summary>
        ///<param name="palavra">Variável do tipo PalavraGrupoPontuacao utilizada para armazenar os títulos das listas.</param>
        ///<returns>Retorna um array de palavras separadas, linha-a-linha, sem os sinais de pontuação.</returns>
        static string RetirarSinais(string palavra)
        {
            return palavra.Replace(";", "").Replace(",", "").Replace(".", "").Replace(")", "").Replace("(", "").Replace("_", "").Replace(" -", "");
        }
       
        ///<summary>Função utilizada para retirar palavras já pré-definidas.</summary>
        ///<param name="entrada">Variável do tipo array de strings.</param>
        ///<returns>Retorna uma nova lista tipo array sem as palavras da lista negra.</returns>       
        static string[] RetirarListaNegra(string[] entrada)
        {
            List<string> lista = new List<string>();
            foreach (string palavra in entrada)
            {
                if (!_listaNegra.Any(bl => bl.ToUpper() == palavra.ToUpper()))
                    lista.Add(palavra);
            }
            return lista.ToArray();
        }

        ///<summary>Função utilizada para ranquear os pontos com base nas palavras e no pontos.</summary>
        ///<param name="entrada">Variável do tipo PalavraGrupoPontuacao.</param>
        ///<returns>Retorna uma nova lista lista de elementos mais buscados na pesquisa.</returns>       
        static List<PalavraGrupoPontuacao> RanquearPontosEmCategorias(List<PalavraGrupoPontuacao> entrada)
        {
            List<PalavraGrupoPontuacao> listaDeElementos = new List<PalavraGrupoPontuacao>();
            foreach (var elemento in _tabelaFinal)
            {
                var le = listaDeElementos.FirstOrDefault(le => le.Palavra == elemento.Palavra && le.Grupo == elemento.Grupo);
                if (le == null)
                    listaDeElementos.Add
                    (
                        new PalavraGrupoPontuacao
                        {
                            Palavra = elemento.Palavra,
                            Grupo = elemento.Grupo,
                            Pontos = elemento.Pontos
                        }
                    );
                else
                    le.Pontos += elemento.Pontos;
            }
            return listaDeElementos;
        } 
    } 
}





