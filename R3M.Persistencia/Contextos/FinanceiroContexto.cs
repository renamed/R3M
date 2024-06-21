using Microsoft.EntityFrameworkCore;
using R3M.Persistencia.Interfaces;

namespace R3M.Persistencia.Contextos
{
    public class FinanceiroContexto : DbContext, IFinanceiroContexto
    {
    }
}