namespace DicPalavras
{
    /// <summary>Representa uma relação pontuada entre uma palavra e um grupo.</summary>
    public class PalavraGrupoPontuacao
    {
        /// <summary>Palavra à qual se refere a pontuação.</summary>
        public string Palavra { get; set; }

        /// <summary>Código de identificação do grupo do CNAE.</summary>
        public int Grupo { get; set; }

        /// <summary>Quantidade de pontos atribuída a relação.</summary>
        public int Pontos{ get; set; }
    }
}