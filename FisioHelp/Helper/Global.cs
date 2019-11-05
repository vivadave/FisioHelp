using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FisioHelp.Helper
{
  static class Global
  {
    private static DateTime _filterFromData = DateTime.Today.AddDays(-30);
    private static DateTime _filterToData = DateTime.Today.AddDays(7);

    public static DateTime FilterFromData
    {
      get { return _filterFromData; }
      set { _filterFromData = value; }
    }

    public static DateTime FilterToData
    {
      get { return _filterToData; }
      set { _filterToData = value; }
    }
  }
}
