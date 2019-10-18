using System;
using LinqToDB;

namespace FisioHelp.Helper
{
  public static class DbManagement
  {
    public static Guid SaveToDB<T>(T model)
    {
      var a = model as DataModels.BaseModel;
      using (var db = new Db.PhisioDB())
      {
        if (a.Id != null && a.Id != Guid.Empty)
          db.Update(model);
        else
        {
          a.Id = Guid.NewGuid();
          a.Id = Guid.Parse(db.InsertWithIdentity(model).ToString());
        }

        return a.Id;
      }
    }
  }
}
