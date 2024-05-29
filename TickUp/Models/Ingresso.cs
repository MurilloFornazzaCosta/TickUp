using FireSharp;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace TickUp.Models
{

    public class Ingresso : Evento
    {

        private int quantidadeCompra;
        private double valoringresso;

        public int QuantidadeCompra { get => quantidadeCompra; set => quantidadeCompra = value; }
        public double Valoringresso { get => valoringresso; set => valoringresso = value; }

        public Ingresso(string assuntoEvento, string categoriaEvento, string nomeEvento, string emailContato, string observacoes, string horarioInicio, string horarioTermino, string cpf, string email, DateOnly dataInicio, DateOnly dataTermino, int capacidade, byte[] bytesImagem, string nomeLocal, string cep, string rua, string numero, string complemento, string bairro, string estado, string cidade, int quantidadeCompra, double valoringresso) : 
            base(assuntoEvento, categoriaEvento, nomeEvento, emailContato, observacoes, horarioInicio, horarioTermino, cpf, email, dataInicio, dataTermino, capacidade, bytesImagem, nomeLocal, cep, rua, numero, complemento, bairro, estado, cidade)
        {

            this.quantidadeCompra = quantidadeCompra;
            this.valoringresso = valoringresso;

        }



       
    }
}
