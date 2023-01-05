using System.Collections;
using System.Collections.Generic;
using Osb.Core.Platform.Business.Entity.Models;

namespace Osb.Core.Platform.Business.Service.Models
{
  public class Favoreds : IEnumerable<Favored>, IEnumerable
  {

    List<Favored> favoreds = new List<Favored>();

    public IEnumerator<Favored> GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
      throw new System.NotImplementedException();
    }

    public int Count() {
        return favoreds.Count;
    }

  }
}