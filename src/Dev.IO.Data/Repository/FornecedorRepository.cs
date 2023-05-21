using Dev.IO.Business.Interfaces.Repository;
using Dev.IO.Data.Context;
using DevIO.Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dev.IO.Data.Repository
{
    public class FornecedorRepository : Repository<Fornecedor>, IFornecedorRepository
    {
        public FornecedorRepository(MeuDbContext context) : base(context) { }

        public async Task<Fornecedor> ObterFornecedorEndereco(Guid id) =>
            await Db.Fornecedores.AsNoTracking().Include(f => f.Endereco)
            .FirstOrDefaultAsync(f => f.Id == id);

        public async Task<Fornecedor> ObterFornecedorProdutosEndereco(Guid id) =>
            await Db.Fornecedores.AsNoTracking()
            .Include(f => f.Produtos)
            .Include(f => f.Endereco)
            .FirstOrDefaultAsync(n => n.Id == id);
    }
}
