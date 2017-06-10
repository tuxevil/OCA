using Castle.Windsor;
using SharpArch.Core.PersistenceSupport.NHibernate;
using SharpArch.Data.NHibernate;
using SharpArch.Core.PersistenceSupport;
using SharpArch.Web.Castle;
using Castle.MicroKernel.Registration;
using SharpArch.Core.CommonValidator;
using SharpArch.Core.NHibernateValidator.CommonValidatorAdapter;
using Nybble.Security;
using Nybble.Messaging;
using Nybble.Caching;
using Nybble.Utils;

namespace ePack.Web.CastleWindsor
{
    public class ComponentRegistrar
    {
        public static void AddComponentsTo(IWindsorContainer container)
        {
            AddGenericRepositoriesTo(container);
            AddCustomRepositoriesTo(container);
            AddApplicationServicesTo(container);

            container.AddComponent("tokenizer",
                typeof(ITokenizer), typeof(ExpireTokenizer));

            container.AddComponent("encryptionHelper",
               typeof(IEncryptionHelper), typeof(EncryptionHelper));

            container.AddComponent("passwordGenerator",
                typeof(IPasswordGenerator), typeof(BasicPasswordGenerator));

            container.AddComponent("hashGenerator",
                typeof(IHashGenerator), typeof(Sha1HashGenerator));

            container.AddComponent("stringEncryptor",
                typeof(IStringEncryptor), typeof(TripleDesStringEncryptor));

            container.AddComponent("saltGenerator",
                typeof(ISaltGenerator), typeof(SaltGenerator));

            container.AddComponent("authenticationService",
                typeof(IAuthenticationService<IUserContext>), typeof(FormsAuthenticationService<IUserContext>));

            container.AddComponent("messageSenderService",
                typeof(IMessageSenderService), typeof(SmtpMessageSenderService));

            container.AddComponent("cache",
                typeof(ICache), typeof(WebCache));

            container.AddComponent("validator",
                typeof(IValidator), typeof(Validator));
        }

        private static void AddApplicationServicesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Pick()
                .FromAssemblyNamed("ePack.ApplicationServices")
                .WithService.FirstInterface());
        }

        private static void AddCustomRepositoriesTo(IWindsorContainer container)
        {
            container.Register(
                AllTypes.Pick()
                .FromAssemblyNamed("ePack.Data")
                .WithService.FirstNonGenericCoreInterface("ePack.Core"));
        }

        private static void AddGenericRepositoriesTo(IWindsorContainer container)
        {
            container.AddComponent("entityDuplicateChecker",
                typeof(IEntityDuplicateChecker), typeof(EntityDuplicateChecker));
            container.AddComponent("repositoryType",
                typeof(IRepository<>), typeof(Repository<>));
            container.AddComponent("nhibernateRepositoryType",
                typeof(INHibernateRepository<>), typeof(NHibernateRepository<>));
            container.AddComponent("repositoryWithTypedId",
                typeof(IRepositoryWithTypedId<,>), typeof(RepositoryWithTypedId<,>));
            container.AddComponent("nhibernateRepositoryWithTypedId",
                typeof(INHibernateRepositoryWithTypedId<,>), typeof(NHibernateRepositoryWithTypedId<,>));
        }
    }
}
