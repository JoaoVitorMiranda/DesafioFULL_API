using AutoMapper;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Interfaces.Repository;
using Paschoalotto.Devedor.Domain.Interfaces.Services;
using Paschoalotto.Devedor.Domain.Models;
using Paschoalotto.Devedor.Domain.Models.Database;
using Paschoalotto.Devedor.Domain.Models.Parcela;
using Paschoalotto.Devedor.Domain.Interfaces.UoW;
using System;

namespace Paschoalotto.Devedor.API.Services
{
    public class ParcelaService : ServiceBase, IParcelaService
    {
        private readonly IParcelaRepository _parcelaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ParcelaService(IParcelaRepository parcelaRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _parcelaRepository = parcelaRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ParcelaModel>> GetAllByDevedorId(int idDevedor)
        {
            return _mapper.Map<IEnumerable<ParcelaModel>>(await _parcelaRepository.GetAllByDevedorId(idDevedor));
        }

        public async Task<ParcelaModel> Post(ParcelaAddModel model)
        {

            Domain.Models.Database.Parcela dbParcela = _mapper.Map<Domain.Models.Database.Parcela>(model);
            dbParcela.Valor = Convert.ToDecimal(model.Valor, new CultureInfo("pt-BR"));
          

            _parcelaRepository.Add(dbParcela);
            _unitOfWork.Commit();

            return await this.GetById(dbParcela.Id);
        }

        public async Task<ParcelaModel> GetById(int id)
        {
            Domain.Models.Database.Parcela dbParcela = await _parcelaRepository.GetById(id);
            if (dbParcela == null)
            {
                AddNotification(HttpStatusCode.NotFound.ToString(), "Parcela não encontrada");
                return null;
            }

            ParcelaModel parcela = _mapper.Map<ParcelaModel>(dbParcela);
            return parcela;
        }
    }
}
