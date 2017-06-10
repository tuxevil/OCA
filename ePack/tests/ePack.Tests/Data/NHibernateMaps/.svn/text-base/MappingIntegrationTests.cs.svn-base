using System.Collections.Generic;
using NHibernate;
using NHibernate.Metadata;
using NUnit.Framework;
using ePack.Data.NHibernateMaps;
using SharpArch.Data.NHibernate;
using SharpArch.Testing.NHibernate;
using NHibernate.Cfg;
using NHibernate.Tool.hbm2ddl;

namespace Tests.ePack.Data.NHibernateMaps
{
    /// <summary>
    /// Provides a means to verify that the target database is in compliance with all mappings.
    /// Taken from http://ayende.com/Blog/archive/2006/08/09/NHibernateMappingCreatingSanityChecks.aspx.
    /// 
    /// If this is failing, the error will likely inform you that there is a missing table or column
    /// which needs to be added to your database.
    /// </summary>
    [TestFixture]
    [Category("DB Tests")]
    public class MappingIntegrationTests
    {
        [SetUp]
        public virtual void SetUp()
        {
            string[] mappingAssemblies = RepositoryTestsHelper.GetMappingAssemblies();
            //configuration = NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
            //                       new AutoPersistenceModelGenerator().Generate(),
            //                       "../../../../app/ePack.Web/NHibernate.config");

            configuration = NHibernateSession.Init(new SimpleSessionStorage(), mappingAssemblies,
                       new AutoPersistenceModelGenerator().Generate(),
                       "../../../../tests/ePack.Tests/Hibernate.cfg.xml");

        }

        [TearDown]
        public virtual void TearDown()
        {
            NHibernateSession.CloseAllSessions();
            NHibernateSession.Reset();
        }

        [Test]
        public void CanConfirmDatabaseMatchesMappings()
        {
            GenerateDatabaseSchema();
            
            var allClassMetadata = NHibernateSession.GetDefaultSessionFactory().GetAllClassMetadata();

            foreach (var entry in allClassMetadata)
            {
                NHibernateSession.Current.CreateCriteria(entry.Value.GetMappedClass(EntityMode.Poco))
                     .SetMaxResults(0).List();
            }
        }

        /// <summary>
        /// Generates and outputs the database schema SQL to the console
        /// </summary>
        public void GenerateDatabaseSchema()
        {
            new SchemaExport(configuration).Execute(true, true, false, NHibernateSession.Current.Connection, null);
        }

        private Configuration configuration;
    }
}
