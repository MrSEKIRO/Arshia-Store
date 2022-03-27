using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.HomePages.Queries.GetSlider
{
	public interface IGetSliderService
	{
		ResultDto<List<SliderDto>> Execute();
	}

	public class GetSliderService : IGetSliderService
	{
		private readonly IStoreDbContext _context;

		public GetSliderService(IStoreDbContext context)
		{
			_context = context;
		}
		public ResultDto<List<SliderDto>> Execute()
		{
			try
			{
				var sliders=_context.Sliders.OrderByDescending(s=>s.InsertTime)
					.Select(s=>new SliderDto()
					{
						Link=s.Link,
						Src=s.Src,
					})
					.ToList();

				return new ResultDto<List<SliderDto>>()
				{
					Data = sliders,
					IsSuccess = true,
					Message = "اسلایدر ها با موفقیت ارسال شدند",
				};
			}
			catch(Exception e)
			{
				return new ResultDto<List<SliderDto>>()
				{
					IsSuccess = false,
					Message = e.Message,
					Data = new List<SliderDto>(),
				};
			}
		}
	}

	public class SliderDto
	{
		public string Src { get; set; }
		public string Link { get; set; }
	}
}
