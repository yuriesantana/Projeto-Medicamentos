using System.Collections.Generic;

namespace ProjetoMedicamentos
{
    public class Medicamentos
    {
        private List<Medicamento> listaMedicamentos;

        public List<Medicamento> ListaMedicamentos => listaMedicamentos;

        public Medicamentos()
        {
            listaMedicamentos = new List<Medicamento>();
        }

        public void Adicionar(Medicamento medicamento)
        {
            listaMedicamentos.Add(medicamento);
        }

        public bool Deletar(Medicamento medicamento)
        {
            Medicamento medEncontrado = Pesquisar(medicamento);
            
            if (medEncontrado.Id != 0 && medEncontrado.QtdeDisponivel() == 0)
            {
                return listaMedicamentos.Remove(medEncontrado);
            }
            
            return false;
        }

        public Medicamento Pesquisar(Medicamento medicamento)
        {
            foreach (var med in listaMedicamentos)
            {
                if (med.Equals(medicamento))
                {
                    return med;
                }
            }
            return new Medicamento(); // Objeto vazio caso não encontre
        }
    }
}
