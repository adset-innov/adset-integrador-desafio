using ADSET.Domain.Interfaces;
using ADSET.Domain.Interfaces.Repositories;
using ADSET.Infra.Repositories;

namespace ADSET.Infra.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public readonly SqlContext _context;

        public UnitOfWork(SqlContext context) => _context = context;

        private IVeiculoRepository _veiculoRepository;
        private IMarcaRepository _marcaRepository;
        private IModeloRepository _modeloRepository;
        private IFotoRepository _fotoRepository;
        private IOpcionalRepository _opcionalRepository;
        private IPacoteRepository _pacoteRepository;

        public IVeiculoRepository VeiculoRepository
        {
            get
            {
                if (_veiculoRepository == null)
                    _veiculoRepository = new VeiculoRepository(_context);

                return _veiculoRepository;
            }
        }

        public IMarcaRepository MarcaRepository
        {
            get
            {
                if (_marcaRepository == null)
                    _marcaRepository = new MarcaRepository(_context);

                return _marcaRepository;
            }
        }

        public IModeloRepository ModeloRepository
        {
            get
            {
                if (_modeloRepository == null)
                    _modeloRepository = new ModeloRepository(_context);

                return _modeloRepository;
            }
        }

        public IFotoRepository FotoRepository
        {
            get
            {
                if (_fotoRepository == null)
                    _fotoRepository = new FotoRepository(_context);

                return _fotoRepository;
            }
        }

        public IOpcionalRepository OpcionalRepository
        {
            get
            {
                if (_opcionalRepository == null)
                    _opcionalRepository = new OpcionalRepository(_context);

                return _opcionalRepository;
            }
        }

        public IPacoteRepository PacoteRepository
        {
            get
            {
                if (_pacoteRepository == null)
                    _pacoteRepository = new PacoteRepository(_context);

                return _pacoteRepository;
            }
        }

        public async Task<bool> CommitAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
