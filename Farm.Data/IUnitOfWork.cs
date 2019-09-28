using Farm.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Data
{
    /// <summary>
    ///  IDisposable -> IUnitOfWork'ün tüm işlemler bittikten sonra otomatik olarak silmeye yarar.
    /// </summary>
    public interface IUnitOfWork:IDisposable
    {
        int Commit();
    }
}
