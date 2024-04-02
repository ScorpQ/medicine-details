using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Helpers.FileHelper;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Module = Autofac.Module;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            

            builder.RegisterType<PatientManager>().As<IPatientService>().SingleInstance();
            builder.RegisterType<EfPatientDal>().As<IPatientDal>().SingleInstance();

            builder.RegisterType<PatientAuthManager>().As<IPatientAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();

            builder.RegisterType<DoctorAuthManager>().As<IDoctorAuthService>();
            builder.RegisterType<EfDoctorDal>().As<IDoctorDal>().SingleInstance();
            builder.RegisterType<DoctorManager>().As<IDoctorService>().SingleInstance();

            builder.RegisterType<PrescriptionManager>().As<IPrescriptionService>().SingleInstance();
            builder.RegisterType<EfPrescriptionDal>().As<IPrescriptionDal>().SingleInstance();

            builder.RegisterType<MedicineManager>().As<IMedicineService>().SingleInstance();
            builder.RegisterType<EfMedicineDal>().As<IMedicineDal>().SingleInstance();

            builder.RegisterType<DepartmentManager>().As<IDepartmentService>().SingleInstance();
            builder.RegisterType<EfDepartmentDal>().As<IDepartmentDal>().SingleInstance();

            builder.RegisterType<TimeOfUseManager>().As<ITimeOfUseService>().SingleInstance();
            builder.RegisterType<EfTimeOfUseDal>().As<ITimeOfUseDal>().SingleInstance();

            builder.RegisterType<MedicineDetailManager>().As<IMedicineDetailService>().SingleInstance();
            builder.RegisterType<EfMedicineDetailDal>().As<IMedicineDetailDal>().SingleInstance();

            builder.RegisterType<MedicineTypeManager>().As<IMedicineTypeService>().SingleInstance();
            builder.RegisterType<EfMedicineTypeDal>().As<IMedicineTypeDal>().SingleInstance();

            builder.RegisterType<DoctorImageManager>().As<IDoctorImageService>().SingleInstance();
            builder.RegisterType<EfDoctorImageDal>().As<IDoctorImageDal>().SingleInstance();
            builder.RegisterType<MedicineImageManager>().As<IMedicineImageService>().SingleInstance();
            builder.RegisterType<EfMedicineImageDal>().As<IMedicineImageDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            var assembly = Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new Castle.DynamicProxy.ProxyGenerationOptions
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }

    }
}
