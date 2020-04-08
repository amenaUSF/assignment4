using assignment4.data_access_folder;
using System;

namespace assignment4.APIHandlerManager
{
    public class ApplicationDbContext
    {
        public static implicit operator ApplicationDbContext(ApplicationDBContext v)
        {
            throw new NotImplementedException();
        }
    }
}