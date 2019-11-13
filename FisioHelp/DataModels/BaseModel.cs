using System;
using System.Collections.Generic;
using LinqToDB.Mapping;
using LinqToDB;

namespace FisioHelp.DataModels
{
  public abstract class BaseModel
  {
    [Column("id"), PrimaryKey, NotNull] public Guid Id { get; set; } // uuid

    public abstract Guid SaveToDB();

    public bool IsInitialized()
    {
      return Id != null && Id != Guid.Empty;
    }
  }
}
