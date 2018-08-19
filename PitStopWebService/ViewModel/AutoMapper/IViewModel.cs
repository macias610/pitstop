using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModel.AutoMapper
{
    public interface IViewModel<TSource,TDestination>
    {
        TDestination MapFrom(TSource sourceObject);
        TSource MapTo();

    }
}
