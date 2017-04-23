using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MEMSail.Models
{
    public class SailContextSingleton
    {
        private static SailContext context;
        // generic object to used to exclude others
        private static object syncLock = new object();

        /// <summary>
        /// Instantiate the context instance, if it doesn't yet exist
        /// </summary>
        /// <returns></returns>
        public static SailContext Context()
        {
            // Support multithreaded applications through 'double-checked locking' pattern which, 
            // once the instance exists, avoids locking each time the method is invoked
            if (context == null) // if instance already exists, skip to end
            {
                lock (syncLock) // first one here locks everyone else out until instance is created
                {
                    if (context == null) // people who were locked out see instance & skip to end
                    {
                        var optionsBuilder = new DbContextOptionsBuilder<SailContext>();
                        optionsBuilder.UseSqlServer(
@"(localdb)\\MSSQLLocalDB;Initial Catalog=Sail;Integrated Security=SSPI;MultipleActiveResultSets=true");
                        context = new SailContext(optionsBuilder.Options);
                    }
                }
            }
            return context;
        }
    }
}
