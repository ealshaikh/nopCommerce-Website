using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Core.Domain.TestProduct;
public class TestProduct : BaseEntity
{
    public int ID {get; set;}

    public string Name {get; set;}

    public string Description {get; set;}

    public string ImageUrl { get; set;}
}
