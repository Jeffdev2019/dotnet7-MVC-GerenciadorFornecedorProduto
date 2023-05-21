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
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(MeuDbContext context) : base(context) { }
        public async Task<Produto> ObterProdutoFornecedor(Guid id) =>
            await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
            .FirstOrDefaultAsync(p => p.Id == id);

        public async Task<IEnumerable<Produto>> ObterProdutosFornecedor() =>
            await Db.Produtos.AsNoTracking().Include(f => f.Fornecedor)
            .OrderBy(p => p.Nome).ToListAsync();

        public async Task<IEnumerable<Produto>> ObterProdutosPorFornecedor(Guid fornecedorId) =>
            await Buscar(p => p.FornecedorId == fornecedorId);
    }
}
