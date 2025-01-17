﻿using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using FinalPRN3.Models;

namespace FinalPRN3.Common
{
    public class PhotoManager
    {
        public IConfiguration Configuration { get; }
        private CloudinarySettings setting;
        private Cloudinary cloundinary;
        private lovetientdContext context;

        public PhotoManager(IConfiguration configuration, lovetientdContext context)
        {
            this.context = context;
            Configuration = configuration;
            setting = Configuration.GetSection("CloudinarySettings").Get<CloudinarySettings>();
            Account account = new Account(setting.CloudName,
                setting.ApiKey,
                setting.ApiSecret);
            cloundinary = new Cloudinary(account);
        }

        //public Image UploadImage(IFormFile inputFile)
        //{
        //    Image returnImg = new Image();

        //    var result = new ImageUploadResult();
        //    if (inputFile.Length > 0)
        //    {
        //        using (var stream = inputFile.OpenReadStream())
        //        {
        //            var param = new ImageUploadParams()
        //            {
        //                File = new FileDescription(inputFile.Name, stream)
        //            };

        //            result = cloundinary.Upload(param);
        //        }
        //    }

        //    returnImg.Url = result.Uri.ToString();

        //    context.Images.Add(returnImg);
        //    context.SaveChanges();

        //    return returnImg;
        //}
    }
}
