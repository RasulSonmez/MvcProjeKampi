﻿using BusinessLayer.Absract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imafefileDal;

        public ImageFileManager(IImageFileDal imafefileDal)
        {
            _imafefileDal = imafefileDal;
        }

        public List<ImageFile> GetList()
        {
            return _imafefileDal.List();
        }
    }
}
