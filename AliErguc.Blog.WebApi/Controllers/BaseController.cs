using AliErguc.Blog.WebApi.Enums;
using AliErguc.Blog.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AliErguc.Blog.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [NonAction]
        public async Task<UploadModel> UploadFileAsync(IFormFile file,string contentType)
        {
            UploadModel uploadModel = new UploadModel();
            if (file != null)
            {
                if (file.ContentType != contentType)
                {
                    uploadModel.ErrorMessage = "Uyumsuz dosya !";
                    uploadModel.UploadState = UploadState.Error;
                    return uploadModel;
                }
                else
                {
                    var newName = Guid.NewGuid() + Path.GetExtension(file.FileName);
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/" + newName);
                    var stream = new FileStream(path, FileMode.Create);
                    await file.CopyToAsync(stream);

                    uploadModel.NewName = newName;
                    uploadModel.UploadState = UploadState.Success;
                    return uploadModel;
                }
            }
            uploadModel.ErrorMessage = "Dosya Yok. !";
            uploadModel.UploadState = UploadState.NotExists;
            return uploadModel;

        }
    }
}
