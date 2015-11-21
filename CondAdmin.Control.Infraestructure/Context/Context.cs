using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Text;
using MySql.Data.Entity;

namespace CondAdmin.Control.Infraestructure.Context
{
    [DbConfigurationType ( typeof ( MySqlEFConfiguration ) )]
    public class Context : DbContext
    {
        public Context ( )
            : base ( "Name=Gse" )
        {
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.ProxyCreationEnabled = false;
        }

        public override int SaveChanges ( )
        {
            bool saveFailed = false;
            var retorno = 0;
            do
            {
                try
                {
                    retorno = base.SaveChanges ( );
                }
                catch ( DbEntityValidationException ex )
                {
                    var sb = new StringBuilder ( );

                    foreach ( var failure in ex.EntityValidationErrors )
                    {
                        sb.AppendFormat ( "{0} \n", failure.Entry.Entity.GetType ( ) );
                        foreach ( var error in failure.ValidationErrors )
                        {
                            sb.AppendFormat ( "- {0} : {1}", error.PropertyName, error.ErrorMessage );
                            sb.AppendLine ( );
                        }
                    }

                    throw new DbEntityValidationException (
                        "Entity Validation Failed - errors follow:\n" +
                        sb.ToString ( ), ex
                        ); // Add the original exception as the innerException
                }
                catch ( DbUpdateConcurrencyException ex )
                {
                    saveFailed = true;

                    // Update original values from the database 
                    var lista = ( List<DbEntityEntry> ) ex.Entries;
                    foreach ( var item in lista )
                    {
                        var entry = item;
                        entry.OriginalValues.SetValues ( entry.GetDatabaseValues ( ) );
                    }
                }
                catch ( DbUpdateException ex )
                {
                    saveFailed = true;

                    // Update original values from the database 
                    var lista = ( List<DbEntityEntry> ) ex.Entries;
                    foreach ( var item in lista )
                    {
                        var entry = item;
                        entry.OriginalValues.SetValues ( entry.GetDatabaseValues ( ) );
                    }
                }
            } while ( saveFailed );

            return retorno;
        }

        protected override void OnModelCreating ( DbModelBuilder modelBuilder )
        {
        }
    }
}
