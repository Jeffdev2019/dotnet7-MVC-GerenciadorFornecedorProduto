using Dev.IO.Business.Interfaces.Repository;
using Dev.IO.Data.Context;
using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.IO.Data.Repository
{
    public class EnderecoRepository : Repository<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(MeuDbContext context) : base(context) { }

        public async Task<Endereco> ObterEnderecoPorFornecedor(Guid fornecedorId) =>
            await Db.Enderecos.AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == fornecedorId);
    }
}
