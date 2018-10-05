using ControleFreteApi.Data;
using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Models;
using ControleFreteApi.Data.Repository;
using ControleFreteApi.Domain.Interface;
using ControleFreteApi.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFreteApi.Domain.Services
{

    public class CotarFreteService : ICotarFreteService
    {
        private IUnitOfWork _unitOfWork;
        private double _valorFinalFrete;

        public CotarFreteService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public ValorFreteDto GetValorFrete(CotarFreteDto cotacao)
        {
            var oD = _unitOfWork.OrigemDestinos.GetByOrigemDestino(cotacao.IdCidadeOrigem, cotacao.IdCidadeDestino);
            var vlBaseFrete = _unitOfWork.BaseFretes.GetByOrigemDestino(oD.IdOrigemDestino).VlBase;
            FreteCliente cliente = _unitOfWork.FreteClientes.GetByEmail(cotacao.Email);
            cotacao.Cubagem = cotacao.Altura * cotacao.Largura * cotacao.Comprimento;

            if (cliente != null)
            {
                _valorFinalFrete = FreteComDesconto(cotacao, cliente, vlBaseFrete);
            }
            else
            {
                _valorFinalFrete = FreteSemDesconto(cotacao, vlBaseFrete);
            }

            var retorno = new ValorFreteDto
            {
                IdCidadeDestino = cotacao.IdCidadeDestino,
                IdCidadeOrigem = cotacao.IdCidadeOrigem,
                DtCotacao = DateTime.Now,
                PzEstimadoEntrega = 8,
                VlFrete = _valorFinalFrete,
                Cubagem = cotacao.Cubagem,
                Peso = cotacao.Peso,
                Altura = cotacao.Altura,
                Comprimento = cotacao.Comprimento,
                Largura = cotacao.Largura
                
            };

            return retorno;
        }

        private double FreteComDesconto(CotarFreteDto cotacao, FreteCliente cliente, decimal valorFrete)
        {
            if (cotacao.Cubagem * 300 < cotacao.Peso)
            {
                return System.Convert.ToDouble(valorFrete * (decimal)cliente.VlDesconto * ((decimal)cotacao.Peso / 1000));
            }
            else
            {
                return System.Convert.ToDouble(valorFrete * (decimal)cliente.VlDesconto * (((decimal)cotacao.Cubagem * 300) / 1000));
            }
        }

        private double FreteSemDesconto(CotarFreteDto cotacao, decimal valorFrete)
        {
            if (cotacao.Cubagem * 300 < cotacao.Peso)
            {
                return System.Convert.ToDouble(valorFrete * ((decimal)cotacao.Peso / 1000));
            }
            else
            {
                return System.Convert.ToDouble(valorFrete * (((decimal)cotacao.Cubagem * 300) / 1000));
            }
        }

    }
}
