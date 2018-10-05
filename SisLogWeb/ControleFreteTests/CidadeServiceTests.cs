using ControleFreteApi.Data;
using ControleFreteApi.Data.Interfaces;
using ControleFreteApi.Data.Repository;
using ControleFreteApi.Domain.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ControleFreteApi.Domain.Interface;
using ControleFreteApi.Data.Models;
using ControleFreteTests.Builder;
using ControleFreteApi.Dto;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace CidadeServiceTests
{
    [TestClass]
    public class CidadeServiceTests
    {
        private ICidadeService _cidadeService;
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
            servicesColletcion.AddTransient<ICidadeService, CidadeService>();

            _provider = servicesColletcion.BuildServiceProvider();
            _unitOfWork = _provider.GetService<IUnitOfWork>();
            _cidadeService = _provider.GetService<ICidadeService>();

        }

        [TestCleanup]
        public void CleanUp()
        {
            _unitOfWork.Cidades.RemoveRange(_unitOfWork.Cidades.GetAll());
            _unitOfWork.Commit();
        }

        [TestMethod]
        public void CidadesTest()
        {
            var cidades = new CidadeBuilder().Cidades();
            _unitOfWork.Cidades.AddRange(cidades);
            _unitOfWork.Commit();
            IEnumerable<CidadeDto> getCidade = _cidadeService.GetCidades();
            Assert.IsTrue(getCidade.Select(x => true).Count() == 2);
        }

        [TestMethod]
        public void CidadeTest()
        {
            var cidade = new CidadeBuilder().Cidade();
            _unitOfWork.Cidades.Add(cidade);
            _unitOfWork.Commit();

        }

        [TestMethod]
        public void GetCidadesByListTests()
        {
            //var cidades = new CidadeBuilder().Cidades();
            //_unitOfWork.Cidades.AddRange(cidades);
            List<string> listCidades = new List<string>
            {
                "5208707",
                "5201405"
            };

            var result = _cidadeService.GetCidades(listCidades);
        }
    }
}
