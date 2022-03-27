using Arshia_Store.Application.Interfaces.Contexts;
using Arshia_Store.Common.Dto;
using Arshia_Store.Domain.Entities.HomePage;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arshia_Store.Application.Serivces.HomePages.Command.AddNewSlider
{
	public interface IAddNewSliderService
	{
		ResultDto Execute(IFormFile file, string link);
	}

	public class AddNewSliderService : IAddNewSliderService
	{
		private readonly IStoreDbContext _context;
		private readonly IWebHostEnvironment _environment;

		public AddNewSliderService(IStoreDbContext context, IWebHostEnvironment environment)
		{
			_context = context;
			_environment = environment;
		}
		public ResultDto Execute(IFormFile file, string link)
		{
			try
			{
				var resultUpload = UploadFile(file, _environment);

				if(resultUpload.Status == false)
				{
					throw new Exception("Doesn`t upload slider image");
				}

				Slider slider = new Slider()
				{
					Link = link,
					Src = resultUpload.FileNameAddress,
				};

				_context.Sliders.Add(slider);
				_context.SaveChanges();

				return new ResultDto()
				{
					IsSuccess = true,
					Message = "اسلایدر با موفقیت افزوده شد!",
				};
			}
			catch(Exception e)
			{
				return new ResultDto()
				{
					IsSuccess = false,
					Message = e.Message,
				};
			}
		}
		private static UploadDto UploadFile(IFormFile file, IWebHostEnvironment environment)
		{
			if(file != null)
			{
				string folder = $@"images\HomePages\Slider\";
				var uploadsRootFolder = Path.Combine(environment.WebRootPath, folder);
				if(Directory.Exists(uploadsRootFolder) == false)
				{
					Directory.CreateDirectory(uploadsRootFolder);
				}

				if(file == null || file.Length == 0)
				{
					return new UploadDto()
					{
						Status = false,
						FileNameAddress = string.Empty,
					};
				}

				string fileName = DateTime.Now.Ticks.ToString() + file.FileName;
				var filePath = Path.Combine(uploadsRootFolder, fileName);
				using(var fileStream = new FileStream(filePath, FileMode.Create))
				{
					file.CopyTo(fileStream);
				}

				return new UploadDto()
				{
					Status = true,
					FileNameAddress = folder + fileName,
				};
			}
			else
			{
				return new UploadDto()
				{
					Status = false,
					FileNameAddress = string.Empty,
				};
			}
		}
	}


	public class UploadDto
	{
		public bool Status { get; set; }
		public string FileNameAddress { get; set; }
	}
}
