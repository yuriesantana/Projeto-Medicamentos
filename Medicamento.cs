using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjetoMedicamentos
{
    public class Medicamento
    {
        private int id;
        private string nome;
        private string laboratorio;
        private Queue<Lote> lotes;

        public int Id { get => id; set => id = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Laboratorio { get => laboratorio; set => laboratorio = value; }
        public Queue<Lote> Lotes { get => lotes; }

        public Medicamento() : this(0, "", "") { }

        public Medicamento(int id, string nome, string laboratorio)
        {
            this.id = id;
            this.nome = nome;
            this.laboratorio = laboratorio;
            this.lotes = new Queue<Lote>();
        }

        public int QtdeDisponivel()
        {
            return lotes.Sum(l => l.Qtde);
        }

        public void Comprar(Lote lote)
        {
            lotes.Enqueue(lote);
        }

        public bool Vender(int qtde)
        {
            if (qtde > QtdeDisponivel() || qtde <= 0)
            {
                return false;
            }

            int qtdePendente = qtde;

            while (qtdePendente > 0 && lotes.Count > 0)
            {
                Lote loteAtual = lotes.Peek();

                if (loteAtual.Qtde <= qtdePendente)
                {
                    qtdePendente -= loteAtual.Qtde;
                    lotes.Dequeue(); // Remove o lote zerado
                }
                else
                {
                    loteAtual.Qtde -= qtdePendente;
                    qtdePendente = 0;
                }
            }

            return true;
        }

        public override string ToString()
        {
            return $"{id}-{nome}-{laboratorio}-{QtdeDisponivel()}";
        }

        public override bool Equals(object obj)
        {
            if (obj is Medicamento outro)
            {
                return this.id == outro.id;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return id.GetHashCode();
        }
    }
}
