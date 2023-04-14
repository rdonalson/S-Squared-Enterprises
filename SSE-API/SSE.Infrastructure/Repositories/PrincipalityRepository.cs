using Microsoft.EntityFrameworkCore;
using SSE.Data.Context;
using SSE.Data.Domain;
using SSE.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSE.Infrastructure.Repositories
{
	public class PrincipalityRepository : IPrincipalityRepository
	{
		private readonly SSEContext _context;

		public PrincipalityRepository(SSEContext context)
		{
			_context = context;
		}

		public async Task<List<Principality>> GetPrincipalities()
		{
			try
			{
				return await _context.Principalities.ToListAsync();
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}
	}
}
