using System;
using System.Collections.Generic;
using System.Linq;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {
        public List<Pessoa> Hospedes { get; set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; set; }

        public Reserva() { }

        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
        }

        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            // Verifica se a suíte foi cadastrada
            if (Suite == null)
            {
                throw new InvalidOperationException("A suíte deve ser cadastrada antes de adicionar os hóspedes.");
            }

            // Verifica se a capacidade da suíte é maior ou igual ao número de hóspedes
            if (Suite.Capacidade >= hospedes.Count)
            {
                Hospedes = hospedes;
            }
            else
            {
                // Lança uma exception caso a capacidade seja menor que o número de hóspedes
                throw new Exception($"A capacidade da suíte ({Suite.Capacidade}) é menor que o número de hóspedes ({hospedes.Count}).");
            }
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            // Retorna a quantidade de hóspedes (propriedade Hospedes)
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            // Calcula o valor total da diária
            // Cálculo: DiasReservados * Suite.ValorDiaria
            decimal valorTotal = DiasReservados * Suite.ValorDiaria;

            // Regra: Caso os dias reservados sejam maior ou igual a 10, conceder um desconto de 10%
            if (DiasReservados >= 10)
            {
                decimal desconto = valorTotal * 0.10m; // 10% de desconto
                valorTotal -= desconto;
            }

            return valorTotal;
        }
    }
}