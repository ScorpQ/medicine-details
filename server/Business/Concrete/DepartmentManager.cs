using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DepartmentManager : IDepartmentService
    {
        private readonly IDepartmentDal _departmentDal;

        public DepartmentManager(IDepartmentDal departmentDal)
        {
            _departmentDal = departmentDal;
        }
        public IResult Add(Department department)
        {
            _departmentDal.Add(department);
            return new SuccessResult(Messages.DepartmentAdded);
        }

        public IResult Delete(int id)
        {
            var department = _departmentDal.Get(d => d.Id == id);
            if (department != null)
            {
                _departmentDal.Delete(department);
                return new SuccessResult(Messages.DepartmentDelete);
            }
            else
            {
                return new ErrorResult(Messages.DepartmentNotDelete);
            }
        }

        public IDataResult<List<Department>> GetAll()
        {
            return new DataResult<List<Department>>(_departmentDal.GetAll(), true, Messages.DepartmentGetAll);
        }

        public IDataResult<Department> GetById(int id)
        {
            return new DataResult<Department>(_departmentDal.Get(d => d.Id == id), true, Messages.DepartmentListedById);
        }

        public IResult Update(Department department)
        {
            _departmentDal.Update(department);
            return new SuccessResult(Messages.DepartmentUpdated);
        }
    }
}

