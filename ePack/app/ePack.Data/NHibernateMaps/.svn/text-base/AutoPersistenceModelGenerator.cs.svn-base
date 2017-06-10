using System;
using System.Linq;
using FluentNHibernate.Automapping;
using FluentNHibernate.Conventions;
using ePack.Core;
using ePack.Data.NHibernateMaps.Conventions;
using SharpArch.Core.DomainModel;
using SharpArch.Data.NHibernate.FluentNHibernate;
using Nybble.Data.Fluent.Conventions;

namespace ePack.Data.NHibernateMaps
{
    public class AutoPersistenceModelGenerator : IAutoPersistenceModelGenerator
    {
        public AutoPersistenceModel Generate()
        {
            var mappings = AutoMap.AssemblyOf<Feed>(new AutomappingConfiguration())
                .IgnoreBase<Entity>()
                .IgnoreBase(typeof(EntityWithTypedId<>))
                .UseOverridesFromAssemblyOf<AutoPersistenceModelGenerator>();

            Integrator.SetupConventions(mappings);

            return mappings;
        }
    }
}
