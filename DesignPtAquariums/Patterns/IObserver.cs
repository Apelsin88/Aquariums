using DesignPtAquariums.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPtAquariums.Patterns
{
    public interface IObserver
    {
        void Notify(Aquarium aquarium);
    }
}
