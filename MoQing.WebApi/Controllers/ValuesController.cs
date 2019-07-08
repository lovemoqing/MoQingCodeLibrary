using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MoQing.Application.FileService;
using MoQing.Domain;

namespace MoQing.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IFileService _fileService;
        private readonly IMapper _mapper;
        public ValuesController(IFileService fileService, IMapper mapper)
        {
            _fileService = fileService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult<string> Post(FileInfoDto model)
        {
            var user = _mapper.Map<FileInfo>(model); //映射
            return _fileService.GetName() + "|" + user.Name;
        }
    }
}
