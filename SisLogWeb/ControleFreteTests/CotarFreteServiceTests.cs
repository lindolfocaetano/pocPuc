using ControleFreteApi.Data;
using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Repository;
using ControleFreteApi.Domain.Interface;
using ControleFreteApi.Domain.Services;
using ControleFreteApi.Dto;
using ControleFreteTests.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CotarFreteServiceTests
{
    [TestClass]
    public class CotarFreteServiceTests
    {


        private ICotarFreteService _cotarFreteService;
        private IUnitOfWork _unitOfWork;
        private ServiceProvider _provider;


        [TestInitialize]
        public void Init()
        {
            // Create the container builder.
            var servicesColletcion = new ServiceCollection();

            servicesColletcion.AddTransient<IUnitOfWork, UnitOfWork>();
            servicesColletcion.AddDbContext<SisLogFreteContext>(
                options => options.UseSqlServer(@"Server="));
            servicesColletcion.AddTransient<ICotarFreteService, CotarFreteService>();

            _provider = servicesColletcion.BuildServiceProvider();
            _unitOfWork = _provider.GetService<IUnitOfWork>();
            _cotarFreteService = _provider.GetService<ICotarFreteService>();

            _unitOfWork.BaseFretes.RemoveRange(_unitOfWork.BaseFretes.GetAll());
            _unitOfWork.OrigemDestinos.RemoveRange(_unitOfWork.OrigemDestinos.GetAll());
            _unitOfWork.Cidades.RemoveRange(_unitOfWork.Cidades.GetAll());
            _unitOfWork.Commit();

        }
        [TestCleanup]
        public void CleanUp()
        {
            _unitOfWork.BaseFretes.RemoveRange(_unitOfWork.BaseFretes.GetAll());
            _unitOfWork.OrigemDestinos.RemoveRange(_unitOfWork.OrigemDestinos.GetAll());
            _unitOfWork.Cidades.RemoveRange(_unitOfWork.Cidades.GetAll());
            _unitOfWork.Commit();

        }

        [TestMethod]
        public void Valor1kTests()
        {
            _unitOfWork.BaseFretes.RemoveRange(_unitOfWork.BaseFretes.GetAll());
            _unitOfWork.OrigemDestinos.RemoveRange(_unitOfWork.OrigemDestinos.GetAll());
            _unitOfWork.Cidades.RemoveRange(_unitOfWork.Cidades.GetAll());
            _unitOfWork.Commit();
            var cidades = new CidadeBuilder().Cidades();
            var od = new OrigemDestinoBuilder().ODGoianiaAparecida();
            var baseFrete = new BaseFreteBuilder().BaseFreteGoianiaAparecida(od.IdOrigemDestino);
            _unitOfWork.Cidades.AddRange(cidades);
            _unitOfWork.OrigemDestinos.Add(od);
            _unitOfWork.BaseFretes.Add(baseFrete);
            _unitOfWork.Commit();

            var cotacao = new CotarFreteDto
            {
                IdCidadeOrigem = od.IdCidadeOrigem,
                IdCidadeDestino = od.IdCidadeDestino,
                Email = "",
                Peso = 1000
            };

            var frete = _cotarFreteService.GetValorFrete(cotacao);
            Assert.IsTrue(frete.VlFrete == 1150);
        }

        [TestMethod]
        public void Valor10KilosTests()
        {
            var cidades = new CidadeBuilder().Cidades();
            var od = new OrigemDestinoBuilder().ODGoianiaAparecida();
            var baseFrete = new BaseFreteBuilder().BaseFreteGoianiaAparecida(od.IdOrigemDestino);
            _unitOfWork.Cidades.AddRange(cidades);
            _unitOfWork.OrigemDestinos.Add(od);
            _unitOfWork.BaseFretes.Add(baseFrete);
            _unitOfWork.Commit();

            var cotacao = new CotarFreteDto
            {
                IdCidadeOrigem = od.IdCidadeOrigem,
                IdCidadeDestino = od.IdCidadeDestino,
                Email = "",
                Peso = 10
            };

            var frete = _cotarFreteService.GetValorFrete(cotacao);
            Assert.IsTrue(frete.VlFrete == 11.50);
        }
    }
}
