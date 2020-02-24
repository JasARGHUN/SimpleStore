using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleTemplate_1.Models
{
    public interface IInfoRepository
    {
        Info Add(Info info);
        Info GetInfo(int id);
        Info Update(Info infoUpdate);
    }
}
