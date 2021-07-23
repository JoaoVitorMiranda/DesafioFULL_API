using AutoMapper;
using System.Collections.Generic;
using System.Globalization;
using System.Net;
using System.Threading.Tasks;
using Paschoalotto.Devedor.Domain.Interfaces.Repository;
using Paschoalotto.Devedor.Domain.Interfaces.Services;
using Paschoalotto.Devedor.Domain.Models;
using Paschoalotto.Devedor.Domain.Models.Database;
using Paschoalotto.Devedor.Domain.Models.Devedor;
using Paschoalotto.Devedor.Domain.Interfaces.UoW;
using System;
using Paschoalotto.Devedor.Domain.Models.Parcela;

namespace Paschoalotto.Devedor.API.Services
{
    public class DevedorService : ServiceBase, IDevedorService
    {

        private readonly IDevedorRepository _devedorRepository;
        private readonly IParcelaRepository _parcelaRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;


        public DevedorService(IDevedorRepository devedorRepository, IUnitOfWork unitOfWork, IMapper mapper, IParcelaRepository parcelaRepository)
        {
            _devedorRepository = devedorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _parcelaRepository = parcelaRepository;
        }

        public async Task<IEnumerable<DevedorModel>> GetAllAsync()
        {
            var devedores = _mapper.Map<IEnumerable<DevedorModel>>(await _devedorRepository.GetAllAsync());

            foreach (var d in devedores)
            {
                var parcela = _mapper.Map<IEnumerable<ParcelaModel>>(await _parcelaRepository.GetAllByDevedorId(d.Id));
                d.Parcela = new List<ParcelaModel>();
                d.Parcela.AddRange(parcela);
            }
            return devedores;
        }

        public async Task<DevedorModel> Post(DevedorModel model)
        {
            Domain.Models.Database.Devedor dbDevedor = _mapper.Map<Domain.Models.Database.Devedor>(model);

            _devedorRepository.Add(dbDevedor);
            _unitOfWork.Commit();

            return _mapper.Map<DevedorModel>(dbDevedor);
        }
    }
}
