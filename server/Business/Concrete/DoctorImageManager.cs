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
        private readonly IHttpContextAccessor _httpContextAccessor;
        public DoctorImageManager(IFileHelper fileHelper, IDoctorImageDal doctorImageDal, IHttpContextAccessor httpContextAccessor)
        {
            _fileHelper = fileHelper;
            _doctorImageDal = doctorImageDal;
            _httpContextAccessor = httpContextAccessor;
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
            var images = _doctorImageDal.GetAll();

            images.ForEach(image =>
            {

                string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                image.ImagePath = $"{baseUrl}/{PathConstants.ImagesDoctorPath}{image.ImagePath}";
            });

            return new DataResult<List<DoctorImage>>(images, true, Messages.DoctorImageAllListed);
            
        }

        public IDataResult<List<DoctorImage>> GetById(int id)
        {
            var result = BusinessRules.Run(CheckImage(id));
            if (result != null)
            {
                return new ErrorDataResult<List<DoctorImage>>(GetDefaultImage(id).Data, false, Messages.ImageNotFound);
            }

            var images = _doctorImageDal.GetAll(d => d.DoctorId == id);
            images.ForEach(image =>
            {
                string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                image.ImagePath = $"{baseUrl}/{PathConstants.ImagesMedicinePath}{image.ImagePath}";
            });

            return new DataResult<List<DoctorImage>>(images, true, Messages.MedicineImageListed);
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
            string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            string defaultImageUrl = $"{baseUrl}/{PathConstants.ImagesDoctorPath}{"DefaultImage.jpg"}";
            List<DoctorImage> doctorImage = new List<DoctorImage>
    {
        new DoctorImage { DoctorId = id, ImagePath = defaultImageUrl }
    };

            return new SuccessDataResult<List<DoctorImage>>(doctorImage);
        }
    }
}
