using Microsoft.AspNetCore.Mvc;
using SSE.Data.Context;
using SSE.Infrastructure.Interfaces;
using SSE.Infrastructure.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SSE.Web.Controllers.Principality
{
	[Route("api/[controller]")]
	[ApiController]
	public class PrincipalitiesController : ControllerBase
	{
		private readonly IPrincipalityRepository _principalityRepository;

		public PrincipalitiesController(SSEContext context)
		{
			_principalityRepository = new PrincipalityRepository(context);
		}

		public async Task<ActionResult<List<Data.Domain.Principality>>> GetEmployees()
		{
			return await _principalityRepository.GetPrincipalities();
		}
	}
}
