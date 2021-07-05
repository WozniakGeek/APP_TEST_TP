using System;
using System.Collections.Generic;
using System.Text;
using TestAppTP.Models;

namespace TestApp.BLL.Util
{
    public interface IUtilService
    {
        int Restock(List<int> itemCount, int target);

        double ResponseNotes(StudentViewModel Model);
    }
}
