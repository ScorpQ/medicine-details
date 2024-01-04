using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IResult = Core.Utilities.Results.IResult;

namespace Business.Concrete
{
    public class DoctorImageManager : IDoctorImageService
    {
        private readonly IDoctorImageDal _doctorImageDal;
        private readonly IFileHelper _fileHelper;

        public DoctorImageManager(IFileHelper fileHelper, IDoctorImageDal doctorImageDal)
        {
            _fileHelper = fileHelper;
            _doctorImageDal = doctorImageDal;
        }
        public IResult Add(IFormFile file, int id)
        {
            DoctorImage doctorImage = new DoctorImage();
            doctorImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesDoctorPath);
            doctorImage.Id = id;
            _doctorImageDal.Add(doctorImage);
            return new SuccessResult(Messages.DoctorImageAdded);
        }

        public IResult Delete(int id)
        {
            var result = _doctorImageDal.Get(d => d.Id == id);
            if (result != null)
            {
                _fileHelper.Delete(PathConstants.ImagesDoctorPath + result.ImagePath);
                _doctorImageDal.Delete(result);
                return new SuccessResult(Messages.DoctorImageDelete);
            }
            else
            {
                return new ErrorResult(Messages.DoctorImageNotDelete);
            }
        }

        public IDataResult<List<DoctorImage>> GetAll()
        {
            return new DataResult<List<DoctorImage>>(_doctorImageDal.GetAll(), true, Messages.DoctorImageAllListed);
        }

        public IDataResult<List<DoctorImage>> GetId(int id)
        {
            var result = BusinessRules.Run(CheckImage(id));
            if (result != null)
            {
                return new ErrorDataResult<List<DoctorImage>>(GetDefaultImage(id).Data, false, Messages.ImageNotFound);
            }
            return new DataResult<List<DoctorImage>>(_doctorImageDal.GetAll(d => d.DoctorId == id), true, Messages.DoctorImageListed);
        }

        public IResult Update(IFormFile file, int id)
        {
            var result = _doctorImageDal.Get(d => d.Id == id);
            if (result != null)
            {
                result.ImagePath = _fileHelper.Update(file, PathConstants.ImagesDoctorPath + result.ImagePath, PathConstants.ImagesDoctorPath);
                _doctorImageDal.Update(result);
                return new SuccessResult(Messages.DoctorImageUpdate);
            }
            return new ErrorResult(Messages.DoctorImageNotUpdate);
        }

        private IResult CheckImage(int Id)
        {
            var result = _doctorImageDal.GetAll(d => d.DoctorId == Id).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ImageNotFound);
        }

        private IDataResult<List<DoctorImage>> GetDefaultImage(int id)
        {
            List<DoctorImage> doctorImage = new List<DoctorImage>();
            doctorImage.Add(new DoctorImage { DoctorId = id, ImagePath = "DefaultImage.jpg" });
            return new SuccessDataResult<List<DoctorImage>>(doctorImage);
        }
    }
}
