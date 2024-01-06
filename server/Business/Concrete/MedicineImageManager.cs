using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Results;
using DataAccess.Abstract;
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
    public class MedicineImageManager : IMedicineImageService
    {
        private readonly IMedicineImageDal _medicineImageDal;
        private readonly IFileHelper _fileHelper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MedicineImageManager(IFileHelper fileHelper, IMedicineImageDal medicineImageDal, IHttpContextAccessor httpContextAccessor)
        {
            _fileHelper = fileHelper;
            _medicineImageDal = medicineImageDal;
            _httpContextAccessor = httpContextAccessor;
        }

        public IResult Add(IFormFile file, int id)
        {

            MedicineImage medicineImage = new MedicineImage();
            medicineImage.ImagePath = _fileHelper.Upload(file, PathConstants.ImagesMedicinePath);
            medicineImage.MedicineId = id;
            _medicineImageDal.Add(medicineImage);
            return new SuccessResult(Messages.MedicineImageAdded);
        }

        public IResult Delete(int id)
        {
            var result = _medicineImageDal.Get(m => m.Id == id);
            if (result != null)
            {
                _fileHelper.Delete(PathConstants.ImagesMedicinePath + result.ImagePath);
                _medicineImageDal.Delete(result);
                return new SuccessResult(Messages.MedicineImageDelete);
            }
            else
            {
                return new ErrorResult(Messages.MedicineImageNotDelete);
            }
        }

        public IDataResult<List<MedicineImage>> GetAll()
        {
            var images = _medicineImageDal.GetAll();

            images.ForEach(image =>
            {
               
                string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                image.ImagePath = $"{baseUrl}/{PathConstants.ImagesMedicinePath}{image.ImagePath}";
            });

            return new DataResult<List<MedicineImage>>(images, true, Messages.MedicineImageListed);
        }


        public IDataResult<List<MedicineImage>> GetId(int id)
        {
            var result = BusinessRules.Run(CheckImage(id));
            if (result != null)
            {
                return new ErrorDataResult<List<MedicineImage>>(GetDefaultImage(id).Data, false, Messages.ImageNotFound);
            }
            return new DataResult<List<MedicineImage>>(_medicineImageDal.GetAll(m => m.MedicineId == id), true, Messages.MedicineImageListed);
        }

        public IDataResult<List<MedicineImage>> GetById(int id)
        {
            var result = BusinessRules.Run(CheckImage(id));
            if (result != null)
            {
                return new ErrorDataResult<List<MedicineImage>>(GetDefaultImage(id).Data, false, Messages.ImageNotFound);
            }

            var images = _medicineImageDal.GetAll(m => m.MedicineId == id);
            images.ForEach(image =>
            {
                string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
                image.ImagePath = $"{baseUrl}/{PathConstants.ImagesMedicinePath}{image.ImagePath}";
            });

            return new DataResult<List<MedicineImage>>(images, true, Messages.MedicineImageListed);
        }

            public IResult Update(IFormFile file, int id)
        {
            var result = _medicineImageDal.Get(m => m.Id == id);
            if (result != null)
            {
                result.ImagePath = _fileHelper.Update(file, PathConstants.ImagesMedicinePath + result.ImagePath, PathConstants.ImagesMedicinePath);
                _medicineImageDal.Update(result);
                return new SuccessResult(Messages.MedicineImageUpdate);
            }
            return new ErrorResult(Messages.MedicineImageNotUpdate);
        }

        private IResult CheckImage(int Id)
        {
            var result = _medicineImageDal.GetAll(m => m.MedicineId == Id).Count;
            if (result > 0)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.ImageNotFound);
        }

        private IDataResult<List<MedicineImage>> GetDefaultImage(int id)
        {
            string baseUrl = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}";
            string defaultImageUrl = $"{baseUrl}/{PathConstants.ImagesMedicinePath}{"DefaultImage.jpg"}";
            List<MedicineImage> medicineImage = new List<MedicineImage>
    {
        new MedicineImage { MedicineId = id, ImagePath = defaultImageUrl }
    };

            return new SuccessDataResult<List<MedicineImage>>(medicineImage);
        }


    }
}
